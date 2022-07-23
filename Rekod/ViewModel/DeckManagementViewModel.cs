using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Rekod.Views;

namespace Rekod.ViewModel
{
    public partial class DeckManagementViewModel : ObservableObject
    {
        [RelayCommand]
        async void AddCard()
        {
            await Shell.Current.GoToAsync(nameof(AddCardPage));
        }
    }
}
