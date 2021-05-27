using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CollectionViewClearReloadGlitch
{
    public partial class MainPage
    {
        public ObservableCollection<Restaurant> Restaurants { get; } = new ObservableCollection<Restaurant>();

        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
            RefreshRestaurants();
        }

        private void RefreshRestaurants()
            => GetDefaultRestaurants().ForEach(restaurant => Restaurants.Add(restaurant));

        private static List<Restaurant> GetDefaultRestaurants()
        {
            return new List<Restaurant>()
            {
                new Restaurant("McDonald's"),
                new Restaurant("Chic-fil-a"),
                new Restaurant("Burger King", 3),
                new Restaurant("Sonic", 5),
            };
        }

        private void ClearAndReloadRestaurants(object sender, EventArgs e)
        {
            Restaurants.Clear();

            // This fixes the animation problem but may not scale in a larger app
            // await Task.Delay(100);

            RefreshRestaurants();
        }

        private void AddRestaurant(object sender, EventArgs e)
            => Restaurants.Add(new Restaurant("Red Robin", 4));

        private void RemoveRestaurant(object sender, EventArgs e)
            => Restaurants.RemoveAt(Restaurants.Count - 1);
    }
}
