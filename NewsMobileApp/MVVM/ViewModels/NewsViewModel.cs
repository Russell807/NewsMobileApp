using NewsMobileApp.MVVM.Models;
using NewsMobileApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace NewsMobileApp.MVVM.ViewModels
{
    public class NewsViewModel
    {
       
        public List<Article> ArticleList { get; set; } = new List<Article>();
        

        public async Task <List<Article>> LoadNews() 
        {
          var rootNews = await APIData.GetNews();
            foreach (var item in rootNews.Articles)
            {
                ArticleList.Add(item);
            }
            return ArticleList;
        }


    }
}
