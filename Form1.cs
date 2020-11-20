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
        private void Canvas_Panel_MouseMove(object sender, MouseEventArgs e)
        {// Показывает координаты точки при передвижении курсора по полотну
            Cord_Label.Text = "X: " + e.X + "  Y: " + e.Y;
        }
        private void Main_Form_MouseMove(object sender, MouseEventArgs e)
        {// Очищает лэйбл при передвижении курсора по форме
            Cord_Label.Text = "";
        }
        private void ClearCanvas_Button_Click(object sender, EventArgs e)
        {// Очищает полотно
            Canvas_Panel.Refresh(); // Перерисовывем панель Canvas_Panel
            for (int i = 0; i < count_cells; ++i)
                if (!storage.Is_empty(i))
                {
                    storage.objects[i].is_drawed = false; // Для элемента ставим флаг - не нарисован
                    storage.objects[i].color = default_color; // Ставим цвет по умолчанию
                }
        }
        private void ClearStorage_Button_Click(object sender, EventArgs e)
        {// Очищает хранилище от всех элементов
            for (int i = 0; i < count_cells; ++i)
                storage.Delete_object(ref i); // Удаляем объект из хранилища
            count_elements = 0; // Кол-во элементов в хранилище обнуляем 
        }
        private void DeleteSelected_Button_Click(object sender, EventArgs e)
        {
            if (storage.Occupied(count_cells) != 0)
                for (int i = 0; i < count_cells; ++i)
                    // Если элемент существует и он окрашен в цвет выбранных элементов
                    if (storage.Is_empty(i) == false && storage.objects[i].color == selected_color)
                        storage.Delete_object(ref i); // Удаляет объект из хранилища
            ClearCanvas_Button_Click(sender, e); // Очищает полотно
            ShowCircles_Button_Click(sender, e); // Показывает все круги из хранилища
        }
        private void ShowCircles_Button_Click(object sender, EventArgs e)
        {// Показывает все круги из хранилища
            // Если хранилище не пустое
            if (storage.Occupied(count_cells) != 0)
                for (int i = 0; i < count_cells; ++i)
                {
                    Paint_Circle(ref storage, i); // Рисует круг
                    if (!storage.Is_empty(i))
                        storage.objects[i].is_drawed = true; // Для элемента ставим флаг - нарисован
                }
        }
        private void Paint_Circle(ref Storage storage, int count_elements)
        {// Рисует круг на панели
            // Если ячейка хранилища не пуста
            if (storage.objects[count_elements] != null)
            {
                Pen pen = new Pen(storage.objects[count_elements].color, 2);
                Canvas_Panel.CreateGraphics().DrawEllipse(pen, storage.objects[count_elements].x,
                    storage.objects[count_elements].y, storage.objects[count_elements].rad * 2, storage.objects[count_elements].rad * 2);
            }
        }
        private void Remove_Selection(ref Storage storage)
        {//Убирает выделение объектов
            for (int i = 0; i < count_cells; ++i)
                if (!storage.Is_empty(i))
                {
                    storage.objects[i].color = default_color; // Устанавливает стандартный цвет
                    if (storage.objects[i].is_drawed == true) // Если флаг  = нарисован
                        Paint_Circle(ref storage, i); // Рисует круг
                }
        }

        static int count_cells = 1; // Кол-во ячеек в хранилище
        Storage storage = new Storage(count_cells); // Создаем объект хранилища
        int count_elements = 0; // Кол-во элементов в хранилище
        static readonly Color default_color = Color.Azure; // Цвет по умолчанию
        readonly Color selected_color = Color.Red; // Цвет выбранных элементов
        int indexin = 0; // Индекс, в какое место был помещён круг
        bool ctrl_is_pressed = false;

        private void Canvas_Panel_MouseDown(object sender, MouseEventArgs e)
        {//Обработчик нажатия на полотно
            // Создаём объект класса Круг
            CCircle circle = new CCircle(e.X, e.Y, default_color);
            // Если кол-во элементов в хранилище = кол-ву ячеек
            if (count_elements == count_cells)
                // Увеличиваем хранилище
                storage.Increase_Storage(ref count_cells);
            // Получаем индекс элемента
            int selected_item = Check_Circle(ref storage, count_cells, circle.x, circle.y);
            if (selected_item != -1)
            {
                if (Control.ModifierKeys == Keys.Control)
                {   // Если нажат ctrl, то выделяем несколько объектов
                    if (ctrl_is_pressed == false)
                    {
                        storage.objects[selected_item].color = selected_color;
                        Paint_Circle(ref storage, indexin);
                        ctrl_is_pressed = true;
                    }
                    storage.objects[selected_item].color = selected_color;
                    // Вызываем функцию отрисовки круга
                    Paint_Circle(ref storage, selected_item);
                }
                else
                {   // Иначе выделяем только один объект
                    // Снимаем выделение у всех объектов хранилища
                    int x = e.X - circle.rad;
                    int y = e.Y - circle.rad;
                    Remove_Selection(ref storage);
                    for (int i = 0; i < count_cells; ++i)
                        if(!storage.Is_empty(i))
                        {
                            int x1 = storage.objects[i].x - storage.objects[i].rad;
                            int x2 = storage.objects[i].x + storage.objects[i].rad;
                            int y1 = storage.objects[i].y - storage.objects[i].rad;
                            int y2 = storage.objects[i].y + storage.objects[i].rad;

                            if ((x1 <= x && x <= x2) && (y1 <= y && y <= y2))
                            {
                                storage.objects[i].color = selected_color;
                                Paint_Circle(ref storage, i);
                            }
                        }
                    
                    // Вызываем функцию отрисовки круга
                    storage.objects[selected_item].color = selected_color;
                    Paint_Circle(ref storage, selected_item);
                }
                return;
            }
            // Добавляем круг в хранилище
            storage.Add_object(count_elements, ref circle, count_cells, ref indexin);
            // Снимаем выделение у всех объектов хранилища
            Remove_Selection(ref storage);
            storage.objects[indexin].color = selected_color;
            // Вызываем функцию отрисовки круга
            Paint_Circle(ref storage, indexin);
            ++count_elements;
            ctrl_is_pressed = false;
        }
