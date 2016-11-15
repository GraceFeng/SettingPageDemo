using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace SettingPageDemo
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SettingPage : Page
    {
        public SettingPage()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Enabled; //Cache this setting page.
        }

        private ObservableCollection<CustomBackground> colorCollection = new ObservableCollection<CustomBackground>();

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            colorCollection.Clear();
            colorCollection.Add(new CustomBackground() { ColorName = "Wheat", CustomColor = new SolidColorBrush(Colors.Wheat) });
            colorCollection.Add(new CustomBackground() { ColorName = "Light Blue", CustomColor = new SolidColorBrush(Colors.LightBlue) });
            colorCollection.Add(new CustomBackground() { ColorName = "Light Gray", CustomColor = new SolidColorBrush(Colors.LightGray) });
            colorCollection.Add(new CustomBackground() { ColorName = "Olive", CustomColor = new SolidColorBrush(Colors.Olive) });
            colorCollection.Add(new CustomBackground() { ColorName = "Gold", CustomColor = new SolidColorBrush(Colors.Gold) });
        }

        private void Combo1_Loaded(object sender, RoutedEventArgs e)
        {
            Combo1.SelectedIndex = App.SettingDay;
        }

        private void Combo2_Loaded(object sender, RoutedEventArgs e)
        {
            Combo2.SelectedIndex = App.SettingBrush;
        }

        private void Combo1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedindex = Combo1.SelectedIndex;
            App.SettingDay = selectedindex;
        }

        private void Combo2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedindex = Combo2.SelectedIndex;
            if (selectedindex != -1)
            {
                App.SettingBrush = selectedindex;
                var selecteditem = Combo2.SelectedItem as CustomBackground;
                var rootFrame = Window.Current.Content as Frame;
                var main = rootFrame.Content as MainPage;
                main.setting.CurrentCustomBrush = selecteditem.CustomColor;
            }
        }

        public class CustomBackground
        {
            public SolidColorBrush CustomColor { get; set; }
            public string ColorName { get; set; }
        }
    }
}