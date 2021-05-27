namespace CollectionViewClearReloadGlitch.Models
{
    public class Restaurant
    {
        public string Name { get; }
        private readonly int _rating;
        public string Stars { get; private set; }
        public bool StarsAreVisible => _rating > 0;

        public Restaurant(string name, int rating = 0)
        {
            Name = name;
            _rating = rating;

            SetStars();
        }

        private void SetStars()
        {
            switch (_rating)
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
