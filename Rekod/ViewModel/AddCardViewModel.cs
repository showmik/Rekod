using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Rekod.Model;
using Rekod.Services;

namespace Rekod.ViewModel
{
    [QueryProperty(nameof(Deck), nameof(Deck))]
    public partial class AddCardViewModel : ObservableObject
    {
        [ObservableProperty]
        private Deck deck;

        [ObservableProperty]
        private string frontText;

        [ObservableProperty]
        private string backText;

        [RelayCommand]
        private async Task AddAsync()
        {
            if(!string.IsNullOrEmpty(FrontText) && !string.IsNullOrEmpty(BackText))
            {
                //deck.CardList.Add(new Card(FrontText, BackText));
                //FrontText = string.Empty;
                //BackText = string.Empty;

                //await CardServices.AddCard(FrontText, BackText);
                await CardServices.AddCard("Hello", "YO");
                //var cards = await CardServices.GetCards();
                //deck.CardList.AddRange(cards);
            }
        }
    }
}