private int Check_Circle(ref Storage storage, int size, int x, int y)
        { // Проверяет есть ли уже круг с такими же координатами в хранилище
            if (storage.Occupied(size) != 0)
            {
                for (int i = 0; i < size; ++i)
                    if (!storage.Is_empty(i))
                    {
                        int x1 = storage.objects[i].x - storage.objects[i].rad;
                        int x2 = storage.objects[i].x + storage.objects[i].rad;
                        int y1 = storage.objects[i].y - storage.objects[i].rad;
                        int y2 = storage.objects[i].y + storage.objects[i].rad;

                        if ((x1 <= x && x <= x2) && (y1 <= y && y <= y2))
                            return i;
                    }
            }
            return -1;
        }

        public class CCircle
        {
            public int rad = 30; // Постоянный радиус
            public int x, y;
            public bool is_drawed = true; // Провекра на нарисованность на полотне
            public Color color = default_color; // Устанавливаем цвет по умолчанию
            public CCircle() // Конструктор по умолчанию
            {
                x = 0;
                y = 0;
            }
            public CCircle(int x, int y, Color color) // Конструктор с параметрами
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
            public void Add_object(int ind, ref CCircle new_object, int count, ref int indexin)
            {   // Добавляет ячейку в хранилище
                // Если ячейка занята ищем свободное место
                while (objects[ind] != null)
                {
                    ind = (ind + 1) % count;
                }
                objects[ind] = new_object;
                indexin = ind;
            }
            public void Delete_object(ref int count_elements)
            {   // Удаляет объект из хранилища
                if (objects[count_elements] != null)
                {
                    objects[count_elements] = null;
                    count_elements--;
                }
            }
            public bool Is_empty(int count_elements)
            {   // Проверяет занято ли место в хранилище
                if (objects[count_elements] == null)
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
            { // Увеличивает хранилище в 2 раза
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
}
