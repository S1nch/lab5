using Astronomy.Pages;

namespace Astronomy.Pages
{
    // ������� ��� ���������� ��������� ������ � ���������� AstroName
    [QueryProperty(nameof(AstroName), "astroName")]
    public partial class AstronomicalBodyPage : ContentPage
    {
        // ���������� ��� ��������� ����� ������������� ���
        string astroName;

        public string AstroName
        {
            get => astroName;
            set
            {
                astroName = value;
                // ��������� UI ���� ���� �������� ����������
                UpdateAstroBodyUI(astroName);
            }
        }

        public AstronomicalBodyPage()
        {
            InitializeComponent();
        }

        // ��������� UI � ����������� ��� ����������� ���
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

        // ����������� ����� ��� ����������� ���
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
