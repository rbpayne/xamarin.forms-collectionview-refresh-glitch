namespace CollectionViewClearReloadGlitch
{
    public class Restaurant
    {
        public string Name { get; }
        private int Rating { get; }

        public string Stars
        {
            get
            {
                return Rating switch
                {
                    0 => "",
                    1 => "⭐️",
                    2 => "⭐️⭐️",
                    3 => "⭐️⭐️⭐️",
                    4 => "⭐️⭐️⭐️⭐️",
                    5 => "⭐️⭐️⭐️⭐️⭐️",
                    _ => ""
                };
            }
        }
        public bool StarsAreVisible => Rating > 0;

        public Restaurant(string name, int rating = 0)
        {
            Name = name;
            Rating = rating;
        }
    }
}
