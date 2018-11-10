using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manager
{
    public partial class ManagerMain : Form
    {     

        public ManagerMain()
        {
            InitializeComponent();
        }

        private void ManagerMain_Load(object sender, EventArgs e)
        {

        }

        private void ManagerMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void systemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Systems sys = new Systems();
            sys.MdiParent = this;
            sys.Show();
        }

                  
    }
}
