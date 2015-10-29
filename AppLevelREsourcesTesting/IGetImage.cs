using System;

namespace AppLevelREsourcesTesting
{
	public interface IGetImage
	{
		void GetImageFromURL (string URL);
		string URL { get; set; }
		double Width{ get; }
		double Height{ get; }
	}
}

