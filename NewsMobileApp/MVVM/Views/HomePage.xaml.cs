using NewsMobileApp.MVVM.Models;
using NewsMobileApp.MVVM.ViewModels;
using System;
using System.Windows.Input;
using static System.Net.Mime.MediaTypeNames;

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
    private void OnHyperlinkTapped(object sender, EventArgs e)
    {
     
        if (sender is Label label)
        {
            string articleUrl = label.Text;

            if (!string.IsNullOrEmpty(articleUrl))
            {
                Launcher.OpenAsync(articleUrl);
            }
        }
    }
}