using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _20._04._23_HW
{
    public partial class Form1 : Form
    {
        Process[] processes;
        Process proc;
        public Form1()
        {
            InitializeComponent();
            Text = "Диспетчер задач";
            listView1.Columns.Add("Имя процесса");
            listView1.Columns[0].Width = listView1.Width - 81;
            listView1.Columns.Add("ID");
            processes = Process.GetProcesses();
            foreach (Process process in processes)
            {
                ListViewItem item = new ListViewItem(process.ProcessName);
                item.SubItems.Add(process.Id.ToString());
                listView1.Items.Add(item);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            proc = new Process();
            proc.StartInfo.FileName = textBox1.Text;
            proc.Start();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            processes = Process.GetProcesses();
            foreach (Process process in processes)
            {
                ListViewItem item = new ListViewItem(process.ProcessName);
                item.SubItems.Add(process.Id.ToString());
                listView1.Items.Add(item);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int processId = int.Parse(listView1.SelectedItems[0].SubItems[1].Text);
            Process process = Process.GetProcessById(processId);
            process.Kill();
        }
    }
}