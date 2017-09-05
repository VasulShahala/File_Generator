using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;

namespace File_Generator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            saveFileDialog1.DefaultExt = "txt";
            saveFileDialog1.Filter = "Text files(*.txt)|*.txt|"
                + "Rich tex format(*.rtf)|*.rtf|"
                + "MS WORD(*.doc)|*.doc|All files(*.*)|*.*";
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < Convert.ToInt32(textBox1.Text); i++)
            {
                try
                {
                    if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = saveFileDialog1.FileName;
                System.IO.FileInfo file = new System.IO.FileInfo(filename);
                try
                {
                    using (FileStream fs = File.Create(filename, Convert.ToInt32(textBox2.Text)))
                    {
                    Byte[] info = new UTF8Encoding(true).GetBytes("This is some text in the file.This is some text in the file.This is some text in the file.");

                            double maxcount = ( Convert.ToInt32(textBox2.Text)/(Marshal.SizeOf(info.GetType().GetElementType()) * info.Length));

                            int mc =Convert.ToInt32( Math.Floor(maxcount));
                            for (int k = 0; k < mc; k++)
                            {
                                    fs.Write(info, 0, info.Length);
                            }
                            
                    
                    
                    }
                }

                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
           
            MessageBox.Show("Files was saved");
        }


    }
}
           


