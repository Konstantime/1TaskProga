﻿using BusinessLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class GistogramForm : Form
    {
        private Logic logic = new Logic();
        public GistogramForm( Logic logic )
        {
            this.logic = logic;
            InitializeComponent();
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
        //private void GistogramForm_Load(object sender, EventArgs e)
        //{
        //    FillGistogram();
        //    MessageBox.Show("Я родился");
        //}
        private void FillGistogram()
        {
            Dictionary<string, int> countEverySpeciality = logic.GetCountStudentsOfEverySpeciality();

            List<string> namesSpecialties = new List<string>();
            List<int> countsSpecialties = new List<int>();

            foreach ( var item in countEverySpeciality )
            {
                namesSpecialties.Add( item.Key );
                countsSpecialties.Add( item.Value );
            }

            // Настраиваем диаграмму
            chart1.ChartAreas[0].AxisX.Title = "Items";
            chart1.ChartAreas[0].AxisY.Title = "Values";
            chart1.ChartAreas[0].AxisX.Interval = 1;

            // Добавляем серию данных
            chart1.Series["Series1"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            chart1.Series["Series1"].Points.DataBindXY(namesSpecialties, countsSpecialties);
        }

        private void GistogramForm_Load_1(object sender, EventArgs e)
        {
            FillGistogram();
        }
    }
}
