using System;
using System.Collections.Generic;

using Xamarin.Forms;
using System.Diagnostics;

namespace AppLevelREsourcesTesting
{
	public partial class MyPage : ContentPage
	{
		int currImage = 0;
		public string[] images = {
			"https://itandmecloud.blob.core.windows.net/04f90a340fdc89e261908ee7fb012d27c93a802bbf3239ffd4945cc9aeb7a51/thumbnail/447777788888/358714058742028/IMG-20150521-WA0000.jpg",
			"https://itandmecloud.blob.core.windows.net/04f90a340fdc89e261908ee7fb012d27c93a802bbf3239ffd4945cc9aeb7a51/thumbnail/447777722222/353918058347515/IMG_20150506_141146.jpg",
			"https://itandmecloud.blob.core.windows.net/04f90a340fdc89e261908ee7fb012d27c93a802bbf3239ffd4945cc9aeb7a51/thumbnail/447777722222/353918058347515/IMG_20150506_141149.jpg",
			"https://itandmecloud.blob.core.windows.net/04f90a340fdc89e261908ee7fb012d27c93a802bbf3239ffd4945cc9aeb7a51/thumbnail/447777722222/353918058347515/IMG_20150506_141153.jpg",
//			"https://itandmecloud.blob.core.windows.net/04f90a340fdc89e261908ee7fb012d27c93a802bbf3239ffd4945cc9aeb7a51/thumbnail/447777722222/353918058347515/IMG_20150506_141157.jpg",
//			"https://itandmecloud.blob.core.windows.net/04f90a340fdc89e261908ee7fb012d27c93a802bbf3239ffd4945cc9aeb7a51/thumbnail/447777788888/1801210_10154630878015221_4585627400036777754_o.jpg",
//			"https://itandmecloud.blob.core.windows.net/04f90a340fdc89e261908ee7fb012d27c93a802bbf3239ffd4945cc9aeb7a51/thumbnail/447777788888/292-934x.jpg",
//			"https://itandmecloud.blob.core.windows.net/04f90a340fdc89e261908ee7fb012d27c93a802bbf3239ffd4945cc9aeb7a51/thumbnail/447777788888/353922055415960/IMG_20150529_131819.jpg.jpg",
//			"https://itandmecloud.blob.core.windows.net/04f90a340fdc89e261908ee7fb012d27c93a802bbf3239ffd4945cc9aeb7a51/thumbnail/447777788888/353922055415960/IMG_20150529_145223.jpg.jpg",
//			"https://itandmecloud.blob.core.windows.net/04f90a340fdc89e261908ee7fb012d27c93a802bbf3239ffd4945cc9aeb7a51/thumbnail/447777788888/358714058742028/IMAG1873.jpg",
//			"https://itandmecloud.blob.core.windows.net/04f90a340fdc89e261908ee7fb012d27c93a802bbf3239ffd4945cc9aeb7a51/thumbnail/447777788888/358714058742028/IMAG1913.jpg",
//			"https://itandmecloud.blob.core.windows.net/04f90a340fdc89e261908ee7fb012d27c93a802bbf3239ffd4945cc9aeb7a51/thumbnail/447777788888/358714058742028/IMG-20150519-WA0002.jpg",
//			"https://itandmecloud.blob.core.windows.net/04f90a340fdc89e261908ee7fb012d27c93a802bbf3239ffd4945cc9aeb7a51/thumbnail/447777788888/358714058742028/IMG-20150519-WA0003.jpg",
//			"https://itandmecloud.blob.core.windows.net/04f90a340fdc89e261908ee7fb012d27c93a802bbf3239ffd4945cc9aeb7a51/thumbnail/447777788888/358714058742028/IMG-20150519-WA0004.jpg",

			"https://itandmecloud.blob.core.windows.net/04f90a340fdc89e261908ee7fb012d27c93a802bbf3239ffd4945cc9aeb7a51/thumbnail/447777788888/358714058742028/IMG-20150522-WA0000.jpg"
		};
		public MyPage ()
		{
			InitializeComponent ();
			myImageView.OnSwipedLeft += OnImageSwipedLeft;
			myImageView.OnSwipedRight += OnImageSwipedRight;
			SetCurrImage ();
		}

		public void SetCurrImage()
		{
			Debug.WriteLine ("currImage is " + currImage.ToString ());
			myImageView.Source = images [currImage];
		}

		public void OnImageSwipedLeft()
		{
			if (currImage >= 0 && currImage < images.Length - 1) {
				currImage++;
				SetCurrImage ();
			}			
		}

		public void OnImageSwipedRight()
		{
			if (currImage > 0 && currImage <= images.Length - 1) {
				currImage--;
				SetCurrImage ();
			}
		}
	}
}

