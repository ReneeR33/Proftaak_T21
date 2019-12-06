using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartBike
{
    public partial class FormAddFingerprint : Form
    {
        public LockMyBike lockMyBike;
        public int selectedIndex;
        public FormAddFingerprint()
        {
            //lockMyBike = LMB;
            //selectedIndex = selected;
            InitializeComponent();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            
        }
    }
}
