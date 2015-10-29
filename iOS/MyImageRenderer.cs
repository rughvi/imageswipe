using System;
using Xamarin.Forms.Platform.iOS;
using AppLevelREsourcesTesting.iOS;
using AppLevelREsourcesTesting;
using Xamarin.Forms;
using UIKit;


[assembly:ExportRenderer(typeof(MyImage), typeof(MyImageRenderer))]
namespace AppLevelREsourcesTesting.iOS
{
	public class MyImageRenderer : ImageRenderer
	{
		MyImage image;
		public MyImageRenderer ()
		{
		}

		protected override void OnElementChanged (ElementChangedEventArgs<Image> e)
		{
			base.OnElementChanged (e);
			if (e.NewElement is MyImage) {
				image = e.NewElement as MyImage;

				UIView view = this as UIView;
				view.UserInteractionEnabled = true;
				UISwipeGestureRecognizer gestureRecognizerLeft = new UISwipeGestureRecognizer (() => {
					image.SwipedLeft();
				});
				gestureRecognizerLeft.Direction = UISwipeGestureRecognizerDirection.Left;

				UISwipeGestureRecognizer gestureRecognizerRight = new UISwipeGestureRecognizer (() => {
					image.SwipedRight();
				});
				gestureRecognizerRight.Direction = UISwipeGestureRecognizerDirection.Right;

				view.AddGestureRecognizer (gestureRecognizerLeft);
				view.AddGestureRecognizer (gestureRecognizerRight);

			}
		}
	}
}

