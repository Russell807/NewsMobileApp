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
         new Category { Id = 0, Name = "ALL NEWS", ImageSource = "globalnews.avif", BackgroundColor = Color.FromArgb("#000080") },
        new Category { Id = 1, Name = "CCS", ImageSource = "ccs.webp", BackgroundColor = Color.FromArgb("#8B0000") }, 
        new Category { Id = 2, Name = "CBA", ImageSource = "cba.webp", BackgroundColor = Color.FromArgb("#33FF57") }, 
        new Category { Id = 3, Name = "CAFA", ImageSource = "cafa.webp", BackgroundColor = Color.FromArgb("#FF8000") }, 
        new Category { Id = 4, Name = "CASS", ImageSource = "cass.webp", BackgroundColor = Color.FromArgb("#3357FF") }, 
        new Category { Id = 5, Name = "CCJE", ImageSource = "ccje.webp", BackgroundColor = Color.FromArgb("#808080") }, 
        new Category { Id = 6, Name = "CIT", ImageSource = "cit.webp", BackgroundColor = Color.FromArgb("#E1D9D1 ") }, 
        new Category { Id = 7, Name = "COE", ImageSource = "coe.webp", BackgroundColor = Color.FromArgb("#800000") },
        new Category { Id = 8, Name = "COS", ImageSource = "cos.webp", BackgroundColor = Color.FromArgb("#808080") }, 
        new Category { Id = 9, Name = "CPAG", ImageSource = "cpag.webp", BackgroundColor = Color.FromArgb("#008000") }, 
        new Category { Id = 10, Name = "CTED", ImageSource = "cted.webp", BackgroundColor = Color.FromArgb("#8B8000") }  
    };
        }

    }
}
