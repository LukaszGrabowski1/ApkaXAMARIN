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

        public MonumentDetailPage(MonumentDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public MonumentDetailPage()
        {
            InitializeComponent();

            var monument = new Monument
            {
                Location = "Monument 1",
                Description = "This is an monument description."
            };

            viewModel = new MonumentDetailViewModel(monument);
            BindingContext = viewModel;
        }
    }
}