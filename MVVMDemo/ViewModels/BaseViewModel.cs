using System.ComponentModel;

namespace MVVMDemo.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged //For databinding
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        //eventhandler

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
