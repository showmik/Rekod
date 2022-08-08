using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Rekod.Model;
using Rekod.Services;
using System.Collections.ObjectModel;

namespace Rekod.ViewModel
{
    [QueryProperty(nameof(Deck), nameof(Deck))]
    public partial class StudyViewModel : ObservableObject
    {
        [ObservableProperty]
        private Deck deck;

        private Card currentCard;

        [ObservableProperty]
        private List<Card> cardCollection;

        [ObservableProperty]
        private ObservableCollection<Deck> boxCollection;

        [ObservableProperty]
        private bool isReady = false;

        [ObservableProperty]
        private bool isReaveled = false;

        [ObservableProperty]
        private bool revealButtonVisible = true;

        [ObservableProperty]
        private string cardText;

        [RelayCommand]
        private void Ready()
        {
            if (!isReady)
            {
                IsReady = true;
                cardCollection = deck.CardList;
                currentCard = cardCollection.FirstOrDefault();
                CardText = currentCard.BackText;
            }
            else
            {
                IsReady = false;
            }
        }

        [RelayCommand]
        private void RevealCard()
        {
            if (!IsReaveled)
            {
                IsReaveled = true;
                CardText = currentCard.FrontText;
            }
            else
            {
                IsReaveled = false;
            }
        }

        [RelayCommand]
        private void Remember()
        {
            currentCard.MoveToNextBox();
            _ = CardDataBaseService.UpdateCard(deck.DeckName, currentCard);
        }
    }
}