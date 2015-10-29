using System;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Android.Graphics;
using Android.Views.Animations;
using Android.Graphics.Drawables;


namespace AppLevelREsourcesTesting.Droid
{
	public class FadeImageView : ImageView
	{
		Animation fadeInAnimation;
		Animation fadeOutAnimation;
		Bitmap bm = null;
		public FadeImageView (Context ctx) : base (ctx)
		{
			Initialize ();
		}

		public FadeImageView (Context context, IAttributeSet attrs) :
		base (context, attrs)
		{
			Initialize ();
		}

		public FadeImageView (Context context, IAttributeSet attrs, int defStyle) :
		base (context, attrs, defStyle)
		{
			Initialize ();
		}

		void Initialize ()
		{
			fadeInAnimation = new AlphaAnimation (0, 1) {
				Duration = 500
			};
			fadeOutAnimation = new AlphaAnimation (1, 0) {
				Duration = 100
			};
		}

		protected override void OnMeasure (int widthMeasureSpec, int heightMeasureSpec)
		{
			int parentWidth = MeasureSpec.GetSize(widthMeasureSpec);
			int parentHeight = MeasureSpec.GetSize(heightMeasureSpec);

			Drawable d = this.Drawable;

			if(d!=null){
				// ceil not round - avoid thin vertical gaps along the left/right edges
				int width = MeasureSpec.GetSize(widthMeasureSpec);
				int height = (int) Math.Ceiling((float) width * (float) d.IntrinsicHeight / (float) d.IntrinsicWidth);
				this.SetMeasuredDimension(width, height);
			}else{
				base.OnMeasure(widthMeasureSpec, heightMeasureSpec);
			}

			if (bm != null) {
				
			}
//			base.OnMeasure (widthMeasureSpec, heightMeasureSpec);
		}

		void DoAnimation (bool really, Action changePic)
		{
			if (!really)
				changePic ();
			else {
				EventHandler<Animation.AnimationEndEventArgs> callback = (s, e) => {
					changePic ();
					StartAnimation (fadeInAnimation);
//					fadeOutAnimation.AnimationEnd -= callback;
				};
				fadeOutAnimation.AnimationEnd += callback;
				StartAnimation (fadeOutAnimation);
			}
		}

		public void SetImageBitmap (Bitmap bm, bool animate)
		{
			this.bm = bm;
			DoAnimation (animate, () => SetImageBitmap (bm));
		}

		public void SetImageDrawable (Drawable drawable, bool animate)
		{
			DoAnimation (animate, () => SetImageDrawable (drawable));
		}

		public void SetImageResource (int resId, bool animate)
		{
			DoAnimation (animate, () => SetImageResource (resId));
		}

		public void SetImageURI (Android.Net.Uri uri, bool animate)
		{
			DoAnimation (animate, () => SetImageURI (uri));
		}
	}
}