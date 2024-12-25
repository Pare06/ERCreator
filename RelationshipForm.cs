using ERCreator.Controls;

namespace ERCreator;

public partial class RelationshipForm : Form
{
    private readonly IEnumerable<Link> links; 
    private readonly Entity firstEntity;
    private readonly Entity secondEntity;

    public bool Valid { get; }

    public RelationshipForm()
    {
        Relationship r = (Relationship)ERForm.Active!;
        links = ERForm.MainForm.GetLinks(r);

        if (links.Count() != 2)
        {
            MessageBox.Show("La relazione deve avere due entità collegate!");
            Valid = false;
            return;
        }

        Valid = true;

        firstEntity = links.First().LinkedEntity!;
        secondEntity = links.ElementAt(1).LinkedEntity!;

        InitializeComponent();
        nameTextBox.Text = r.Name;

        firstEntityLabel.Text = firstEntity.Name;
        secondEntityLabel.Text = secondEntity.Name;
        firstCardinalityComboBox.Text = links.First().Cardinality.ConvertToText();
        secondCardinalityComboBox.Text = links.ElementAt(1).Cardinality.ConvertToText();
    }

    private void saveNameButton_Click(object? sender, EventArgs e)
    {
        if (nameTextBox.Text.Trim() == "")
        {
            MessageBox.Show("Il nome non può essere vuoto!");
            return;
        }

        // aggiorna nome e cardinalità della relazione
        ERForm.Active!.Name = nameTextBox.Text;

        links.First().Cardinality = firstCardinalityComboBox.Text.ToCardinality();
        links.ElementAt(1).Cardinality = secondCardinalityComboBox.Text.ToCardinality();

        Close();
    }

    protected override void OnClosed(EventArgs e)
    {
        base.OnClosed(e);

        ERForm.Active = null;
    }
}