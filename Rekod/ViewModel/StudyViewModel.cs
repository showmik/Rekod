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
        private async Task Ready()
        {
            if (!isReady)
            {
                IsReady = true;
                await LoadNextCard();
            }
            else
            {
                IsReady = false;
            }
        }

        [RelayCommand]
        private void RevealCard()
        {
            if (!IsReaveled && currentCard != null)
            {
                CardText = currentCard.FrontText;
                IsReaveled = true;
            }
            else
            {
                CardText = "Congratulations! No card for today!";
                IsReaveled = false;
                return;
            }
        }

        [RelayCommand]
        private async Task Remember()
        {
            if (currentCard != null)
            {
                currentCard.MoveToNextBox();
                await CardDataBaseService.UpdateCard(deck.DeckName, currentCard);
                await LoadNextCard();
            }
        }

        [RelayCommand]
        private async Task Forgot()
        {
            if (currentCard != null)
            {
                currentCard.MoveToPreviousBox();
                await CardDataBaseService.UpdateCard(deck.DeckName, currentCard);
                await LoadNextCard();
            }
        }

        private async Task LoadNextCard()
        {
            cardCollection = (List<Card>)await CardDataBaseService.GetCardsForStudy(deck.DeckName);
            currentCard = cardCollection.FirstOrDefault();

            if (currentCard != null && currentCard.NextStudyTime < DateTime.Now)
            {
                CardText = currentCard.BackText;
                IsReaveled = false;
            }
            else
            {
                CardText = "Congratulations! No card for today!";
            }
        }
    }
}