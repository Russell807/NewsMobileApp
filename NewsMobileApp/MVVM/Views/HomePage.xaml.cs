using NewsMobileApp.MVVM.ViewModels;

namespace NewsMobileApp.MVVM.Views;

public partial class HomePage : ContentPage
{
	public HomePage()
	{
		InitializeComponent();
		CategoryView.BindingContext = new CategoryViewModel();
		
	}
    protected override async void OnAppearing()
    {
        base.OnAppearing();
		ArticleList1.ItemsSource = await new NewsViewModel()
			.LoadNews();
			
    }

}