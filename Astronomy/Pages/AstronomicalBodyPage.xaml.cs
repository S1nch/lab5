using Astronomy.Pages;

namespace Astronomy.Pages
{
    // Атрибут для зіставлення параметра запиту з властивістю AstroName
    [QueryProperty(nameof(AstroName), "astroName")]
    public partial class AstronomicalBodyPage : ContentPage
    {
        // Властивість для зберігання назви астрономічного тіла
        string astroName;

        public string AstroName
        {
            get => astroName;
            set
            {
                astroName = value;
                // Оновлення UI після зміни значення властивості
                UpdateAstroBodyUI(astroName);
            }
        }

        public AstronomicalBodyPage()
        {
            InitializeComponent();
        }

        // Оновлення UI з інформацією про астрономічне тіло
        void UpdateAstroBodyUI(string astroName)
        {
            AstronomicalBody body = FindAstroData(astroName);

            Title = body.Name;

            lblIcon.Text = body.EmojiIcon;
            lblName.Text = body.Name;
            lblMass.Text = body.Mass;
            lblCircumference.Text = body.Circumference;
            lblAge.Text = body.Age;
        }

        // Знаходження даних про астрономічне тіло
        AstronomicalBody FindAstroData(string astronomicalBodyName)
        {
            return astronomicalBodyName switch
            {
                "comet" => SolarSystemData.HalleysComet,
                "earth" => SolarSystemData.Earth,
                "moon" => SolarSystemData.Moon,
                "sun" => SolarSystemData.Sun,
                _ => throw new ArgumentException()
            };
        }
    }
}
