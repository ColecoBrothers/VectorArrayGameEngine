using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Vector_Point_Array
{
    public partial class Form3 : Form
    {
        // Example Sound check form
        // Winforms doesnt have any formal sound support.
        // it cannot play multiple sounds at once. 
        // It references the WIndows Media play to play sound ecffecst files. 
        // Files are packaged as resources and written tothe hadrd drive at runtime
        // Media player will play multiple files, but may not be installed
        // 

        public Form3()
        {
            InitializeComponent();
        }
        
        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            // delete the files when exiting
            // TODO get all waves files from the folder and delete reguardless of filename
            // or use a "snd" subfolder and just delete the folder

            if (System.IO.File.Exists(Application.StartupPath + @"\chord.wav"))
            {
                System.IO.File.Delete(Application.StartupPath + @"\chord.wav");
            }

            if (System.IO.File.Exists(Application.StartupPath + @"\tada.wav"))
            {
                System.IO.File.Delete(Application.StartupPath + @"\tada.wav");
            }

        }

        private void Form4_Load(object sender, EventArgs e)
        {
            //extract sounds form a resource file  and save to the executables folder

            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
  
            using (System.IO.Stream input = Properties.Resources.tada)
            using (System.IO.Stream output = System.IO.File.Create(Application.StartupPath + @"\tada.wav"))
            {
                // Insert null checking here for production
                byte[] buffer = new byte[8192];

                int bytesRead;
                while ((bytesRead = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    output.Write(buffer, 0, bytesRead);
                }
            }


            using (System.IO.Stream input = Properties.Resources.chord)
            using (System.IO.Stream output = System.IO.File.Create(Application.StartupPath + @"\chord.wav"))
            {
                // Insert null checking here for production
                byte[] buffer = new byte[8192];

                int bytesRead;
                while ((bytesRead = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    output.Write(buffer, 0, bytesRead);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // media player plays multiple sounds at the same time
            // play sounds directly from a File
            // Windows media default sounds for testing

            var p1 = new System.Windows.Media.MediaPlayer();
            p1.Open(new System.Uri(@"C:\windows\media\ring09.wav"));
            p1.Play();

            // this sleep is here just so you can distinguish the two sounds playing simultaneously
            System.Threading.Thread.Sleep(300);

            var p2 = new System.Windows.Media.MediaPlayer();
            p2.Open(new System.Uri(@"C:\windows\media\ring08.wav"));
            p2.Play();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // media player plays multiple sounds at the same time
            // play sounds directly from a File in the exe folder
            // these Sounds are extracted from a resources file at startup

            var p1 = new System.Windows.Media.MediaPlayer();
            p1.Open(new System.Uri(Application.StartupPath + @"\chord.wav"));
            p1.Play();
   
            var p2 = new System.Windows.Media.MediaPlayer();
            p2.Open(new System.Uri(Application.StartupPath + @"\tada.wav"));
            p2.Play();

        }
  
    } //class
}//namespace
