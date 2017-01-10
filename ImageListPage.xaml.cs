using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace Zhang.Yujia.PJ3
{
	public partial class ImageListPage : ContentPage
	{
		//public IList<TestVM> list = new ObservableCollection<TestVM>();

	//	public IList<TestVM> InfoCollection;
		public ImageListPage(AppData appdata)
		{
			InitializeComponent();

			BindingContext = appdata;
			//InfoCollection = (IList<TestVM>)listView.ItemsSource;
		}

		void OnGetInfoButtonClicked(object sender, EventArgs args) 
		{
			GoToInfoPage(new TestVM(), true);
		}




		 void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs args)
		{
			if (args.SelectedItem != null)
			{
				// De-select the item.
		    	listView.SelectedItem = null;
				//GoToInfoPage((TestVM)args.SelectedItem);
				GoToInfoPage((TestVM)args.SelectedItem, false);
			}
		}
		//async void GoToInfoPage(TestVM info)
		async void GoToInfoPage(TestVM info, bool isNewItem)
		{
			// Get AppData object (set to BindingContext in XAML file).
			AppData appData = (AppData)BindingContext;
			// Set info item to CurrentInfo property of AppData.
			appData.CurrentInfo = info;
			// Navigate to the info page.
			await Navigation.PushModalAsync(new ImageDetailPage(info));

			// Add new info item to the collection.
			if (isNewItem)
			{
				appData.InfoCollection.Add(info);
			}

		}


	}
}
//ItemsSource="{Binding Items.dataModels}"
//ItemsSource = "{Binding InfoCollection}"