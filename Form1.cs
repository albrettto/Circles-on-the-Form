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
        private void ClearCanvas_Button_Click(object sender, EventArgs e)
        {
            CreateGraphics().Clear(Color.White);
        }
        private void ClearStorage_Button_Click(object sender, EventArgs e)
        {

        }
        private void Canvas_Panel_MouseDown(object sender, MouseEventArgs e)
        {
            CCircle cirle = new CCircle(e.X, e.Y);
            CreateGraphics().DrawEllipse(new Pen(Color.Red, 2), cirle.x, cirle.y, 2 * cirle.rad, 2 * cirle.rad);
        }

        private void Canvas_Panel_MouseMove(object sender, MouseEventArgs e)
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

    class Storage
    {
        public CCircle[] objects;

        public Storage(int amount)
        {   // Конструктор по умолчанию 
            objects = new CCircle[amount];
            for (int i = 0; i < amount; ++i)
                objects[i] = null;
        }

        public void Initialization(int amount)
        {   // Выделяем amount мест в хранилище
            objects = new CCircle[amount];
            for (int i = 0; i < amount; ++i)
                objects[i] = null;
        }

        public void Add_object(int index, ref CCircle new_object, int amount)
        {   // Добавляет ячейку в хранилище
            if (Is_empty(index)) // Если ячейка пуста, добавляет объект
                objects[index] = new_object;
            else
            {   // Иначе ищет свободное место
                while (objects[index] != null)
                {
                    index = (index + 1) % amount;
                }
                objects[index] = new_object;
            }
        }

        public void Delete_object(ref int index)
        {   // Удаляет объект из хранилища
            objects[index] = null;
            index--;
        }

        public bool Is_empty(int index)
        {   // Проверяет занято ли место хранилище
            if (objects[index] == null)
                return true;
            else return false;
        }

        public int Occupied(int size)
        { // Определяет кол-во занятых мест в хранилище
            int count_occupied = 0;
            for (int i = 0; i < size; ++i)
                if (!Is_empty(i))
                    ++count_occupied;
            return count_occupied;
        }

        public void DoubleSize(ref int size)
        {   // Функция для увеличения кол-ва элементов в хранилище в 2 раза 
            Storage new_storage = new Storage(size * 2);
            for (int i = 0; i < size; ++i)
                new_storage.objects[i] = objects[i];
            for (int i = size; i < (size * 2) - 1; ++i)
            {
                new_storage.objects[i] = null;
            }
            size = size * 2;
            Initialization(size);
            for (int i = 0; i < size; ++i)
                objects[i] = new_storage.objects[i];
        }
        ~Storage() { }
    };
}
