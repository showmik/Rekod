using Rekod.ViewModel;

namespace Rekod.Views;

public partial class StudyPage : ContentPage
{
    public StudyPage(StudyViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}