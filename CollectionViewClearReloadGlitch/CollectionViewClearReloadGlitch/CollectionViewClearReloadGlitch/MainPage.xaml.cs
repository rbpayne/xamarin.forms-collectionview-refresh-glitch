using System;
using CollectionViewClearReloadGlitch.Models;
using CollectionViewClearReloadGlitch.ViewModels;

namespace CollectionViewClearReloadGlitch
{
    public partial class MainPage
    {
        private static readonly RestaurantCollection RestaurantCollection = new RestaurantCollection();
        private readonly RestaurantCollectionViewModel _viewModel;

        public MainPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new RestaurantCollectionViewModel(RestaurantCollection);
        }

        private void RefreshRestaurants(object sender, EventArgs e) => _viewModel.RefreshRestaurants();
        private void AddRestaurant(object sender, EventArgs e) => _viewModel.AddRestaurant();
        private void RemoveRestaurant(object sender, EventArgs e) => _viewModel.RemoveRestaurant();
    }
}
