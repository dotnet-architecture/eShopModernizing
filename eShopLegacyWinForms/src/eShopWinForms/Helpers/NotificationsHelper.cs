using Windows.UI.Notifications;
using eShop.Domain.Models;
using Microsoft.Toolkit.Uwp.Notifications;

namespace eShop.UWP.Helpers
{
    public static class NotificationsHelper
    {
        public static void ShowToastNotification(string title, CatalogItem item)
        {
            var content = GenerateToastContent(title, item);
            ToastNotificationManager.CreateToastNotifier().Show(new ToastNotification(content.GetXml()));
        }

        private static ToastContent GenerateToastContent(string title, CatalogItem item)
        {
            var binding = new ToastBindingGeneric
            {
                Children =
                {
                    new AdaptiveText
                    {
                        Text = title
                    },
                    new AdaptiveText
                    {
                        Text = item.Name
                    },
                    new AdaptiveText
                    {
                        Text = item.Description
                    }
                }
            };

            if (!string.IsNullOrEmpty(item.PictureUri))
            {
                binding.Children.Add(new AdaptiveImage
                {
                    Source = item.PictureUri
                });
            }

            return new ToastContent
            {
                Visual = new ToastVisual
                {
                    BindingGeneric = binding
                }
            };
        }
    }
}
