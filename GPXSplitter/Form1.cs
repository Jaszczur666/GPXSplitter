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
            int numSeg = 0;
            List<int> segLengths = new List<int>();
            List<int> lengths = new List<int>();
            System.Xml.Serialization.XmlSerializer reader =
            new System.Xml.Serialization.XmlSerializer(typeof(gpxType));
            System.IO.StreamReader file = new System.IO.StreamReader(@Pathin.Text);
            gpxType overview = new gpxType();
            gpxType gpxout = new gpxType();
            overview = (gpxType)reader.Deserialize(file);
            file.Close();
            numSeg = overview.trk[0].trkseg.Length;
            Console.WriteLine("Found " + numSeg + " jump(s) at position(s)");
            for (int i = 0; i < numSeg; i++)
            {
                segLengths.Add(overview.trk[0].trkseg[i].trkpt.Length);
                Console.WriteLine(i + " " + segLengths[i]);
            }
            if (gpxout.trk == null) gpxout.trk = new trkType[numSeg];
            for (int i = 0; i < numSeg; i++)
            {
                if (gpxout.trk[i] == null) gpxout.trk[i] = new trkType();
                if (gpxout.trk[i].trkseg == null) gpxout.trk[i].trkseg = new trksegType[1];
                if (gpxout.trk[i].trkseg[0] == null) gpxout.trk[i].trkseg[0] = new trksegType();
                if (gpxout.trk[i].trkseg[0].trkpt == null) gpxout.trk[i].trkseg[0].trkpt = new wptType[segLengths[i]];
                Console.WriteLine(gpxout.trk[i].trkseg[0].trkpt.Length);
                for (int j = 0; j < segLengths[i]; j++)
                {
                    if (gpxout.trk[i].trkseg[0].trkpt[j] == null) gpxout.trk[i].trkseg[0].trkpt[j] = new wptType();
                    //Console.WriteLine(i+" "+j);
                    gpxout.trk[i].trkseg[0].trkpt[j] = overview.trk[0].trkseg[i].trkpt[j];
                }
            }
            System.IO.TextWriter writer = new System.IO.StreamWriter(@Pathout.Text);
            reader.Serialize(writer, gpxout);
            writer.Close();
        }

        private void loadinbutton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                foreach (String file in openFileDialog1.FileNames)
                {
                    Pathin.Text = @file;
                    Pathout.Text = Pathin.Text.Replace(".gpx", "v2.gpx");
                    button1_Click(sender, e);
                }
            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void Pathin_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
