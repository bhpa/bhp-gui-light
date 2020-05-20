﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bhp.UI
{
    public partial class LockUTXODialog : Form
    {
        public LockUTXODialog(DateTime timestamp)
        {
            InitializeComponent();
            if (timestamp > new DateTime())
            {
                this.dateTimePicker1.Value = timestamp;
            }
        }

        public DateTime GetUXTOLockTime { get => this.dateTimePicker1.Value; }
    }//end of class
}
