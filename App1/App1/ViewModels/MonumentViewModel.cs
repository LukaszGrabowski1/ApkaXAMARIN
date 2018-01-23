using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using App1.Models;
using App1.Views;

namespace App1.ViewModels
{
    public class MonumentViewModel : BaseViewModel
    {
        public ObservableCollection<Monument> Monuments { get; set; }
        public Command LoadMonumentsCommand { get; set; }

        public MonumentViewModel()
        {
            Title = "Browse";
            Monuments = new ObservableCollection<Monument>();
            LoadMonumentsCommand = new Command(async () => await ExecuteLoadMonumentsCommand());

            MessagingCenter.Subscribe<NewMonumentPage, Monument>(this, "AddMonument", async (obj, monument) =>
            {
                var _monument = monument as Monument;
                Monuments.Add(_monument);
                await DataStore.AddMonumentAsync(_monument);
            });

            MessagingCenter.Subscribe<MonumentDetailPage, Monument>(this, "DeleteMonument", async (obj, monument) =>
            {
                try
                {
                    var _monument = monument as Monument;
                    Monuments.Remove(_monument);
                    await DataStore.DeleteMonumentAsync(_monument);
                }catch(Exception e)
                {
                    Console.WriteLine(e);
                }
            });
        }

        async Task ExecuteLoadMonumentsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Monuments.Clear();
                var monuments = await DataStore.GetMonumentsAsync(true);
                foreach (var monument in monuments)
                {
                    Monuments.Add(monument);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}