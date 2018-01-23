using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using App1.Models;

namespace App1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewMonumentPage : ContentPage
    {
        public Monument Monument { get; set; }

        public NewMonumentPage()
        {
            InitializeComponent();

            Monument = new Monument();

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddMonument", Monument);
            await Navigation.PopModalAsync();
        }
    }
}