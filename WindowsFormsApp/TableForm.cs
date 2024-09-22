using BusinessLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class TableForm : Form
    {
        private Logic logic = new Logic();
        public TableForm( Logic logic )
        {
            this.logic = logic;
            InitializeComponent();
        }

        private void TableForm_Load(object sender, EventArgs e)
        {
            FillTable();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void FillTable()
        {
            dataGridView1.DataSource = ToDataTable( logic.GetAllStudentsFormatArrayOfArrays() );
        }

        private DataTable ToDataTable(string[][] data)
        {
            DataTable result = new DataTable();
            string[] namesColumns = new string[] { "Индекс", "Имя", "Специальность", "Группа" };

            result.Columns.Add($"Column{0}");
            result.Columns[0].ColumnName = namesColumns[0];

            // Добавляем столбцы
            for (int i = 0; i < data[1].Length; i++)
            {
                result.Columns.Add($"Column{i + 1}");
                result.Columns[i].ColumnName = namesColumns[i];
            }

            int count = 0;
            for (int i = 0; i < data.Length; i++)
            {
                DataRow row = result.NewRow();
                row[0] = count;
                count++;
                for (int j = 1; j < data[1].Length + 1; j++) {
                    row[j] = data[i][j-1];
                }

                result.Rows.Add(row);
            }

            return result;
        }
    }
}
