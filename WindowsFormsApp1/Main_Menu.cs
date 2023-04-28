using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Main_Menu : Form
    {
        public Main_Menu()
        {
            InitializeComponent();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            Screen myScreen = Screen.FromControl(this);
                     Import _Import = new Import();
            _Import.StartPosition = FormStartPosition.Manual;
            _Import.Location =  this.Location;
            _Import.Show();
            this.Hide();
        }

        private void Main_Menu_Load(object sender, EventArgs e)
        {

        }

        private void Main_Menu_FormClosed(object sender, FormClosedEventArgs e)
        {
           // Application.Exit();
            Environment.Exit(0);
        }
    }
}
