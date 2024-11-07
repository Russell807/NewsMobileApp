using NewsMobileApp.MVVM.Models;
using System.Collections.ObjectModel;

namespace NewsMobileApp.MVVM.Views;

public partial class SavedPage : ContentPage
{
	public SavedPage()
	{
		InitializeComponent();
        BindingContext = this;
    }
    private void OnUnsaveClicked(object sender, EventArgs e)
    {
        // Get the article from the button's BindingContext
        var article = (sender as Button).BindingContext as Article;

        // Remove the article from the SavedArticles collection
        if (article != null)
        {
            SavedArticles.Remove(article);
        }
    }
    public ObservableCollection<Article> SavedArticles => HomePage.SavedArticles;
}