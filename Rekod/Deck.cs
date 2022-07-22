namespace Rekod
{
    internal class Deck
    {
        private Button openDeckButton;
        private Button deleteDeckButton;
        private MainPage mainPage;
        public HorizontalStackLayout deckStackLayout;

        public Deck(string name, MainPage mainPage)
        {
            openDeckButton = new Button
            {
                Text = name,
                BackgroundColor = Color.Parse("YellowGreen")
            };

            deleteDeckButton = new Button
            {
                Text = "Delete",
                BackgroundColor = Color.Parse("Tomato"),
                TextColor = Color.Parse("White")
            };

            openDeckButton.Clicked += OnOpenDeckButton_Clicked;
            deleteDeckButton.Clicked += OnDeleteDeckButton_Clicked;

            deckStackLayout = new HorizontalStackLayout { Margin = new Thickness(0, 5)};
            deckStackLayout.Children.Add(openDeckButton);
            deckStackLayout.Children.Add(deleteDeckButton);

            this.mainPage = mainPage;
        }

        public void OnDeleteDeckButton_Clicked(object sender, EventArgs e)
        {
            mainPage.DeleteDeck((HorizontalStackLayout)deleteDeckButton.Parent);
        }

        public void OnOpenDeckButton_Clicked(object sender, EventArgs e)
        {
            
        }
    }
}