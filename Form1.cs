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
    public partial class Main_Form : Form
    {
        public Main_Form()
        {
            InitializeComponent();
        }
        private void Main_Form_MouseDown(object sender, MouseEventArgs e)
        {
            CCircle cirle = new CCircle(/*e.X, e.Y*/);
            this.CreateGraphics().DrawEllipse(new Pen(Color.Red, 3), cirle.x, cirle.y, 2 * cirle.rad, 2 * cirle.rad);
        }
        private void ClearCanvas_Button_Click(object sender, EventArgs e)
        {

        }
        private void ClearStorage_Button_Click(object sender, EventArgs e)
        {

        }
        private void Main_Form_MouseMove(object sender, MouseEventArgs e)
        {
            Cord_Label.Text = "X: " + e.X + "  Y: " + e.Y; 
        }
    }
    public class CCircle
    {
        public int rad = 15;
        public int x, y;
        public CCircle()
        {
            x = 0;
            y = 0;
        }
        public CCircle(int x, int y)
        {
            this.x = x - rad;
            this.y = y - rad;
        }
        ~CCircle() { }
    }
}
