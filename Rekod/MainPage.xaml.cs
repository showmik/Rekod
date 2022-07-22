namespace Rekod;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();

	}

    public async void OnDeckCreateButton_Clicked(object sender, EventArgs e)
    {
        string deckName = await DisplayPromptAsync("Create Deck", "Enter name of the deck:");

        if (!string.IsNullOrEmpty(deckName))
        {
            Deck newDeck = new Deck(deckName, this);
            deckCollectionStack.Children.Add(newDeck.deckStackLayout);
        }
    }

    public void DeleteDeck(HorizontalStackLayout deckStackLayout)
    {
        int index = deckCollectionStack.Children.IndexOf(deckStackLayout);
        deckCollectionStack.Children.RemoveAt(index);
    }
}

