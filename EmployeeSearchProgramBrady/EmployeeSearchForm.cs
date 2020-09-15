using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/***************************************************************
* Name        : Employee Search
* Author      : Kabrina Brady
* Created     : 11/5/2019
* Course      : CIS 169 - C#
* Version     : 1.0
* OS          : Windows 10
* Copyright   : This is my own original work
* Description : User can search for a specific employee by using the search TextBox
*               Input:  TextBox input, button clicks
*               Output: Table data
* Academic Honesty: I attest that this is my original work.
* I have not used unauthorized source code, either modified or unmodified. I have not given other fellow student(s) access to my program.         
***************************************************************/

namespace EmployeeSearchProgramBrady
{
    public partial class EmpSearchForm : Form
    {
        public EmpSearchForm()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close(); //closes the form
        }

        private void employeeBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.employeeBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.personnelDataSet);
        }

        private void EmpSearchForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'personnelDataSet.Employee' table. You can move, or remove it, as needed.
            this.employeeTableAdapter.Fill(this.personnelDataSet.Employee);

        }

        //searches for name
        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.employeeTableAdapter.NameSearch(this.personnelDataSet.Employee, txtInput.Text);

            //prompts user to enter name if nothing entered and search button clicked
            if (txtInput.Text == "")
            {
                MessageBox.Show("Please enter a name.");
            }
        }

        //fills the table if less than total is displayed
        private void button1_Click(object sender, EventArgs e)
        {
            this.employeeTableAdapter.Fill(this.personnelDataSet.Employee);
        }
    }
}
