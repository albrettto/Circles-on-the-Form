﻿using System;
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
        private void Canvas_Panel_MouseMove(object sender, MouseEventArgs e)
        {
            Cord_Label.Text = "X: " + e.X + "  Y: " + e.Y;
        }
        private void Main_Form_MouseMove(object sender, MouseEventArgs e)
        {
            Cord_Label.Text = "";
        }
        private void ClearCanvas_Button_Click(object sender, EventArgs e)
        {
            Canvas_Panel.Refresh(); // Перерисовывем панель Canvas_Panel
        }
        private void ClearStorage_Button_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < count_cells; ++i)
                storage.Delete_object(ref i);
            index = 0;
        }
        private void DeleteSelected_Button_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < count_cells; ++i)
                if (storage.Is_empty(i) == false && storage.objects[i].color == Color.Red)
                    storage.Delete_object(ref i);
            ClearCanvas_Button_Click(sender, e);
            ShowCircles_Button_Click(sender, e);
        }
        private void ShowCircles_Button_Click(object sender, EventArgs e)
        {
            if(storage.Occupied(count_cells) != 0)
                for (int i = 0; i < count_cells; ++i)
                    Paint_Circle(ref storage, i);
        }
        private void Paint_Circle(ref Storage storage, int index)
        {   // Рисует круг на панели
            if (storage.objects[index] != null)
            {
                Pen pen = new Pen(storage.objects[index].color, 2);
                Canvas_Panel.CreateGraphics().DrawEllipse(pen, storage.objects[index].x,
                    storage.objects[index].y, storage.objects[index].rad * 2, storage.objects[index].rad * 2);
            }
        }
        private void Remove_Selection(ref Storage storage)
        {
            for (int i = 0; i < count_cells; ++i)
                if (!storage.Is_empty(i))
                {
                    storage.objects[i].color = Color.Azure;
                    Paint_Circle(ref storage, i);
                }
        }

        static int count_cells = 1; // Кол-во ячеек в хранилище
        Storage storage = new Storage(count_cells); // Создаем объект хранилища
        int index = 0; // Индекс элемента в хранилище
        private void Canvas_Panel_MouseDown(object sender, MouseEventArgs e)
        {
            CCircle circle = new CCircle(e.X, e.Y, Color.Azure);
            if (storage.Occupied(count_cells) == count_cells)
                storage.Increase_Storage(ref count_cells);
            int selected_item = Check_Circle(ref storage, count_cells, circle.x, circle.y);
            if (selected_item != -1)
            {
                if (Control.ModifierKeys == Keys.Control)
                {   // Если нажат ctrl, то выделяем выделяем несколько объектов
                    storage.objects[selected_item].color = Color.Red;
                    Paint_Circle(ref storage, selected_item); // Вызываем функцию отрисовки круга
                }
                else
                {   // Иначе выделяем только один объект
                    Remove_Selection(ref storage);
                    storage.objects[selected_item].color = Color.Red;
                    Paint_Circle(ref storage, selected_item); // Вызываем функцию отрисовки круга
                }
                return;
            }
            Remove_Selection(ref storage);
            storage.Add_object(index, ref circle, count_cells); // Добавляем круг в хранилище
            storage.objects[index].color = Color.Red;
            Paint_Circle(ref storage, index); // Вызываем функцию отрисовки круга
            index++;
        }

        private int Check_Circle(ref Storage storage, int size, int x, int y)
        {   // Проверяет есть ли уже круг с такими же координатами в хранилище
            if (storage.Occupied(size) != 0)
            {
                for (int i = 0; i < size; ++i)
                    if (!storage.Is_empty(i))
                    {
                        int x1 = storage.objects[i].x - 15;
                        int x2 = storage.objects[i].x + 15;
                        int y1 = storage.objects[i].y - 15;
                        int y2 = storage.objects[i].y + 15;

                        if ((x1 <= x && x <= x2) && (y1 <= y && y <= y2))
                            return i;
                    }
            }
            return -1;
        }
    }
    public class CCircle
    {
        public int rad = 15;
        public int x, y;
        public Color color = Color.Azure;
        public CCircle()
        {
            x = 0;
            y = 0;
        }
        public CCircle(int x, int y, Color color)
        {
            this.x = x - rad;
            this.y = y - rad;
            this.color = color;
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
            // Ищет свободное место
            while (objects[index] != null)
            {
                index = (index + 1) % amount;
            }
            objects[index] = new_object;
        }

        public void Delete_object(ref int index)
        {   // Удаляет объект из хранилища
            if (objects[index] != null)
            {
                objects[index] = null;
                index--;
            }
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

        public void Increase_Storage(ref int size)
        {
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
