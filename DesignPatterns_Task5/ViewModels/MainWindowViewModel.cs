using DesignPatterns_Task5.Commands;
using DesignPatterns_Task5.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using DesignPatterns_Task5.Models;

namespace DesignPatterns_Task5.ViewModels
{
    internal class MainWindowViewModel : BaseViewModel
    {
        public RelayCommand SendCommand { get; set; }

        private StackPanel notificationsCheckBoxesSP;

        public StackPanel NotificationsCheckBoxesSP
        {
            get { return notificationsCheckBoxesSP; }
            set { notificationsCheckBoxesSP = value; OnPropertyChanged(); }
        }


        public List<NotificationUC> Notifications { get; set; }

        public ListBox NotificationsLB { get; set; }

        public MainWindowViewModel()
        {
            SendCommand = new RelayCommand((s) =>
            {
                var notificationMessages = GetNotifications();
                var notificationViews = GetNotificationViews(notificationMessages);
                NotificationsLB.Items.Clear();
                foreach (var item in notificationViews)
                {
                    NotificationsLB.Items.Add(item);
                }
            });
        }

        public List<NotificationUC> GetNotificationViews(string notificationMessages)
        {
            var notificationViews = new List<NotificationUC>();
            var items = notificationMessages.Split(' ');
            foreach (var _item in items)
            {
                var item = _item.Trim();
                var notificationsView = new NotificationUC();
                var notificationsViewModel = new NotificationUCViewModel("", "");
                if (item == "instagram")
                {
                    notificationsViewModel = new NotificationUCViewModel(@"\Images\instagram.png", "Instagram Notification");
                }
                if (item == "telegram")
                {
                    notificationsViewModel = new NotificationUCViewModel(@"\Images\telegram.png", "Telegram Notification");
                }
                if (item == "twitter")
                {
                    notificationsViewModel = new NotificationUCViewModel(@"\Images\twitter.png", "Twitter Notification");
                }
                if (item == "facebook")
                {
                    notificationsViewModel = new NotificationUCViewModel(@"\Images\facebook.png", "Facebook Notification");
                }
                notificationsView.DataContext = notificationsViewModel;
                notificationViews.Add(notificationsView);
            }

            return notificationViews;
        }

        public string GetNotifications()
        {
            IMessage message = new Message();
            MessageDecorator decorator = new MessageDecorator(message);
            foreach (var item in NotificationsCheckBoxesSP.Children)
            {
                var cb = item as CheckBox;
                if (cb.IsChecked is true)
                {
                    var content = cb.Content.ToString().Split(' ')[0].ToLower().Trim();
                    if (content == "instagram")
                    {
                        IMessage instagramDecorator = new InstagramNotifier(message);
                        message = instagramDecorator;
                    }
                    if (content == "telegram")
                    {
                        IMessage telegramDecorator = new TelegramNotifier(message);
                        message = telegramDecorator;
                    }
                    if (content == "twitter")
                    {
                        IMessage twitterDecorator = new TwitterNotifier(message);
                        message = twitterDecorator;
                    }
                    if (content == "facebook")
                    {
                        IMessage facebookDecorator = new FacebookNotifier(message);
                        message = facebookDecorator;
                    }
                }
            }
            return message.GetMessages();
        }
    }
}
