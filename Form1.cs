using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Runtime.ExceptionServices;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;
using System.IO;
using System.Text.Json;
using System.Linq.Expressions;
namespace cafe_system_managment
{
    public partial class Form1 : Form
    {


        public product2 newItem { get; set; }

        List<product2> productlist = new List<product2>();

        BindingSource bs = new BindingSource();

        StreamWriter sr = new StreamWriter("ttt.txt", true);
        string searchname2;
        int ordernumber;








        private void SaveData(List<product2> products)
        {
            string json = JsonSerializer.Serialize(products);
            File.WriteAllText("data.json", json);
        }
        private List<product2> LoadData()
        {
            if (File.Exists("data.json"))
            {
                string json = File.ReadAllText("data.json");
                return JsonSerializer.Deserialize<List<product2>>(json);
            }
            return new List<product2>();
        }



        public Form1()
        {
            InitializeComponent();
            newItem = null;


        }


        int fristquantity;
        int secondquantity;
        int addquantity;
        string searchname;
        decimal grandTotal;
        Cusomertype Type;


        private void butadd_Click(object sender, EventArgs e)
        {

            sr.Close();

            //edit add

            try
            {
                if (Erorchecker.eror(txtname, txtprice, txtquantity) == true)
                {

                    return;
                }


                if (Erorchecker.erorsamename(dgvfare, txtname, sr) == true) { return; }


                Addd.AddTocombobox(productlist, txtname, txtprice, txtquantity, cbxproduct, bs, txtinvoiceprice);
                Addd.AddToDgvfare(dgvfare, txtname, txtprice, txtquantity, productlist, bs);
                Addd.Addtostreamraider(sr, txtname, txtprice, txtquantity);






                sr.Close();

                /* StreamWriter sr = new StreamWriter("ttt.txt", true);
                 string strname = txtname.Text;
                 string strprice = txtprice.Text;
                 string strquantity = txtquantity.Text;
                 sr.WriteLine(strname + ";" + strprice + ";" + strquantity);
                 sr.Close();*/

                //  productlist.Add(newItem);
                // bs.DataSource = productlist;
                // cbxproduct.DataSource = bs;
                // cbxproduct.DisplayMember = "name";
                // cbxproduct.ValueMember = "price";
                // cbxproduct.DataSource = new BindingSource(productlist, null);




            }

            catch (Exception ex) { MessageBox.Show(ex.Message); }

            txtname.Clear();
            txtprice.Clear();
            txtquantity.Clear();
            txtname.Focus();







        }







        private void Form1_Load(object sender, EventArgs e)
        {
            txtdate.Text = DateTime.Now.ToString("yyyy/MM/dd");
            txtname.Focus();
            txtname.Select();
            txtname.SelectAll();




            // تغيير عناوين الأعمدة بعد ربط المصدر

            sr.Close();
            StreamReader srchker = new StreamReader("ttt.txt");
            Addd.AddToDgvfarefromstream(srchker, sr, dgvfare, txtname, txtprice, txtquantity);
            srchker.Close();





            productlist = LoadData(); // خزنتها في ليست عامة



            // عرض أسماء المنتجات في ComboBox
            cbxproduct.DataSource = productlist;
            cbxproduct.DisplayMember = "Name";
            cbxproduct.ValueMember = "Price";
            txtinvoiceprice.Clear();
            txtordernumber.Text = "1";
            delete.deletetalltextboxpagemanagment(txtname, txtprice, txtquantity);

        }



        private void butedit_Click(object sender, EventArgs e)
        {
            try
            {
                if (Erorchecker.erorrowselected(dgvfare) == true) { return; }
                if (Erorchecker.eror(txtname, txtprice, txtquantity) == true) { return; }
                edit.EditLineInFile("ttt.txt", searchname, txtname.Text, txtprice.Text, txtquantity.Text, txtname);
                
                edit.Editdgvfare(dgvfare, txtname, txtprice, txtquantity);
                edit.editcombobox(productlist, txtname, txtprice, txtquantity, cbxproduct, bs, txtinvoiceprice, searchname);


                delete.deletetalltextboxpagemanagment(txtname, txtprice, txtquantity);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);


            }
        }





