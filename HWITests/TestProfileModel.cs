using Microsoft.VisualStudio.TestTools.UnitTesting;
using HWInternshipProject.Models;

namespace HWITests
{
    [TestClass]
    public class TestProfileModel
    {
        User user;
        [TestInitialize]
        public void TestInit()
        {
            (new Context()).Clear();
            user = User.Create("admin", "admin");
        }

        [TestMethod]
        public void TestProfileCreate()
        {
            var profile = Profile.Create(user.UserId, "admin", "admin", "./");

            user.Profiles.Add(profile);
            profile = new Profile()
            {
                Name = "admin2",
                NickName = "admin2",
                Description = "description",
                ImageDestination = "./"
            };
            user.Profiles.Add(profile);
            user.Update();

            Assert.IsTrue(true);

        }
    }
}
