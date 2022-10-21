using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns_Task5.ViewModels
{
    public class NotificationUCViewModel : BaseViewModel
    {
        public NotificationUCViewModel(string imagePath, string text)
        {
            ImagePath = imagePath;
            Text = text;
        }

        public string ImagePath { get; set; }
        public string Text { get; set; }
    }
}
