﻿using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using XamlBrewer.WinUI3.Navigation.Sample.Services;
using XamlBrewer.WinUI3.Navigation.Sample.Views;

namespace XamlBrewer.WinUI3.Navigation.Sample
{
    public sealed partial class Shell : Window, INavigation
    {
        private void NavigationView_Loaded(object sender, RoutedEventArgs e)
        {
            // Navigates, but does not update the Menu.
            // ContentFrame.Navigate(typeof(HomePage));

            SetCurrentNavigationViewItem(GetNavigationViewItems(typeof(HomePage)).First());
        }

        private void NavigationView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            SetCurrentNavigationViewItem(args.SelectedItemContainer as NavigationViewItem);
        }

        public List<NavigationViewItem> GetNavigationViewItems()
        {
            var items = NavigationView.MenuItems.Select(i => (NavigationViewItem)i).ToList();
            items.AddRange(NavigationView.FooterMenuItems.Select(i => (NavigationViewItem)i));

            return items;
        }

        public List<NavigationViewItem> GetNavigationViewItems(Type type)
        {
            var result = new List<NavigationViewItem>();
            result.AddRange(GetNavigationViewItems().Where(i => i.Tag.ToString() == type.FullName));
            foreach (NavigationViewItem mainItem in NavigationView.MenuItems)
            {
                result.AddRange(mainItem.MenuItems.Select(i => (NavigationViewItem)i).Where(i => i.Tag.ToString() == type.FullName));
            }
            return result;
        }

        public List<NavigationViewItem> GetNavigationViewItems(Type type, string title)
        {
            return GetNavigationViewItems(type).Where(ni => ni.Content.ToString() == title).ToList();
        }

        public void SetCurrentNavigationViewItem(NavigationViewItem item)
        {
            if (item == null)
            {
                return;
            }

            if (item.Tag == null)
            {
                return;
            }

            ContentFrame.Navigate(Type.GetType(item.Tag.ToString()), item.Content);
            NavigationView.Header = item.Content;
            NavigationView.SelectedItem = item;
        }

        public NavigationViewItem GetCurrentNavigationViewItem()
        {
            return NavigationView.SelectedItem as NavigationViewItem;
        }
    }
}