using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Presentation.Forms
{
    public partial class OrderFilter : Form
    {
        #region Properties
        private bool filling = false, filling2 = false, filling3 = false, filling4 = false;
        private static Dictionary<int, string> years;
        private Filters filters;
        #endregion

        #region Constructors
        public OrderFilter(ref Filters filters)
        {
            InitializeComponent();
            filling3 = true;
            FillCombos();
            filling3 = false;
            this.filters = filters;

            orderByCmb.SelectedIndex = filters.OrderBy;
            orderToCmb.SelectedIndex = filters.OrderTo;
            dateFilterCmb.SelectedIndex = filters.DateFilter;
            yearCmb.SelectedIndex = filters.YearIndex;
            monthCmb.SelectedIndex = filters.Month;
            dayCmb.SelectedIndex = filters.Day;
            searchByCmb.SelectedIndex = filters.SearchBy;

        }
        #endregion

        #region Functional Methods
        private void FillCombos()
        {
            Dictionary<int, string> fields = new Dictionary<int, string>();
            fields.Add(0, "Fecha de orden");
            fields.Add(1, "Fecha de entrega");
            fields.Add(2, "Cliente");
            fields.Add(3, "Costo");
            Dictionary<int, string> fields2 = new Dictionary<int, string>();
            fields2.Add(0, "Fecha de orden");
            fields2.Add(1, "Fecha de entrega");
            fields2.Add(2, "Cliente");
            fields2.Add(3, "Costo");
            Dictionary<int, string> fields3 = new Dictionary<int, string>();
            fields3.Add(0, "Fecha de orden");
            fields3.Add(1, "Fecha de entrega");
            Dictionary<int, string> fields4 = new Dictionary<int, string>();
            fields4.Add(0, "Orden ascendente");
            fields4.Add(1, "Orden descendente");
            orderByCmb.DataSource = searchByCmb.DataSource =
                dateFilterCmb.DataSource = null;
            orderByCmb.DataSource = new BindingSource(fields, null);
            searchByCmb.DataSource = new BindingSource(fields2, null);
            dateFilterCmb.DataSource = new BindingSource(fields3, null);
            orderToCmb.DataSource = new BindingSource(fields4, null);
            orderByCmb.ValueMember = searchByCmb.ValueMember = 
                dateFilterCmb.ValueMember = orderToCmb.ValueMember = "Key";
            orderByCmb.DisplayMember = searchByCmb.DisplayMember = 
                dateFilterCmb.DisplayMember = orderToCmb.DisplayMember = "Value";

            FillYears();

            Dictionary<int, string> months = new Dictionary<int, string>();
            months.Add(0, "Ninguno");
            months.Add(1, "Enero");
            months.Add(2, "Febrero");
            months.Add(3, "Marzo");
            months.Add(4, "Abril");
            months.Add(5, "Mayo");
            months.Add(6, "Junio");
            months.Add(7, "Julio");
            months.Add(8, "Agosto");
            months.Add(9, "Septiembre");
            months.Add(10, "Octubre");
            months.Add(11, "Noviembre");
            months.Add(12, "Diciembre");

            filling = true;
            monthCmb.DataSource = null;
            monthCmb.DataSource = new BindingSource(months, null);
            monthCmb.ValueMember = "Key";
            monthCmb.DisplayMember = "Value";
            filling = false;

            FillDays();
        }
        private void FillYears()
        {
            filling2 = true;
            years = new Dictionary<int, string>();
            years.Add(0, "Ninguno");
            int year = DateTime.Now.Year;
            for (int i = 1; i <= 10; i++)
            {
                years.Add(i, year.ToString());
                year -= 1;
            }
            yearCmb.DataSource = null;
            yearCmb.DataSource = new BindingSource(years, null);
            yearCmb.ValueMember = "Key";
            yearCmb.DisplayMember = "Value";
            filling2 = false;
        }
        private void FillDays()
        {
            if (!filling && !filling2)
            {
                filling4 = true;
                Dictionary<int, string> days = new Dictionary<int, string>();
                int length = 31;
                string yearValue = ((KeyValuePair<int, string>)yearCmb.SelectedItem).Value;
                int monthValue = ((KeyValuePair<int, string>)monthCmb.SelectedItem).Key;
                days.Add(0, "Ninguno");
                if (monthValue != 0)
                {
                    switch (monthValue)
                    {
                        case 2:
                            length = 29;
                            if (yearValue != "Ninguno")
                                if (!DateTime.IsLeapYear(Convert.ToInt32(yearValue)))
                                    length = 28;
                            break;
                        case 4:
                        case 6:
                        case 9:
                        case 11:
                            length = 30;
                            break;
                    }
                }
                for (int i = 1; i <= length; i++)
                    days.Add(i, i.ToString());
                dayCmb.DataSource = null;
                dayCmb.DataSource = new BindingSource(days, null);
                dayCmb.ValueMember = "Key";
                dayCmb.DisplayMember = "Value";
                filling4 = false;
            }
        }
        #endregion

        #region Event Methods
        private void todayLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            yearCmb.SelectedIndex = 1;
            monthCmb.SelectedIndex = DateTime.Now.Month;
            dayCmb.SelectedIndex = DateTime.Now.Day;
        }
        private void orderByCmb_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!filling3)
                filters.OrderBy = ((KeyValuePair<int, string>)((ComboBox)sender).SelectedItem).Key;
        }
        private void orderToCmb_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!filling3)
                filters.OrderTo = ((KeyValuePair<int, string>)((ComboBox)sender).SelectedItem).Key;
        }
        private void dateFilterCmb_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!filling3)
                filters.DateFilter = ((KeyValuePair<int, string>)((ComboBox)sender).SelectedItem).Key;
        }
        private void dayCmb_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!filling4)
                filters.Day = ((KeyValuePair<int, string>)((ComboBox)sender).SelectedItem).Key;
        }
        private void monthCmb_SelectedValueChanged(object sender, EventArgs e)
        {
            FillDays();
            if (!filling3)
                filters.Month = ((KeyValuePair<int, string>)((ComboBox)sender).SelectedItem).Key;
        }
        private void yearCmb_SelectedValueChanged(object sender, EventArgs e)
        {
            FillDays();
            if (!filling3)
            {
                filters.YearIndex = ((KeyValuePair<int, string>)((ComboBox)sender).SelectedItem).Key;
                filters.Year = ((KeyValuePair<int, string>)((ComboBox)sender).SelectedItem).Value;
            }
        }
        private void searchByCmb_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!filling3)
                filters.SearchBy = ((KeyValuePair<int, string>)((ComboBox)sender).SelectedItem).Key;
        }
        #endregion
    }
}
