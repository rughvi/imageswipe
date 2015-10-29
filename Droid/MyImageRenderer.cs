using System;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using AppLevelREsourcesTesting;
using AppLevelREsourcesTesting.Droid;
using Android.Graphics;
using System.Net;
using Android.Views;

[assembly:ExportRenderer(typeof(MyImage), typeof(MyImageRenderer))]
namespace AppLevelREsourcesTesting.Droid
{
	public class MyImageRenderer : ImageRenderer
	{
		MyImage image = null;
		Bitmap bm;
		public MyImageRenderer ()
		{
		}

		protected override void OnElementChanged (ElementChangedEventArgs<Image> e)
		{
			base.OnElementChanged (e);
			if (e.NewElement is MyImage) {
				image = e.NewElement as MyImage;

				this.Control.Touch += OnTouchImageView;
			}
		}

		float startX = 0;
		float endX = 0;
		void OnTouchImageView(object sender, TouchEventArgs e)
		{
			string message;
			switch (e.Event.Action) {
			case MotionEventActions.Down:
			case MotionEventActions.Move:
				message = "Touch Begins";
				startX = e.Event.RawX;
				break;

			case MotionEventActions.Up:
			case MotionEventActions.Cancel:
				message = "Touch Ends";
				endX = e.Event.RawX;
				if (endX - startX > 20) {
					image.SwipedRight ();
				} else if (endX - startX < -20) {					
					image.SwipedLeft ();
				}
				break;

			default:
				message = string.Empty;
				break;
			}
		}
//		protected override void OnElementPropertyChanged (object sender, System.ComponentModel.PropertyChangedEventArgs e)
//		{
//			Console.WriteLine ("Property changed is " + e.PropertyName);
//			base.OnElementPropertyChanged (sender, e);
//		}

//		protected override void OnMeasure (int widthMeasureSpec, int heightMeasureSpec)
//		{
//			base.OnMeasure (widthMeasureSpec, widthMeasureSpec);
//
//
//		}

//		private Bitmap GetImageBitmapFromUrl(string url)
//		{
//			Bitmap imageBitmap = null;
//
//			using (var webClient = new WebClient())
//			{
//				var imageBytes = webClient.DownloadData(url);
//				if (imageBytes != null && imageBytes.Length > 0)
//				{
//					imageBitmap = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
//				}
//			}
//
//			return imageBitmap;
//		}
	}
}

