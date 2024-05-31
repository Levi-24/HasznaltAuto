using HasznaltAuto.src;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;

namespace HasznaltAuto
{
    public partial class MainWindow : Window
    {
        List<Car> Vehicles { get; set; } = new List<Car>();
        List<Car> searched { get; set; } = new List<Car>();

        public ObservableCollection<Car> Final { get; set; } = new ObservableCollection<Car>();

        public MainWindow()
        {
            InitializeComponent();

            using (var sr = new StreamReader("../../../src/Cars.txt"))
            {
                _ = sr.ReadLine();
                while (!sr.EndOfStream) Vehicles.Add(new Car(sr.ReadLine()));
            }
            foreach (Car car in Vehicles)
            {
                Final.Add(car);
            }

            DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string temp = Text.Text.Trim();
            searched.Clear();

            if (temp == "")
            {
                Final.Clear();
                foreach (Car car1 in Vehicles)
                {
                    Final.Add(car1);
                }
                return;
            }

            foreach (Car car in Vehicles)
            {
                // Convert Price to string for comparison
                string priceString = car.Price.ToString();

                // Use string.Equals for case-insensitive comparison
                if (car.Brand.Contains(temp, StringComparison.OrdinalIgnoreCase) ||
                    car.Model.Contains(temp, StringComparison.OrdinalIgnoreCase) ||
                    car.Type.Equals(temp, StringComparison.OrdinalIgnoreCase) ||
                    car.Fuel.Equals(temp, StringComparison.OrdinalIgnoreCase) ||
                    car.Year.ToString().Equals(temp, StringComparison.OrdinalIgnoreCase) ||
                    priceString.Equals(temp, StringComparison.OrdinalIgnoreCase))
                {
                    searched.Add(car);
                    Final.Clear();
                    foreach (Car car2 in searched)
                    {
                        Final.Add(car2);
                    }
                }
            }
        }

    }
}
