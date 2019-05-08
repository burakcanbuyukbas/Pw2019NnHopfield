using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HopfieldAssociativeMemory
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            int vectorCount;
            int vectorSize;
            try
            {
                vectorCount = Int32.Parse(textBox1.Text);
                vectorSize = Int32.Parse(textBox2.Text);
                Form2 form2 = new Form2(vectorCount, vectorSize);
                form2.Show();

            }
            catch (Exception)
            {

                throw new Exception("Bad Input. Please check.");
            }





        }
    }
}
