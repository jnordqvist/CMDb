using BattleShipBoardGame.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;

namespace BattleShipBoardGame.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        //public string WizardName { get; set; } = "Harry Potter";
        public ICommand CreateWizardCommand { get; }
        private string wizardName;

        public string WizardName
        {
            get { return wizardName; }
            set 
            { 
                wizardName = value;
                NotifyPropertyChanged();
            }
        }

        public MainViewModel()
        {
            CreateWizardCommand = new CreateWizardCommand(this);
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
