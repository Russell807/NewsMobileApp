using NewsMobileApp.MVVM.Models;
using NewsMobileApp.MVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Input;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace NewsMobileApp.MVVM.Views
{
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

        //hyperlink
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

        //search function
        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            var keyword = SearchBar.Text;
            keyword = keyword.ToLower();
            ArticleList1.ItemsSource = myCollection.Where(s => s.Title.ToLower().Contains(keyword)).ToList();
        }

        // show-summary button
        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (sender is Button button)
            {

                if (button.BindingContext is Article article)
                {
                    string[] sentences = article.Content.Split(new char[] { '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);

                        string summary = sentences[0] + " " + sentences[1];
                        await DisplayAlert("Summary", summary + "\n[click the link to read the full article]", "Close");
                 
                }
            }
        }

    }
}


    



            
        
    

