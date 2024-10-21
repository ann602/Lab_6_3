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

        public fTablet(Electronicdevice t)
        {
            TheElectronicdevice = t;
            InitializeComponent();
        }

        public Electronicdevice TheElectronicdevice;

        private void fTablet_Load_1(object sender, EventArgs e)
        {
            if (TheElectronicdevice != null)
            {
                tbBrand.Text = TheElectronicdevice.brand;
                tbPrice.Text = TheElectronicdevice.price.ToString();
                tbWeight.Text = TheElectronicdevice.weight.ToString();
                tbColor.Text = TheElectronicdevice.color;
                tbScreendiagonal.Text = TheElectronicdevice.screendiagonal.ToString("0.0");
                tbCPUfrequency.Text = TheElectronicdevice.CPUfrequency.ToString("0.0");
                chbisthereasimcard.Checked = TheElectronicdevice.isthereasimcard;
                chbisthereamemorycardslot.Checked = TheElectronicdevice.isthereamemorycardslot;
            }
        }

        private void btnOk_Click_1(object sender, EventArgs e)
        {
            TheElectronicdevice.brand = tbBrand.Text.Trim();
            TheElectronicdevice.price = int.Parse(tbPrice.Text.Trim());
            TheElectronicdevice.weight = int.Parse(tbWeight.Text.Trim());
            TheElectronicdevice.color = tbColor.Text.Trim();
            TheElectronicdevice.screendiagonal = double.Parse(tbScreendiagonal.Text.Trim());
            TheElectronicdevice.CPUfrequency = double.Parse(tbCPUfrequency.Text.Trim());
            TheElectronicdevice.isthereasimcard = chbisthereasimcard.Checked;
            TheElectronicdevice.isthereamemorycardslot = chbisthereamemorycardslot.Checked;

            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