        private void butdelete_Click(object sender, EventArgs e)
        {



            try
            {
                if (Erorchecker.erorrowselected(dgvfare) == true) { return; }


                delete.DeleteLineFromFile("ttt.txt", txtname.Text, txtname);
                delete.DeleteFromcombobox(productlist, cbxproduct, bs, txtname.Text, txtname, txtprice, txtquantity, txtinvoiceprice);

                delete.DeleteFromDgvfare(dgvfare);
                txtname.Clear();
                txtprice.Clear();
                txtquantity.Clear();

                delete.deletetalltextboxpagemanagment(txtname, txtprice, txtquantity);










            }




            catch (Exception ex) { MessageBox.Show(ex.Message); }






        }

        private void butre_Click(object sender, EventArgs e)
        {
            restockcs.re(labnewstock, txtnewquantity);




        }

        private void btnstock_Click(object sender, EventArgs e)
        {


            restockcs.restockquantity(txtnewquantity, txtquantity, dgvfare, txtname, txtprice,searchname);

        }

        private void btndeleteallrows_Click(object sender, EventArgs e)
        {
            dgvfare.Rows.Clear();
            txtname.Clear();
            txtprice.Clear();
            txtquantity.Clear();
        }

        private void btndeletealltextbox_Click(object sender, EventArgs e)
        {
            txtname.Clear();
            txtprice.Clear();
            txtquantity.Clear();
        }



        private void tpinvoice_Click(object sender, EventArgs e)
        {

            txtcustomername.Focus();
            txtcustomername.Select();
            txtcustomername.SelectAll();


        }







