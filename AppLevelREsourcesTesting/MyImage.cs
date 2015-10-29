using System;
using Xamarin.Forms;
using System.Diagnostics;

namespace AppLevelREsourcesTesting
{
	public delegate void SwipedLeft();
	public delegate void SwipedRight();
	public class MyImage : Image
	{
		public SwipedLeft OnSwipedLeft;
		public SwipedRight OnSwipedRight;
		public MyImage ()
		{
			
		}
		double imageWidth, imageHeight;
		protected override void OnBindingContextChanged ()
		{
			base.OnBindingContextChanged ();
		}
		protected override SizeRequest OnSizeRequest (double widthConstraint, double heightConstraint)
		{
			
			Rectangle bounds = this.Bounds;

			return new SizeRequest (new Size (widthConstraint, (imageHeight / imageWidth) * widthConstraint));
		}

		protected override void OnPropertyChanged (string propertyName)
		{
			Debug.WriteLine ("************************PCL Property changed is " + propertyName);
			if (propertyName == "Source") {
				IGetImage imageGetter = DependencyService.Get<IGetImage> ();
				imageGetter.GetImageFromURL (this.Source.GetValue (UriImageSource.UriProperty).ToString ());
				imageWidth = imageGetter.Width;
				imageHeight = imageGetter.Height;
			}
			base.OnPropertyChanged (propertyName);
		}

		public void SwipedLeft()
		{
			if (OnSwipedLeft != null)
				OnSwipedLeft ();
		}

		public void SwipedRight()
		{
			if (OnSwipedRight != null)
				OnSwipedRight ();
		}
	}
}

