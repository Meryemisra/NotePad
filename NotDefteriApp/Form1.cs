using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace NotDefteriApp
{
    public partial class Form1 : Form
    {
        private string currentFilePath = string.Empty;

        public Form1()
        {
            InitializeComponent();
        }

        private void yeniToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            currentFilePath = string.Empty;
            this.Text = "Yeni Belge - Not Defteri";
        }

        private void açToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Metin Dosyaları|*.txt|Tüm Dosyalar|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = File.ReadAllText(ofd.FileName);
                currentFilePath = ofd.FileName;
                this.Text = Path.GetFileName(currentFilePath) + " - Not Defteri";
            }
        }

        private void kaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(currentFilePath))
            {
                FarkliKaydet();
            }
            else
            {
                File.WriteAllText(currentFilePath, textBox1.Text);
            }
        }

        private void farklıKaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FarkliKaydet();
        }

        private void FarkliKaydet()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Metin Dosyaları|*.txt|Tüm Dosyalar|*.*";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(sfd.FileName, textBox1.Text);
                currentFilePath = sfd.FileName;
                this.Text = Path.GetFileName(currentFilePath) + " - Not Defteri";
            }
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void geriAlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Undo();
        }

        private void kesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Cut();
        }

        private void kopyalaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Copy();
        }

        private void yapıştırToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Paste();
        }

        private void hepsiniSeçToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.SelectAll();
        }

        private void hakkındaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Basit Not Defteri Uygulaması\nYapan: irem GPT", "Hakkında", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
