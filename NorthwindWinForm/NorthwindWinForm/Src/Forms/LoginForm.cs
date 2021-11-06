
using NorthwindModel.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NorthwindWinForm.Src.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm(string email)
        {
            InitializeComponent();
            Email = email;
        }
        public string Email { get; }
        private void btRegistry_Click(object sender, EventArgs e)
        {
            //User user = new User();
            //user.Email = tbEmail.Text;
            //user.Password = tbPassword.Text;
            //var northwindDAO = new NorthwindUsersDAO();
            //var result = northwindDAO.UserSelect(user.Email);
            //if(result == null)
            //    northwindDAO.UserInsert(user);
            //else            
            //    MessageBox.Show(this, "Usuario ja cadastrado", "Login");            
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            //if (ValidatorEmail(tbEmail.Text))
            //{
            //    User user = new User();
            //    user.Email = tbEmail.Text;
            //    user.Password = tbPassword.Text;
            //    var northwindDAO = new NorthwindUsersDAO();
            //    var result = northwindDAO.UserSelect(user.Email);
            //    if (result == null)
            //        MessageBox.Show(this, "Usuario não cadastrado", "Login");
            //    else
            //    {
            //        if (user.Password == result.Password)
            //        {
            //            email = user.Email;
            //            DialogResult = DialogResult.OK;
            //        }
            //        else
            //            MessageBox.Show(this, "Senha de usuario invalida", "Login");
            //    }
            //}
            //else
            //    MessageBox.Show(this, "Email invalido", "Login");
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void tbEmail_TextChanged(object sender, EventArgs e)
        {
            if((tbEmail.Text.Length > 0)&&(tbPassword.Text.Length>0))
            {
                btOk.Enabled = true;
                btRegistry.Enabled = true;
            }
            else
            {
                btOk.Enabled = false;
                btRegistry.Enabled = false;
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            
            tbEmail.Focus();
            tbEmail_TextChanged(sender, e);
            //btOk.Enabled = false;
            //btRegistry.Enabled = false;
        }

        private bool ValidatorEmail(string email)
        {
            Regex rg = new Regex(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$");
            if (rg.IsMatch(email))            
                return true;            
            else            
                return false;            
        }
    }
}
