using NewsMobileApp.MVVM.Models;
using NewsMobileApp.MVVM.ViewModels;
using System;
using System.Windows.Input;
using static System.Net.Mime.MediaTypeNames;

namespace NewsMobileApp.MVVM.Views;

public partial class HomePage : ContentPage
{


    List<Article> myCollection;


    public HomePage()
	{
		InitializeComponent();
		CategoryView.BindingContext = new CategoryViewModel();
        myCollection = new List<Article>();
        ArticleList1.ItemsSource = myCollection;

    }
	protected override async void OnAppearing()
	{
        base.OnAppearing();
        var newsViewModel = new NewsViewModel();
        myCollection = await newsViewModel.LoadNews();
        ArticleList1.ItemsSource = myCollection;

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

   private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
     {
         var keyword = SearchBar.Text;
         keyword = keyword.ToLower();
         ArticleList1.ItemsSource = myCollection.Where(s => s.Title.ToLower().Contains(keyword)).ToList();


       

    }
}