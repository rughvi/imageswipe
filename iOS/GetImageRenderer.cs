using System;
using UIKit;
using Foundation;
using Xamarin.Forms;
using AppLevelREsourcesTesting.iOS;

[assembly: Dependency(typeof(GetImageRenderer))]
namespace AppLevelREsourcesTesting.iOS
{
	public class GetImageRenderer : IGetImage
	{
		public GetImageRenderer ()
		{
		}
		UIImage image;
		#region IGetImage implementation
		public void GetImageFromURL (string URL)
		{
			this.URL = URL;
			DownLoadImageWithURL (URL);
		}
		public string URL {
			get;
			set;
		}
		public double Width {
			get {				
				return image.Size.Width;
			}
		}

		public double Height {
			get {
				return image.Size.Height;
			}
		}

		#endregion

		void DownLoadImageWithURL(string url)
		{
			var request = NSMutableUrlRequest.FromUrl (new NSUrl(url));
			NSUrlResponse response;
			NSError error;
			NSData data = NSUrlConnection.SendSynchronousRequest (request, out response, out error);
			if (error == null) {
				image = new UIImage (data);
			} else {
				image = new UIImage ();
			}
//			NSUrlConnection.SendAsynchronousRequest (request, NSOperationQueue.MainQueue, (NSUrlResponse response, NSData data, NSError error) => {
//				if (error == null)
//				{
//					UIImage image = new UIImage(data);
//					imageView.Image = image;
////					if(tableView.images.ElementAt(index) == null)
////					{
////						tableView.images[index] = image;
////						tableView.Parent.View.EventImages.First(ei => ei.thumbnailFile == url).ImageAsNativeControl = image;
////					}
//					completionBlock(true,image);
//				} else{
//					completionBlock(false,null);
//				}
//			});
		}
	}
}

