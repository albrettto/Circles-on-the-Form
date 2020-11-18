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
            CCircle cirle = new CCircle(e.X, e.Y);
            CreateGraphics().DrawEllipse(new Pen(Color.Azure, 2), cirle.x, cirle.y, 2 * cirle.rad, 2 * cirle.rad);
            
        }
        private void ClearCanvas_Button_Click(object sender, EventArgs e)
        {
            CreateGraphics().Clear(Color.Gray);
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


    //unsafe class Storage
    //{
    //    CCircle** circles;
    //    Storage() { }

    //    void initialisat(int count)
    //    {
    //        circles = new CCircle*[count];
    //        for (int i = 0; i < count; ++i)
    //            circles[i] = null;
    //    }

    //    void add_object(int index, CCircle* circle)
    //    {
    //        circles[index] = circle;
    //    }

    //    //void delete_object(int index)
    //    //{
    //    //    delete circles[index];
    //    //    circles[index] = null;
    //    //}

    //    bool is_empty(int index)
    //    {
    //        if (circles[index] == null)
    //            return true;
    //        else return false;
    //    }

    //    int occupied(int size)
    //    {
    //        int count_occupied = 0;
    //        for (int i = 0; i < size; ++i)
    //            if (!is_empty(i))
    //                ++count_occupied;
    //        return count_occupied;
    //    }

    //    ~Storage()
    //    {

    //    }
    //};
}
