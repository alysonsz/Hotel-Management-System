using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Hotel_Management_System
{
    public partial class FormPrincipal : Form
    {
        Connection connector = new Connection();
        MySqlDataAdapter adapter;
        MySqlCommand command;
        string sql;
        int qtfUsers = 0;
        public FormPrincipal()
        {
            InitializeComponent();
            clearTxt();
            disableTxt();
            disableButtons();
            btnNew.Enabled = true;
        }
        private void FormatGrid()
        {
            grid.Columns[0].HeaderText = "ID";
            grid.Columns[0].HeaderText = "Name";
            grid.Columns[0].HeaderText = "Adress";
            grid.Columns[0].HeaderText = "CPF";
            grid.Columns[0].HeaderText = "Telephone";
        }
        private void ListGrid()
        {
            connector.openConnection();
            sql = "SELECT * from client ORDER BY NAME ASC";
            command = new MySqlCommand(sql, connector.sqlConnector);
            adapter = new MySqlDataAdapter();
            adapter.SelectCommand = command;
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            grid.DataSource = dt;
            connector.closedConnection();
            FormatGrid();
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
            if (txtName.ToString().Trim() == "")
            {
                MessageBox.Show("Insira o nome!");
                txtName.Text = "";
                txtName.Focus();
                return;
            }
            if (txtCPF.Text == "   .   .   -" || txtCPF.Text.Length < 14)
            {
                MessageBox.Show("Insira um CPF valido!");
                txtCPF.Focus();
                return;
            }
            if (txtTel.Text == "(  )      -" || txtTel.Text.Length < 11)
            {
                MessageBox.Show("Insira um numero valido!");
                txtTel.Focus();
                return;
            }
            connector.openConnection();
            sql = "INSERT INTO client (name, adress, cpf, tel) VALUES (@name, @adress, @cpf, @tel)";
            command = new MySqlCommand(sql, connector.sqlConnector);
            command.Parameters.AddWithValue("@name", txtName.Text);
            command.Parameters.AddWithValue("@adress", txtAdress.Text);
            command.Parameters.AddWithValue("@cpf", txtCPF.Text);
            command.Parameters.AddWithValue("@tel", txtTel.Text);
            command.ExecuteNonQuery();
            connector.closedConnection();
            MessageBox.Show("Os dados foram salvos com sucesso!");
            qtfUsers = qtfUsers + 1;
            disableButtons();
            btnNew.Enabled = true;
            btnDelete.Enabled = true;
            clearTxt();
            disableTxt();
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
            connector.openConnection();
            sql = "DELETE FROM client (name, adress, cpf, tel) VALUES (@name, @adress, @cpf, @tel)";
            command = new MySqlCommand(sql, connector.sqlConnector);
            command.Parameters.AddWithValue("@name", txtName.Text);
            command.Parameters.AddWithValue("@adress", txtAdress.Text);
            command.Parameters.AddWithValue("@cpf", txtCPF.Text);
            command.Parameters.AddWithValue("@tel", txtTel.Text);
            command.ExecuteNonQuery();
            connector.closedConnection();
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
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtName.ToString().Trim() == "")
            {
                MessageBox.Show("Insira o nome!");
                txtName.Text = "";
                txtName.Focus();
                return;
            }
            if (txtCPF.Text == "   .   .   -" || txtCPF.Text.Length < 14)
            {
                MessageBox.Show("Insira um CPF valido!");
                txtCPF.Focus();
                return;
            }
            if (txtTel.Text == "(  )      -" || txtTel.Text.Length < 11)
            {
                MessageBox.Show("Insira um numero valido!");
                txtTel.Focus();
                return;
            }
            connector.openConnection();
            sql = "UPDATE client SET name = @name, adress = @adress, cpf = @cpf, tel = @tel";
            command = new MySqlCommand(sql, connector.sqlConnector);
            command.Parameters.AddWithValue("@name", txtName.Text);
            command.Parameters.AddWithValue("@adress", txtAdress.Text);
            command.Parameters.AddWithValue("@cpf", txtCPF.Text);
            command.Parameters.AddWithValue("@tel", txtTel.Text);
            command.ExecuteNonQuery();
            connector.closedConnection();
            MessageBox.Show("Os dados foram editados com sucesso!");
            disableButtons();
            clearTxt();
            disableTxt();
            btnNew.Enabled = true;
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

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            ListGrid();
        }
    }
}
