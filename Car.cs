using System;
using System.Globalization;
using System.Windows.Media.Imaging;

namespace HasznaltAuto.src
{
    public class Car
    {
        public string PicturePath { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Type { get; set; }
        public string Fuel { get; set; }
        public int Year { get; set; }
        public double Price { get; set; }

        public Car(string readLine)
        {
            var data = readLine.Split(";");
            PicturePath = data[0];
            Brand = data[1];
            Model = data[2];
            Type = data[3];
            Fuel = data[4];
            Year = int.Parse(data[5]);
            Price = double.Parse(data[6]);
        }

        public BitmapImage Picture
        {
            get
            {
                var image = new BitmapImage();
                if (string.IsNullOrEmpty(PicturePath))
                {
                    image.BeginInit();
                    image.UriSource = new Uri("C:/Users/Ny19MajorL/source/repos/HasznaltAuto/src/Images/NoImage.png", UriKind.RelativeOrAbsolute);
                    image.CacheOption = BitmapCacheOption.OnLoad;
                    image.EndInit();
                }
                else
                {
                    image = new BitmapImage();
                    image.BeginInit();
                    image.UriSource = new Uri("C:/Users/Ny19MajorL/source/repos/HasznaltAuto/src/Images/" + PicturePath, UriKind.RelativeOrAbsolute);
                    image.CacheOption = BitmapCacheOption.OnLoad;
                    image.EndInit();
                }
                return image;
            }
        }
    }
}