        private void tabcontrol_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabcontrol.SelectedIndex >= 0)
            {



                if (tabcontrol.SelectedIndex == 0)
                {
                    txtname.Focus();

                }
                else
                {
                    txtcustomername.Focus();

                }
            }
        }

        private void txtcastomername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cbxproduct.Focus();
            }

        }

        private void cbproduct_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtinvoicequantity.Focus();
            }

            txtinvoiceprice.Text = cbxproduct.SelectedValue.ToString();
        }

        private void txtname_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtprice.Focus();
            }
            if (e.KeyData == (Keys.Alt | Keys.E))
            {
                butedit.PerformClick();
                txtname.Focus();
            }

        }

        private void txtprice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtquantity.Focus();
            }
            if (e.KeyData == (Keys.Alt | Keys.E))
            {
                butedit.PerformClick();
                txtname.Focus();
            }
        }

        private void txtquantity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                butadd.PerformClick();
                txtname.Focus();
            }
            if (e.KeyData == (Keys.Alt | Keys.E))
            {
                butedit.PerformClick();
                txtname.Focus();
            }
        }

        private void dgvfare_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete)
            {
                butdelete.PerformClick();
                txtname.Focus();
            }

        }

        private void txtinvoicequantity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                butinvoiceadd.PerformClick();
                txtcustomername.Focus();
            }
        }

        private void cbxproduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbxproduct.Text != "")
                {
                    txtinvoiceprice.Text = cbxproduct.SelectedValue.ToString();
                }
                
                if (cbxproduct.SelectedItem is product2 selectedProduct)
                {
                    txtname.Text = selectedProduct.name;
                    txtprice.Text = selectedProduct.price.ToString();
                    txtquantity.Text = selectedProduct.quantity.ToString();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtname_Enter(object sender, EventArgs e)
        {
            searchname = txtname.Text;
            searchname2 = txtname.Text;
        }

        private void butinvoiceadd_Click(object sender, EventArgs e)
        {
            /*txtcbxproduct.Text = cbxproduct.Text;
            dgvproduct.DataSource = null; // تأكد من إلغاء الربط
            dgvproduct.Columns.Clear();   // مسح أي أعمدة مُعرفة مسبقاً (اختياري)
            Addd.AddToDgvproduct(dgvproduct, txtcbxproduct, txtinvoiceprice, txtinvoicequantity);*/
            /*string name = txtcbxproduct.Text;
            decimal price = Convert.ToDecimal(txtinvoiceprice.Text);
            int quantity = Convert.ToInt32(txtinvoicequantity.Text);
            decimal subtotal = price * quantity;

            // إنشاء كائن جديد وإضافته للقائمة
            dgvproduct newProduct = new dgvproduct(name, price, quantity, subtotal);
            productList.Add(newProduct);

            // تحديث مصدر البيانات (مهم جداً)
            dgvproduct.DataSource = null;
            dgvproduct.DataSource = productList;

            txtinvoicequantity.Clear();*/
            try
            {
                if (Erorchecker.InvoicEror(txtinvoiceprice, txtinvoicequantity, txtcustomername, txtordernumber, cbxproduct, txtoverall) == true)
                {

                    txtinvoicequantity.Clear();

                    return;
                }
                string name = cbxproduct.Text; // اسم المنتج من الكومبوبوكس
                decimal price = Convert.ToDecimal(txtinvoiceprice.Text);
                int quantity = Convert.ToInt32(txtinvoicequantity.Text);
                decimal subtotal = price * quantity;

                // إضافة الصف مباشرة (بدون استخدام كلاس datadgvproduct)
                dgvproduct.Rows.Add(name, price, quantity, subtotal);
                txtinvoicequantity.Clear();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);


            }
        }

        private void butoverall_Click(object sender, EventArgs e)
        {
            try
            {

                if (cbcustomer.Checked == true)
                {

                    Type = Cusomertype.premium;
                }
                else
                {
                    Type = Cusomertype.normal;
                }
                if (Type == Cusomertype.premium)
                {
                    if (txtdiscount.Text == "")
                    {
                        MessageBox.Show("please enter discount");
                        return;
                    }
                    else
                    {
                        Addd.Addoverallpricewithdiscount(dgvproduct, txtoverall, txtdiscount);
                    }

                }
                else { Addd.Addoverallprice(dgvproduct, txtoverall); }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        /*else if (Type == Cusomertype.normal)
        {

            if (txtdiscount.Text == "")
            {

                Addd.Addoverallprice(dgvproduct, txtoverall);
            }
            if (txtdiscount.Text != "")
            {
                Addd.Addoverallpricewithdiscount(dgvproduct, txtoverall, txtdiscount);
            }*/
    

            
        }

        private void btndeleteall_Click(object sender, EventArgs e)
        {
            delete.deletetrow(txtinvoiceprice, txtinvoicequantity, dgvproduct, txtoverall);
        }

        private void btndeleteall_Click_1(object sender, EventArgs e)
        {
            delete.deletetallpageinvoice(dgvproduct, txtinvoiceprice, txtinvoicequantity,txtcustomername);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveData(productlist);
        }

        private void dgvfare_SelectionChanged_1(object sender, EventArgs e)
        {
            /*if (dgvfare.CurrentRow != null)
            {
                // تأكد من أن هناك صف محدد
                if (dgvfare.CurrentRow.Cells.Count > 0)
                {
                    // عرض محتوى العمود colname (الفهرس 0) في txtName (بافتراض أن لديك TextBox بهذا الاسم)
                    if (dgvfare.CurrentRow.Cells[0].Value != null)
                    {
                        txtname.Text = dgvfare.CurrentRow.Cells[0].Value.ToString();


                    }
                    else
                    {
                        txtname.Text = string.Empty;
                    }
                }

                if (dgvfare.CurrentRow.Cells.Count > 1)
                {
                    // عرض محتوى العمود colprice (الفهرس 1) في txtPrice (بافتراض أن لديك TextBox بهذا الاسم)
                    if (dgvfare.CurrentRow.Cells[1].Value != null)
                    {
                        txtprice.Text = dgvfare.CurrentRow.Cells[1].Value.ToString();
                    }
                    else
                    {
                        txtprice.Text = string.Empty;
                    }
                }

                if (dgvfare.CurrentRow.Cells.Count > 2)
                {
                    // عرض محتوى العمود colquantity (الفهرس 2) في txtQuantity (بافتراض أن لديك TextBox بهذا الاسم)
                    if (dgvfare.CurrentRow.Cells[2].Value != null)
                    {
                        txtquantity.Text = dgvfare.CurrentRow.Cells[2].Value.ToString();
                    }
                    else
                    {
                        txtquantity.Text = string.Empty;
                    }
                }

                // يمكنك إضافة المزيد من الشروط لعرض محتويات المزيد من الأعمدة في مربعات نصوص إضافية
            }
            else
            {
                // إذا لم يكن هناك صف محدد، قم بمسح محتويات مربعات النصوص
                txtname.Text = string.Empty;
                txtprice.Text = string.Empty;
                txtquantity.Text = string.Empty;
                // قم بمسح أي مربعات نصوص أخرى تستخدمها
            }
            txtname.Focus();*/
            try { find.selectedrow(dgvfare, txtname, txtprice, txtquantity); }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }




        }

        private void btnfind_Click(object sender, EventArgs e)
        {
            // كود الي لو مش موجود
            //string searchName = txtname.Text; // الحصول على الاسم من TextBox وإزالة المسافات الزائدة

            /*  if (!string.IsNullOrEmpty(searchName))
              {
                  bool found = false;
                  // افتراض أن عمود الاسم هو العمود الأول (الفهرس 0)
                  foreach (DataGridViewRow row in dgvfare.Rows)
                  {
                      if (row.Cells[0].Value != null && row.Cells[0].Value.ToString().Equals(searchName, StringComparison.OrdinalIgnoreCase))
                      {
                          dgvfare.ClearSelection(); // قم بإلغاء تحديد أي صف محدد حاليًا
                          row.Selected = true;      // حدد الصف الحالي
                          dgvfare.CurrentCell = row.Cells[0];
                          find.selectedrow(dgvfare, txtname, txtprice, txtquantity);// اجعل الخلية الأولى من الصف الحالي هي الخلية النشطة (للتأكد من ظهور التحديد)
                                                                                    // PopulateTextBoxesFromSelectedRow(); // املأ مربعات النصوص ببيانات الصف المحدد
                          found = true;
                          break; // اخرج من الحلقة بمجرد العثور على الصف
                      }
                  }

                  if (!found)
                  {
                      MessageBox.Show($"لم يتم العثور على منتج بالاسم '{searchName}'.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                  }
              }
              else
              {
                  MessageBox.Show("الرجاء إدخال اسم المنتج للبحث.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
              }*/
            try
            {
                searchname = txtname.Text;
                bool found = false;
                if (txtname.Text == "")
                {
                    MessageBox.Show("please enter name");
                    return;
                }
                foreach (DataGridViewRow row in dgvfare.Rows)
                {
                    if (row.Cells[0].Value != null && row.Cells[0].Value.ToString().Equals(searchname, StringComparison.OrdinalIgnoreCase))
                    {
                        dgvfare.ClearSelection(); // قم بإلغاء تحديد أي صف محدد حاليًا
                        row.Selected = true;      // حدد الصف الحالي
                        dgvfare.CurrentCell = row.Cells[0];
                        find.selectedrow(dgvfare, txtname, txtprice, txtquantity);// اجعل الخلية الأولى من الصف الحالي هي الخلية النشطة (للتأكد من ظهور التحديد)
                        found = true;                                     // PopulateTextBoxesFromSelectedRow(); // املأ مربعات النصوص ببيانات الصف المحدد

                        break; // اخرج من الحلقة بمجرد العثور على الصف
                    }
                }
                if (found == false)
                {
                    MessageBox.Show("item not found"); return;


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            /* string name = txtname.Text.Trim();
             decimal price = decimal.Parse(txtprice.Text.Trim());
             int quantity = int.Parse(txtquantity.Text.Trim());
             product2 newitem = new product2(name, price, quantity);
             dgvfare.CurrentRow.Cells[0].Value = newitem.name;
             dgvfare.CurrentRow.Cells[1].Value = newitem.price.ToString();
             dgvfare.CurrentRow.Cells[2].Value = newitem.quantity.ToString();*/
        }

        private void butprint_Click(object sender, EventArgs e)
        {
            
            if (txtoverall.Text == "")
            {
                MessageBox.Show("the overall section is empty");
                return;
            }
            ordernumber++;
            txtordernumber.Text = ordernumber.ToString();
            ((Form)printPreviewDialog1).WindowState = FormWindowState.Maximized;
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }

            dgvproduct.DataSource = null; 
           
            delete.deletetrow(txtinvoiceprice, txtinvoicequantity, dgvproduct, txtoverall);
            
            


        }

        private void txtordernumber_TextChanged(object sender, EventArgs e)
        {
            /*if (Erorchecker.ValidateOrderNumberIsNumeric(txtordernumber) == true)
            {
                return;
            }*/
        }



        private void printDocument1_PrintPage_1(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            float margin = 40;
            Font f = new Font("Arial", 18, FontStyle.Bold);

            string strNo = "Order Number : " + txtordernumber.Text;
            string strDate = "Date : " + txtdate.Text;
            string strName = "Customer Name : " + txtcustomername.Text;

            SizeF fontSizeNo = e.Graphics.MeasureString(strNo, f);
            SizeF fontSizeDate = e.Graphics.MeasureString(strDate, f);
            SizeF fontSizeName = e.Graphics.MeasureString(strName, f);

            e.Graphics.DrawString(strNo, f, Brushes.Red, (e.PageBounds.Width - fontSizeNo.Width) / 2, margin);
            e.Graphics.DrawString(strDate, f, Brushes.Black, margin, margin + fontSizeNo.Height);
            e.Graphics.DrawString(strName, f, Brushes.Black, margin, margin + fontSizeNo.Height + fontSizeDate.Height);

            float preHeights = margin + fontSizeNo.Height + fontSizeDate.Height + fontSizeName.Height + 20;

            e.Graphics.DrawRectangle(Pens.Black, margin, preHeights, e.PageBounds.Width - margin * 2, e.PageBounds.Height - margin * 2 - preHeights);

            float colHeight = 60;
            float colOneWidth = 300;
            float colTwoWidth = 125 + colOneWidth;
            float colThreeWidth = 125 + colTwoWidth;
            float colFourWidth = 125 + colThreeWidth;

            e.Graphics.DrawLine(Pens.Black, margin, preHeights + colHeight, e.PageBounds.Width - margin, preHeights + colHeight);

            e.Graphics.DrawString("Product", f, Brushes.Black, margin + 10, preHeights + 15);
            e.Graphics.DrawLine(Pens.Black, margin + colOneWidth, preHeights, margin + colOneWidth, e.PageBounds.Height - margin * 2);

            e.Graphics.DrawString("Price", f, Brushes.Black, margin + colOneWidth + 10, preHeights + 15);
            e.Graphics.DrawLine(Pens.Black, margin + colTwoWidth, preHeights, margin + colTwoWidth, e.PageBounds.Height - margin * 2);

            e.Graphics.DrawString("Quantity", f, Brushes.Black, margin + colTwoWidth + 10, preHeights + 15);
            e.Graphics.DrawLine(Pens.Black, margin + colThreeWidth, preHeights, margin + colThreeWidth, e.PageBounds.Height - margin * 2);

            e.Graphics.DrawString("Overall", f, Brushes.Red, margin + colThreeWidth + 10, preHeights + 15);

            // Invoice Content :
            float rowsHeight = 60;

            for (int x = 0; x < dgvproduct.Rows.Count; x += 1)
            {
                e.Graphics.DrawString(dgvproduct.Rows[x].Cells[0].Value.ToString(), f, Brushes.Black, margin + 15, preHeights + rowsHeight);
                e.Graphics.DrawString(dgvproduct.Rows[x].Cells[1].Value.ToString(), f, Brushes.Black, margin + colOneWidth + 15, preHeights + rowsHeight);
                e.Graphics.DrawString(dgvproduct.Rows[x].Cells[2].Value.ToString(), f, Brushes.Black, margin + colTwoWidth + 15, preHeights + rowsHeight);
                e.Graphics.DrawString(dgvproduct.Rows[x].Cells[3].Value.ToString(), f, Brushes.Black, margin + colThreeWidth + 15, preHeights + rowsHeight);

                e.Graphics.DrawLine(Pens.Black, margin, preHeights + rowsHeight + colHeight, e.PageBounds.Width - margin, preHeights + rowsHeight + colHeight);

                rowsHeight += 60;
            }


            e.Graphics.DrawString("Total", f, Brushes.Red, margin + colTwoWidth + 15, preHeights + rowsHeight + 15);
            e.Graphics.DrawString(txtoverall.Text, f, Brushes.Red, margin + colThreeWidth + 15, preHeights + rowsHeight + 15);
            e.Graphics.DrawLine(Pens.Black, margin, preHeights + rowsHeight + colHeight, e.PageBounds.Width - margin, preHeights + rowsHeight + colHeight);

        }

        private void txtoverall_TextChanged(object sender, EventArgs e)
        {
            string price = (txtoverall.Text);
        }

        private void cbcustomer_CheckedChanged(object sender, EventArgs e)
        {
            if (cbcustomer.Checked == true)
            {
                txtdiscount.Enabled = true;
                txtdiscount.Visible = true;
                labdiscount.Visible = true;
            }
            else
            {
                txtdiscount.Enabled = false;
                txtdiscount.Visible = false;
                labdiscount.Visible = false;
            }
        }
    }
}

            
