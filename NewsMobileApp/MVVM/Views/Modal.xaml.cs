using CommunityToolkit;
using CommunityToolkit.Maui.Views;
namespace NewsMobileApp.MVVM.Views;

public partial class Modal : Popup
{
    public Modal()
    {
        InitializeComponent();
    }
    private async void filterBtn(object sender, EventArgs e)
    {
        this.Close(new Modal());
    }
}