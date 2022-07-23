using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Rekod.Model;
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
        }

        [RelayCommand]
        private async Task AddDeck()
        {
            string deckName = await Application.Current.MainPage.DisplayPromptAsync("Create Deck", "Enter name of the deck:");

            if (!string.IsNullOrEmpty(deckName))
            {
                deckItem = new Deck(deckName);
                deckCollection.Add(deckItem);
                
                //DeckItem = null;
            }
        }

        [RelayCommand]
        private void DeleteDeck(Deck deck)
        {
            if (deckCollection.Contains(deck))
            {
                deckCollection.Remove(deck);
            }
        }

        [RelayCommand]
        private async Task Tap(Deck deck)
        {
            await Shell.Current.GoToAsync(nameof(DeckManagementPage),
                new Dictionary<string, object>
                {
                    ["Deck"] = deck
                });
        }
    }
}