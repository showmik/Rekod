using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Rekod.Model;
using Rekod.Services;

namespace Rekod.ViewModel
{
    [QueryProperty(nameof(Deck), nameof(Deck))]
    public partial class AddCardViewModel : ObservableObject
    {
        [ObservableProperty]
        private Deck deck;

        [ObservableProperty]
        private string frontText;

        [ObservableProperty]
        private string backText;

        [RelayCommand]
        private async Task Add()
        {
            if (!string.IsNullOrEmpty(FrontText) && !string.IsNullOrEmpty(BackText))
            {
                Card card = new Card { FrontText = FrontText, BackText = BackText, Status = CardStatus.New };
                await CardDataBaseService.AddCard(deck.DeckName, card);
                FrontText = string.Empty;
                BackText = string.Empty;
                await Refresh();
            }
        }

        private async Task Refresh()
        {
            deck.CardList.Clear();
            var cards = await CardDataBaseService.GetCards(deck.DeckName);
            deck.CardList.AddRange(cards);
        }
    }
}