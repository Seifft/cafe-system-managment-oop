using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Runtime.ExceptionServices;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;

namespace cafe_system_managment
{
    public partial class Form1 : Form
    {


        public product2 newItem { get; set; }


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

        List<product2> productlist = new List<product2>();

        BindingSource bs = new BindingSource();
        private void butadd_Click(object sender, EventArgs e)
        {
            // find button add
            // متنساش الفانكشن الي هتشوف هو في اسم متكرر ولا لا  وهتحطها في ال add و ال edid
            {
                try
                {
                    if (Erorchecker.eror(txtname, txtprice, txtquantity) == true) { return; }


                    

                    Add.AddTocombobox(productlist, txtname, txtprice, txtquantity, cbxproduct, bs, txtinvoiceprice);
                    Add.AddToDgvfare(dgvfare, txtname, txtprice, txtquantity, productlist, bs);



                }

                catch (Exception ex) { MessageBox.Show(ex.Message); }

                txtname.Clear();
                txtprice.Clear();
                txtquantity.Clear();
                txtname.Focus();







            }
        }





        private void Form1_Load(object sender, EventArgs e)
        {
            txtdate.Text = DateTime.Now.ToString("yyyy/MM/dd");
            txtname.Focus();
            txtname.Select();
            txtname.SelectAll();

        }

        private void butedit_Click(object sender, EventArgs e)
        {
            if (Erorchecker.erorrowselected(dgvfare) == true) { return; }
            if (Erorchecker.eror(txtname, txtprice, txtquantity) == true) { return; }
            edit.Editdgvfare(dgvfare, txtname, txtprice, txtquantity);
            edit.editcombobox(productlist, txtname, txtprice, txtquantity, cbxproduct, bs, txtinvoiceprice, searchname);




        }

















        private void dgvfare_SelectionChanged(object sender, EventArgs e)
        {

            if (dgvfare.CurrentRow != null)
            {
                txtname.Text = dgvfare.CurrentRow.Cells[0].Value.ToString();
                txtprice.Text = dgvfare.CurrentRow.Cells[1].Value.ToString();
                txtquantity.Text = dgvfare.CurrentRow.Cells[2].Value.ToString();

                txtname.Focus();



            }

        }

        private void butdelete_Click(object sender, EventArgs e)
        {

            if (Erorchecker.erorrowselected(dgvfare) == true) { return; }
            else
            {
                try
                {


                    delete.DeleteFromcombobox(productlist, cbxproduct, bs, searchname, txtname, txtprice, txtquantity, txtinvoiceprice);
                    delete.DeleteFromDgvfare(dgvfare);








                }




                catch (Exception ex) { MessageBox.Show(ex.Message); }



            }


        }

        private void butre_Click(object sender, EventArgs e)
        {
            restockcs.re(labnewstock, txtnewquantity);




        }

        private void btnstock_Click(object sender, EventArgs e)
        {


            restockcs.restockquantity(txtnewquantity, txtquantity, dgvfare, txtname, txtprice);

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

            txtcastomername.Focus();
            txtcastomername.Select();
            txtcastomername.SelectAll();


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
                    txtcastomername.Focus();

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
                txtcastomername.Focus();
            }
        }

        private void cbxproduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtinvoiceprice.Text = cbxproduct.SelectedValue.ToString();
        }


        private void txtname_Enter(object sender, EventArgs e)
        {
            searchname = txtname.Text;
        }

        private void butinvoiceadd_Click(object sender, EventArgs e)
        {
            Add.AddToDgvproduct(dgvproduct, cbxproduct, txtinvoiceprice, txtinvoicequantity);


        }

        private void butoverall_Click(object sender, EventArgs e)
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
                    Add.Addoverallpricewithdiscount(dgvproduct, txtoverall, txtdiscount);
                }

            }

            else if (Type == Cusomertype.normal)
            {

                if (txtdiscount.Text == "")
                {

                    Add.Addoverallprice(dgvproduct, txtoverall);
                }
                if (txtdiscount.Text != "")
                {
                    Add.Addoverallpricewithdiscount(dgvproduct, txtoverall, txtdiscount);
                }

            }
        }

        private void btndeleteall_Click(object sender, EventArgs e)
        {
            delete.deletetrow(txtinvoiceprice, txtinvoicequantity, dgvproduct,txtoverall);
        }

        private void btndeleteall_Click_1(object sender, EventArgs e)
        {
            delete.deletetallpageinvoice(dgvproduct, txtinvoiceprice,txtinvoicequantity);
        }
    }
}
