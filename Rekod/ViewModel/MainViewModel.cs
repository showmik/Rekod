using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Rekod.Model;
using Rekod.Services;
using Rekod.Views;
using System.Collections.ObjectModel;

namespace Rekod.ViewModel
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<Deck> deckCollection;
        
        private ObservableCollection<string> deckNames;

        public MainViewModel()
        {
            deckCollection = new ObservableCollection<Deck>();
            deckNames = new ObservableCollection<string>();
            _ = Refresh();
        }

        [RelayCommand]
        private async Task AddDeck()
        {
            string deckName = await Application.Current.MainPage.DisplayPromptAsync("Create Deck", "Enter name of the deck:");

            if (!string.IsNullOrEmpty(deckName) && !deckNames.Contains(deckName))
            {
                deckNames.Add(deckName);
                Deck deck = new() {DeckName = deckName};
                await DeckDataBaseService.AddDeck(deck);
                await Refresh();
            }
        }

        [RelayCommand]
        private async void DeleteDeck(Deck deck)
        {
            if (deckCollection.Contains(deck))
            {
                CardDataBaseService.DeleteDatabase(deck.DeckName);
                deckNames.Remove(deck.DeckName);
                await DeckDataBaseService.RemoveDeck(deck.Id);
                await Refresh();
                deck.CardList.Clear();
            }
        }

        [RelayCommand]
        private async Task Tap(Deck deck)
        {
            deck.CardList.Clear();
            var cards = await CardDataBaseService.GetCards(deck.DeckName);
            deck.CardList.AddRange(cards);

            await Shell.Current.GoToAsync(nameof(DeckManagementPage),
                new Dictionary<string, object>
                {
                    ["Deck"] = deck
                });
        }

        [RelayCommand]
        private async Task Refresh()
        {
            DeckCollection.Clear();
            deckNames.Clear();

            var deckList = await DeckDataBaseService.GetDecks();

            foreach (Deck deck in deckList)
            {
                DeckCollection.Add(deck);
                deckNames.Add(deck.DeckName);
            }
        }
    }
}