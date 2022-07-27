using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace WeatherFormsApp1
{
    public partial class Form1 : Form
    {
        string weather_forecast_link = "https://www.mgm.gov.tr/FTPDATA/analiz/sonSOA.xml";
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            XmlDocument doc1 = new XmlDocument();
            doc1.Load(weather_forecast_link);
            XmlElement root = doc1.DocumentElement; //Main Body root element
            XmlNodeList nodes = root.SelectNodes("sehirler");

            foreach (XmlNode node in nodes)
            {
                string ili = node["ili"].InnerText;
                string Durum = node["Durum"].InnerText;
                string maks_sicaklik = node["Mak"].InnerText;
                string bolge = node["Bolge"].InnerText;

                DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
                row.Cells[0].Value = ili;
                row.Cells[1].Value = Durum;
                row.Cells[2].Value = maks_sicaklik;
                row.Cells[3].Value = bolge;
                dataGridView1.Rows.Add(row);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            foreach (DataGridViewRow secili_satir in dataGridView1.Rows)
            {
                if (Convert.ToInt32(secili_satir.Cells[2].Value) > 35)
                {
                    secili_satir.DefaultCellStyle.BackColor = Color.Red;
                }
            }
        }
    }
}
