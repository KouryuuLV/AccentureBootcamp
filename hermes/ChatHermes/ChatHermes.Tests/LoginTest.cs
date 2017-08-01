using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace ChatHermes.Tests
{
    [TestClass]
    public class LoginTest
    {
        [TestMethod]
        public void Login_Succesful()
        {
            Mock<ChatHermes.Models.LoginModel> LoginObj = new Mock<Models.LoginModel>();
            LoginObj.Setup(x => x.CanEnter()).Returns(true);

            ChatHermes obj = new ChatHermes();
            bool good = obj.CanEnter(LoginObj.Object);
            Assert.AreEqual(good, true); 
        }
    }
}
