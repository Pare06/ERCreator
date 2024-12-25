namespace ERCreator.Controls;

/// <summary>
/// Rappresenta un'Entità nel modello E/R.
/// </summary>
public class Entity : BaseComponent
{
    private static int totalEntities = 0;

    /// <summary>
    /// Contiene gli attributi appartenenti all'Entità.
    /// </summary>
    public Dictionary<string, Attribute> Attributes { get; set; } = [];
    /// <summary>
    /// Contiene gli attributi primari appartenti all'Entità.
    /// </summary>
    public Dictionary<string, Attribute> PrimaryAttributes => Attributes.Where(a => a.Value.Primary).ToDictionary();

    public Entity()
    {
        Name = $"Entità{++totalEntities}";
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        Brush brush = new SolidBrush(Settings.EntityColor);

        e.Graphics.FillRectangle(brush, e.ClipRectangle); // rettangolo pieno
        DrawName(10, e.Graphics, e.ClipRectangle);
    }

    protected override void OnMouseClick(MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Right && ERForm.Active == null && !IsMenu)
        {
            // apri il menù Entità
            ERForm.Active = this;
            ERForm.MainForm.entityActionMenu.Show();
            ERForm.MainForm.entityActionMenu.Location = PointToScreen(e.Location);
        }

        // se sta venendo creato un collegamento
        if (e.Button == MouseButtons.Left && ERForm.IsCreatingLink && ERForm.Active is not Entity && !IsMenu)
        {
            // completalo con questa entità
            ERForm.IsCreatingLink = false;
            ERForm.MainForm.AddLink(new(this, (Relationship?)ERForm.Active));
            ERForm.Active = null;
        }
    }
}