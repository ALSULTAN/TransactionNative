using Foundation;
using UIKit;

namespace TransactionNative.iOS
{
    [Register("AppDelegate")]
    public class AppDelegate : UIApplicationDelegate
    {
        public override UIWindow Window { get; set; }

        public override bool FinishedLaunching(UIApplication Application, NSDictionary LaunchOptions) => true;     
    }
}

