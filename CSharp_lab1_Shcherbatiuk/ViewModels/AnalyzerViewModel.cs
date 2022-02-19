using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using CSharp_lab1_Shcherbatiuk.Annotations;
using CSharp_lab1_Shcherbatiuk.Models;
using CSharp_lab1_Shcherbatiuk.Tools;

namespace CSharp_lab1_Shcherbatiuk.ViewModels
{
    internal class AnalyzerViewModel: INotifyPropertyChanged
    {
        #region Fields

        private readonly User _user;
        private RelayCommand<object> _analyzeDateCommand;
        #endregion

        #region Properties

        public DateTime Date
        {
            get => _user.BirthDate;
            set
            {
                _user.BirthDate = value;
                OnPropertyChanged();
            }
        }
        public string Age
        {
            get => $"Your age: {_user.Age} ";
            set
            {
                _user.Age = value;
                OnPropertyChanged();
            }
        }
        public string WesternZodiac
        {
            get => $"Astrological Zodiac: {_user.WesternZodiac}";
            set
            {
                _user.WesternZodiac = value;
                OnPropertyChanged();
            }
        }
        public string ChineseZodiac
        {
            get => $"Chinese Zodiac: {_user.ChineseZodiac}";
            set
            {
                _user.ChineseZodiac = value;
                OnPropertyChanged();
            }
        }
        public RelayCommand<object> AnalyzeDateCommand
        {
            get
            {
                return _analyzeDateCommand ??= new RelayCommand<object>(Analyzer);
            }
        }

        #endregion

        internal AnalyzerViewModel()
        {
            _user = new User();
            Date = DateTime.Today;
        }
        private async void Analyzer(object o)
        {
           await Task.Run(() =>
            {
                try
                {
                    Age=CountAge();
                    ChineseZodiac=AnalyzeChineseZodiac();
                    WesternZodiac=AnalyzeWesternZodiac();
                    CheckIfBirthday();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            });
        }
        private string CountAge()
        {
           int years = DateTime.Today.Year - Date.Year;
           if ((DateTime.Today.Month < Date.Month) || (DateTime.Today.Month == Date.Month && DateTime.Today.Day < Date.Day)) years--;
           if (DateTime.Today.Year - Date.Year < 0) throw new ArgumentException("Date is from the future");
           if (DateTime.Today.Year - Date.Year > 135) throw new ArgumentException("Date is from the past");
           return years.ToString();
        }
        private string AnalyzeChineseZodiac()
        {
            return (Date.Year % 12) switch
            {
                0 => "Monkey",
                1 => "Rooster",
                2 => "Dog",
                3 => "Pig",
                4 => "Rat",
                5 => "Ox",
                6 => "Tiger",
                7 => "Rabbit",
                8 => "Dragon",
                9 => "Snake",
                10 => "Horse",
                _ => "Goat"
            };
        }
        private string AnalyzeWesternZodiac()
        {
            return Date.Month switch
            {
                1 => (Date.Day < 20 ? "Capricorn" : "Aquarius"),
                2 => (Date.Day < 19 ? "Aquarius" : "Pisces"),
                3 => (Date.Day < 21 ? "Pisces" : "Aries"),
                4 => (Date.Day < 20 ? "Aries" : "Taurus"),
                5 => (Date.Day < 21 ? "Taurus" : "Gemini"),
                6 => (Date.Day < 21 ? "Gemini" : "Cancer"),
                7 => (Date.Day < 23 ? "Cancer" : "Leo"),
                8 => (Date.Day < 23 ? "Leo" : "Virgo"),
                9 => (Date.Day < 23 ? "Virgo" : "Libra"),
                10 => (Date.Day < 23 ? "Libra" : "Scorpio"),
                11 => (Date.Day < 22 ? "Scorpio" : "Sagittarius"),
                _ => (Date.Day < 22 ? "Sagittarius" : "Capricorn")
            };
        }
        private void CheckIfBirthday()
        {
            if (DateTime.Today.Month == Date.Month && DateTime.Today.Day == Date.Day) MessageBox.Show("Happy Birthday!");
        }

        #region INotifyPropertyImplementation
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
