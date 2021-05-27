using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace CollectionViewClearReloadGlitch.Models
{
    public class RestaurantCollection : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<Restaurant> Restaurants { get; } = new ObservableCollection<Restaurant>();

        public void RefreshRestaurants()
        {
            var remoteRestaurants = GetAllRestaurants();
            Restaurants.Clear();
            remoteRestaurants.ForEach(restaurant => Restaurants.Add(restaurant));
        }

        public void AddRestaurant() => Restaurants.Add(new Restaurant("Red Robin", 4));
        public void RemoveRestaurant() => Restaurants.RemoveAt(Restaurants.Count - 1);

        private static List<Restaurant> GetAllRestaurants()
        {
            return new List<Restaurant>()
            {
                new Restaurant("McDonald's"),
                new Restaurant("Chic-fil-a"),
                new Restaurant("Burger King", 3),
                new Restaurant("Sonic", 5)
            };
        }
    }
}
