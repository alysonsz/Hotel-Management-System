using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel_Management_System
{
    public partial class FormPrincipal : Form
    {
        Connection connector = new Connection();
        int qtfUsers = 0;
        public FormPrincipal()
        {
            InitializeComponent();
            clearTxt();
            disableTxt();
            disableButtons();
            btnNew.Enabled = true;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            enableTxt();
            disableButtons();
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
            txtName.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            qtfUsers = qtfUsers + 1;
            disableButtons();
            btnNew.Enabled = true;
            btnDelete.Enabled = true;
            clearTxt();
            disableTxt();
            connector.openConnection();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            qtfUsers = qtfUsers - 1;
            disableButtons();
            btnNew.Enabled = true;
            if (qtfUsers >= 1)
            {
                btnDelete.Enabled = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            disableButtons();
            disableTxt();
            clearTxt();
            btnNew.Enabled = true;
            if (qtfUsers >= 1)
            {
                btnDelete.Enabled = true;
            }
        }
        private void clearTxt()
        {
            txtName.Text = "";
            txtAdress.Text = "";
            txtCPF.Text = "";
            txtTel.Text = "";
        }
        private void enableTxt()
        {
            txtName.Enabled = true;
            txtAdress.Enabled = true;
            txtCPF.Enabled = true;
            txtTel.Enabled = true;
        }
        private void disableTxt()
        {
            txtName.Enabled = false;
            txtAdress.Enabled = false;
            txtCPF.Enabled = false;
            txtTel.Enabled = false;
        }
        private void enableButtons()
        {
            btnNew.Enabled = true;
            btnSave.Enabled = true;
            btnDelete.Enabled = true;
            btnCancel.Enabled = true;
        }
        private void disableButtons()
        {
            btnNew.Enabled = false;
            btnSave.Enabled = false;
            btnDelete.Enabled = false;
            btnCancel.Enabled = false;
        }

    }
}
