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
        private string deckName;

        public MainViewModel()
        {
            deckCollection = new ObservableCollection<Deck>();
        }

        [ObservableProperty]
        private Deck _deckItem;

        [RelayCommand]
        private async Task AddDeck()
        {
            deckName = await Application.Current.MainPage.DisplayPromptAsync("Create Deck", "Enter name of the deck:");

            if(deckName != null)
            {
                _deckItem = new Deck(deckName);
                deckCollection.Add(_deckItem);
                //DeckItem = null;
                //deckName = string.Empty;
            }
            
        }

        [RelayCommand]
        void DeleteDeck(Deck deck)
        {
            if(deckCollection.Contains(deck))
            {
                deckCollection.Remove(deck);
            }
        }

        [RelayCommand]
        async Task Tap(Deck deck)
        {
            await Shell.Current.GoToAsync(nameof(DeckManagementPage));
        }
    }
}