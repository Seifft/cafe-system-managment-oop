using cafe_system_managment;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace cafe_system_managment
{
    public class find
    {

        public static void selectedrow(DataGridView dgvfare, TextBox txtname, TextBox txtprice, TextBox txtquantity)

        {
            /* if (dgvfare.CurrentRow != null)
             {
                 // تأكد من أن هناك صف محدد
                 if (dgvfare.CurrentRow.Cells.Count > 0)
                 {
                     // عرض محتوى العمود colname (الفهرس 0) في txtName (بافتراض أن لديك TextBox بهذا الاسم)
                     if (dgvfare.CurrentRow.Cells[0].Value != null)
                     {
                         txtname.Text = dgvfare.CurrentRow.Cells[0].Value.ToString();
                     }
                     //else
                     //{
                         txtname.Text = string.Empty;
                     //}
                 }

                 if (dgvfare.CurrentRow.Cells.Count > 1)
                 {
                     // عرض محتوى العمود colprice (الفهرس 1) في txtPrice (بافتراض أن لديك TextBox بهذا الاسم)
                     //if (dgvfare.CurrentRow.Cells[1].Value != null)
                     //{
                         txtprice.Text = dgvfare.CurrentRow.Cells[1].Value.ToString();
                     //}
                    // else
                     //{
                         txtprice.Text = string.Empty;
                    // }
                 }

                 if (dgvfare.CurrentRow.Cells.Count > 2)
                 {
                     // عرض محتوى العمود colquantity (الفهرس 2) في txtQuantity (بافتراض أن لديك TextBox بهذا الاسم)
                    // if (dgvfare.CurrentRow.Cells[2].Value != null)
                     //{
                         txtquantity.Text = dgvfare.CurrentRow.Cells[2].Value.ToString();
                     //}
                     //else
                     //{
                         txtquantity.Text = string.Empty;
                     //}
                 }

                 // يمكنك إضافة المزيد من الشروط لعرض محتويات المزيد من الأعمدة في مربعات نصوص إضافية
             }*/


            /*else
            {
                // إذا لم يكن هناك صف محدد، قم بمسح محتويات مربعات النصوص
                txtname.Text = "";
                txtprice.Text = "";
                txtquantity.Text = "";
                // قم بمسح أي مربعات نصوص أخرى تستخدمها
            }*/


            /*txtname.Text = dgvfare.CurrentRow.Cells[0].Value.ToString();
            txtprice.Text = dgvfare.CurrentRow.Cells[1].Value.ToString();
            txtquantity.Text = dgvfare.CurrentRow.Cells[2].Value.ToString();*/
            if (dgvfare.Rows.Count != 0)
            {
                string name = dgvfare.CurrentRow.Cells[0].Value.ToString();
                decimal price = decimal.Parse(dgvfare.CurrentRow.Cells[1].Value.ToString());
                int quantity = int.Parse(dgvfare.CurrentRow.Cells[2].Value.ToString());



                product2 newitem = new product2(name, price, quantity);
                txtname.Text = newitem.name;
                txtprice.Text = newitem.price.ToString();
                txtquantity.Text = newitem.quantity.ToString();

                
            }
            txtname.Focus();
            txtname.Select(txtname.Text.Length, 0);


        }


        }
    
}

