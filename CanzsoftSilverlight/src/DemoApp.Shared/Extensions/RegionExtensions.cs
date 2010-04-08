using Microsoft.Practices.Composite.Regions;

namespace DemoApp.Shared.Extensions
{
    public static class RegionExtensions
    {
        public static void DeactivateAll(this IRegion region)
        {
            foreach (var v in region.Views)
            {
                region.Deactivate(v);
            }
        }
    }
}