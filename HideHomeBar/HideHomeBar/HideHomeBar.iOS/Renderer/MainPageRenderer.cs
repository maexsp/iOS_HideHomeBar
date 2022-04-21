using HideHomeBar;
using HideHomeBar.iOS.Renderer;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(MainPage), typeof(MainPageRenderer))]

namespace HideHomeBar.iOS.Renderer
{
    public class MainPageRenderer : PageRenderer
    {
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            if (Element is MainPage mainPage)
            {
                mainPage.Background = Brush.Red;

                SetNeedsUpdateOfScreenEdgesDeferringSystemGestures();
            }
        }

        // not working (Xamarin Forms Bug): hide homebar indicator so that app does not get into one-hand reachability mode (minimized mode) due to bottom-edge swipe-down-gesture
        // old bug entry: https://github.com/xamarin/Xamarin.Forms/issues/2241
        // origin post: https://stackoverflow.com/questions/49626146/how-to-use-a-custom-uiviewcontroller-with-xamarin-forms

        public override UIRectEdge PreferredScreenEdgesDeferringSystemGestures
        {
            get
            {
                return UIRectEdge.Bottom;
            }
        }
    }
}