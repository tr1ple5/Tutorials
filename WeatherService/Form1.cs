using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeatherService.ServiceReference;
using System.ServiceModel;
using System.Xml.Serialization;
using System.IO;

namespace WeatherService
{
    public partial class formWeather : Form
    {
        internal Cities.NewDataSet cn;

        BasicHttpBinding binding = new BasicHttpBinding();
        EndpointAddress address = new EndpointAddress("http://www.webservicex.com/globalweather.asmx");

        public formWeather()
        {
            InitializeComponent();
            binding.MaxReceivedMessageSize = 2000000;

            GlobalWeatherSoapClient gwsc = new GlobalWeatherSoapClient(binding, address);

            var cities = gwsc.GetCitiesByCountry("");

            XmlSerializer result = new XmlSerializer(typeof(Cities.NewDataSet));
            cn = (Cities.NewDataSet)result.Deserialize(new StringReader(cities));

            var Countries = cn.Table.Select(x => x.Country).Distinct();
            comboBoxCountries.Items.AddRange(Countries.ToArray());
            var Cities = cn.Table.Select(x => x.City).Distinct();
            comboBoxCities.Items.AddRange(Cities.ToArray());
        }

        private void comboBoxCountries_SelectedIndexChanged(object sender, EventArgs e)
        {
            var rr = cn.Table.Where(m => m.Country == comboBoxCountries.Text).Select(x => x.City);

            comboBoxCities.Items.Clear();
            comboBoxCities.Items.AddRange(rr.ToArray());
        }

        private void comboBoxCities_SelectedIndexChanged(object sender, EventArgs e)
        {

            GlobalWeatherSoapClient gwsc = new GlobalWeatherSoapClient(binding, address);

            var weather = gwsc.GetWeather(comboBoxCities.Text, comboBoxCountries.Text);

            if(weather != "Data Not Found")
            {
                richTextBoxWeatherDetails.Clear();

               //Deserialize xml again but Web Service is no longer in use. No data found for all cities and countries.
            }
            else
            {
                richTextBoxWeatherDetails.Clear();
                richTextBoxWeatherDetails.Text = "Data Not Found";
            }
        }
    }
}
