using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Windows.Forms;
using System.Diagnostics.Eventing.Reader;
namespace cafe_system_managment
{
    public static class Erorchecker 
    {
        public static bool eror(TextBox txtname, TextBox txtprice, TextBox txtquantity) 
        {

            if (txtname.Text == null || txtname.Text.Length == 0)
            {

                MessageBox.Show("Eror: Name Text is Empty");
                return true;



            }

             if (txtprice.Text == null || txtprice.Text.Length == 0)
            {
                MessageBox.Show("Eror: Price Text is empty");
                return true;
            }
             if (txtquantity.Text == null || txtquantity.Text.Length == 0)
            {

                MessageBox.Show("Eror: quantity Text is Empty");
                return true;
            }
            string name = txtname.Text;
          
             if (name.Any(char.IsDigit))
            {
                MessageBox.Show("Eror: Name Text Contains Numbers");
                return true;
            }
            decimal price = decimal.Parse(txtprice.Text);

           /* if (decimal.TryParse(txtquantity.Text, out price))
            {

                
             
            }
            else 
            
            {
                MessageBox.Show("Eror: Price Text Contains a char or string ");
               
            }*/



            if (price < 0) { MessageBox.Show("Eror: Price Text Contains Negative Number"); return true; }
           
            int quantity = int.Parse(txtquantity.Text);

            if (int.TryParse(txtquantity.Text, out quantity))
            {

                
            }
            else { MessageBox.Show("Eror: Text Contains a char or string"); return true; }


            if (quantity < 0) { MessageBox.Show("Eror: Stock Text Contains Negative Number"); return true; }
            else { return false; }
        }
      


        public static bool erorrowselected(DataGridView dgvfare) 
        {
            if (dgvfare.SelectedRows.Count == 0)
            {
                MessageBox.Show("Eror: You Donot Select A Row (please select one) ");

                return true;
            }
        else {return false; }



        
        
        
        
        }







        
        }









}



    

