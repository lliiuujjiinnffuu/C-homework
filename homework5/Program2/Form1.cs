using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Program2
{
    public partial class Form1 : Form
    {
        CreateForm createForm = new CreateForm();
        SetForm setForm = new SetForm();
        public Form1()
        {
            InitializeComponent();
            createForm.MdiParent = this;
            setForm.MdiParent = this;
            createForm.FormBorderStyle = FormBorderStyle.None;
            setForm.FormBorderStyle = FormBorderStyle.None;
            setForm.Parent = panel1;
            createForm.Parent = panel1;
            setForm.Show();
            createForm.Show();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (createForm.IsDisposed)
            {
                createForm = new CreateForm();
                createForm.MdiParent = this;
            }
            createForm.BringToFront();
            createForm.Draw();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (setForm.IsDisposed)
            {
                SetForm setForm = new SetForm();
                setForm.MdiParent = this;
            }
            setForm.BringToFront();
            setForm.Show();
        }

        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setForm.Reset();
            createForm.Refresh();
            createForm.BringToFront();
            createForm.Draw();
        }
        private void ToolStripMenuItem_Click1(object sender, EventArgs e)
        {
            setForm.RandomSet();
            createForm.Refresh();
            createForm.BringToFront();
            createForm.Draw();
        }
    }
}

