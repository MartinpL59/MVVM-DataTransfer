using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using System.Windows.Input;
using System.Xml.Serialization;
namespace Zhang.Yujia.PJ3
{
	public class TestVM: ViewModelBase
	{
		public string title;

		public string detail;

		public DateTime timeTaken;

		public string image;

		public string Title
		{
			set { SetProperty(ref title, value); }
			get { return title; }
		}

		public string Detail
		{
			set { SetProperty(ref detail, value); }
			get { return detail; }
		}

		public DateTime TimeTaken
		{
			set { SetProperty(ref timeTaken, value); }
			get { return timeTaken; }
		}
		public string Image
		{
			set { SetProperty(ref image, value); }
			get { return image; }
		}


	/*	public TestVM() 
		{
			
			//MoveToTopCommand = new Command(() => StudentBody.MoveStudentToTop(this));
			
			MoveToTopCommand = new Command(() => appData.MoveStudentToTop(this));
			
			MoveToBottomCommand = new Command(() => InfoCollection.MoveStudentToBottom(this));
			
			RemoveCommand = new Command(() => InfoCollection.RemoveStudent(this));
		}*/

      /*  [XmlIgnore]
		public ICommand MoveToTopCommand { private set; get; }

		[XmlIgnore]
		public ICommand MoveToBottomCommand { private set; get; }

		[XmlIgnore]
		public ICommand RemoveCommand { private set; get; }

		[XmlIgnore]
		public AppData appData { set; get; }*/



		public ICommand UpCommand { set; get; }
		public ICommand DownCommand { private set; get; }
		public ICommand DeleteCommand { private set; get; }
		public ICommand AddCommand { private set; get; }
		public AppData AppData { set; get; }

		public TestVM()
		{
			//AppState = new AppState();
			UpCommand = new Command(() => AppData.UpCommand(this));
			DownCommand = new Command(() => AppData.DownCommand(this));
			DeleteCommand = new Command(() => AppData.DeleteCommand(this));
			AddCommand = new Command(() => AppData.AddCommand(this));
		}

	}
}
