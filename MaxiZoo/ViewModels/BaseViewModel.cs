using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace MaxiZoo.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged 
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        // BaseViewModel er en baseklasse for alle ViewModels i applikationen.
        // Den implementerer INotifyPropertyChanged, som gør det muligt for ViewModels at underrette UI'et, når en egenskab ændres.
        // Dette er essentielt for data binding i WPF, da det sikrer, at UI'et opdateres automatisk, når data i ViewModel ændres.
    }
}
