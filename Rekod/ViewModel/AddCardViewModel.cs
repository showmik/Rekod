using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Rekod.Model;
using Rekod.Services;

namespace Rekod.ViewModel
{
    [QueryProperty("DeckName", "DeckName")]
    public partial class AddCardViewModel : ObservableObject
    {
        [ObservableProperty] private string deckName;
        [ObservableProperty] private string frontText;
        [ObservableProperty] private string backText;

        [RelayCommand]
        private async Task Add()
        {
            if (!string.IsNullOrEmpty(FrontText) && !string.IsNullOrEmpty(BackText))
            {
                Card card = new Card { FrontText = FrontText, BackText = BackText, Status = CardStatus.New };
                await CardDataBaseService.AddCard(deckName, card);
                FrontText = string.Empty;
                BackText = string.Empty;
            }
        }
    }
}