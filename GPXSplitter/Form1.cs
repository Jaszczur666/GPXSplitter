using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using gpx;
namespace GPXSplitter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            System.Xml.Serialization.XmlSerializer reader =
                new System.Xml.Serialization.XmlSerializer(typeof(gpxType));
            System.IO.StreamReader file = new System.IO.StreamReader(@"d:\test.gpx");
            gpxType overview = new gpxType();
            overview = (gpxType)reader.Deserialize(file);
            file.Close();
            //Console.WriteLine(overview.trk.Length);
            for (int i = 0; i < overview.trk.Length; i++)
            {
                Console.WriteLine("Track number "+i.ToString());
                for (int j = 0; j < overview.trk[i].trkseg.Length; j++)
                {
                    Console.WriteLine("Segment number "+j.ToString());
                    for (int k = 1; k < overview.trk[i].trkseg[j].trkpt.Length; k++)
                    {
                        Console.Write(k.ToString()+" "+overview.trk[i].trkseg[j].trkpt[k].lat.ToString("G6")+" ");
                        Console.Write(overview.trk[i].trkseg[j].trkpt[k].lon.ToString("G6") + " ");
                        Console.Write(overview.trk[i].trkseg[j].trkpt[k].ele.ToString("G6") + " ");
                        Console.Write(overview.trk[i].trkseg[j].trkpt[k].time.ToString()+" ");
                        Console.WriteLine((overview.trk[i].trkseg[j].trkpt[k].time-overview.trk[i].trkseg[j].trkpt[k-1].time).Seconds + " ");
                    }
                }
            }
        }
    }
}
