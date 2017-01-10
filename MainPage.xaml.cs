using Xamarin.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Reflection;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Net;
using Xamarin.Forms;
//using System.ComponentModel;
using System.IO;
using System.Reflection;

namespace Zhang.Yujia.PJ3
{
	public partial class MainPage : ContentPage
	{
		AppData appdata;
		public List<string> uriList = new List<string>();

		int count;
		//	int x = appDatax.InfoCollection.Count;

	   
		//string uri1 = appDatax.InfoCollection[0].Image;
		//string uri1 = appDatax.CurrentInfo.Image;

		//string uri2 = appDatax.InfoCollection[1].Image;
		//string uri1 = "https://developer.xamarin.com/demo/IMG_1415.JPG?width=250";
		//string uri2 = "https://developer.xamarin.com/demo/IMG_0074.JPG";
		//string uri3 = "https://developer.xamarin.com/demo/IMG_3256.JPG";
		//string uri4 = "https://developer.xamarin.com/demo/IMG_0925.JPG?width=512" ;
	
		bool switchOff = false;
		double input = 5;
		int index = 1;
		double countTime = 0;
		//Uri uri;
		//string uri= "uri";
		public MainPage()
		{
			/*for (int i = 0; i < x; i++)
			{
				Binding binding1 = new Binding
				{
					Source = appDatax.InfoCollection[0],
					Path = "Image",
					Mode = BindingMode.TwoWay
				};
			}*/
			InitializeComponent();

			appdata = new AppData();

			count = appdata.InfoCollection.Count;


			/*	uriList.Add(uri1);
				uriList.Add(uri2);
				uriList.Add(uri3);
				uriList.Add(uri4);*/

			//	ImageWeb2(appdata.InfoCollection[0].Image);
			image.Source = appdata.InfoCollection[0].Image;



			var time = TimeSpan.FromSeconds(1);

			Device.StartTimer(time, () =>
			 {
				 if (switchOff)
				 {
					 countTime++;
				 }
				if (switchOff && index < count && countTime >= (int)input)
				 {
					 index++;
					 countTime -= input;
					image.Source = appdata.InfoCollection[index-1].Image;
					// string urx = appdata.InfoCollection[index-1].Image;
					 //ImageWeb2(urx);

					// string picture = "Zhang.Yujia.PJ3.Images.Building" + index + ".jpg";

					//https://developer.xamarin.com/demo/IMG_0074.JPG
					//https://developer.xamarin.com/demo/IMG_1415.JPG?width=250
					//https://developer.xamarin.com/demo/IMG_3256.JPG

					// ImageLocal(picture);
				 }
				/* if (switchOff && index >= 4 && uri != null && countTime >= (int)input)
				 {
					 ImageWeb2();
					 uri = null;
					 countTime -= input;
				 }*/
				if (switchOff && index >= count && countTime >= (int)input)
				 {
					image.Source = appdata.InfoCollection[0].Image;
					// ImageWeb2(appdata.InfoCollection[0].Image);
				 }
				 return true;
			 });


		}
	/*	void InputAlert(object sender, TextChangedEventArgs args) 
		{
			if (sender == entry1)
			{
				double num = Double.Parse(entry1.Text);
				if (num > 60 || num < 1)
				{
					DisplayAlert("Input Alert", "The input is illegal", "OK");
				}
				else
				{
					input = Double.Parse(args.NewTextValue);
				}
			}
		}*/

		void OnSliderValueChanged(object sender, ValueChangedEventArgs args)
		{
			if (entry1 != null)
			{
					input = args.NewValue;
					//input = int.Parse(entry1.Text);
			}
		}

		void OnStepperValueChanged(object sender, ValueChangedEventArgs args)
		{
			if (entry1 != null)
			{
				input = args.NewValue;
			}
		}

		void OnControlImageToggled(object sender, ToggledEventArgs args)
		{
			if (args.Value)
			{
				switchOff = true;
			}
			else
			{
				switchOff = false;
			}
		}
		/*void ImageLocal(String resourceID)
		{
			image1.Source = ImageSource.FromStream(() =>
					{
						Assembly assembly = GetType().GetTypeInfo().Assembly;
						Stream stream = assembly.GetManifestResourceStream(resourceID);
						return stream;
					});
		}*/

		void ImageWeb2(string urx)
		{
			//Uri uriReally = new Uri(urx);
			//Uri urx = uri;
			WebRequest request = WebRequest.Create(urx);
			request.BeginGetResponse((IAsyncResult arg) =>
			 {
				 Stream stream = request.EndGetResponse(arg).GetResponseStream();
				 ImageSource imageSource = ImageSource.FromStream(() => stream);
				 Device.BeginInvokeOnMainThread(() => image.Source = imageSource);
			 }, null);
		}
		void InputAlert(object sender, EventArgs args)
		{
			if (sender == entry1)
			{
				double num = Double.Parse(entry1.Text);
				if (num > 60 || num < 1)
				{
					Task task = DisplayAlert("Input Alert", "The input is illegal", "OK");
				}
				else
				{
					input = (int) num;
				}
			}
		}
		void OnImagePropertyChanged(object sender, PropertyChangedEventArgs args)
		{
			if (args.PropertyName == "IsLoading")
			{
				activityIndicator.IsRunning = ((Image)sender).IsLoading;
			}
		}
		async void OnButtonClicked(object sender, EventArgs args) 
		{
			if (args !=null) 
			{
				ImageListPage infoPage = new ImageListPage(appdata);
				await Navigation.PushAsync(infoPage);

			}
		}
		void OnPageSizeChanged(object sender, EventArgs args)
		{
			// Portrait mode.
			if (Width < Height)
			{
				mainGrid.RowDefinitions[1].Height = GridLength.Auto;
				mainGrid.ColumnDefinitions[1].Width = new GridLength(0, GridUnitType.Absolute);

				Grid.SetRow(controlPanelStack, 1);
				Grid.SetColumn(controlPanelStack, 0);
			}
			else
			{
				mainGrid.RowDefinitions[1].Height = new GridLength(0, GridUnitType.Absolute);
				mainGrid.ColumnDefinitions[1].Width = new GridLength(1, GridUnitType.Star);

				Grid.SetRow(controlPanelStack, 0);
				Grid.SetColumn(controlPanelStack, 1);
			}
		}


	}
}


//string uri1 = "https://developer.xamarin.com/demo/IMG_1415.JPG?width=250";