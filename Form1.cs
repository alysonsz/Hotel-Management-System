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
        string id;
        public FormPrincipal()
        {
            InitializeComponent();
            clearTxt();
            disableTxt();
            disableButtons();
            btnNew.Enabled = true;
        }
        private void formatGrid()
        {
            grid.Columns[0].HeaderText = "ID";
            grid.Columns[1].HeaderText = "Name";
            grid.Columns[2].HeaderText = "Adress";
            grid.Columns[3].HeaderText = "CPF";
            grid.Columns[4].HeaderText = "Telephone";
        }
        private void listGrid()
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
            formatGrid();
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
            qtfUsers = qtfUsers + 1;
            disableButtons();
            btnNew.Enabled = true;
            btnDelete.Enabled = true;
            btnEdit.Enabled = true;
            clearTxt();
            disableTxt();
            listGrid();
            MessageBox.Show("Saved successfully!", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            qtfUsers = qtfUsers - 1;
            disableButtons();
            btnNew.Enabled = true;
            if (qtfUsers >= 1)
            {
                deleteOrEdit();
            }
            listGrid();
            MessageBox.Show("Deleted successfully!", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            disableButtons();
            disableTxt();
            clearTxt();
            btnNew.Enabled = true;
            if (qtfUsers >= 1)
            {
                deleteOrEdit();
            }
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtName.ToString().Trim() == "")
            {
                MessageBox.Show("Enter a valid name!");
                txtName.Text = "";
                txtName.Focus();
                return;
            }
            if (txtCPF.Text == "   .   .   -" || txtCPF.Text.Length < 14)
            {
                MessageBox.Show("Enter a valid CPF!");
                txtCPF.Focus();
                return;
            }
            if (txtTel.Text == "(  )      -" || txtTel.Text.Length < 11)
            {
                MessageBox.Show("Enter a valid number!");
                txtTel.Focus();
                return;
            }
            connector.openConnection();
            sql = "UPDATE client SET name = @name, adress = @adress, cpf = @cpf, tel = @tel WHERE id = @id";
            command = new MySqlCommand(sql, connector.sqlConnector);
            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@name", txtName.Text);
            command.Parameters.AddWithValue("@adress", txtAdress.Text);
            command.Parameters.AddWithValue("@cpf", txtCPF.Text);
            command.Parameters.AddWithValue("@tel", txtTel.Text);
            formatGrid();
            command.ExecuteNonQuery();
            connector.closedConnection();
            MessageBox.Show("Edited successfully!", "Edit", MessageBoxButtons.OK, MessageBoxIcon.Information);
            disableButtons();
            clearTxt();
            disableTxt();
            btnNew.Enabled = true;
            listGrid();
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
            btnEdit.Enabled = true;
        }
        private void disableButtons()
        {
            btnNew.Enabled = false;
            btnSave.Enabled = false;
            btnDelete.Enabled = false;
            btnCancel.Enabled = false;
            btnEdit.Enabled = false;
        }
        private void deleteOrEdit()
        {
            btnDelete.Enabled = true;
            btnEdit.Enabled = true;
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            listGrid();
        }

        private void grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            enableButtons();
            btnNew.Enabled = false;
            btnSave.Enabled = false;
            enableTxt();
            id = grid.CurrentRow.Cells[0].Value.ToString();
            txtName.Text = grid.CurrentRow.Cells[1].Value.ToString();
            txtAdress.Text = grid.CurrentRow.Cells[2].Value.ToString();
            txtCPF.Text = grid.CurrentRow.Cells[3].Value.ToString();
            txtTel.Text = grid.CurrentRow.Cells[4].Value.ToString();
        }
    }
}
