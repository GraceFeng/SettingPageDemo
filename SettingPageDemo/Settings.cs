using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Media;

namespace SettingPageDemo
{
    public class Settings : INotifyPropertyChanged
    {
        public Settings()
        {
            _CurrentCustomBrush = Setting_Brush[App.SettingBrush];
        }

        public static List<string> Setting_Day = new List<string>()
        {
            "Monday",
            "Tuesday",
            "Wensday",
            "Thursday",
            "Friday",
            "Saturday",
            "Sunday"
        };

        public static List<SolidColorBrush> Setting_Brush = new List<SolidColorBrush>()
        {
            new SolidColorBrush(Colors.Wheat),
            new SolidColorBrush(Colors.LightBlue),
            new SolidColorBrush(Colors.LightGray),
            new SolidColorBrush(Colors.Olive),
            new SolidColorBrush(Colors.Gold)
        };

        private SolidColorBrush _CurrentCustomBrush;

        public SolidColorBrush CurrentCustomBrush
        {
            get { return _CurrentCustomBrush; }
            set
            {
                if (value != _CurrentCustomBrush)
                {
                    _CurrentCustomBrush = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName]string propertyName = "")
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}