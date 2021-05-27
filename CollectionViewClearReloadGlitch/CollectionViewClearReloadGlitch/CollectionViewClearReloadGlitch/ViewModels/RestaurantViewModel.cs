using CollectionViewClearReloadGlitch.Models;

namespace CollectionViewClearReloadGlitch.ViewModels
{
    public class RestaurantViewModel
    {
        private readonly Restaurant _restaurant;

        public string Name => _restaurant.Name;
        public string Stars => _restaurant.Stars;
        public bool StarsAreVisible => _restaurant.StarsAreVisible;

        public RestaurantViewModel(Restaurant restaurant)
        {
            _restaurant = restaurant;
        }
    }
}
