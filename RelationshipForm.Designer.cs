namespace ERCreator
{
    partial class RelationshipForm
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
            saveNameButton = new Button();
            label2 = new Label();
            label3 = new Label();
            firstEntityLabel = new Label();
            secondEntityLabel = new Label();
            firstCardinalityComboBox = new ComboBox();
            secondCardinalityComboBox = new ComboBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(40, 15);
            label1.TabIndex = 0;
            label1.Text = "Nome";
            // 
            // nameTextBox
            // 
            nameTextBox.Location = new Point(72, 6);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new Size(121, 23);
            nameTextBox.TabIndex = 1;
            // 
            // saveNameButton
            // 
            saveNameButton.Location = new Point(199, 6);
            saveNameButton.Name = "saveNameButton";
            saveNameButton.Size = new Size(75, 23);
            saveNameButton.TabIndex = 2;
            saveNameButton.Text = "Salva";
            saveNameButton.UseVisualStyleBackColor = true;
            saveNameButton.Click += saveNameButton_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(14, 40);
            label2.Name = "label2";
            label2.Size = new Size(0, 15);
            label2.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(116, 52);
            label3.Name = "label3";
            label3.Size = new Size(64, 15);
            label3.TabIndex = 4;
            label3.Text = "Cardinalità";
            // 
            // firstEntityLabel
            // 
            firstEntityLabel.AutoSize = true;
            firstEntityLabel.Location = new Point(12, 88);
            firstEntityLabel.Name = "firstEntityLabel";
            firstEntityLabel.Size = new Size(48, 15);
            firstEntityLabel.TabIndex = 5;
            firstEntityLabel.Text = "*prima*";
            // 
            // secondEntityLabel
            // 
            secondEntityLabel.AutoSize = true;
            secondEntityLabel.Location = new Point(14, 120);
            secondEntityLabel.Name = "secondEntityLabel";
            secondEntityLabel.Size = new Size(61, 15);
            secondEntityLabel.TabIndex = 6;
            secondEntityLabel.Text = "*seconda*";
            // 
            // firstCardinalityComboBox
            // 
            firstCardinalityComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            firstCardinalityComboBox.Items.AddRange(new object[] { "Zero a uno", "Zero a molti", "Uno a uno", "Uno a molti", "Molti a molti" });
            firstCardinalityComboBox.Location = new Point(153, 80);
            firstCardinalityComboBox.Name = "firstCardinalityComboBox";
            firstCardinalityComboBox.Size = new Size(121, 23);
            firstCardinalityComboBox.TabIndex = 7;
            // 
            // secondCardinalityComboBox
            // 
            secondCardinalityComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            secondCardinalityComboBox.FormattingEnabled = true;
            secondCardinalityComboBox.Items.AddRange(new object[] { "Zero a uno", "Zero a molti", "Uno a uno", "Uno a molti", "Molti a molti" });
            secondCardinalityComboBox.Location = new Point(153, 117);
            secondCardinalityComboBox.Name = "secondCardinalityComboBox";
            secondCardinalityComboBox.Size = new Size(121, 23);
            secondCardinalityComboBox.TabIndex = 8;
            // 
            // RelationshipForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(296, 174);
            Controls.Add(secondCardinalityComboBox);
            Controls.Add(firstCardinalityComboBox);
            Controls.Add(secondEntityLabel);
            Controls.Add(firstEntityLabel);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(saveNameButton);
            Controls.Add(nameTextBox);
            Controls.Add(label1);
            Name = "RelationshipForm";
            Text = "Modifica relazione";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox nameTextBox;
        private Button saveNameButton;
        private Label label2;
        private Label label3;
        private Label firstEntityLabel;
        private Label secondEntityLabel;
        private ComboBox firstCardinalityComboBox;
        private ComboBox secondCardinalityComboBox;
    }
}