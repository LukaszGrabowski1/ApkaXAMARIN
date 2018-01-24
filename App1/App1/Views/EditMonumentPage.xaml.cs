using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using App1.Models;

namespace App1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditMonumentPage : ContentPage
    {
        public Monument Monument { get; set; }
        
        public EditMonumentPage(Monument monument)
        {
            InitializeComponent();

            this.Monument = monument;

            BindingContext = this;
        }

        async void Update_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "UpdateMonument", Monument);
            await Navigation.PopAsync();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}