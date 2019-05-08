using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HopfieldAssociativeMemory
{
    public partial class Form2 : Form
    {
        int vector, size;
        public Form2(int vectorCount, int vectorSize)
        {
            InitializeComponent();
            vector = vectorCount;
            size = vectorSize;
            #region switch
            switch (vectorCount)
            {
                case 1:
                    textBox1.Visible = true;
                    label1.Visible = true;
                    break;
                case 2:
                    textBox1.Visible = true;
                    textBox2.Visible = true;
                    label1.Visible = true;
                    label2.Visible = true;
                    break;
                case 3:
                    textBox1.Visible = true;
                    textBox2.Visible = true;
                    textBox3.Visible = true;
                    label1.Visible = true;
                    label2.Visible = true;
                    label3.Visible = true;
                    break;
                case 4:
                    textBox1.Visible = true;
                    textBox2.Visible = true;
                    textBox3.Visible = true;
                    textBox4.Visible = true;
                    label1.Visible = true;
                    label2.Visible = true;
                    label3.Visible = true;
                    label4.Visible = true;
                    break;
                case 5:
                    textBox1.Visible = true;
                    textBox2.Visible = true;
                    textBox3.Visible = true;
                    textBox4.Visible = true;
                    textBox5.Visible = true;
                    label1.Visible = true;
                    label2.Visible = true;
                    label3.Visible = true;
                    label4.Visible = true;
                    label5.Visible = true;
                    break;
                case 6:
                    textBox1.Visible = true;
                    textBox2.Visible = true;
                    textBox3.Visible = true;
                    textBox4.Visible = true;
                    textBox5.Visible = true;
                    textBox6.Visible = true;
                    label1.Visible = true;
                    label2.Visible = true;
                    label3.Visible = true;
                    label4.Visible = true;
                    label5.Visible = true;
                    label6.Visible = true;
                    break;
                case 7:
                    textBox1.Visible = true;
                    textBox2.Visible = true;
                    textBox3.Visible = true;
                    textBox4.Visible = true;
                    textBox5.Visible = true;
                    textBox6.Visible = true;
                    textBox7.Visible = true;
                    label1.Visible = true;
                    label2.Visible = true;
                    label3.Visible = true;
                    label4.Visible = true;
                    label5.Visible = true;
                    label6.Visible = true;
                    label7.Visible = true;
                    break;
                case 8:
                    textBox1.Visible = true;
                    textBox2.Visible = true;
                    textBox3.Visible = true;
                    textBox4.Visible = true;
                    textBox5.Visible = true;
                    textBox6.Visible = true;
                    textBox7.Visible = true;
                    textBox8.Visible = true;
                    label1.Visible = true;
                    label2.Visible = true;
                    label3.Visible = true;
                    label4.Visible = true;
                    label5.Visible = true;
                    label6.Visible = true;
                    label7.Visible = true;
                    label8.Visible = true;
                    break;
                case 9:
                    textBox1.Visible = true;
                    textBox2.Visible = true;
                    textBox3.Visible = true;
                    textBox4.Visible = true;
                    textBox5.Visible = true;
                    textBox6.Visible = true;
                    textBox7.Visible = true;
                    textBox8.Visible = true;
                    textBox9.Visible = true;
                    label1.Visible = true;
                    label2.Visible = true;
                    label3.Visible = true;
                    label4.Visible = true;
                    label5.Visible = true;
                    label6.Visible = true;
                    label7.Visible = true;
                    label8.Visible = true;
                    label9.Visible = true;
                    break;
                case 10:
                    textBox1.Visible = true;
                    textBox2.Visible = true;
                    textBox3.Visible = true;
                    textBox4.Visible = true;
                    textBox5.Visible = true;
                    textBox6.Visible = true;
                    textBox7.Visible = true;
                    textBox8.Visible = true;
                    textBox9.Visible = true;
                    textBox10.Visible = true;
                    label1.Visible = true;
                    label2.Visible = true;
                    label3.Visible = true;
                    label4.Visible = true;
                    label5.Visible = true;
                    label6.Visible = true;
                    label7.Visible = true;
                    label8.Visible = true;
                    label9.Visible = true;
                    label10.Visible = true;
                    break;
                default:
                    throw new Exception("Max vector count is 10.");
            }
            #endregion

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Text files | *.txt"; // only txt files allowed
            dialog.Multiselect = false; // no multi select


            List<int[]> vectorList = new List<int[]>();
            string line;
            int counter;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                String path = dialog.FileName;
                using (StreamReader reader = new StreamReader(new FileStream(path, FileMode.Open), new UTF8Encoding()))
                {
                    while ((line = reader.ReadLine()) != null)
                    {

                        int[] vector = Array.ConvertAll(line.Split(','), s => int.Parse(s));
                        vectorList.Add(vector);

                    }
                    reader.Close();


                    size = vectorList[0].Length;
                    vector = vectorList.Count;
                    int[,] matrix = new int[size, vector];
                    for(int i = 0; i < vectorList.Count; i++)
                    {
                        for(int j = 0; j < size; j++)
                        {
                            matrix[j, i] = vectorList[i][j];
                        }

                    }


                    int[,] weightMatrix = new int[size, size];
                    int sum;
                    for (int i = 0; i < size; i++)
                    {
                        for (int j = 0; j < size; j++)
                        {
                            if (i == j)
                            {
                                weightMatrix[i, j] = 0;
                            }
                            else
                            {
                                sum = 0;
                                for (int k = 0; k < vector; k++)
                                    sum += (matrix[i, k]) * (matrix[j, k]);
                                weightMatrix[i, j] = sum / vector;
                            }
                        }
                    }


                    Form3 form3 = new Form3(weightMatrix);
                    form3.Show();

                }
            }
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            int[] v1, v2, v3, v4, v5, v6, v7, v8, v9, v10;
            int[,] matrix = new int[size, vector];
            List<int[]> vectors = new List<int[]>();

            #region create vector arrays
            switch (vector)
            {
                case 1:
                    v1 = textBox1.Text.Split(',').Select(item => int.Parse(item)).ToArray();
                    vectors.Add(v1);
                    break;
                case 2:
                    v1 = textBox1.Text.Split(',').Select(item => int.Parse(item)).ToArray();
                    v2 = textBox2.Text.Split(',').Select(item => int.Parse(item)).ToArray();
                    for (int i = 0; i < size; i++)
                    {
                        matrix[i, 0] = v1[i];
                        matrix[i, 1] = v2[i];
                    }
                    vectors.Add(v1);
                    vectors.Add(v2);

                    break;
                case 3:
                    v1 = textBox1.Text.Split(',').Select(item => int.Parse(item)).ToArray();
                    v2 = textBox2.Text.Split(',').Select(item => int.Parse(item)).ToArray();
                    v3 = textBox3.Text.Split(',').Select(item => int.Parse(item)).ToArray();
                    for (int i = 0; i < size; i++)
                    {
                        matrix[i, 0] = v1[i];
                        matrix[i, 1] = v2[i];
                        matrix[i, 2] = v3[i];
                    }
                    vectors.Add(v1);
                    vectors.Add(v2);
                    vectors.Add(v3);
                    break;
                case 4:
                    v1 = textBox1.Text.Split(',').Select(item => int.Parse(item)).ToArray();
                    v2 = textBox2.Text.Split(',').Select(item => int.Parse(item)).ToArray();
                    v3 = textBox3.Text.Split(',').Select(item => int.Parse(item)).ToArray();
                    v4 = textBox4.Text.Split(',').Select(item => int.Parse(item)).ToArray();
                    for (int i = 0; i < size; i++)
                    {
                        matrix[i, 0] = v1[i];
                        matrix[i, 1] = v2[i];
                        matrix[i, 2] = v3[i];
                        matrix[i, 3] = v4[i];
                    }
                    vectors.Add(v1);
                    vectors.Add(v2);
                    vectors.Add(v3);
                    vectors.Add(v4);
                    break;
                case 5:
                    v1 = textBox1.Text.Split(',').Select(item => int.Parse(item)).ToArray();
                    v2 = textBox2.Text.Split(',').Select(item => int.Parse(item)).ToArray();
                    v3 = textBox3.Text.Split(',').Select(item => int.Parse(item)).ToArray();
                    v4 = textBox4.Text.Split(',').Select(item => int.Parse(item)).ToArray();
                    v5 = textBox5.Text.Split(',').Select(item => int.Parse(item)).ToArray();
                    for (int i = 0; i < size; i++)
                    {
                        matrix[i, 0] = v1[i];
                        matrix[i, 1] = v2[i];
                        matrix[i, 2] = v3[i];
                        matrix[i, 3] = v4[i];
                        matrix[i, 4] = v5[i];
                    }
                    vectors.Add(v1);
                    vectors.Add(v2);
                    vectors.Add(v3);
                    vectors.Add(v4);
                    vectors.Add(v5);
                    break;
                case 6:
                    v1 = textBox1.Text.Split(',').Select(item => int.Parse(item)).ToArray();
                    v2 = textBox2.Text.Split(',').Select(item => int.Parse(item)).ToArray();
                    v3 = textBox3.Text.Split(',').Select(item => int.Parse(item)).ToArray();
                    v4 = textBox4.Text.Split(',').Select(item => int.Parse(item)).ToArray();
                    v5 = textBox5.Text.Split(',').Select(item => int.Parse(item)).ToArray();
                    v6 = textBox6.Text.Split(',').Select(item => int.Parse(item)).ToArray();
                    for (int i = 0; i < size; i++)
                    {
                        matrix[i, 0] = v1[i];
                        matrix[i, 1] = v2[i];
                        matrix[i, 2] = v3[i];
                        matrix[i, 3] = v4[i];
                        matrix[i, 4] = v5[i];
                        matrix[i, 5] = v6[i];
                    }
                    vectors.Add(v1);
                    vectors.Add(v2);
                    vectors.Add(v3);
                    vectors.Add(v4);
                    vectors.Add(v5);
                    vectors.Add(v6);
                    break;
                case 7:
                    v1 = textBox1.Text.Split(',').Select(item => int.Parse(item)).ToArray();
                    v2 = textBox2.Text.Split(',').Select(item => int.Parse(item)).ToArray();
                    v3 = textBox3.Text.Split(',').Select(item => int.Parse(item)).ToArray();
                    v4 = textBox4.Text.Split(',').Select(item => int.Parse(item)).ToArray();
                    v5 = textBox5.Text.Split(',').Select(item => int.Parse(item)).ToArray();
                    v6 = textBox6.Text.Split(',').Select(item => int.Parse(item)).ToArray();
                    v7 = textBox7.Text.Split(',').Select(item => int.Parse(item)).ToArray();
                    for (int i = 0; i < size; i++)
                    {
                        matrix[i, 0] = v1[i];
                        matrix[i, 1] = v2[i];
                        matrix[i, 2] = v3[i];
                        matrix[i, 3] = v4[i];
                        matrix[i, 4] = v5[i];
                        matrix[i, 5] = v6[i];
                        matrix[i, 6] = v7[i];
                    }
                    vectors.Add(v1);
                    vectors.Add(v2);
                    vectors.Add(v3);
                    vectors.Add(v4);
                    vectors.Add(v5);
                    vectors.Add(v6);
                    vectors.Add(v7);
                    break;
                case 8:
                    v1 = textBox1.Text.Split(',').Select(item => int.Parse(item)).ToArray();
                    v2 = textBox2.Text.Split(',').Select(item => int.Parse(item)).ToArray();
                    v3 = textBox3.Text.Split(',').Select(item => int.Parse(item)).ToArray();
                    v4 = textBox4.Text.Split(',').Select(item => int.Parse(item)).ToArray();
                    v5 = textBox5.Text.Split(',').Select(item => int.Parse(item)).ToArray();
                    v6 = textBox6.Text.Split(',').Select(item => int.Parse(item)).ToArray();
                    v7 = textBox7.Text.Split(',').Select(item => int.Parse(item)).ToArray();
                    v8 = textBox8.Text.Split(',').Select(item => int.Parse(item)).ToArray();
                    for (int i = 0; i < size; i++)
                    {
                        matrix[i, 0] = v1[i];
                        matrix[i, 1] = v2[i];
                        matrix[i, 2] = v3[i];
                        matrix[i, 3] = v4[i];
                        matrix[i, 4] = v5[i];
                        matrix[i, 5] = v6[i];
                        matrix[i, 6] = v7[i];
                        matrix[i, 7] = v8[i];
                    }
                    vectors.Add(v1);
                    vectors.Add(v2);
                    vectors.Add(v3);
                    vectors.Add(v4);
                    vectors.Add(v5);
                    vectors.Add(v6);
                    vectors.Add(v7);
                    vectors.Add(v8);

                    break;
                case 9:
                    v1 = textBox1.Text.Split(',').Select(item => int.Parse(item)).ToArray();
                    v2 = textBox2.Text.Split(',').Select(item => int.Parse(item)).ToArray();
                    v3 = textBox3.Text.Split(',').Select(item => int.Parse(item)).ToArray();
                    v4 = textBox4.Text.Split(',').Select(item => int.Parse(item)).ToArray();
                    v5 = textBox5.Text.Split(',').Select(item => int.Parse(item)).ToArray();
                    v6 = textBox6.Text.Split(',').Select(item => int.Parse(item)).ToArray();
                    v7 = textBox7.Text.Split(',').Select(item => int.Parse(item)).ToArray();
                    v8 = textBox8.Text.Split(',').Select(item => int.Parse(item)).ToArray();
                    v9 = textBox9.Text.Split(',').Select(item => int.Parse(item)).ToArray();
                    for (int i = 0; i < size; i++)
                    {
                        matrix[i, 0] = v1[i];
                        matrix[i, 1] = v2[i];
                        matrix[i, 2] = v3[i];
                        matrix[i, 3] = v4[i];
                        matrix[i, 4] = v5[i];
                        matrix[i, 5] = v6[i];
                        matrix[i, 6] = v7[i];
                        matrix[i, 7] = v8[i];
                        matrix[i, 8] = v9[i];
                    }
                    vectors.Add(v1);
                    vectors.Add(v2);
                    vectors.Add(v3);
                    vectors.Add(v4);
                    vectors.Add(v5);
                    vectors.Add(v6);
                    vectors.Add(v7);
                    vectors.Add(v8);
                    vectors.Add(v9);
                    break;
                case 10:
                    v1 = textBox1.Text.Split(',').Select(item => int.Parse(item)).ToArray();
                    v2 = textBox2.Text.Split(',').Select(item => int.Parse(item)).ToArray();
                    v3 = textBox3.Text.Split(',').Select(item => int.Parse(item)).ToArray();
                    v4 = textBox4.Text.Split(',').Select(item => int.Parse(item)).ToArray();
                    v5 = textBox5.Text.Split(',').Select(item => int.Parse(item)).ToArray();
                    v6 = textBox6.Text.Split(',').Select(item => int.Parse(item)).ToArray();
                    v7 = textBox7.Text.Split(',').Select(item => int.Parse(item)).ToArray();
                    v8 = textBox8.Text.Split(',').Select(item => int.Parse(item)).ToArray();
                    v9 = textBox9.Text.Split(',').Select(item => int.Parse(item)).ToArray();
                    v10 = textBox10.Text.Split(',').Select(item => int.Parse(item)).ToArray();
                    for (int i = 0; i < size; i++)
                    {
                        matrix[i, 0] = v1[i];
                        matrix[i, 1] = v2[i];
                        matrix[i, 2] = v3[i];
                        matrix[i, 3] = v4[i];
                        matrix[i, 4] = v5[i];
                        matrix[i, 5] = v6[i];
                        matrix[i, 6] = v7[i];
                        matrix[i, 7] = v8[i];
                        matrix[i, 8] = v9[i];
                        matrix[i, 9] = v10[i];
                    }
                    vectors.Add(v1);
                    vectors.Add(v2);
                    vectors.Add(v3);
                    vectors.Add(v4);
                    vectors.Add(v5);
                    vectors.Add(v6);
                    vectors.Add(v7);
                    vectors.Add(v8);
                    vectors.Add(v9);
                    vectors.Add(v10);

                    break;
                default:
                    throw new Exception("Max vector count is 10.");
            }
            #endregion

            int[,] weightMatrix = new int[size, size];
            //int sum;
            //for (int i = 0; i < size; i++)
            //{
            //    for (int j = 0; j < size; j++)
            //    {
            //        if (i == j)
            //        {
            //            weightMatrix[i, j] = 0;
            //        }
            //        else
            //        {
            //            sum = 0;
            //            for (int k = 0; k < vector; k++)
            //                sum += (matrix[i, k]) * (matrix[j, k]);
            //            weightMatrix[i, j] = sum / vector;
            //        }
            //    }
            //}
            
            foreach (int[] vec in vectors)
            {
                if (vec == vectors[0])
                {
                    for (int i = 0; i < size; i++)
                    {
                        if (vec[i] == 1)
                        {
                            for (int j = 0; j < size; j++)
                            {
                                if (i==j)
                                {
                                    weightMatrix[j, i] = 0;
                                }
                                else
                                {
                                    weightMatrix[j, i] = vec[j];

                                }
                            }
                        }
                        else
                        {
                            for (int j = 0; j < size; j++)
                            {
                                weightMatrix[j, i] = -1 * vec[j];
                            }
                        }
                    }
                }

                else
                {
                    int[,] temp = new int[size, size];
                    for (int i = 0; i < size; i++)
                    {
                        if (vec[i] == 1)
                        {
                            for (int j = 0; j < size; j++)
                            {
                                temp[j, i] = vec[j];
                            }
                        }
                        else
                        {
                            for (int j = 0; j < size; j++)
                            {
                                temp[j, i] = -1 * vec[j];
                            }
                        }

                    }
                    for (int k = 0; k < size; k++)
                    {
                        for (int l = 0; l < size; l++)
                        {
                            weightMatrix[k,l] += temp[k,l];
                        }
                    }
                }

                for (int x = 0; x < size; x++)
                {
                    for (int y = 0; y < size; y++)
                    {
                        if (x == y)
                        {
                            weightMatrix[x, y] = 0;

                        }
                    }
                }

            }



            Form3 form3 = new Form3(weightMatrix);
            form3.Show();

        }
    }
}

