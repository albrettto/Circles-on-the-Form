using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Circles_on_the_Form
{
    public class CCircle
    {
        public int rad = 5;
        public int x, y;
        public CCircle()
        {
            x = 0 + rad;
            y = 0 + rad;
        }
        public CCircle(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        ~CCircle() { }
    }

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
    }
}
