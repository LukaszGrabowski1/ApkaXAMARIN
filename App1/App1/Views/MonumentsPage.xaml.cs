using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using App1.Models;
using App1.Views;
using App1.ViewModels;

namespace App1.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MonumentsPage : ContentPage
	{
        MonumentViewModel viewModel;

        public MonumentsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new MonumentViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var monument = args.SelectedItem as Monument;
            if (monument == null)
                return;

            await Navigation.PushAsync(new MonumentDetailPage(new MonumentDetailViewModel(monument)));

            MonumentsListView.SelectedItem = null;
        }

        async void AddMonument_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewMonumentPage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Monuments.Count == 0)
                viewModel.LoadMonumentsCommand.Execute(null);
        }
    }
}