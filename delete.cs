﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cafe_system_managment
{
    public class delete
    {
        public static void DeleteFromDgvfare(DataGridView dgvfare)
        {

            dgvfare.Rows.RemoveAt(dgvfare.CurrentRow.Index);
        }


        public static void DeleteFromcombobox(List<product2> productlist, ComboBox cbxproduct, BindingSource bs, string searchname, TextBox txtname, TextBox txtprice, TextBox txtquantity, TextBox txtinvoiceprice)
        {
            // string searchName = searchvalue;
            var foundItem = productlist.FirstOrDefault(item => item.name == searchname);
            if (foundItem != null)
            {
                cbxproduct.SelectedItem = foundItem;
            }
            else { MessageBox.Show("item not found"); return; }
            int selectedIndex = cbxproduct.SelectedIndex;
            if (selectedIndex >= 0)
            {

                productlist.RemoveAt(selectedIndex);
                bs.DataSource = productlist;
                cbxproduct.DataSource = bs;
                bs.ResetBindings(false);

                txtinvoiceprice.Clear();


                delete.deletetalltextboxpagemanagment(txtname, txtprice, txtquantity);

            }
        }
        public static void deletetalltextboxpagemanagment(TextBox txtname, TextBox txtprice, TextBox txtquantity)
        {
            txtname.Clear();
            txtprice.Clear();
            txtquantity.Clear();

        }
        public static void deletetrow(TextBox txtinvoiceprice, TextBox txtinvoicequantity, DataGridView dgvproduct,TextBox txtoverall)
        {
            foreach (DataGridViewRow row in dgvproduct.Rows)
            {

                dgvproduct.Rows.RemoveAt(row.Index);

            }
            txtinvoiceprice.Clear();
            txtinvoicequantity.Clear();
            txtoverall.Clear();
        }
        public static void deletetallpageinvoice(DataGridView dgvproduct, TextBox txtinvoiceprice,TextBox txtinvoicequantity,TextBox txtcustomername)
        {
            for (int i = dgvproduct.Rows.Count - 1; i >= 0; i--)
            {


                dgvproduct.Rows.RemoveAt(i);

            }


            dgvproduct.Rows.Clear();
            txtinvoiceprice.Clear();
            txtinvoicequantity.Clear();
            txtcustomername.Clear();


        }
        public static void DeleteLineFromFile(string filename, string searchname,TextBox txtname)
        {
            List<string> lines = File.ReadAllLines(filename).ToList();

            for (int i = 0; i < lines.Count; i++)
            {
                string[] parts = lines[i].Split(';');
                if (parts.Length >= 3 && parts[0] == searchname)
                {
                    lines.RemoveAt(i);
                    break;
                }
            }
           
            

            File.WriteAllLines(filename, lines);
        }

    }
}
    

