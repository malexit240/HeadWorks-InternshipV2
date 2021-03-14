using Microsoft.VisualStudio.TestTools.UnitTesting;
using HWInternshipProject.Models;
using HWInternshipProject.Services.Models;

namespace HWITests
{
    [TestClass]
    public class TestUserManager
    {
        IUserManager manager;
        IUserService service;

        [TestInitialize]
        public void TestInit()
        {
            (new Context()).Clear();
            manager = new UserManager();
            service = new UserService(new UserManager());
        }

        [TestCleanup]
        public void TestCleanup()
        {
            (new Context()).Clear();
        }

        [TestMethod]
        public void TestCreateUser()
        {
            var user = manager.Create("admin", "Password123").Result;
            Assert.IsTrue(RFCHasher.Verify("Password123", user.HashPassword));
            user = manager.Create("admin", "Password123").Result;
            Assert.IsNull(user);
        }

        [TestMethod]
        public void TestSignIn()
        {
            var user = manager.Create("admin", "Password123").Result;
            user = service.SignInAsync("admin", "Password123").Result;
            Assert.IsNotNull(user);
            Assert.AreEqual(user.UserId, User.Current.UserId);

            user = service.SignInAsync("admin", "Password321").Result;
            Assert.IsNull(user);
            user = service.SignInAsync("user", "Password123").Result;
            Assert.IsNull(user);
        }
    }
}
