using starwars;
using System.Windows;

namespace StarWarsUI
{
    public partial class SecondWindow : Window
    {
        private Person _selectedPerson;
        private Planet _selectedPlanet;
        private MainWindow _mainWindow;

        public SecondWindow(object selectedItem, MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;

            if (selectedItem is Person person)
            {
                SetSelectedPerson(person);
            }
            else if (selectedItem is Planet planet)
            {
                SetSelectedPlanet(planet);
            }
        }

        public void SetSelectedPerson(Person person)
        {
            _selectedPerson = person;
            textBoxName.Text = _selectedPerson.Name;
            textBoxHeight.Text = _selectedPerson.Height.ToString();
        }

        public void SetSelectedPlanet(Planet planet)
        {
            _selectedPlanet = planet;
            textBoxName.Text = _selectedPlanet.Name;
            textBoxHeight.Text = _selectedPlanet.Population.ToString();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedPerson != null)
            {
                _selectedPerson.Name = textBoxName.Text;
                _selectedPerson.Height = int.Parse(textBoxHeight.Text);
            }

            if (_selectedPlanet != null)
            {
                _selectedPlanet.Name = textBoxName.Text;
                _selectedPlanet.Population = int.Parse(textBoxHeight.Text);
            }

            this.Close();
            _mainWindow.RefreshPeopleQuery();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
