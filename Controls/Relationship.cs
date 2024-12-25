namespace ERCreator.Controls;

/// <summary>
/// Rappresenta una relazione nel modello E/R.
/// </summary>
public class Relationship : BaseComponent
{
    private static int totalRelationships = 0;

    public Relationship()
    {
        Name = $"Relazione{++totalRelationships}";
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        Brush brush = new SolidBrush(Settings.RelationshipColor);
        Graphics g = e.Graphics;
        Rectangle clip = e.ClipRectangle;

        Point p1 = new(clip.X + Width / 2, clip.Y);
        Point p2 = new(clip.X + Width, clip.Y + Height / 2);
        Point p3 = new(clip.X + Width / 2, clip.Y + Height);
        Point p4 = new(clip.X, clip.Y + Height / 2);

        g.FillPolygon(brush, p1, p2, p3, p4); // rombo pieno

        DrawName(15, e.Graphics, e.ClipRectangle);
    }

    protected override void OnMouseClick(MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Right && ERForm.Active == null && !IsMenu)
        {
            // apri il menù Relazione
            ERForm.Active = this;
            ERForm.MainForm.relationshipActionMenu.Show();
            ERForm.MainForm.relationshipActionMenu.Location = PointToScreen(e.Location);
        }

        // se sta venendo creato un collegamento
        if (e.Button == MouseButtons.Left && ERForm.IsCreatingLink && ERForm.Active is not Relationship && !IsMenu)
        {
            // completalo con questa relazione
            ERForm.IsCreatingLink = false;
            ERForm.MainForm.AddLink(new((Entity?)ERForm.Active, this));
            ERForm.Active = null;
        }
    }
}