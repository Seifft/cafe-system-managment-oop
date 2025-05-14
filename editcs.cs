using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cafe_system_managment
{
    internal class edit
    {
        public static void Editdgvfare(DataGridView dgvfare, TextBox txtname, TextBox txtprice, TextBox txtquantity)
        {
            /*if (dgvfare.SelectedRows.Count > 0)
            {
                int selectedIndex = dgvfare.SelectedRows[0].Index;
                dgvfare.Rows[selectedIndex].Cells[0].Value = txtname.Text;
                dgvfare.Rows[selectedIndex].Cells[1].Value = Convert.ToDecimal(txtprice.Text);
                dgvfare.Rows[selectedIndex].Cells[2].Value = Convert.ToInt32(txtquantity.Text);
            }*/
            string name = txtname.Text;

            decimal price = decimal.Parse(txtprice.Text);

            int quantity = int.Parse(txtquantity.Text);


            product2 newItem = new product2(name, price, quantity);
            dgvfare.CurrentRow.Cells[0].Value = newItem.name;
            dgvfare.CurrentRow.Cells[1].Value = newItem.price;
            dgvfare.CurrentRow.Cells[2].Value = newItem.quantity;

        }
        public static void editcombobox(List<product2> productlist, TextBox txtname, TextBox txtprice, TextBox txtquantity, ComboBox cbxproduct, BindingSource bs, TextBox txtinvoiceprice, string searchname)
        {
            // string searchName = searchvalue;

            product2 newItem = new product2(txtname.Text, decimal.Parse(txtprice.Text), int.Parse(txtquantity.Text));
            var foundItem = productlist.FirstOrDefault(item => item.name == searchname);

            if (foundItem != null)
            {
                cbxproduct.SelectedItem = foundItem;
            }
            else { MessageBox.Show("item not found"); return; }

            int selectedIndex = cbxproduct.SelectedIndex;
            if (selectedIndex >= 0)
            {

                productlist[selectedIndex] = newItem;

                bs.DataSource = productlist;
                cbxproduct.DataSource = bs;
                cbxproduct.DisplayMember = "name";
                cbxproduct.ValueMember = "price";
                bs.ResetBindings(false);


                // cbxproduct.SelectedIndex = selectedIndex;
                txtinvoiceprice.Clear();
            }
        }
        public static void EditLineInFile(string filename, string searchname, string newName, string newPrice, string newQuantity, TextBox txtname)
        {
            txtname.Focus();
            string[] lines = File.ReadAllLines(filename);
            for (int i = 0; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(';');
                if (parts.Length >= 3 && parts[0] == searchname)
                {
                    
                    parts[0] = newName;
                    parts[1] = newPrice;
                    parts[2] = newQuantity;
                    lines[i] = string.Join(";", parts);
                    break;
                }
            }
            File.WriteAllLines(filename, lines);
        }
        /*public static bool EditLineInFile(string filename, string searchName, string newName, string newPrice, string newQuantity)
        {
            bool recordFound = false;

            try
            {
                // قراءة جميع السطور من الملف
                List<string> lines = File.ReadAllLines(filename).ToList();

                // البحث عن السطر المطلوب
                for (int i = 0; i < lines.Count; i++)
                {
                    // تجاهل السطور الفارغة
                    if (string.IsNullOrWhiteSpace(lines[i]))
                        continue;

                    string[] parts = lines[i].Split(';');

                    // التأكد من أن السطر يحتوي على البيانات المطلوبة
                    if (parts.Length >= 3)
                    {
                        // مقارنة الاسم بعد إزالة المسافات الزائدة من البداية والنهاية
                        if (parts[0].Trim().Equals(searchName.Trim(), StringComparison.OrdinalIgnoreCase))
                        {
                            // تعديل البيانات
                            parts[0] = newName.Trim();
                            parts[1] = newPrice.Trim();
                            parts[2] = newQuantity.Trim();

                            // إعادة تجميع السطر
                            lines[i] = string.Join(";", parts);
                            recordFound = true;
                            break;
                        }
                    }
                }

                // كتابة البيانات المحدثة للملف فقط إذا تم العثور على السجل
                if (recordFound)
                {
                    File.WriteAllLines(filename, lines);
                }

                return recordFound;
            }
            catch (Exception ex)
            {
                // معالجة الأخطاء
                MessageBox.Show("حدث خطأ أثناء تعديل البيانات: " + ex.Message, "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }*/


    }
}

