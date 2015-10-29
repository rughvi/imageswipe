using System;
using Xamarin.Forms;
using Android.Graphics;
using System.Net;
using AppLevelREsourcesTesting.Droid;

[assembly: Dependency(typeof(GetImageRenderer))]
namespace AppLevelREsourcesTesting.Droid
{
	public class GetImageRenderer : IGetImage
	{
		public GetImageRenderer ()
		{
		}

		Bitmap bm;
		#region IGetImage implementation
		public void GetImageFromURL (string URL)
		{
			this.URL = URL;
			bm = GetImageBitmapFromUrl (URL);
		}
		public string URL {
			get;
			set;
		}
		public double Width {
			get {				
				return bm.Width;
			}
		}

		public double Height {
			get {
				return bm.Height;
			}
		}

		#endregion

		private Bitmap GetImageBitmapFromUrl(string url)
		{
			if (string.IsNullOrEmpty (url))
				return null;
			Bitmap imageBitmap = null;

			using (var webClient = new WebClient())
			{
				var imageBytes = webClient.DownloadData(url);
				if (imageBytes != null && imageBytes.Length > 0)
				{
					imageBitmap = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
				}
			}

			return imageBitmap;
		}
	}
}

