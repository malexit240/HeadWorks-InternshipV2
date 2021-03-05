using Microsoft.VisualStudio.TestTools.UnitTesting;
using HWInternshipProject.Models;
using HWInternshipProject.Services.Models;
using System.Linq;

namespace HWITests
{
    [TestClass]
    public class TestProfileManager
    {
        IUserManager Umanager;
        IUserService Uservice;

        IProfileManager Pmanager;
        IProfileService Pservice;

        [TestInitialize]
        public void TestInit()
        {
            (new Context()).Clear();

            Umanager = new UserManager();
            Uservice = new UserService(Umanager);
            Pmanager = new ProfileManager();
            Pservice = new ProfileService(Pmanager);
            Umanager.Create("admin", "Password123").Wait();
            Uservice.SignInAsync("admin", "Password123").Wait();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            (new Context()).Clear();
        }

        [TestMethod]
        public void TestProfileCreate()
        {
            var user = User.Current;
            var profile = Pmanager.Create(user.UserId, "Profile1", "Profile1", "./").Result;
            user = User.Current;

            Assert.IsTrue(user.Profiles[0].ProfileId == profile.ProfileId);
        }

        [TestMethod]
        public void TestProfileUpdate()
        {
            var user = User.Current;
            var profile = Pmanager.Create(user.UserId, "Profile1", "Profile1", "Desc", "./").Result;
            user = User.Current;

            var newName = "Profile2";
            var newNickName = newName;
            var newDescription = "Description Text";
            var newImageDestination = "./folder/image.extension";

            profile.Name = newName;
            profile.NickName = newNickName;
            profile.Description = newDescription;
            profile.ImageDestination = newImageDestination;
            Pmanager.Update(profile).Wait();
            user = User.Current;

            Assert.AreEqual(user.Profiles[0].Name, newName);
            Assert.AreEqual(user.Profiles[0].NickName, newNickName);
            Assert.AreEqual(user.Profiles[0].Description, newDescription);
            Assert.AreEqual(user.Profiles[0].ImageDestination, newImageDestination);
        }
    }
}
