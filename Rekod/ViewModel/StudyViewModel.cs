using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Rekod.Model;
using System.Collections.ObjectModel;

namespace Rekod.ViewModel
{
    public partial class StudyViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<Deck> boxCollection;

        [ObservableProperty]
        private bool haveViewed = false;

        [ObservableProperty]
        private string labelText;

        [RelayCommand]
        private void HelloCard()
        {
            labelText = "smk";
            if (haveViewed)
            {
                haveViewed = false;
                return;
            }
            haveViewed = true;
        }

    }
}