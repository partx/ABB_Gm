using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ABBGeneral
{
    public partial class wizard : Form
    {
        public wizard()
        {
            InitializeComponent();
        }

        private void wizard_Load(object sender, EventArgs e)
        {
            int ledWidth = SystemInformation.VirtualScreen.Width;
            int ledHeight = SystemInformation.VirtualScreen.Height;
            this.MaximumSize = new Size(3 * ledWidth / 4, 3 * ledHeight / 4);    //固定窗体
            this.MinimumSize = new Size(3 * ledWidth / 4, 3 * ledHeight / 4);
            this.Top = (ledHeight - this.Height) / 2;
            this.Left = (ledWidth - this.Width) / 2;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void wizard_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
