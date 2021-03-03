using HWInternshipProject.Models;

namespace HWITests
{
    public static class ContextTestExtension
    {
        public static void Clear(this Context context)
        {
            context.Database.EnsureDeleted();
        }
    }
}
