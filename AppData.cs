using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Zhang.Yujia.PJ3
{
	public class AppData
	{
		public AppData()
		{
			InfoCollection = new ObservableCollection<TestVM>();
			TestVM building1 = new TestVM();
			TestVM building2 = new TestVM();
			TestVM building3 = new TestVM();
			TestVM building4 = new TestVM();

			building1.Title = "Building1";
			building1.TimeTaken = DateTime.Now;
			building1.Detail = "Building4--beatiful" ;
			building1.Image = "https://developer.xamarin.com/demo/IMG_1415.JPG?width=250";

			building2.Title = "Building2";
			building2.TimeTaken = DateTime.Now;
			building2.Detail = "Building4--beatiful" ;
			building2.Image = "https://developer.xamarin.com/demo/IMG_0074.JPG";

			building3.Title = "Building3";
			building3.TimeTaken = DateTime.Now;
			building3.Detail = "Building3--beatiful";
			building3.Image = "https://developer.xamarin.com/demo/IMG_3256.JPG";

			building4.Title = "Building4";
			building4.TimeTaken = DateTime.Now;
			building4.Detail = "Building4--beatiful";
			building4.Image = "https://developer.xamarin.com/demo/IMG_0925.JPG?width=512";

			InfoCollection.Add(building1);
			InfoCollection.Add(building2);
			InfoCollection.Add(building3);
			InfoCollection.Add(building4);
		}
		public  ObservableCollection<TestVM> InfoCollection { set; get; }
		public TestVM CurrentInfo { set; get; }
		//public static TestVM building1 { set; get; }


		public void UpCommand(TestVM curr)
		{
			if (InfoCollection.IndexOf(curr) >= 1)
			{
				InfoCollection.Move(InfoCollection.IndexOf(curr), InfoCollection.IndexOf(curr) - 1);
			}
		}
		public void DownCommand(TestVM curr)
		{
			if (InfoCollection.IndexOf(curr) < InfoCollection.Count)
			{
				InfoCollection.Move(InfoCollection.IndexOf(curr), InfoCollection.IndexOf(curr) + 1);
			}
		}
		public void DeleteCommand(TestVM curr)
		{
			InfoCollection.Remove(curr);
		}
		public void AddCommand(TestVM curr)
		{
		}

	}
}
