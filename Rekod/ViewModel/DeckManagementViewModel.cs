using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Rekod.Model;
using Rekod.Services;
using Rekod.Views;
using System.Collections.ObjectModel;

namespace Rekod.ViewModel
{
    [QueryProperty(nameof(Deck), nameof(Deck))]
    [QueryProperty("DeckCollection", "DeckCollection")]
    public partial class DeckManagementViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<Card> cards;

        [ObservableProperty]
        private ObservableCollection<Deck> deckCollection;

        [ObservableProperty]
        private Deck deck;

        [ObservableProperty]
        private string frontText;

        [ObservableProperty]
        private string backText;

        public DeckManagementViewModel()
        {
            cards = new ObservableCollection<Card>();
            Refresh();
        }

        [RelayCommand]
        private async void AddCard()
        {
            await Shell.Current.GoToAsync(nameof(AddCardPage),
                new Dictionary<string, object>
                {
                    ["Deck"] = deck
                });
            //await Refresh();
        }

        [RelayCommand]
        private void ChangeName()
        {
            deck.DeckName = "Name Changed!";
        }

        [RelayCommand]
        private void Tap(Card card)
        {
            FrontText = card.FrontText;
            BackText = card.BackText;
        }

        [RelayCommand]
        private async Task Refresh()
        {
            //deck.CardList.Clear();
            //var cards = await CardServices.GetCards();
            //deck.CardList.AddRange(cards);
            deck.CardList.Add(new Card{ FrontText="hello", BackText="mewo"});
        }
    }
}