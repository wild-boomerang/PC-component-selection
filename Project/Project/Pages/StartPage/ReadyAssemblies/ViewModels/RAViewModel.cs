using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Project.Pages.StartPage.ReadyAssemblies.ViewModels
{
    public class RAViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public Models.ReadyAssemblies ReadyAssemblies { get; set; }
        public RAListViewModel ralvm;

        public RAViewModel()
        {
            ReadyAssemblies = new Models.ReadyAssemblies();
        }

        public RAListViewModel ListViewModel
        {
            get { return ralvm; }
            set
            {
                if (ralvm != value)
                {
                    ralvm = value;
                    OnPropertyChanged("ralvm");
                }
            }
        }

        public string Name
        {
            get { return ReadyAssemblies.Name; }
            set
            {
                if (ReadyAssemblies.Name != value)
                {
                    ReadyAssemblies.Name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        public Computer Computer
        {
            get { return ReadyAssemblies.Assembly; }
            set
            {
                if (ReadyAssemblies.Assembly != value)
                {
                    ReadyAssemblies.Assembly = value;
                    OnPropertyChanged("Assembly");
                }
            }
        }

        public string ImageSource
        {
            get { return ReadyAssemblies.Assembly.ImageSource; }
            set
            {
                if (ReadyAssemblies.Assembly.ImageSource != value)
                {
                    ReadyAssemblies.Assembly.ImageSource = value;
                    OnPropertyChanged("ImageSource");
                }
            }
        }

        protected void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
