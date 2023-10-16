using NewsMobileApp.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsMobileApp.MVVM.ViewModels
{
    public class CategoryViewModel
    {
        public ObservableCollection<Category> ListOfCategory { get; set;}

        public CategoryViewModel() {

            LoadCategory();

        }

        private void LoadCategory()
        {
            ListOfCategory = new ObservableCollection<Category>()
           {
               new Category{Id=1,Name="College of Computer Studies"},
                new Category{Id=2,Name="College of Business and Accountancy"},
                 new Category{Id=3,Name="College of Architecture and Fine Arts"},
                  new Category{Id=4,Name="College of Arts and Social Sciences"},
                   new Category{Id=5,Name="College of Engineering and Technology"},
                    new Category{Id=6,Name=" College of Criminal Justice Education"},
                     new Category{Id=7,Name="College of Teachers' Education"},
                      new Category{Id=8,Name="College of Science"}
           };
        }
    }
}
