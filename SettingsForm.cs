namespace ERCreator;

public partial class SettingsForm : Form
{
    public SettingsForm()
    {
        InitializeComponent();
        UpdateSettings();
    }

    private void UpdateSettings()
    {
        // carica i colori dalle impostazioni
        entityPicture.BackColor = Settings.EntityColor;
        relationshipPicture.BackColor = Settings.RelationshipColor;
        linkPicture.BackColor = Settings.LinkColor;
        attributePicture.BackColor = Settings.AttributeColor;
        fontPicture.BackColor = Settings.FontColor;
        respectConventionsCheckBox.Checked = Settings.RespectConventions;
        useTabsCheckBox.Checked = Settings.UseTabs;
        autoCorrectCheckBox.Checked = Settings.AutoCorrect;
        fontTextBox.Text = Settings.FontFamily;
        ERForm.MainForm.Invalidate();
    }

    private void entityColorButton_Click(object sender, EventArgs e)
    {
        SetColor(ref Settings.EntityColor);
    }

    private void relationshipColorButton_Click(object sender, EventArgs e)
    {
        SetColor(ref Settings.RelationshipColor);
    }

    private void linkColorButton_Click(object sender, EventArgs e)
    {
        SetColor(ref Settings.LinkColor);
    }

    private void attributeColorButton_Click(object sender, EventArgs e)
    {
        SetColor(ref Settings.AttributeColor);
    }

    private void fontColorButton_Click(object sender, EventArgs e)
    {
        SetColor(ref Settings.FontColor);
    }

    private void SetColor(ref Color c)
    {
        // mostra la finestra della selezione colori
        if (colorDialog.ShowDialog() == DialogResult.OK)
        {
            c = colorDialog.Color;
            UpdateSettings();
        }
    }

    private void respectConventionsCheckBox_Click(object sender, EventArgs e)
    {
        Settings.RespectConventions = respectConventionsCheckBox.Checked;
    }

    private void useTabsCheckBox_CheckedChanged(object sender, EventArgs e)
    {
        Settings.UseTabs = useTabsCheckBox.Checked;
    }

    private void autoCorrectCheckBox_CheckedChanged(object sender, EventArgs e)
    {
        Settings.AutoCorrect = autoCorrectCheckBox.Checked;
    }

    private void fontSaveButton_Click(object sender, EventArgs e)
    {
        if (fontTextBox.Text.Length < 2)
        {
            MessageBox.Show("Il font non esiste!");
            return;
        }

        // imposta la prima lettera in maiuscolo
        fontTextBox.Text = fontTextBox.Text.Trim().ToLower();
        fontTextBox.Text = $"{char.ToUpper(fontTextBox.Text[0])}{fontTextBox.Text[1..]}";

        if (FontFamily.Families.Select(f => f.Name).Contains(fontTextBox.Text))
        {
            // aggiorna il font
            Settings.FontFamily = fontTextBox.Text;
        }
        else
        {
            fontTextBox.Text = "";
            MessageBox.Show("Il font non esiste!");
        }
    }

    private void closeButton_Click(object sender, EventArgs e)
    {
        Close();
    }
}