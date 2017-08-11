
(function () {

    function Group(name) {
        var self = this;

        this.name = name;
        this.isActiveRoom = ko.observable(false);

        this.joinRoom = function (group) {
            if (viewModel.activeRoom() === group.name) {
                viewModel.activeRoom(null);
                self.isActiveRoom(false);
            } else {
                viewModel.activeRoom(group.name);
                $.each(viewModel.groups(), function (i, group) {
                    group.isActiveRoom(false);
                });
                self.isActiveRoom(true);
                $.connection.chatHub.server.joinRoom(group.name);
            }
        };

    }

    function Message(from, msg, isPrivate, isGroup) {
        this.from = ko.observable(from);
        this.message = ko.observable(msg);
        this.isPrivate = ko.observable(isPrivate);
        this.isGroup = ko.observable(isGroup);

        var d = new Date();
        var time = ('0' + d.getHours()).slice(-2) + ':' + ('0' + d.getMinutes()).slice(-2) + ':' + ('0' + d.getSeconds()).slice(-2);

        this.date = time;
    }

    function User(name) {

        var self = this;

        self.name = ko.observable(name);
        self.isPrivateChatUser = ko.observable(false);
        self.isGroupMem = ko.observable(publicRoom);
        self.setAsPrivateChat = function (user) {
            
            if (viewModel.privateChatUser() === user.name()) {
                viewModel.();
            } else {
                viewModel.privateChatUser(user.name());
                viewModel.isInPrivateChat(true);
                $.each(viewModel.users(), function (i, user) {
                    user.isPrivateChatUser(false);
                });
                self.isPrivateChatUser(true);
            } 
        };
    }

    var viewModel = {
        messages: ko.observableArray([]),
        users: ko.observableArray([]),
        groups: ko.observableArray([]),
        activeRoom: ko.observable(publicRoom),
        isGroupMember: ko.observable(),
        isInPrivateChat: ko.observable(false),
        privateChatUser: ko.observable(),

        exitFromPrivateChat: function () {

            viewModel.isInPrivateChat(false);
            viewModel.privateChatUser(null);
            $.each(viewModel.users(), function (i, user) {
                user.isPrivateChatUser(false);
            });
        }
    };

    $(function () {

        var chatHub = $.connection.chatHub,
            loginHub = $.connection.login,
            $newGroup = $('#newGroup'),
            $sendBtn = $('#btnSend'),
            $msgTxt = $('#txtMsg'),
            $grpRoom = $('#currentRoom');

        // turn the logging on for demo purposes
        $.connection.hub.logging = true;

        chatHub.client.received = function (message) {
            viewModel.messages.push(new Message(message.sender, message.message, message.isPrivate, message.date, message.isGroup));
        };

        chatHub.client.userConnected = function (username) {
            viewModel.users.push(new User(username));
        };

        chatHub.client.userDisconnected = function (username) {
            viewModel.users.pop(new User(username));
            if (viewModel.isInPrivateChat() && viewModel.privateChatUser() === username) {
                viewModel.isInPrivateChat(false);
                viewModel.privateChatUser(null);
            }
        };

        chatHub.client.groupAdded = function (groupName) {
            viewModel.groups.push(new Group(groupName));
        };

        chatHub.client.GroupDeleted = function (group) {
            viewModel.users.pop(new activeRoom(group));
            if (viewModel.isInPrivateChat() && viewModel.privateChatUser() === username) {
                viewModel.isInPrivateChat(false);
                viewModel.isGroupMember(publicRoom);
                viewModel.privateChatUser(null);
            }
        };

        chatHub.client.addChatMessage = function (message) {
            console.log(message);
        };

        startConnection();
        ko.applyBindings(viewModel);

        function startConnection() {

            $.connection.hub.start().done(function () {

                toggleInputs(false);
                bindClickEvents();

                $msgTxt.focus();

                chatHub.server.getConnectedUsers().done(function (users) {
                    $.each(users, function (i, username) {
                        viewModel.users.push(new User(username));
                    });
                });

            }).fail(function (err) {

                console.log(err);
            });
        }

        function bindClickEvents() {

            $msgTxt.keypress(function (e) {
                var code = (e.keyCode ? e.keyCode : e.which);
                if (code === 13) {
                    sendMessage();
                }
            });

            $sendBtn.click(function (e) {
                sendMessage();
                e.preventDefault();
            });

            $newGroup.click(function (e) {
                var groupName = prompt("New group name:");

                chatHub.server.createRoom(groupName).fail(function (err) {
                    console.log('Send method failed: ' + err);
                });
                e.preventDefault();
            });

        }

        function sendMessage() {

            var msgValue = $msgTxt.val();
            if (msgValue !== null && msgValue.length > 0) {

                    if (viewModel.isInPrivateChat()) {

                        chatHub.server.send(msgValue, viewModel.privateChatUser()).fail(function (err) {
                            console.log('Send method failed: ' + err);
                        });
                    }
                    else {
                        chatHub.server.send(msgValue).fail(function (err) {
                            console.log('Send method failed: ' + err);
                        });
                    }
                
            }

            $msgTxt.val(null);
            $msgTxt.focus();
        }

        function sendMessageToGroup() {

            var msgValue = $msgTxt.val();
            var roomName = $roomName.val();
            if (msgValue !== null && msgValue.length > 0) {

                chatHub.server.sendMessageToGroup(msgValue, name, roomName);
            }
            $msgTxt.val(null);
            $msgTxt.focus();
        }

        function toggleInputs(status) {

            $newGroup.prop('disabled', status);
            $sendBtn.prop('disabled', status);
            $msgTxt.prop('disabled', status);
            $grpRoom.prop('disabled', status);

        }
    });

}());