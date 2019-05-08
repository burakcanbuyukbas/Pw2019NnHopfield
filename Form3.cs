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
    public partial class Form3 : Form
    {
        int[,] _weightMatrix;
        public Form3(int[,] weightMatrix)
        {
            InitializeComponent();
            _weightMatrix = weightMatrix;
            int height = weightMatrix.GetLength(0);
            int width = weightMatrix.GetLength(1);

            this.dataGridView1.ColumnCount = width;

            for (int r = 0; r < height; r++)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(this.dataGridView1);

                for (int c = 0; c < width; c++)
                {
                    row.Cells[c].Value = weightMatrix[r, c];
                }

                this.dataGridView1.Rows.Add(row);
            }
            for (int i = 0; i < width; i++)
            {
                dataGridView1.Columns[i].Width = 20;

            }
        }

        private void testButton_Click(object sender, EventArgs e)
        {
            
            int[] testvec = textBox1.Text.Split(',').Select(item => int.Parse(item)).ToArray();
            int[] result = CheckStability(testvec, _weightMatrix);
            dataGridView2.Rows.Clear();
            dataGridView2.Refresh();

            int height = result.GetLength(0);

            this.dataGridView2.ColumnCount = 1;
            for (int r = 0; r < height; r++)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(this.dataGridView2);

                row.Cells[0].Value = result[r];
                this.dataGridView2.Rows.Add(row);
            }
            bool isStable = true;
            for (int i = 0; i < result.Length; i++)
            {
                if (testvec[i] != result[i])
                {
                    isStable = false;
                }
            }
            if (isStable)
            {
                textBox2.Text = "Stable";
            }
            else if (!isStable)
            {
                textBox2.Text = "Not Stable";
            }

        }



        public static int[] CheckStability(int[] testVector, int[,] weightMatrix)
        {
            int[] result = new int[testVector.Length];

            for (int i = 0; i < testVector.Length; i++)
            {
                int sum = 0;
                for (int j = 0; j < testVector.Length; j++)
                {
                    sum += weightMatrix[i, j] * testVector[j];
                }
                if (sum > 0)
                    result[i] = 1;
                else if(sum < 0)
                    result[i] = -1;
            }
            return result;

        }
    }
}
