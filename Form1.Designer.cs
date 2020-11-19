namespace Circles_on_the_Form
{
    partial class Main_Form
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main_Form));
            this.ClearCanvas_Button = new System.Windows.Forms.Button();
            this.ClearStorage_Button = new System.Windows.Forms.Button();
            this.Cord_Label = new System.Windows.Forms.Label();
            this.Canvas_Panel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // ClearCanvas_Button
            // 
            this.ClearCanvas_Button.BackColor = System.Drawing.Color.GreenYellow;
            this.ClearCanvas_Button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ClearCanvas_Button.ForeColor = System.Drawing.Color.DarkGreen;
            this.ClearCanvas_Button.Location = new System.Drawing.Point(12, 416);
            this.ClearCanvas_Button.Name = "ClearCanvas_Button";
            this.ClearCanvas_Button.Size = new System.Drawing.Size(127, 22);
            this.ClearCanvas_Button.TabIndex = 0;
            this.ClearCanvas_Button.Text = "Очистить полотно";
            this.ClearCanvas_Button.UseVisualStyleBackColor = false;
            this.ClearCanvas_Button.Click += new System.EventHandler(this.ClearCanvas_Button_Click);
            // 
            // ClearStorage_Button
            // 
            this.ClearStorage_Button.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClearStorage_Button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ClearStorage_Button.ForeColor = System.Drawing.Color.MidnightBlue;
            this.ClearStorage_Button.Location = new System.Drawing.Point(145, 416);
            this.ClearStorage_Button.Name = "ClearStorage_Button";
            this.ClearStorage_Button.Size = new System.Drawing.Size(127, 22);
            this.ClearStorage_Button.TabIndex = 1;
            this.ClearStorage_Button.Text = "Очистить хранилище";
            this.ClearStorage_Button.UseVisualStyleBackColor = false;
            this.ClearStorage_Button.Click += new System.EventHandler(this.ClearStorage_Button_Click);
            // 
            // Cord_Label
            // 
            this.Cord_Label.AutoSize = true;
            this.Cord_Label.ForeColor = System.Drawing.Color.Indigo;
            this.Cord_Label.Location = new System.Drawing.Point(713, 9);
            this.Cord_Label.Name = "Cord_Label";
            this.Cord_Label.Size = new System.Drawing.Size(0, 13);
            this.Cord_Label.TabIndex = 2;
            // 
            // Canvas_Panel
            // 
            this.Canvas_Panel.BackColor = System.Drawing.Color.Gray;
            this.Canvas_Panel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Canvas_Panel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Canvas_Panel.Location = new System.Drawing.Point(12, 9);
            this.Canvas_Panel.Name = "Canvas_Panel";
            this.Canvas_Panel.Size = new System.Drawing.Size(695, 401);
            this.Canvas_Panel.TabIndex = 3;
            this.Canvas_Panel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Canvas_Panel_MouseDown);
            this.Canvas_Panel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Canvas_Panel_MouseMove);
            // 
            // Main_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Cord_Label);
            this.Controls.Add(this.ClearStorage_Button);
            this.Controls.Add(this.ClearCanvas_Button);
            this.Controls.Add(this.Canvas_Panel);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Лабораторная работа 4";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ClearCanvas_Button;
        private System.Windows.Forms.Button ClearStorage_Button;
        private System.Windows.Forms.Label Cord_Label;
        private System.Windows.Forms.Panel Canvas_Panel;
    }
}

