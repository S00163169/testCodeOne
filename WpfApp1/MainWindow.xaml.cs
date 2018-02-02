using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Load specific customers into the listbox 
            customerData.ItemsSource = MasterMethod();
        }

        static List<Template> MasterMethod()
        {
            try
            {
                //  String with the Customer JSON file
                string path = "gistfile1.txt";
                // List for holding all Customers in the JSON file
                List<Template> template = new List<Template>();
                // List for diplaying selected Customers Details
                List<Template> customerDetails = new List<Template>();
                // StreamReader for reading the File
                using (StreamReader sr = new StreamReader(path))
                {
                    string text = sr.ReadLine();
                    // Loop for getting each customer and storing them to the above List
                    while (text != null)
                    {
                        Template t1 = JsonConvert.DeserializeObject<Template>(text);

                        template.Add(t1);

                        text = sr.ReadLine();
                    }
                    sr.Close();
                }
                // Loop to get distance of all customers from office that are under 100 (Kilometers)
                for (int i = 0; i < template.Count; i++)
                {
                    double dist = Calculations.CalculateDistance(double.Parse(template[i].latitude), double.Parse(template[i].longitude));

                    if (dist <= 100)
                    {
                        Template t2 = new Template { user_id = template[i].user_id, name = template[i].name };
                        customerDetails.Add(t2);
                    }
                }

                customerDetails.Sort();

                return customerDetails;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }

    public class Calculations
    {
        public static double CalculateDistance(double lattitude, double longitude)
        {
            try
            {
                // Calculates the distance between two point using their latitude and longitude points
                double absoluteDifference = Math.Abs(-6.257664 - longitude);
                double distance = Math.Sin(ConvertToRadians(53.339428)) * Math.Sin(ConvertToRadians(lattitude)) + Math.Cos(ConvertToRadians(53.339428)) * Math.Cos(ConvertToRadians(lattitude)) * Math.Cos(ConvertToRadians(absoluteDifference));
                distance = Math.Acos(distance);
                distance = ConvertToDegrees(distance);
                distance = distance * 60 * 1.1515;
                distance = distance * 1.60934;

                return distance;
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public static double ConvertToRadians(double value)
        {
            // Converts to Radians
            return Math.Round((value * Math.PI / 180), 6);
        }

        public static double ConvertToDegrees(double value)
        {
            // Converts to Degrees
            return Math.Round((value / Math.PI * 180), 6);
        }
    }
}
