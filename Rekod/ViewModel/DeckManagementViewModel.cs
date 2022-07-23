using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Rekod.Model;
using Rekod.Views;
using System.Collections.ObjectModel;

namespace Rekod.ViewModel
{
    [QueryProperty(nameof(Deck), nameof(Deck))]
    public partial class DeckManagementViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<Card> cards;

        [ObservableProperty]
        private Deck deck;

        [ObservableProperty]
        private string frontText;

        [ObservableProperty]
        private string backText;

        public DeckManagementViewModel()
        {
            cards = new ObservableCollection<Card>();
        }

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
    }
}