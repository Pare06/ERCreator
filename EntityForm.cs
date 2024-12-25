using ERCreator.Controls;

namespace ERCreator;

public partial class EntityForm : Form
{
    private readonly List<TextBox> names = [];
    private readonly List<CheckBox> primaries = [];
    private readonly List<CheckBox> optionals = [];
    private readonly List<ComboBox> types = [];
    private readonly List<CheckBox> autoIncrements = [];
    private readonly List<TextBox> lengths = [];
    private readonly List<CheckBox> multiples = [];

    public EntityForm()
    {
        InitializeComponent();

        nameTextBox.Text = ERForm.Active!.Name;

        foreach ((string name, Attribute attr) in ((Entity)ERForm.Active).Attributes)
        {
            CreateAttribute(null!, null!, name, attr.Primary, attr.Optional, attr.Type, attr.AutoIncrement, attr.Length, attr.Multiple);
        }
    }

    /// <summary>
    /// Aggiunge una riga di elementi nel form per creare un attributo con i valori predefiniti.
    /// </summary>
    private void CreateAttribute(object sender, EventArgs e)
    {
        CreateAttribute(sender, e, "", false, false, "", false, 10, false);
    }

    /// <summary>
    /// Aggiunge una riga di elementi nel form per creare un attributo.
    /// </summary>
    private void CreateAttribute(object sender, EventArgs e, string name, bool primary, bool optional, string type, bool autoIncrement, int length, bool multiple)
    {
        // crea spazio per i nuovi elementi
        createAttributeButton.Location = createAttributeButton.Location with { Y = createAttributeButton.Location.Y + 30 };
        createAttributeButton.Invalidate();
        Height += 30;
        Invalidate();

        TextBox tbN = new(); // nome
        tbN.Location = new(10, 100 + 30 * names.Count);
        tbN.Size = new(90, 20);
        tbN.Text = name;
        names.Add(tbN);

        CheckBox cbP = new(); // primario?
        cbP.Location = new(120, 100 + 30 * primaries.Count);
        cbP.Size = new(38, 20);
        cbP.Checked = primary;
        primaries.Add(cbP);

        CheckBox cbO = new(); // opzionale?
        cbO.Location = new(160, 100 + 30 * optionals.Count);
        cbO.Size = new(38, 20);
        cbO.Checked = optional;
        optionals.Add(cbO);

        ComboBox cbT = new(); // tipo
        cbT.Location = new Point(200, 100 + 30 * types.Count);
        cbT.Size = new Size(120, 20);
        cbT.Items.AddRange("Testo", "Numero intero", "Numero decimale", "Data");
        cbT.DropDownStyle = ComboBoxStyle.DropDownList;
        cbT.Text = type;
        types.Add(cbT);

        CheckBox cbA = new(); // auto increment?
        cbA.Location = new(350, 100 + 30 * autoIncrements.Count);
        cbA.Size = new(38, 20);
        cbA.Checked = autoIncrement;
        autoIncrements.Add(cbA);

        TextBox tbL = new(); // lunghezza
        tbL.Location = new Point(400, 100 + 30 * lengths.Count);
        tbL.Size = new(30, 20);
        tbL.Text = length.ToString();
        lengths.Add(tbL);

        CheckBox cbM = new(); // multiplo?
        cbM.Location = new(480, 100 + 30 * multiples.Count);
        cbM.Size = new(38, 20);
        cbM.Checked = multiple;
        multiples.Add(cbM);

        // aggiunge gli elementi al form
        Controls.Add(tbN);
        Controls.Add(cbP);
        Controls.Add(cbO);
        Controls.Add(cbT);
        Controls.Add(cbA);
        Controls.Add(tbL);
        Controls.Add(cbM);
    }

    private void SaveEntity(object sender, EventArgs e)
    {
        Entity entity = (Entity)ERForm.Active!;

        if (names.Any(n => n.Text == ""))
        {
            MessageBox.Show("C'è un nome vuoto!");
            return;
        }

        if (types.Any(t => t.Text == ""))
        {
            MessageBox.Show("Un attributo non ha il tipo impostato!");
            return;
        }

        if (names.GroupBy(n => n.Text).Any(m => m.Count() > 1))
        {
            MessageBox.Show("Ci sono più nomi uguali!");
            return;
        }

        if (names.Any(n => n.Text == entity.Name))
        {
            MessageBox.Show("C'è un nome uguale a quello dell'entità!");
            return;
        }

        if (lengths.Any(l => !int.TryParse(l.Text, out _)))
        {
            MessageBox.Show("C'è una lunghezza non numerica!");
            return;
        }

        if (multiples.All(m => m.Checked))
        {
            MessageBox.Show("Deve esserci almeno un attributo non multiplo!");
            return;
        }

        Dictionary<string, Attribute> attributes = [];
        for (int i = 0; i < names.Count; i++)
        {
            if (primaries[i].Checked && optionals[i].Checked)
            {
                MessageBox.Show("Una chiave primaria non può essere opzionale!");
                return;
            }

            if (primaries[i].Checked && multiples[i].Checked)
            {
                MessageBox.Show("Una chiave primaria non può essere multipla!");
                return;
            }

            int length = int.Parse(lengths[i].Text);
            if (types[i].Text == "Testo" && length < 0)
            {
                MessageBox.Show("La lunghezza deve essere positiva!");
                return;
            }

            // aggiungi gli attributi al Dictionary
            attributes[names[i].Text] = new(primaries[i].Checked, optionals[i].Checked, types[i].Text, autoIncrements[i].Checked, length, multiples[i].Checked);
        }

        // aggiorna gli attributi dell'entità
        entity.Attributes = new(attributes);

        // di quanti radianti deve essere girata ogni casella di testo?
        double stepRadians = Math.Tau / attributes.Count;
        // quanti elementi sono stati inseriti?
        int step = 0;

        // sovrascrivi gli elementi vecchi nel form
        ERForm.MainForm.DeleteAttributeLinks(entity);
        foreach ((string name, Attribute attr) in attributes)
        {
            AttributeLink link = new(name, entity, attr.Primary, attr.Optional, attr.Multiple);
            // gira l'attributo
            link.Location = entity.CenterPoint.RotateAroundPoint(entity.CenterPoint with { X = entity.CenterPoint.X + 100 }, stepRadians * step);
            step++;
            ERForm.MainForm.AddAttributeLink(link);
        }

        ERForm.Active!.Name = nameTextBox.Text;
        Close();
    }

    protected override void OnClosed(EventArgs e)
    {
        base.OnClosed(e);

        ERForm.Active = null;
    }
}