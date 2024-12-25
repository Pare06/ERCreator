namespace ERCreator
{
    partial class EntityForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            nameTextBox = new TextBox();
            label2 = new Label();
            createAttributeButton = new Button();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            saveEntityButton = new Button();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 10);
            label1.Name = "label1";
            label1.Size = new Size(40, 15);
            label1.TabIndex = 0;
            label1.Text = "Nome";
            // 
            // nameTextBox
            // 
            nameTextBox.Location = new Point(72, 6);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new Size(259, 23);
            nameTextBox.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(208, 44);
            label2.Name = "label2";
            label2.Size = new Size(51, 15);
            label2.TabIndex = 2;
            label2.Text = "Attributi";
            // 
            // createAttributeButton
            // 
            createAttributeButton.Location = new Point(198, 103);
            createAttributeButton.Name = "createAttributeButton";
            createAttributeButton.Size = new Size(75, 23);
            createAttributeButton.TabIndex = 3;
            createAttributeButton.Text = "Aggiungi";
            createAttributeButton.UseVisualStyleBackColor = true;
            createAttributeButton.Click += CreateAttribute;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 70);
            label3.Name = "label3";
            label3.Size = new Size(40, 15);
            label3.TabIndex = 4;
            label3.Text = "Nome";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 7F);
            label4.Location = new Point(102, 70);
            label4.Name = "label4";
            label4.Size = new Size(41, 12);
            label4.TabIndex = 5;
            label4.Text = "Primario";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 7F);
            label5.Location = new Point(149, 70);
            label5.Name = "label5";
            label5.Size = new Size(50, 12);
            label5.TabIndex = 6;
            label5.Text = "Opzionale";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(242, 68);
            label6.Name = "label6";
            label6.Size = new Size(31, 15);
            label6.TabIndex = 7;
            label6.Text = "Tipo";
            // 
            // saveEntityButton
            // 
            saveEntityButton.Location = new Point(350, 5);
            saveEntityButton.Name = "saveEntityButton";
            saveEntityButton.Size = new Size(75, 23);
            saveEntityButton.TabIndex = 0;
            saveEntityButton.Text = "Salva";
            saveEntityButton.UseVisualStyleBackColor = true;
            saveEntityButton.Click += SaveEntity;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 7F);
            label7.Location = new Point(329, 61);
            label7.Name = "label7";
            label7.Size = new Size(56, 24);
            label7.TabIndex = 8;
            label7.Text = "Incremento\r\nautomatico";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(391, 69);
            label8.Name = "label8";
            label8.Size = new Size(63, 15);
            label8.TabIndex = 9;
            label8.Text = "Lunghezza";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(471, 70);
            label9.Name = "label9";
            label9.Size = new Size(52, 15);
            label9.TabIndex = 10;
            label9.Text = "Multiplo";
            // 
            // EntityForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(549, 161);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(saveEntityButton);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(createAttributeButton);
            Controls.Add(label2);
            Controls.Add(nameTextBox);
            Controls.Add(label1);
            Name = "EntityForm";
            Text = "Modifica entità";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox nameTextBox;
        private Label label2;
        private Button createAttributeButton;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Button saveEntityButton;
        private Label label7;
        private Label label8;
        private Label label9;
    }
}