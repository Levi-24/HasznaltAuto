using HasznaltAuto.src;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;

namespace HasznaltAuto
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<Car> Vehicles { get; set; } = new ObservableCollection<Car>();

        public MainWindow()
        {
            InitializeComponent();

            using (var sr = new StreamReader("../../../src/Cars.txt"))
            {
                _ = sr.ReadLine();
                while (!sr.EndOfStream) Vehicles.Add(new Car(sr.ReadLine()));
            }

            DataContext = this;
        }
    }
}
