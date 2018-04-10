using System.Collections.Generic;
using System.Reflection;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;

namespace eShop.UWP.Helpers
{
    public static class DependencyObjectExtensions
    {
        public static void FindChildren<T>(this DependencyObject startNode, List<T> results) where T : DependencyObject
        {
            int count = VisualTreeHelper.GetChildrenCount(startNode);
            for (int i = 0; i < count; i++)
            {
                DependencyObject current = VisualTreeHelper.GetChild(startNode, i);
                if ((current.GetType()).Equals(typeof(T)) || (current.GetType().GetTypeInfo().IsSubclassOf(typeof(T))))
                {
                    T asType = (T)current;
                    results.Add(asType);
                }
                current.FindChildren<T>(results);
            }
        }

        public static T FindParent<T>(this DependencyObject startNode) where T : DependencyObject
        {
            DependencyObject parentObject = VisualTreeHelper.GetParent(startNode);
            if (parentObject == null) return null;

            if (parentObject is T parent)
            {
                return parent;
            }
            else
            {
                return FindParent<T>(parentObject);
            }
        }
    }
}
