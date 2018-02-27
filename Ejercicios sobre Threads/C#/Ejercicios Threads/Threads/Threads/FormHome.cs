// Written By Ismael Heredia in the year 2016

using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Threading;

namespace Threads
{
    public partial class FormHome : Form
    {

        ArrayList listaThreads = new ArrayList();

        public FormHome()
        {
            InitializeComponent();
        }

        public void WorkThreadFunction(string valor)
        {
            Thread.Sleep(5000);
            this.Invoke((MethodInvoker)delegate
            {
                txtTexto.AppendText("Thread ejecutado : " + valor + "\n");
            });
        }

        private void btnTest_Click(object sender, EventArgs e)
        {

            Thread thread1 = new Thread(() => WorkThreadFunction("1"));
            thread1.Start();
            Thread thread2 = new Thread(() => WorkThreadFunction("2"));
            thread2.Start();

            MessageBox.Show("Threads Lanzado");
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 5; i++)
            {
                Thread thread1 = new Thread(() => WorkThreadFunction(i.ToString()));
                thread1.Start();
                listaThreads.Add(thread1);
            }

            MessageBox.Show("Start");
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            foreach (Thread thread in listaThreads)
            {
                thread.Abort();
            }

            MessageBox.Show("Stop");
        }
    }
}
