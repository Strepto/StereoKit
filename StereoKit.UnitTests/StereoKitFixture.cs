using System;

namespace StereoKit.UnitTests
{
    /// <summary>
    /// A shared StereoKit state to use for all tests in a class fixture.
    /// 
    /// See: https://xunit.net/docs/shared-context - class fixtures
    /// </summary>
    public class StereoKitFixture : IDisposable
    {
        public StereoKitFixture()
        {
            var settings = new SKSettings
            {
                displayPreference = DisplayMode.Flatscreen,
                appName = "StereoKit.UnitTests"
            };
            SK.Initialize(settings);
        }

        public void Dispose()
        {
            SK.Shutdown();
        }
    }
}
