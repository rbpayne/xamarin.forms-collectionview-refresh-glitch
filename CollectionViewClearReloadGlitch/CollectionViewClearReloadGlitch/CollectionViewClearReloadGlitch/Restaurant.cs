namespace CollectionViewClearReloadGlitch
{
    public class Restaurant
    {
        public string Name { get; }
        private int Rating { get; }
        public string Stars { get; private set; }
        public bool StarsAreVisible => Rating > 0;

        public Restaurant(string name, int rating = 0)
        {
            Name = name;
            Rating = rating;

            SetStars();
        }

        private void SetStars()
        {
            switch (Rating)
            {
                case 0:
                    Stars = "";
                    break;
                case 1:
                    Stars = "⭐️";
                    break;
                case 2:
                    Stars = "⭐️⭐️";
                    break;
                case 3:
                    Stars = "⭐️⭐️⭐️";
                    break;
                case 4:
                    Stars = "⭐️⭐️⭐️⭐️";
                    break;
                case 5:
                    Stars = "⭐️⭐️⭐️⭐️⭐️";
                    break;
            }
        }
    }
}
