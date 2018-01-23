using System;

using App1.Models;

namespace App1.ViewModels
{
    public class MonumentDetailViewModel : BaseViewModel
    {
        public Monument Monument { get; set; }
        public MonumentDetailViewModel(Monument monument = null)
        {
            Title = monument?.Name;
            Monument = monument;
        }
    }
}
