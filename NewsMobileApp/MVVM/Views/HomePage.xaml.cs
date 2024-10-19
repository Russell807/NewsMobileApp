using NewsMobileApp.MVVM.Models;
using NewsMobileApp.MVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using CommunityToolkit.Maui.Views;
using Microsoft.Maui.Controls;

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

            // Subscribe to the Category selection event
            CategoryView.SelectionChanged += CategoryView_SelectionChanged;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var newsViewModel = new NewsViewModel();
            myCollection = await newsViewModel.LoadNews();
            ArticleList1.ItemsSource = myCollection;
        }

        // Hyperlink function
        private async void OnHyperlinkTapped(object sender, EventArgs e)
        {
            if (sender is Label label)
            {
                string articleUrl = label.Text;

                // Check if the URL is not null or empty
                if (!string.IsNullOrEmpty(articleUrl))
                {
                    // Validate the URL
                    if (IsValidUrl(articleUrl))
                    {
                        try
                        {
                            // Open the URL in the default browser
                            await Launcher.OpenAsync(articleUrl);
                        }
                        catch (Exception ex)
                        {
                            // Handle exceptions gracefully
                            await Application.Current.MainPage.DisplayAlert("Error", $"Could not open the link: {ex.Message}", "OK");
                        }
                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert("Invalid URL", "The provided URL is not valid.", "OK");
                    }
                }
            }
        }

        // Method to check if the URL is well-formed
        private bool IsValidUrl(string url)
        {
            return Uri.IsWellFormedUriString(url, UriKind.Absolute);
        }


        // Search function
        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            var keyword = SearchBar.Text;
            keyword = keyword.ToLower();
            ArticleList1.ItemsSource = myCollection.Where(s => s.Title.ToLower().Contains(keyword)).ToList();
        }

        // Show-summary button
        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (sender is Button button && button.BindingContext is Article article)
            {
                string[] sentences = article.Content.Split(new char[] { '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);

                string summary = sentences[0] + " " + sentences[1];
                await DisplayAlert("Summary", summary + "\n[click the link to read the full article]", "Close");
            }
        }

        // Filter button
        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            this.ShowPopup(new Modal());
        }

        // Category selection handler
        private void CategoryView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.FirstOrDefault() is Category selectedCategory)
            {
                // Test if the event is firing correctly
                DisplayAlert("Category Selected", $"You selected: {selectedCategory.Name}", "OK");
                FilterArticlesByCategory(selectedCategory.Name);
            }
        }

        // Method to filter articles based on category
        private void FilterArticlesByCategory(string category)
        {
            IEnumerable<Article> filteredArticles = myCollection;

            switch (category)
            {
                case "CCS":
                    filteredArticles = myCollection.Where(a => a.Content != null &&
                                                              (a.Content.Contains("smartphone", StringComparison.OrdinalIgnoreCase) ||
                                                              a.Content.Contains("computer", StringComparison.OrdinalIgnoreCase) ||
                                                              a.Content.Contains("tablet", StringComparison.OrdinalIgnoreCase) ||
                                                              a.Content.Contains("phone", StringComparison.OrdinalIgnoreCase) ||
                                                               a.Content.Contains("technology", StringComparison.OrdinalIgnoreCase)));
                    break;
                case "CBA":
                    filteredArticles = myCollection.Where(a => a.Content != null &&
                                                               (a.Content.Contains("business", StringComparison.OrdinalIgnoreCase) ||
                                                               a.Content.Contains("services", StringComparison.OrdinalIgnoreCase) ||
                                                                a.Content.Contains("market", StringComparison.OrdinalIgnoreCase)));
                    break;
                case "CAFA":
                    filteredArticles = myCollection.Where(a => a.Content != null &&
                                                               (a.Content.Contains("design", StringComparison.OrdinalIgnoreCase) ||
                                                               a.Content.Contains("architecture", StringComparison.OrdinalIgnoreCase) ||
                                                                a.Content.Contains("building", StringComparison.OrdinalIgnoreCase)));
                    break;
                case "CASS":
                    filteredArticles = myCollection.Where(a => a.Content != null &&
                                                               (a.Content.Contains("psychology", StringComparison.OrdinalIgnoreCase) ||
                                                               a.Content.Contains("social", StringComparison.OrdinalIgnoreCase) ||
                                                                a.Content.Contains("community", StringComparison.OrdinalIgnoreCase)));
                    break;
                case "CCJE":
                    filteredArticles = myCollection.Where(a => a.Content != null &&
                                                               (a.Content.Contains("police", StringComparison.OrdinalIgnoreCase) ||
                                                                a.Content.Contains("crime", StringComparison.OrdinalIgnoreCase)));
                    break;
                case "CIT":
                    filteredArticles = myCollection.Where(a => a.Content != null &&
                                                               (a.Content.Contains("vehicle", StringComparison.OrdinalIgnoreCase) ||
                                                               a.Content.Contains("technology", StringComparison.OrdinalIgnoreCase) ||
                                                                a.Content.Contains("engineering", StringComparison.OrdinalIgnoreCase) ||
                                                               a.Content.Contains("industry", StringComparison.OrdinalIgnoreCase) ||
                                                                a.Content.Contains("industrial", StringComparison.OrdinalIgnoreCase)));
                    break;
                case "COE":
                    filteredArticles = myCollection.Where(a => a.Content != null &&
                                                               (a.Content.Contains("engineering", StringComparison.OrdinalIgnoreCase) ||
                                                               a.Content.Contains("technology", StringComparison.OrdinalIgnoreCase) ||
                                                                a.Content.Contains("revolution", StringComparison.OrdinalIgnoreCase) ||
                                                               a.Content.Contains("mathematics", StringComparison.OrdinalIgnoreCase) ||
                                                                a.Content.Contains("physics", StringComparison.OrdinalIgnoreCase)));
                    break;
                case "COS":
                    filteredArticles = myCollection.Where(a => a.Content != null &&
                                                               (a.Content.Contains("volcano", StringComparison.OrdinalIgnoreCase) ||
                                                               a.Content.Contains("vitamins", StringComparison.OrdinalIgnoreCase) ||
                                                               a.Content.Contains("typhoon", StringComparison.OrdinalIgnoreCase) ||
                                                               a.Content.Contains("medical", StringComparison.OrdinalIgnoreCase) ||
                                                                a.Content.Contains("science", StringComparison.OrdinalIgnoreCase)));
                    break;
                case "CPAG":
                    filteredArticles = myCollection.Where(a => a.Content != null &&
                                                               (a.Content.Contains("government", StringComparison.OrdinalIgnoreCase) ||
                                                               a.Content.Contains("president", StringComparison.OrdinalIgnoreCase) ||
                                                                a.Content.Contains("governance", StringComparison.OrdinalIgnoreCase) ||
                                                               a.Content.Contains("public", StringComparison.OrdinalIgnoreCase) ||
                                                                a.Content.Contains("people", StringComparison.OrdinalIgnoreCase)));
                    break;
                case "CTED":
                    filteredArticles = myCollection.Where(a => a.Content != null &&
                                                               (a.Content.Contains("education", StringComparison.OrdinalIgnoreCase) ||
                                                               a.Content.Contains("teacher", StringComparison.OrdinalIgnoreCase) ||
                                                                a.Content.Contains("student", StringComparison.OrdinalIgnoreCase) ||
                                                               a.Content.Contains("school", StringComparison.OrdinalIgnoreCase) ||
                                                                a.Content.Contains("university", StringComparison.OrdinalIgnoreCase)));
                    break;
                default:
                    // Display all articles if no category matches
                    filteredArticles = myCollection;
                    break;
            }

            ArticleList1.ItemsSource = filteredArticles.ToList();
        }
    }
}
