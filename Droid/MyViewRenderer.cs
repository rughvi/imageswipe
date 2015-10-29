using System;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using AppLevelREsourcesTesting;
using AppLevelREsourcesTesting.Droid;
using Android.Views;
using Android.Widget;
using Android.Views.Animations;
using Android.Graphics;
using System.Net;

[assembly:ExportRenderer(typeof(MyView), typeof(MyViewRenderer))]
namespace AppLevelREsourcesTesting.Droid
{
	public class MyViewRenderer : ViewRenderer
	{
		public string[] images = {
			"https://itandmecloud.blob.core.windows.net/04f90a340fdc89e261908ee7fb012d27c93a802bbf3239ffd4945cc9aeb7a51/thumbnail/447777788888/358714058742028/IMG-20150521-WA0000.jpg",
			"https://itandmecloud.blob.core.windows.net/04f90a340fdc89e261908ee7fb012d27c93a802bbf3239ffd4945cc9aeb7a51/thumbnail/447777722222/353918058347515/IMG_20150506_141146.jpg",
			"https://itandmecloud.blob.core.windows.net/04f90a340fdc89e261908ee7fb012d27c93a802bbf3239ffd4945cc9aeb7a51/thumbnail/447777722222/353918058347515/IMG_20150506_141149.jpg",
			"https://itandmecloud.blob.core.windows.net/04f90a340fdc89e261908ee7fb012d27c93a802bbf3239ffd4945cc9aeb7a51/thumbnail/447777722222/353918058347515/IMG_20150506_141153.jpg",
			"https://itandmecloud.blob.core.windows.net/04f90a340fdc89e261908ee7fb012d27c93a802bbf3239ffd4945cc9aeb7a51/thumbnail/447777722222/353918058347515/IMG_20150506_141157.jpg",
			"https://itandmecloud.blob.core.windows.net/04f90a340fdc89e261908ee7fb012d27c93a802bbf3239ffd4945cc9aeb7a51/thumbnail/447777788888/1801210_10154630878015221_4585627400036777754_o.jpg",
			"https://itandmecloud.blob.core.windows.net/04f90a340fdc89e261908ee7fb012d27c93a802bbf3239ffd4945cc9aeb7a51/thumbnail/447777788888/292-934x.jpg",
			"https://itandmecloud.blob.core.windows.net/04f90a340fdc89e261908ee7fb012d27c93a802bbf3239ffd4945cc9aeb7a51/thumbnail/447777788888/353922055415960/IMG_20150529_131819.jpg.jpg",
			"https://itandmecloud.blob.core.windows.net/04f90a340fdc89e261908ee7fb012d27c93a802bbf3239ffd4945cc9aeb7a51/thumbnail/447777788888/353922055415960/IMG_20150529_145223.jpg.jpg",
			"https://itandmecloud.blob.core.windows.net/04f90a340fdc89e261908ee7fb012d27c93a802bbf3239ffd4945cc9aeb7a51/thumbnail/447777788888/358714058742028/IMAG1873.jpg",
			"https://itandmecloud.blob.core.windows.net/04f90a340fdc89e261908ee7fb012d27c93a802bbf3239ffd4945cc9aeb7a51/thumbnail/447777788888/358714058742028/IMAG1913.jpg",
			"https://itandmecloud.blob.core.windows.net/04f90a340fdc89e261908ee7fb012d27c93a802bbf3239ffd4945cc9aeb7a51/thumbnail/447777788888/358714058742028/IMG-20150519-WA0002.jpg",
			"https://itandmecloud.blob.core.windows.net/04f90a340fdc89e261908ee7fb012d27c93a802bbf3239ffd4945cc9aeb7a51/thumbnail/447777788888/358714058742028/IMG-20150519-WA0003.jpg",
			"https://itandmecloud.blob.core.windows.net/04f90a340fdc89e261908ee7fb012d27c93a802bbf3239ffd4945cc9aeb7a51/thumbnail/447777788888/358714058742028/IMG-20150519-WA0004.jpg",

			"https://itandmecloud.blob.core.windows.net/04f90a340fdc89e261908ee7fb012d27c93a802bbf3239ffd4945cc9aeb7a51/thumbnail/447777788888/358714058742028/IMG-20150522-WA0000.jpg"
		};
		public int currImage = 0;
		FadeImageView imageSwitcher = null;
		public MyViewRenderer ()
		{
		}

		protected override void OnElementChanged (ElementChangedEventArgs<Xamarin.Forms.View> e)
		{
			base.OnElementChanged (e);
			if (e.NewElement != null) {
				LayoutInflater inflatorservice = (LayoutInflater)Context.GetSystemService (Android.Content.Context.LayoutInflaterService);

				var containerView = (Android.Widget.ScrollView)inflatorservice.Inflate (Resource.Layout.activity_image_switcher_example, null, false);

				imageSwitcher = (FadeImageView)containerView.FindViewById (Resource.Id.imageSwitcher);
//				imageSwitcher.SetFactory (new ViewFactory ());
//				imageSwitcher.SetInAnimation (Android.App.Application.Context, Android.Resource.Animation.SlideInLeft);
//				imageSwitcher.SetOutAnimation (Android.App.Application.Context, Android.Resource.Animation.SlideOutRight);
//
				imageSwitcher.Touch += OnTouchImageView;
				Android.Widget.Button rotateButton = (Android.Widget.Button)containerView.FindViewById (Resource.Id.btnRotateImage);
				rotateButton.SetOnClickListener (new ClickListener (this));

				SetCurrImage ();
				base.SetNativeControl (containerView);
			}
		}

		public void SetCurrImage()
		{
			var imageBitmap = GetImageBitmapFromUrl (images [currImage]);
			imageSwitcher.SetImageBitmap(imageBitmap, true);
//			imageSwitcher.SetImageURI (new Android.Net.Uri.Builder();//SetImageResource (images [currImage]); 
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
					currImage--;
					if (currImage < 0)
						currImage = images.Length - 1;
					SetCurrImage ();
				} else if (endX - startX < -20) {
					currImage++;
					if (currImage >= images.Length)
						currImage = 0;
					SetCurrImage ();
				}
				break;

			default:
				message = string.Empty;
				break;
			}
		}
		private Bitmap GetImageBitmapFromUrl(string url)
		{
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

	public class ViewFactory : ViewSwitcher.IViewFactory
	{
		public ViewFactory()
		{
			
		}
		public Android.Views.View MakeView ()
		{
			ImageView myView = new ImageView (Android.App.Application.Context);
//			myView.SetScaleType(ImageView.ScaleType.FitCenter);
//			myView.SetX (n
//			myView.SetLayoutParams(new ImageSwitcher.LayoutParams(LayoutParams.,LayoutParams.FILL_PARENT));
			return myView;
		}

		public void Dispose ()
		{
			throw new NotImplementedException ();
		}

		public IntPtr Handle {
			get {
				throw new NotImplementedException ();
			}
		}
	}

	public class ClickListener : Java.Lang.Object, Android.Views.View.IOnClickListener
	{
		MyViewRenderer view;
		public ClickListener(MyViewRenderer view)
		{
			this.view = view;	
		}
		#region IOnClickListener implementation
		public void OnClick (Android.Views.View v)
		{
			view.currImage++;
			if (view.currImage == view.images.Length) {
				view.currImage = 0;
			}
			view.SetCurrImage ();
		}
		#endregion
		
	}
}

