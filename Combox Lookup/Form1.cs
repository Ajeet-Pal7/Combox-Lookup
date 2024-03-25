using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Combox_Lookup
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ErrorProvider err = new ErrorProvider();
            if (txtInput.Text != "")
            {
                comboBox1.Items.Add(txtInput.Text);
                txtInput.Text = "";
                txtInput.Focus();  
                err.Clear();
                err.Icon = SystemIcons.Information;
                err.SetError(txtInput, "Success!");
            }else
            {
                err.Clear();
                err.Icon = SystemIcons.Error;
                MessageBox.Show("Please type something");
                err.SetError(txtInput, "Fill this");
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if(txtInput.Text != "")
            {
                try
                {
                    if (comboBox1.Items.Contains(txtInput.Text))
                    {
                        comboBox1.Items.Remove(txtInput.Text);
                        MessageBox.Show("Deleted");
                    }
                    else MessageBox.Show("Err : " + txtInput.Text + " doesn't exists!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Err : " + ex.Message);
                }

            }else MessageBox.Show("Enter what you wanted to delete");
        }

        private void btnRemoveAt_Click(object sender, EventArgs e)
        {
            int index;
            if(int.TryParse(txtInput.Text,out index))
            {
                index = Convert.ToInt32(txtInput.Text);
                if(index <= comboBox1.Items.Count)
                {
                    comboBox1.Items.RemoveAt(index);
                    MessageBox.Show("Deleted");
                }
                else 
                { 
                    MessageBox.Show("Err : can't find" + index + "Items");
                }
            }else
            {
                MessageBox.Show("Err : Please enter index position");
            }
        }
    }
}
