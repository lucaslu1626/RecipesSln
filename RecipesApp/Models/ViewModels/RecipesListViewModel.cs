﻿using RecipesApp.Models;

namespace RecipesApp.Models.ViewModels
{
    public class RecipesListViewModel
    {
        public IEnumerable<Recipe> Recipes { get; set; } = Enumerable.Empty<Recipe>();
        public IEnumerable<Discussion> Discussions { get; set; } = Enumerable.Empty<Discussion>();
        public PagingInfo PagingInfo { get; set; } = new();
        public string? CurrentCategory { get; set; }
        public string? CurrentRecipe { get; set; }
        public Discussion Discussion { get; set; } = new Discussion();
        //public string ImagePath { get { return "~/Content/Image/Golden-Apple-Pie.jpg"; } }
    }
}
