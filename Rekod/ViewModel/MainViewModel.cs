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
        [ObservableProperty] private ObservableCollection<Deck> deckCollection;
        private readonly List<string> deckNameCheckList;

        public MainViewModel()
        {
            deckCollection = new ObservableCollection<Deck>();
            deckNameCheckList = new List<string>();
            _ = Refresh();
        }

        [RelayCommand]
        private async Task AddDeck()
        {
            string deckName = await Application.Current.MainPage.DisplayPromptAsync("Create Deck", "Enter name of the deck:");

            if (!string.IsNullOrEmpty(deckName) && !deckNameCheckList.Contains(deckName))
            {
                deckNameCheckList.Add(deckName);
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
                deckNameCheckList.Remove(deck.DeckName);
                await DeckDataBaseService.RemoveDeck(deck.Id);
                CardDataBaseService.DeleteDatabase(deck.DeckName);
                await Refresh();
            }
        }

        [RelayCommand]
        private async Task Tap(Deck deck)
        {
            await Shell.Current.GoToAsync($"{nameof(DeckManagementPage)}?DeckName={deck.DeckName}");
        }

        [RelayCommand]
        private async Task Refresh()
        {
            DeckCollection.Clear();
            deckNameCheckList.Clear();
            var deckList = await DeckDataBaseService.GetDecks();

            foreach (Deck deck in deckList)
            {
                DeckCollection.Add(deck);
                deckNameCheckList.Add(deck.DeckName);
            }
        }
    }
}