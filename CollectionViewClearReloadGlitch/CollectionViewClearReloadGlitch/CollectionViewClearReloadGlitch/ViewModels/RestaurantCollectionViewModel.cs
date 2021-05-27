using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using CollectionViewClearReloadGlitch.Models;

namespace CollectionViewClearReloadGlitch.ViewModels
{
    public class RestaurantCollectionViewModel
    {
        private readonly RestaurantCollection _restaurantCollection;

        public ObservableCollection<RestaurantViewModel> RestaurantViewModels { get; } =
            new ObservableCollection<RestaurantViewModel>();

        public RestaurantCollectionViewModel(RestaurantCollection restaurantCollection)
        {
            _restaurantCollection = restaurantCollection;

            ResetRestaurantViewModels();
            restaurantCollection.Restaurants.CollectionChanged += RestaurantsOnCollectionChanged;
        }

        private void ResetRestaurantViewModels()
        {
            RestaurantViewModels.Clear();
            _restaurantCollection.Restaurants.ToList()
                .ForEach(restaurant => RestaurantViewModels.Add(new RestaurantViewModel(restaurant)));
        }

        private void RestaurantsOnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
            => ResetRestaurantViewModels();

        public void RefreshRestaurants() => _restaurantCollection.RefreshRestaurants();
        public void AddRestaurant() => _restaurantCollection.AddRestaurant();
        public void RemoveRestaurant() => _restaurantCollection.RemoveRestaurant();
    }
}
