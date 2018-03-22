using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;

namespace DataBinding.LightCommand
{
    class MvvmlightCommandViewModel
    {
        private int _numberOfClicks;

        /// <summary>
        ///     Nastavení Commands
        /// </summary>
        public MvvmlightCommandViewModel()
        {
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


        public ObservableCollection<Person> Persons { get; set; }

        /// <summary>
        ///     Mvvmlight nugget balíček poskytuje zjednodušené rozhraní pro práci s Commands a mnoho dalšího
        /// </summary>

        // Command, který je bindovaný do Buttonu
        public RelayCommand ClickCommand { get; }

        // Command s parametrem typu string
        public RelayCommand<Person> CommandWithParameters { get; }

        public Person SelectedPerson;
        public Person PersonToBind { get; set; } = new Person("Jméno a přijmení", 1,"ne");

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
            MessageBox.Show($"Person name: {person.Name} id: {person.Id}");
        }

        protected void OnPropertyChanged(string name)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(name));
        }
    }
}
