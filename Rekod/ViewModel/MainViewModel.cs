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

        [ObservableProperty]
        private Deck deckItem;

        public MainViewModel()
        {
            deckCollection = new ObservableCollection<Deck>();
            Refresh();
        }

        [RelayCommand]
        private async Task AddDeck()
        {
            string deckName = await Application.Current.MainPage.DisplayPromptAsync("Create Deck", "Enter name of the deck:");

            if (!string.IsNullOrEmpty(deckName))
            {
                deckItem = new Deck();
                deckItem.DeckName = deckName;
                deckItem.CardList = new();
                //deckCollection.Add(deckItem);
                await DeckDataService.AddDeck(deckItem);
                await Refresh();
            }
        }

        [RelayCommand]
        private async void DeleteDeck(Deck deck)
        {
            if (deckCollection.Contains(deck))
            {
                await DeckDataService.RemoveDeck(deck.Id);
                await Refresh();
                //deckCollection.Remove(deck);
            }
        }

        [RelayCommand]
        private async Task Tap(Deck deck)
        {
            await Shell.Current.GoToAsync(nameof(DeckManagementPage),
                new Dictionary<string, object>
                {
                    ["Deck"] = deck,
                    ["DeckCollection"] = deckCollection
                });
        }

        [RelayCommand]
        private async Task Refresh()
        {
            DeckCollection.Clear();
            var deckList = await DeckDataService.GetDecks();
            
            foreach(Deck deck in deckList)
            {
                DeckCollection.Add(deck);
            }
        }
    }
}