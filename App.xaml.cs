using Xamarin.Forms;

namespace Zhang.Yujia.PJ3
{
	public partial class App : Application
	{
		public App()
		{
           Xamarin.FormsBook.Toolkit.Toolkit.Init();

			AppData = new AppData();

			MainPage = new NavigationPage(new MainPage());

			//Page A= new NavigationPage(new ImageListPage());

		}
		public AppData AppData { private set; get; }
		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
