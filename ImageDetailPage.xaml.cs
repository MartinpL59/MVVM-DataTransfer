using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace Zhang.Yujia.PJ3
{
	public partial class ImageDetailPage : ContentPage
	{

		public ImageDetailPage(TestVM info)
		{
			BindingContext = info;
			InitializeComponent();
				

		}

		async void OnGoBackToListPageClick(object sender, EventArgs args) 
		{
			await Navigation.PopModalAsync();
		}

	}
}
