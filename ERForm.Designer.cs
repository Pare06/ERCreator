using ERCreator.Controls;

namespace ERCreator
{
    partial class ERForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ERForm));
            elementsPanel = new Panel();
            toSqlButton = new Button();
            settingsButton = new Button();
            entityLabel = new Label();
            menuEntity = new Entity();
            relationshipLabel = new Label();
            menuRelationship = new Relationship();
            entityActionMenu = new ContextMenuStrip(components);
            collegaToolStripMenuItem = new ToolStripMenuItem();
            proprietàToolStripMenuItem = new ToolStripMenuItem();
            eliminaToolStripMenuItem = new ToolStripMenuItem();
            relationshipActionMenu = new ContextMenuStrip(components);
            toolStripMenuItem1 = new ToolStripMenuItem();
            toolStripMenuItem3 = new ToolStripMenuItem();
            toolStripMenuItem4 = new ToolStripMenuItem();
            linkActionMenu = new ContextMenuStrip(components);
            eliminaToolStripMenuItem1 = new ToolStripMenuItem();
            eliminaToolStripMenuItem2 = new ToolStripMenuItem();
            elementsPanel.SuspendLayout();
            entityActionMenu.SuspendLayout();
            relationshipActionMenu.SuspendLayout();
            linkActionMenu.SuspendLayout();
            SuspendLayout();
            // 
            // elementsPanel
            // 
            elementsPanel.BackColor = Color.LightGray;
            elementsPanel.Controls.Add(toSqlButton);
            elementsPanel.Controls.Add(settingsButton);
            elementsPanel.Controls.Add(entityLabel);
            elementsPanel.Controls.Add(menuEntity);
            elementsPanel.Controls.Add(relationshipLabel);
            elementsPanel.Controls.Add(menuRelationship);
            elementsPanel.Location = new Point(12, 12);
            elementsPanel.Name = "elementsPanel";
            elementsPanel.Size = new Size(152, 210);
            elementsPanel.TabIndex = 0;
            // 
            // toSqlButton
            // 
            toSqlButton.Location = new Point(12, 161);
            toSqlButton.Name = "toSqlButton";
            toSqlButton.Size = new Size(113, 23);
            toSqlButton.TabIndex = 5;
            toSqlButton.Text = "Converti in SQL";
            toSqlButton.UseVisualStyleBackColor = true;
            toSqlButton.Click += CreateSQL;
            // 
            // settingsButton
            // 
            settingsButton.Location = new Point(12, 132);
            settingsButton.Name = "settingsButton";
            settingsButton.Size = new Size(113, 23);
            settingsButton.TabIndex = 4;
            settingsButton.Text = "Impostazioni";
            settingsButton.UseVisualStyleBackColor = true;
            settingsButton.Click += settingsButton_Click;
            // 
            // entityLabel
            // 
            entityLabel.AutoSize = true;
            entityLabel.Location = new Point(12, 26);
            entityLabel.Name = "entityLabel";
            entityLabel.Size = new Size(37, 15);
            entityLabel.TabIndex = 2;
            entityLabel.Text = "Entità";
            // 
            // menuEntity
            // 
            menuEntity.Location = new Point(75, 17);
            menuEntity.Name = "menuEntity";
            menuEntity.Size = new Size(63, 35);
            menuEntity.TabIndex = 3;
            // 
            // relationshipLabel
            // 
            relationshipLabel.AutoSize = true;
            relationshipLabel.Location = new Point(12, 73);
            relationshipLabel.Name = "relationshipLabel";
            relationshipLabel.Size = new Size(57, 15);
            relationshipLabel.TabIndex = 0;
            relationshipLabel.Text = "Relazione";
            // 
            // menuRelationship
            // 
            menuRelationship.Location = new Point(75, 58);
            menuRelationship.Name = "menuRelationship";
            menuRelationship.Size = new Size(63, 50);
            menuRelationship.TabIndex = 1;
            // 
            // entityActionMenu
            // 
            entityActionMenu.Items.AddRange(new ToolStripItem[] { collegaToolStripMenuItem, proprietàToolStripMenuItem, eliminaToolStripMenuItem });
            entityActionMenu.Name = "contextMenuStrip1";
            entityActionMenu.Size = new Size(123, 70);
            entityActionMenu.Closed += CloseActionMenu;
            // 
            // collegaToolStripMenuItem
            // 
            collegaToolStripMenuItem.Name = "collegaToolStripMenuItem";
            collegaToolStripMenuItem.Size = new Size(122, 22);
            collegaToolStripMenuItem.Text = "Collega";
            collegaToolStripMenuItem.Click += CreateLinkE;
            // 
            // proprietàToolStripMenuItem
            // 
            proprietàToolStripMenuItem.Name = "proprietàToolStripMenuItem";
            proprietàToolStripMenuItem.Size = new Size(122, 22);
            proprietàToolStripMenuItem.Text = "Proprietà";
            proprietàToolStripMenuItem.Click += EditE;
            // 
            // eliminaToolStripMenuItem
            // 
            eliminaToolStripMenuItem.Name = "eliminaToolStripMenuItem";
            eliminaToolStripMenuItem.Size = new Size(122, 22);
            eliminaToolStripMenuItem.Text = "Elimina";
            eliminaToolStripMenuItem.Click += DeleteER;
            // 
            // relationshipActionMenu
            // 
            relationshipActionMenu.Items.AddRange(new ToolStripItem[] { toolStripMenuItem1, toolStripMenuItem3, toolStripMenuItem4 });
            relationshipActionMenu.Name = "contextMenuStrip1";
            relationshipActionMenu.Size = new Size(181, 92);
            relationshipActionMenu.Closed += CloseActionMenu;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(180, 22);
            toolStripMenuItem1.Text = "Collega";
            toolStripMenuItem1.Click += CreateLinkR;
            // 
            // toolStripMenuItem3
            // 
            toolStripMenuItem3.Name = "toolStripMenuItem3";
            toolStripMenuItem3.Size = new Size(180, 22);
            toolStripMenuItem3.Text = "Proprietà";
            toolStripMenuItem3.Click += EditR;
            // 
            // toolStripMenuItem4
            // 
            toolStripMenuItem4.Name = "toolStripMenuItem4";
            toolStripMenuItem4.Size = new Size(180, 22);
            toolStripMenuItem4.Text = "Elimina";
            toolStripMenuItem4.Click += DeleteER;
            // 
            // linkActionMenu
            // 
            linkActionMenu.Items.AddRange(new ToolStripItem[] { eliminaToolStripMenuItem1, eliminaToolStripMenuItem2 });
            linkActionMenu.Name = "linkActionMenu";
            linkActionMenu.Size = new Size(123, 48);
            // 
            // eliminaToolStripMenuItem1
            // 
            eliminaToolStripMenuItem1.Name = "eliminaToolStripMenuItem1";
            eliminaToolStripMenuItem1.Size = new Size(122, 22);
            eliminaToolStripMenuItem1.Text = "Proprietà";
            // 
            // eliminaToolStripMenuItem2
            // 
            eliminaToolStripMenuItem2.Name = "eliminaToolStripMenuItem2";
            eliminaToolStripMenuItem2.Size = new Size(122, 22);
            eliminaToolStripMenuItem2.Text = "Elimina";
            // 
            // ERForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(775, 450);
            Controls.Add(elementsPanel);
            Name = "ERForm";
            Text = "Creazione schema ER";
            elementsPanel.ResumeLayout(false);
            elementsPanel.PerformLayout();
            entityActionMenu.ResumeLayout(false);
            relationshipActionMenu.ResumeLayout(false);
            linkActionMenu.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel elementsPanel;
        private Label relationshipLabel;
        private Relationship menuRelationship;
        private Label entityLabel;
        private Entity menuEntity;
        private Button settingsButton;
        public ContextMenuStrip entityActionMenu;
        private ToolStripMenuItem collegaToolStripMenuItem;
        private ToolStripMenuItem proprietàToolStripMenuItem;
        private ToolStripMenuItem eliminaToolStripMenuItem;
        public ContextMenuStrip relationshipActionMenu;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem toolStripMenuItem3;
        private ToolStripMenuItem toolStripMenuItem4;
        public ContextMenuStrip linkActionMenu;
        private ToolStripMenuItem eliminaToolStripMenuItem1;
        private ToolStripMenuItem eliminaToolStripMenuItem2;
        private Button toSqlButton;
    }
}
