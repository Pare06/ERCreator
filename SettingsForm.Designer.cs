namespace ERCreator
{
    partial class SettingsForm
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
            colorDialog = new ColorDialog();
            entityColorButton = new Button();
            relationshipColorButton = new Button();
            linkColorButton = new Button();
            closeButton = new Button();
            entityPicture = new PictureBox();
            relationshipPicture = new PictureBox();
            linkPicture = new PictureBox();
            attributeColorButton = new Button();
            attributePicture = new PictureBox();
            label2 = new Label();
            respectConventionsCheckBox = new CheckBox();
            useTabsCheckBox = new CheckBox();
            autoCorrectCheckBox = new CheckBox();
            label3 = new Label();
            fontColorButton = new Button();
            fontPicture = new PictureBox();
            label5 = new Label();
            fontTextBox = new TextBox();
            fontSaveButton = new Button();
            ((System.ComponentModel.ISupportInitialize)entityPicture).BeginInit();
            ((System.ComponentModel.ISupportInitialize)relationshipPicture).BeginInit();
            ((System.ComponentModel.ISupportInitialize)linkPicture).BeginInit();
            ((System.ComponentModel.ISupportInitialize)attributePicture).BeginInit();
            ((System.ComponentModel.ISupportInitialize)fontPicture).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(57, 9);
            label1.Name = "label1";
            label1.Size = new Size(39, 15);
            label1.TabIndex = 0;
            label1.Text = "Colori";
            // 
            // entityColorButton
            // 
            entityColorButton.Location = new Point(22, 40);
            entityColorButton.Name = "entityColorButton";
            entityColorButton.Size = new Size(103, 23);
            entityColorButton.TabIndex = 1;
            entityColorButton.Text = "Entità";
            entityColorButton.UseVisualStyleBackColor = true;
            entityColorButton.Click += entityColorButton_Click;
            // 
            // relationshipColorButton
            // 
            relationshipColorButton.Location = new Point(22, 86);
            relationshipColorButton.Name = "relationshipColorButton";
            relationshipColorButton.Size = new Size(103, 23);
            relationshipColorButton.TabIndex = 2;
            relationshipColorButton.Text = "Relazioni";
            relationshipColorButton.UseVisualStyleBackColor = true;
            relationshipColorButton.Click += relationshipColorButton_Click;
            // 
            // linkColorButton
            // 
            linkColorButton.Location = new Point(22, 132);
            linkColorButton.Name = "linkColorButton";
            linkColorButton.Size = new Size(103, 23);
            linkColorButton.TabIndex = 3;
            linkColorButton.Text = "Collegamenti";
            linkColorButton.UseVisualStyleBackColor = true;
            linkColorButton.Click += linkColorButton_Click;
            // 
            // closeButton
            // 
            closeButton.Location = new Point(223, 220);
            closeButton.Name = "closeButton";
            closeButton.Size = new Size(75, 23);
            closeButton.TabIndex = 4;
            closeButton.Text = "Chiudi";
            closeButton.UseVisualStyleBackColor = true;
            closeButton.Click += closeButton_Click;
            // 
            // entityPicture
            // 
            entityPicture.Location = new Point(131, 40);
            entityPicture.Name = "entityPicture";
            entityPicture.Size = new Size(23, 23);
            entityPicture.TabIndex = 5;
            entityPicture.TabStop = false;
            // 
            // relationshipPicture
            // 
            relationshipPicture.Location = new Point(131, 86);
            relationshipPicture.Name = "relationshipPicture";
            relationshipPicture.Size = new Size(23, 23);
            relationshipPicture.TabIndex = 6;
            relationshipPicture.TabStop = false;
            // 
            // linkPicture
            // 
            linkPicture.Location = new Point(131, 132);
            linkPicture.Name = "linkPicture";
            linkPicture.Size = new Size(23, 23);
            linkPicture.TabIndex = 7;
            linkPicture.TabStop = false;
            // 
            // attributeColorButton
            // 
            attributeColorButton.Location = new Point(22, 175);
            attributeColorButton.Name = "attributeColorButton";
            attributeColorButton.Size = new Size(103, 23);
            attributeColorButton.TabIndex = 8;
            attributeColorButton.Text = "Attributi";
            attributeColorButton.UseVisualStyleBackColor = true;
            attributeColorButton.Click += attributeColorButton_Click;
            // 
            // attributePicture
            // 
            attributePicture.Location = new Point(131, 175);
            attributePicture.Name = "attributePicture";
            attributePicture.Size = new Size(23, 23);
            attributePicture.TabIndex = 9;
            attributePicture.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(238, 9);
            label2.Name = "label2";
            label2.Size = new Size(28, 15);
            label2.TabIndex = 10;
            label2.Text = "SQL";
            // 
            // respectConventionsCheckBox
            // 
            respectConventionsCheckBox.AutoSize = true;
            respectConventionsCheckBox.Location = new Point(215, 43);
            respectConventionsCheckBox.Name = "respectConventionsCheckBox";
            respectConventionsCheckBox.Size = new Size(135, 19);
            respectConventionsCheckBox.TabIndex = 11;
            respectConventionsCheckBox.Text = "Rispetta convenzioni";
            respectConventionsCheckBox.UseVisualStyleBackColor = true;
            respectConventionsCheckBox.Click += respectConventionsCheckBox_Click;
            // 
            // useTabsCheckBox
            // 
            useTabsCheckBox.AutoSize = true;
            useTabsCheckBox.Location = new Point(215, 89);
            useTabsCheckBox.Name = "useTabsCheckBox";
            useTabsCheckBox.Size = new Size(83, 19);
            useTabsCheckBox.TabIndex = 12;
            useTabsCheckBox.Text = "Utilizza tab";
            useTabsCheckBox.UseVisualStyleBackColor = true;
            useTabsCheckBox.CheckedChanged += useTabsCheckBox_CheckedChanged;
            // 
            // autoCorrectCheckBox
            // 
            autoCorrectCheckBox.AutoSize = true;
            autoCorrectCheckBox.Location = new Point(215, 127);
            autoCorrectCheckBox.Name = "autoCorrectCheckBox";
            autoCorrectCheckBox.Size = new Size(202, 19);
            autoCorrectCheckBox.TabIndex = 13;
            autoCorrectCheckBox.Text = "Correggi automaticamente entità";
            autoCorrectCheckBox.UseVisualStyleBackColor = true;
            autoCorrectCheckBox.CheckedChanged += autoCorrectCheckBox_CheckedChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(440, 9);
            label3.Name = "label3";
            label3.Size = new Size(85, 15);
            label3.TabIndex = 14;
            label3.Text = "Visualizzazione";
            // 
            // fontColorButton
            // 
            fontColorButton.Location = new Point(22, 220);
            fontColorButton.Name = "fontColorButton";
            fontColorButton.Size = new Size(103, 23);
            fontColorButton.TabIndex = 15;
            fontColorButton.Text = "Testo";
            fontColorButton.UseVisualStyleBackColor = true;
            fontColorButton.Click += fontColorButton_Click;
            // 
            // fontPicture
            // 
            fontPicture.Location = new Point(131, 220);
            fontPicture.Name = "fontPicture";
            fontPicture.Size = new Size(23, 23);
            fontPicture.TabIndex = 16;
            fontPicture.TabStop = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(422, 44);
            label5.Name = "label5";
            label5.Size = new Size(31, 15);
            label5.TabIndex = 19;
            label5.Text = "Font";
            // 
            // fontTextBox
            // 
            fontTextBox.Location = new Point(459, 39);
            fontTextBox.Name = "fontTextBox";
            fontTextBox.Size = new Size(100, 23);
            fontTextBox.TabIndex = 20;
            // 
            // fontSaveButton
            // 
            fontSaveButton.Location = new Point(580, 38);
            fontSaveButton.Name = "fontSaveButton";
            fontSaveButton.Size = new Size(51, 23);
            fontSaveButton.TabIndex = 21;
            fontSaveButton.Text = "Salva";
            fontSaveButton.UseVisualStyleBackColor = true;
            fontSaveButton.Click += fontSaveButton_Click;
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(653, 282);
            Controls.Add(fontSaveButton);
            Controls.Add(fontTextBox);
            Controls.Add(label5);
            Controls.Add(fontPicture);
            Controls.Add(fontColorButton);
            Controls.Add(label3);
            Controls.Add(autoCorrectCheckBox);
            Controls.Add(useTabsCheckBox);
            Controls.Add(respectConventionsCheckBox);
            Controls.Add(label2);
            Controls.Add(attributePicture);
            Controls.Add(attributeColorButton);
            Controls.Add(linkPicture);
            Controls.Add(relationshipPicture);
            Controls.Add(entityPicture);
            Controls.Add(closeButton);
            Controls.Add(linkColorButton);
            Controls.Add(relationshipColorButton);
            Controls.Add(entityColorButton);
            Controls.Add(label1);
            Name = "SettingsForm";
            Text = "Impostazioni";
            ((System.ComponentModel.ISupportInitialize)entityPicture).EndInit();
            ((System.ComponentModel.ISupportInitialize)relationshipPicture).EndInit();
            ((System.ComponentModel.ISupportInitialize)linkPicture).EndInit();
            ((System.ComponentModel.ISupportInitialize)attributePicture).EndInit();
            ((System.ComponentModel.ISupportInitialize)fontPicture).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ColorDialog colorDialog;
        private Button entityColorButton;
        private Button relationshipColorButton;
        private Button linkColorButton;
        private Button closeButton;
        private PictureBox entityPicture;
        private PictureBox relationshipPicture;
        private PictureBox linkPicture;
        private Button attributeColorButton;
        private PictureBox attributePicture;
        private Label label2;
        private CheckBox respectConventionsCheckBox;
        private CheckBox useTabsCheckBox;
        private CheckBox autoCorrectCheckBox;
        private Label label3;
        private Button fontColorButton;
        private PictureBox fontPicture;
        private Label label5;
        private TextBox fontTextBox;
        private Button fontSaveButton;
    }
}