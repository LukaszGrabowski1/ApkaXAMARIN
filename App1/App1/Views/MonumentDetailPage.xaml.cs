using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using App1.Models;
using App1.ViewModels;

namespace App1.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MonumentDetailPage : ContentPage
	{
        MonumentDetailViewModel viewModel;
        public Monument Monument { get; set; }

        public MonumentDetailPage(MonumentDetailViewModel viewModel)
        {
                InitializeComponent();

            BindingContext = this.viewModel = viewModel;
            this.Monument = viewModel.Monument;
        }

        public MonumentDetailPage()
        {
            InitializeComponent();

            Monument = new Monument();

            viewModel = new MonumentDetailViewModel(Monument);
            BindingContext = viewModel;
        }

        void EditMonument_Clicked(object sender, EventArgs e)
        {

        }

        async void DeleteMonument_Clicked(object sender, EventArgs s)
        {
            Console.WriteLine("COUNT:" + App.Current.MainPage.Navigation.ModalStack.Count);
            MessagingCenter.Send(this, "DeleteMonument", Monument);
            await Navigation.PopAsync();
        }
    }
}