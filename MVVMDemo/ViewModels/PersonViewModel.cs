using System.Windows.Media;

namespace MVVMDemo.ViewModels
{
    public class PersonViewModel : BaseViewModel
    {
        private Models.Person Person { get; set; } = new Models.Person();

        public string Firstname 
        {
            get { return Person.Firstname; }
            set
            {
                Person.Firstname = value;
                OnPropertyChanged(nameof(FullName));
                OnPropertyChanged(nameof(FirstnameBackgroundColor));

            } 
        }

        public string Lastname
        {
            get { return Person.Lastname; }
            set
            {
                Person.Lastname = value;
                OnPropertyChanged(nameof(FullName));
                OnPropertyChanged(nameof(Lastname));
            }
        }

        public string FullName => $"{Person.Lastname} {Person.Firstname}";

        public Brush FirstnameBackgroundColor => GetBrush(Firstname);
        public Brush LastnameBackgroundColor => GetBrush(Lastname);

        public string Time => DateTime.UtcNow.ToString();

        public PersonViewModel()
        {
            Task.Run(() =>
            {
                while (true)
                {
                    Task.Delay(1000).Wait();
                    OnPropertyChanged(nameof(Time));
                }
            });
        }

        private Brush GetBrush(string name)
        {
            if(name.Length < 1)         return new SolidColorBrush(Colors.Transparent);
            else if(name.Length <= 15)  return new SolidColorBrush(Colors.Green);
            else                        return new SolidColorBrush(Colors.Red);
        }
    }
}
