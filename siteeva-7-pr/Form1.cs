using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace siteeva_7_pr
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
    }
    int[,] mas = new int[4, 4];
    int LIM = 4;
    //В строке матрицы с максимальным элементом  обнулить все элементы, кроме максимального.
    // матрица из четных строк и нечетных столбцов исходной матрицы и найти определитель
    private void button1_Click(object sender, EventArgs e)
    {
      int[] max_index = new int[LIM];
      max_index[0] = 0;
      int max_elem = mas[0, 0];
      for (int i = 1; i < LIM; i++)
        for (int j = 0; j < LIM; j++)
          if (max_elem < mas[i,j])
          {
            max_elem = mas[i, j];
            max_index[0] = i;
          }

      int k = 1;
      for (int i = max_index[0] + 1; i< LIM; i++)
        for (int j = 0; j < LIM; j++)
          if (max_elem == mas[i, j]) max_index[k++] = i;

      for (int key = 0; key < k; key++)
        for (int j = 0; j < LIM; j++)
          if (mas[max_index[key],j] != max_elem)
          {
            dataGridView1.Rows[max_index[key]].Cells[j].Value = '0';
          }
    }

    private void button2_Click(object sender, EventArgs e)
    {
      dataGridView1.RowCount = LIM;
      dataGridView1.ColumnCount = LIM;

      Random rand = new Random();
      for (int i = 0; i < LIM; i++)
        for (int j = 0; j < LIM; j++)
        {
          mas[i, j] = rand.Next(-50, 50);
          dataGridView1.Rows[i].Cells[j].Value = Convert.ToString(mas[i, j]);
        }
    }
    public int[,] less_mat(int[,] mat, int size, int ik, int jk)
    {
      int[,] new_mat = new int[size - 1, size - 1];
      int k = 0;
      int l = 0;
      for (int i = 0; i < size; i++)
      {
        for (int j = 0; j < size; j++)
        {
          if ((i != ik) && (j != jk))
          {
            new_mat[k, l] = mat[i, j];
            l++;
          }
        }
        if (i != ik) k++;
      }
        
      return new_mat;
    }
    public int deter(int[,] mat, int size)
    {
      if (size == 2)
      {
        return mat[0, 0] * mat[1, 1] - mat[1, 0] * mat[0, 1];
      }
      else
      {
        int det = 0;
        for (int i = 0; i < size; i++)
          if (i % 2 == 1)
          {
            det -= mat[0, i] * deter(less_mat(mat, size, 0, i), size - 1);
          }
          else
          {
            det += mat[0, i] * deter(less_mat(mat, size, 0, i), size - 1);
          }
        return det;
      }
      
    }

    private void gen_table2_Click(object sender, EventArgs e)
    {
      int[,] new_mas = new int[LIM / 2, LIM / 2];
      table2.RowCount = LIM/2;
      table2.ColumnCount = LIM/2;

      int k = 0;
      int l = 0;
      for (int i = 0; i < LIM/2; i ++)
      {
        for (int j = 0; j < LIM/2; j ++)
        {
          new_mas[i, j] = mas[i*2+1, j*2];
          table2.Rows[i].Cells[j].Value = Convert.ToString(new_mas[i, j]);
          l++;
        }
        k++;
      }
      textBox1.Text = "определитель матрицы равен = " + Convert.ToString(deter(new_mas,LIM/2));
    }
  }
}
