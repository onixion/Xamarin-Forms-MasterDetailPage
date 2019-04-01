﻿
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TestDetailPage : ContentPage
	{
		public TestDetailPage()
		{
			InitializeComponent ();
            BindingContext = new TestDetailViewModel();
		}
	}

    public class TestDetailViewModel
    {
        /// <summary>
        /// On menu toggle command.
        /// </summary>
        public ICommand OnShowMasterCommand { get; }

        /// <summary>
        /// On open other page command.
        /// </summary>
        public ICommand OnOpenOtherPageCommand { get; }

        /// <summary>
        /// On pop command.
        /// </summary>
        public ICommand OnPopCommand { get; }

        /// <summary>
        /// Show loader command.
        /// </summary>
        public ICommand OnShowLoader { get; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public TestDetailViewModel()
        {
            OnShowMasterCommand = new Command(() =>
            {
                var masterDetailPage = App.MasterDetailPage;
                masterDetailPage.IsMasterShown = true;
            });

            OnOpenOtherPageCommand = new Command(async () =>
            {
                await ((NavigationPage)GetMasterDetailPage().DetailPage).PushAsync(new TestDetailPage());
            });

            OnPopCommand = new Command(async () =>
            {
                await ((NavigationPage)GetMasterDetailPage().DetailPage).PopAsync();
            });

            OnShowLoader = new Command(async () =>
            {
                GetMasterDetailPage().IsBusy = true;
                await Task.Delay(3000);
                GetMasterDetailPage().IsBusy = false;
            });
        }

        MasterDetailPage GetMasterDetailPage()
        {
            return (MasterDetailPage)Application.Current.MainPage;
        }
    }
}