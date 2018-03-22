using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DataBinding
{
    class ViewModelCUSKAMO : INotifyPropertyChanged
    {
        private int _numberOfClicks;
        public ObservableCollection<Person> Persons { get; set; }
        string[] maleNames = { "aaron", "abdul", "abe", "abel", "Matěj", "Filip", "Honza", "Alfréd", "Pan koločko" };
        Random rnd = new Random();

        public string Text { get; set; } = "rygr";
        public ViewModelCUSKAMO()
        {
            var persons = new List<Person>();
            for (int i = 0; i < 50; i++)
            {
                persons.Add(new Person(maleNames[rnd.Next(9)], i, "Ne"));
            }
            Persons = new ObservableCollection<Person>(persons);
            ClickCommand = new RelayCommand(ClickMethod);

            CommandWithParameters = new RelayCommand<Person>(CommandWithParametersMethod);
        }
        


        /// <summary>
        ///     Veřejné přístupové rozhraní pro proměnnou, která je iterována pomocí Buttonu
        /// </summary>
        public int NumberOfClicks
        {
            get => _numberOfClicks;
            set
            {
                _numberOfClicks = value;
                // Po změně hodnoty proměnné je nutné oznámit View tuto změnu, aby se mohlo View obnovit (refresh)
                OnPropertyChanged("NumberOfClicks");
            }
        }
        /// <summary>
        ///     Mvvmlight nugget balíček poskytuje zjednodušené rozhraní pro práci s Commands a mnoho dalšího
        /// </summary>

        // Command, který je bindovaný do Buttonu
        public RelayCommand ClickCommand { get; }

        // Command s parametrem typu string
        public RelayCommand<Person> CommandWithParameters { get; }

        public Person SelectedPerson { get; set; }
        public Person PersonToBind { get; set; } = new Person("Jméno a přijmení", 1, "ne");

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        ///     Metoda volaná Commandem, který je Bindovaný na Button
        /// </summary>
        private void ClickMethod()
        {
            NumberOfClicks++;
            
        }

        /// <summary>
        ///     Zobrazí v MessageBox obsah objektu osoby
        /// </summary>
        /// <param name="person">Osoba získaná z Command parametru</param>
        private void CommandWithParametersMethod(Person person)
        {
            MessageBox.Show($"Person name: {SelectedPerson.Name} id: {SelectedPerson.Id}");
        }

        protected void OnPropertyChanged(string name)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(name));
        }


    }

}
