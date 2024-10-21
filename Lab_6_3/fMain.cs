using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_6_3
{
    public partial class fMain : Form
    {
        public fMain()
        {
            InitializeComponent();
        }


        private void fMain_Load(object sender, EventArgs e)
        {
            gvTablets.AutoGenerateColumns = false;

            DataGridViewColumn column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "brand";
            column.Name = "Бренд";
            gvTablets.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "price";
            column.Name = "Ціна, грн";
            gvTablets.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "weight";
            column.Name = "Вага, г";
            gvTablets.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "color";
            column.Name = "Колір";
            gvTablets.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "screendiagonal";
            column.Name = "Діагональ екрана, ''";
            gvTablets.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "CPUfrequency";
            column.Name = "Частота процесора, ГГц";
            gvTablets.Columns.Add(column);

            column = new DataGridViewCheckBoxColumn();
            column.DataPropertyName = "isthereasimcard";
            column.Name = "Sim-карта";
            column.Width = 60;
            gvTablets.Columns.Add(column);

            column = new DataGridViewCheckBoxColumn();
            column.DataPropertyName = "isthereamemorycardslot";
            column.Name = "Слот для карти пам'яті";
            column.Width = 60;
            gvTablets.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "discountedPrice";
            column.Name = "Ціна зі знижкою 30%, грн";
            gvTablets.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "discountwitharegularcustomercard";
            column.Name = "Ціна зі знижкою 30% та знижкою постійного клієнта, грн";
            gvTablets.Columns.Add(column);


            bindSrcTablets.Add(new Tablet("Acer", 20000, 540, "Black", 9.8, 2.1, true, true, 20000, 20000));
            EventArgs args = new EventArgs(); OnResize(args);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Electronicdevice electronicdevice = new Tablet();

            fTablet ft = new fTablet(electronicdevice);
            if (ft.ShowDialog() == DialogResult.OK)
            {
                bindSrcTablets.Add(electronicdevice);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Electronicdevice electronicdevice = (Electronicdevice)bindSrcTablets.List[bindSrcTablets.Position];

            fTablet ft = new fTablet(electronicdevice);
            if (ft.ShowDialog() ==DialogResult.OK) 
            {
                bindSrcTablets.List[bindSrcTablets.Position] = electronicdevice;
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Видалити поточний запис?", "Видалення запису", 
                MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                bindSrcTablets.RemoveCurrent();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Очистити таблицю?\n\nВсі дані будуть втрачені", "Очищення даних", 
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                bindSrcTablets.Clear();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Закрити застосунок?", "Вихід з програми", MessageBoxButtons.OKCancel, 
                MessageBoxIcon.Question) == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void fMain_Resize(object sender, EventArgs e)
        {
            int buttonsSize = 9 * btnAdd.Width + 3 * tsSeparator1.Width + 30;
            btnExit.Margin = new Padding(Width - buttonsSize, 0, 0, 0); 
        }

        private void btnSaveAsText_Click(object sender, EventArgs e)
        {
            saveFileDialog.Filter = "Текстові файли (*.txt) |*.txt|All files (*.*) |*.*";
            saveFileDialog.Title = "Зберегти дані у текстовому форматі";
            saveFileDialog.InitialDirectory = Application.StartupPath;
            StreamWriter sw;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                sw = new StreamWriter(saveFileDialog.FileName, false, Encoding.UTF8);
                try
                {
                    foreach (Electronicdevice electronicdevice in bindSrcTablets.List)
                    {
                        sw.Write(electronicdevice.brand + "\t" + electronicdevice.price + "\t" +
                            electronicdevice.weight + "\t" + electronicdevice.color + "\t" +
                            electronicdevice.screendiagonal + "\t" + electronicdevice.CPUfrequency +
                            "\t" + electronicdevice.isthereasimcard + "\t" + electronicdevice.isthereamemorycardslot + "\t" + electronicdevice.discountedPrice + "\t" + 
                            electronicdevice.discountwitharegularcustomercard + "\t\n");
                    }
                }
                catch (Exception ex) 
                {
                    MessageBox.Show("Сталась помилка: \n{0}", ex.Message,
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally 
                { 
                    sw.Close();
                }
            }
        }

        private void btnSaveAsBinary_Click(object sender, EventArgs e)
        {
            saveFileDialog.Filter = "Файли даних (*.tablets) |*.tablets|All files (*.*) |*.*";
            saveFileDialog.Title = "Зберегти дані у бінарному форматі";
            saveFileDialog.InitialDirectory = Application.StartupPath;
            BinaryWriter bw;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                bw = new BinaryWriter(saveFileDialog.OpenFile());
                try
                {
                    foreach (Electronicdevice electronicdevice in bindSrcTablets.List)
                    {
                        bw.Write(electronicdevice.brand);
                        bw.Write(electronicdevice.price);
                        bw.Write(electronicdevice.weight);
                        bw.Write(electronicdevice.color);
                        bw.Write(electronicdevice.screendiagonal);
                        bw.Write(electronicdevice.CPUfrequency);
                        bw.Write(electronicdevice.isthereasimcard);
                        bw.Write(electronicdevice.isthereamemorycardslot);
                        bw.Write(electronicdevice.discountedPrice);
                        bw.Write(electronicdevice.discountwitharegularcustomercard);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Сталась помилка: \n{0}", ex.Message,
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    bw.Close();
                }
            }
        }

        private void btnOpenFromText_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Текстові файли (*.txt) |*.txt|All files (*.*) |*.*";
            openFileDialog.Title = "Прочитати дані у текстовому форматі";
            openFileDialog.InitialDirectory = Application.StartupPath;
            StreamReader sr;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                bindSrcTablets.Clear();
                sr = new StreamReader(openFileDialog.FileName, Encoding.UTF8);
                string s;
                try
                {
                    while ((s = sr.ReadLine()) != null)
                    {
                        string[] split = s.Split('\t');
                        Electronicdevice electronicdevice = new Tablet(split[0], int.Parse(split[1]), int.Parse(split[2]),
                            split[3], double.Parse(split[4]), double.Parse(split[5]), bool.Parse(split[6]),
                            bool.Parse(split[7]), double.Parse(split[8]), double.Parse(split[9]));
                        bindSrcTablets.Add(electronicdevice);
                    }
                }
                catch (Exception ex) 
                {
                    MessageBox.Show("Сталась помилка: \n{0}", ex.Message,
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    sr.Close();
                }
            }
        }

        private void btnOpenFromBinary_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Файли даних (*.tablets) |*.tablets|All files (*.*) |*.*";
            openFileDialog.Title = "Прочитати дані у бінарному форматі";
            openFileDialog.InitialDirectory = Application.StartupPath;
            BinaryReader br;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                bindSrcTablets.Clear();
                br = new BinaryReader(openFileDialog.OpenFile());
                try
                {
                    Electronicdevice electronicdevice; while (br.BaseStream.Position < br.BaseStream.Length)
                    {
                        electronicdevice = new Tablet();
                        for (int i = 1; i<=10; i++)
                        {
                            switch (i)
                            {
                                case 1:
                                    electronicdevice.brand = br.ReadString(); break;
                                case 2:
                                    electronicdevice.price = br.ReadInt32(); break;
                                case 3:
                                    electronicdevice.weight = br.ReadInt32(); break;
                                case 4:
                                    electronicdevice.color = br.ReadString(); break;
                                case 5: 
                                    electronicdevice.screendiagonal = br.ReadDouble(); break;
                                case 6:
                                    electronicdevice.CPUfrequency = br.ReadDouble(); break;
                                case 7:
                                    electronicdevice.isthereasimcard = br.ReadBoolean(); break;
                                case 8:
                                    electronicdevice.isthereamemorycardslot = br.ReadBoolean(); break;
                                case 9:
                                    electronicdevice.discountedPrice = br.ReadDouble(); break;
                                case 10:
                                    electronicdevice.discountwitharegularcustomercard = br.ReadDouble(); break;
                            }
                        }
                        bindSrcTablets.Add(electronicdevice);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Сталась помилка: \n{0}", ex.Message, 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    br.Close();
                }
            }
        }
    }
}
