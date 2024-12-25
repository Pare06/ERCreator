namespace ERCreator.Controls;

/// <summary>
/// Rappresenta un attributo nel form.
/// </summary>
public class AttributeLink : BaseComponent
{
    /// <summary>
    /// L'entità a cui appartiene l'attributo.
    /// </summary>
    public Entity Entity { get; set; }
    /// <summary>
    /// Indica se l'attributo è primario (PRIMARY KEY in SQL).
    /// </summary>
    public bool Primary { get; set; }
    /// <summary>
    /// Indica se l'attributo è opzionale.
    /// </summary>
    public bool Optional { get; set; }
    /// <summary>
    /// Indica se l'attributo è multiplo.
    /// </summary>
    public bool Multiple { get; set; }

    public AttributeLink(string name, Entity e, bool primary, bool optional, bool multiple)
    {
        Name = name;
        Entity = e;
        Primary = primary;
        Optional = optional;
        Multiple = multiple;
        Scale(new SizeF(0.2f, 0.2f));
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        if (Primary)
        {
            e.Graphics.FillEllipse(new SolidBrush(Settings.AttributeColor), e.ClipRectangle); // cerchio pieno
        }
        else
        {
            // rimpicciolisci il cerchio per non uscire dai bordi
            e.Graphics.DrawEllipse(new Pen(Settings.AttributeColor, 1.5f), e.ClipRectangle with { Width = e.ClipRectangle.Width - 1, Height = e.ClipRectangle.Height - 1 }); // cerchio vuoto
        }
    }
}