using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace StatusBarEffectExemplo.ViewModels
{
    public class MainViewModel :INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            => this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));


        protected virtual bool Set<T>(ref T property, T value, [CallerMemberName] string propertyName = null)
        {
            if (Object.Equals(property, value))
                return false;

            property = value;
            this.OnPropertyChanged(propertyName);
            return true;
        }

        Color corBar;
        public Color CorBar
        {
            get => this.corBar;
            set => this.Set(ref this.corBar, value);
        }

        public ICommand MudarCorCommand { get; }

        public MainViewModel()
        {
            CorBar = Color.Blue;

            this.MudarCorCommand = new Command(() =>
            {
                if (CorBar == Color.Blue)
                    CorBar = Color.Red;
                else 
                    CorBar = Color.Blue;
            });
        }

    }
}
