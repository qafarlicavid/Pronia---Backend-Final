﻿namespace Pronia_Site___Backend.Areas.Admin.ViewModels.Product
{
    public class CategoryListItemViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public CategoryListItemViewModel(int id, string title)
        {
            Id = id;
            Title = title;
        }
    }
}
