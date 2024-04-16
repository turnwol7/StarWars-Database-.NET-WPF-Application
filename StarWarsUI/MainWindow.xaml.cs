using System;
using System.Linq;
using System.Windows;
using StarWarsDatabaseApp;
using starwars;
using System.Windows.Controls;

namespace StarWarsUI
{
    public partial class MainWindow : Window
    {
        private List<Person> _peopleQuery;
        private List<Planet> _planetsQuery;
        private StarwarsContext _context = new StarwarsContext();

        public MainWindow()
        {
            InitializeComponent();
            ListPeople(null, null);
        }

        private void SaveChanges_Click(object sender, RoutedEventArgs e)
        {
            // Implement the logic to handle the SaveChanges button click event
        }

        public void RefreshPeopleQuery()
        {
            _peopleQuery = _context.People.ToList();
            lstResults.ItemsSource = _peopleQuery.Select(p => p.Name);
            UpdateStatusBar($"Count: {_peopleQuery.Count}");
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            string selectedItemName = lstResults.SelectedItem as string;

            if (selectedItemName != null)
            {
                if (_peopleQuery != null)
                {
                    var selectedPerson = _peopleQuery.FirstOrDefault(p => p.Name == selectedItemName);
                    if (selectedPerson != null)
                    {
                        SecondWindow window2 = new SecondWindow(selectedPerson, this);
                        window2.Show();
                        return;
                    }
                }

                if (_planetsQuery != null)
                {
                    var selectedPlanet = _planetsQuery.FirstOrDefault(p => p.Name == selectedItemName);
                    if (selectedPlanet != null)
                    {
                        SecondWindow window2 = new SecondWindow(selectedPlanet, this);
                        window2.Show();
                        return;
                    }
                }
            }

            MessageBox.Show("Please select an item to edit.");
        }

        private void ListPeople(object sender, RoutedEventArgs e)
        {
            _peopleQuery = _context.People.ToList();
            lstResults.ItemsSource = _peopleQuery.Select(p => p.Name);
            UpdateStatusBar($"Count: {_peopleQuery.Count}");
        }

        private void ListPlanets(object sender, RoutedEventArgs e)
        {
            _planetsQuery = _context.Planets.ToList();
            lstResults.ItemsSource = _planetsQuery.Select(p => p.Name);
            UpdateStatusBar($"Count: {_planetsQuery.Count}");
        }

        private void ListTallPeople(object sender, RoutedEventArgs e)
        {
            _peopleQuery = _context.People.Where(p => p.Height > 200).ToList();
            lstResults.ItemsSource = _peopleQuery.Select(p => p.Name);
            UpdateStatusBar($"Count: {_peopleQuery.Count}");
        }

        private void lstResults_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (lstResults.SelectedItem != null)
            {
                var selectedName = lstResults.SelectedItem as string;
                if (selectedName != null)
                {
                    if (_peopleQuery != null)
                    {
                        var selectedPerson = _peopleQuery.FirstOrDefault(p => p.Name == selectedName);
                        if (selectedPerson != null)
                        {
                            string hairColor = string.IsNullOrWhiteSpace(selectedPerson.HairColor) ? "Unknown" : selectedPerson.HairColor;
                            UpdateStatusBar($"Hair Color: {hairColor}");
                        }
                    }
                    if (_peopleQuery != null)
                    {
                        var selectedPerson = _peopleQuery.FirstOrDefault(p => p.Name == selectedName);
                        if (selectedPerson != null)
                        {
                            if (_peopleQuery.Any(p => p.Name == selectedName && p.Height > 200))
                            {
                                UpdateStatusBar($"Height: {selectedPerson.Height}");
                            }
                            else
                            {
                                UpdateStatusBar($"This person is not tall.");
                            }
                        }
                    }

                    if (_planetsQuery != null)
                    {
                        var selectedPlanet = _planetsQuery.FirstOrDefault(p => p.Name == selectedName);
                        if (selectedPlanet != null)
                        {
                            UpdateStatusBar($"Population: {selectedPlanet.Population}");
                        }
                    }
                }
            }
        }

        private void FilterPeopleByGender(object sender, RoutedEventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;
            if (radioButton != null && radioButton.IsChecked == true)
            {
                string gender = radioButton.Content.ToString();
                if (gender == "Male")
                {
                    _peopleQuery = _context.People.Where(p => p.Gender == "male").ToList();
                }
                else if (gender == "Female")
                {
                    _peopleQuery = _context.People.Where(p => p.Gender == "female").ToList();
                }

                lstResults.ItemsSource = _peopleQuery.Select(p => p.Name);
                UpdateStatusBar($"Count: {_peopleQuery.Count}");
            }
        }

        private void UpdateStatusBar(string message)
        {
            statusText.Text = message;
        }
    }
}
