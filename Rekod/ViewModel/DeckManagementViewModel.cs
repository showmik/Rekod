using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Rekod.Model;
using Rekod.Services;
using Rekod.Views;

namespace Rekod.ViewModel
{
    [QueryProperty("DeckName", "DeckName")]
    public partial class DeckManagementViewModel : ObservableObject
    {
        [ObservableProperty] private string deckName;
        [ObservableProperty] private string frontText;
        [ObservableProperty] private string backText;
        [ObservableProperty] private List<Card> cardCollection;
        [ObservableProperty] private bool isRefreshing;
        [ObservableProperty] private string nextRevisionTime;
        private Card selectedCard;

        public DeckManagementViewModel()
        {
            cardCollection = new List<Card>();
        }

        [RelayCommand]
        private async void AddCard()
        {
            await Shell.Current.GoToAsync($"{nameof(AddCardPage)}?DeckName={deckName}");
        }

        [RelayCommand]
        private async void StudyDeck()
        {
            await Shell.Current.GoToAsync($"{nameof(StudyPage)}?DeckName={deckName}");
        }

        [RelayCommand]
        private void Tap(Card card)
        {
            selectedCard = card;
            FrontText = card.FrontText;
            BackText = card.BackText;
        }

        [RelayCommand]
        private async Task DeleteCard()
        {
            if (selectedCard != null)
            {
                await CardDataBaseService.RemoveCard(deckName, selectedCard.Id);
                FrontText = string.Empty;
                BackText = string.Empty;
                await Refresh();
            }
        }

        [RelayCommand]
        private async Task Refresh()
        {
            var cards = await CardDataBaseService.GetCards(deckName);
            CardCollection = (List<Card>)cards;
            IsRefreshing = false;
        }
    }
}