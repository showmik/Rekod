using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Rekod.Model;
using Rekod.Services;

namespace Rekod.ViewModel
{
    [QueryProperty("DeckName", "DeckName")]
    public partial class StudyViewModel : ObservableObject
    {
        [ObservableProperty] private string deckName;
        [ObservableProperty] private bool isReady;
        [ObservableProperty] private bool isReaveled;
        [ObservableProperty] private string cardText;
        private Card currentCard;

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
            }
        }

        [RelayCommand]
        private async Task Remember()
        {
            if (currentCard != null && !currentCard.DoneForToday)
            {
                currentCard.MoveToNextBox();
                await CardDataBaseService.UpdateCard(deckName, currentCard);
                await LoadNextCard();
            }
        }

        [RelayCommand]
        private async Task Forgot()
        {
            if (currentCard != null && !currentCard.DoneForToday)
            {
                currentCard.MoveToPreviousBox();
                await CardDataBaseService.UpdateCard(deckName, currentCard);
                await LoadNextCard();
            }
        }

        private async Task LoadNextCard()
        {
            var cardCollection = await CardDataBaseService.GetCards(deckName);
            currentCard = cardCollection.FirstOrDefault();

            if (currentCard != null && !currentCard.DoneForToday)
            {
                CardText = currentCard.BackText;
                IsReaveled = false;
            }
            else
            {
                CardText = "Congratulations! No card for today!";
                IsReaveled = true;
            }
            await CardDataBaseService.UpdateCard(deckName, currentCard);
        }
    }
}