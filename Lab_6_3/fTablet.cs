using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_6_3
{
    public partial class fTablet : Form
    {

        public fTablet(Tablet t)
        {
            TheTablet = t;
            InitializeComponent();
        }

        public Tablet TheTablet;

        private void fTablet_Load_1(object sender, EventArgs e)
        {
            if (TheTablet != null)
            {
                tbBrand.Text = TheTablet.brand;
                tbPrice.Text = TheTablet.price.ToString();
                tbWeight.Text = TheTablet.weight.ToString();
                tbColor.Text = TheTablet.color;
                tbScreendiagonal.Text = TheTablet.screendiagonal.ToString("0.0");
                tbCPUfrequency.Text = TheTablet.CPUfrequency.ToString("0.0");
                chbisthereasimcard.Checked = TheTablet.isthereasimcard;
                chbisthereamemorycardslot.Checked = TheTablet.isthereamemorycardslot;
            }
        }

        private void btnOk_Click_1(object sender, EventArgs e)
        {
            TheTablet.brand = tbBrand.Text.Trim();
            TheTablet.price = int.Parse(tbPrice.Text.Trim());
            TheTablet.weight = int.Parse(tbWeight.Text.Trim());
            TheTablet.color = tbColor.Text.Trim();
            TheTablet.screendiagonal = double.Parse(tbScreendiagonal.Text.Trim());
            TheTablet.CPUfrequency = double.Parse(tbCPUfrequency.Text.Trim());
            TheTablet.isthereasimcard = chbisthereasimcard.Checked;
            TheTablet.isthereamemorycardslot = chbisthereamemorycardslot.Checked;

            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
