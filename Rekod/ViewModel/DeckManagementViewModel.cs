using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Rekod.Model;
using Rekod.Services;
using Rekod.Views;

namespace Rekod.ViewModel
{
    [QueryProperty(nameof(Deck), nameof(Deck))]
    public partial class DeckManagementViewModel : ObservableObject
    {
        [ObservableProperty]
        private Deck deck;

        [ObservableProperty]
        private string frontText;

        [ObservableProperty]
        private string backText;

        [RelayCommand]
        private async void AddCard()
        {
            await Shell.Current.GoToAsync(nameof(AddCardPage),
                new Dictionary<string, object>
                {
                    ["Deck"] = deck
                });
        }

        [RelayCommand]
        private async void StudyDeck()
        {
            await Shell.Current.GoToAsync(nameof(StudyPage));
        }

        [RelayCommand]
        private void Tap(Card card)
        {
            FrontText = card.FrontText;
            BackText = card.BackText;
        }

        public async Task Refresh()
        {
            deck.CardList.Clear();
            var cards = await CardDataBaseService.GetCards(deck.DeckName);
            deck.CardList.AddRange(cards);
        }
    }
}