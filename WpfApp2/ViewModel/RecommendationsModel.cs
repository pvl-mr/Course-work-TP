using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using WpfApp2.pages;

namespace WpfApp2.ViewModel
{
    public class RecommendationsModel
    {
        public Page CurrentPage { get; set; }
        private Page recommendationUpdatePage;

        public RecommendationsModel()
        {
            recommendationUpdatePage = new RecommendationUpdatePage();
            CurrentPage = recommendationUpdatePage;
        }
    }
}
