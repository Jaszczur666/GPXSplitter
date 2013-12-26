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
            int jumps = 0;
            List<int> jumppos = new List<int>();
            List<int> lengths = new List<int>();
            System.Xml.Serialization.XmlSerializer reader =
            new System.Xml.Serialization.XmlSerializer(typeof(gpxType));
            System.IO.StreamReader file = new System.IO.StreamReader(@Pathin.Text);
            gpxType overview = new gpxType();
            gpxType gpxout = new gpxType();
            overview = (gpxType)reader.Deserialize(file);
            file.Close();
            jumppos.Add(0);
            //gpxout;
            //Console.WriteLine(overview.trk.Length);
            //if (gpxout.trk==null) gpxout.trk=new trkType[1];
            //if (gpxout.trk[0] == null) gpxout.trk[0]=new trkType();
            //Console.WriteLine(gpxout.trk.Length);
            //if (gpxout.trk[0].trkseg==null) gpxout.trk[0].trkseg = new trksegType[1];
            //if (gpxout.trk[0].trkseg[0] == null) gpxout.trk[0].trkseg[0] = new trksegType();
            //if (gpxout.trk[0].trkseg[0].trkpt == null) gpxout.trk[0].trkseg[0].trkpt = new wptType[1];
            //if (gpxout.trk[0].trkseg[0].trkpt[0] == null) gpxout.trk[0].trkseg[0].trkpt[0] = new wptType();
            for (int i = 0; i < overview.trk.Length; i++)
            {
                Console.WriteLine("Track number " + i.ToString());
                for (int j = 0; j < overview.trk[i].trkseg.Length; j++)
                {
                    Console.WriteLine("Segment number " + j.ToString());
                    for (int k = 1; k < overview.trk[i].trkseg[j].trkpt.Length; k++)
                    {
                        double timediff = (overview.trk[i].trkseg[j].trkpt[k].time - overview.trk[i].trkseg[j].trkpt[k - 1].time).TotalMinutes;
                        //          Console.WriteLine(timediff);
                        if (timediff > 60)
                        {
                            jumps++;
                            jumppos.Add(k);
                            Console.Write(k.ToString() + " " + overview.trk[i].trkseg[j].trkpt[k].lat.ToString("G6") + " ");
                            Console.Write(overview.trk[i].trkseg[j].trkpt[k].lon.ToString("G6") + " ");
                            Console.Write(overview.trk[i].trkseg[j].trkpt[k].ele.ToString("G6") + " ");
                            Console.Write(overview.trk[i].trkseg[j].trkpt[k].time.ToString() + " ");
                            Console.WriteLine(timediff.ToString("G5") + " ");
                        }
                    }
                }
            }
            Console.WriteLine("Found " + jumps + " jump(s) at position(s)");
            for (int i = 0; i <= jumps; i++)
            {
                Console.WriteLine(i + " " + jumppos[i]);
            }
            Console.WriteLine("0 0 added for easier handling");
            if (jumps > 0) lengths.Add(jumppos[1]);
            if (jumps >= 1)
            {
                for (int i = 1; i < jumps - 1; i++)
                {
                    lengths.Add(jumppos[i] - jumppos[i - 1]);
                }
                lengths.Add(overview.trk[0].trkseg[0].trkpt.Length - jumppos[jumps]);
            }
            if (gpxout.trk == null) gpxout.trk = new trkType[jumps + 1];
            for (int i = 0; i <= jumps; i++)
            {
                if (gpxout.trk[i] == null) gpxout.trk[i] = new trkType();
                if (gpxout.trk[i].trkseg == null) gpxout.trk[i].trkseg = new trksegType[1];
                if (gpxout.trk[i].trkseg[0] == null) gpxout.trk[i].trkseg[0] = new trksegType();
                if (gpxout.trk[i].trkseg[0].trkpt == null) gpxout.trk[i].trkseg[0].trkpt = new wptType[lengths[i]];
                Console.WriteLine(gpxout.trk[i].trkseg[0].trkpt.Length);
                for (int j = 0; j < lengths[i]; j++)
                {
                    if (gpxout.trk[i].trkseg[0].trkpt[j] == null) gpxout.trk[i].trkseg[0].trkpt[j] = new wptType();
                    //Console.WriteLine(i+" "+j);
                    gpxout.trk[i].trkseg[0].trkpt[j] = overview.trk[0].trkseg[0].trkpt[j + jumppos[i]];
                }
            }
            System.IO.TextWriter writer = new System.IO.StreamWriter(@Pathout.Text);
            reader.Serialize(writer, gpxout);
            writer.Close();
        }

        private void loadinbutton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                Pathin.Text = @openFileDialog1.FileName;
                Pathout.Text = Pathin.Text.Replace(".gpx","v2.gpx");
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
