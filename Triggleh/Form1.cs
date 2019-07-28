using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Triggleh
{
    public partial class Form1 : Form, IFormGUI
    {
        private FormPresenter presenter;

        public Form1()
        {
            InitializeComponent();

            // new Bot();
            new Config();

        }

        public void register(FormPresenter FP)
        {
            presenter = FP;
        }
    }
}
