namespace ERCreator.Controls;

/// <summary>
/// Rappresenta un elemento nel Form.
/// </summary>
public abstract class BaseComponent : UserControl
{
    private bool dragging = false; // sta venendo trascinato?
    private Point dStart; // punto di inizio trascinamento
    private Point menuPos; // la posizione nel menù
    private Panel? menu; // riferimento al menù

    /// <summary>
    /// Indica se l'elemento fa parte del menù.
    /// </summary>
    public bool IsMenu => menu != null;
    /// <summary>
    /// Restituisce il punto medio dell'elemento.
    /// </summary>
    public Point CenterPoint => new(Location.X + Width / 2, Location.Y + Height / 2);

    /// <summary>
    /// Disegna il nome dell'elemento.
    /// </summary>
    protected void DrawName(int yDist, Graphics g, Rectangle clip)
    {
        if (!IsMenu)
        {
            g.DrawString(Name, new Font(Settings.FontFamily, 8, FontStyle.Bold), new SolidBrush(Settings.FontColor), clip.X, clip.Y + yDist);
        }
    }

    protected override void OnLoad(EventArgs e)
    {
        menu = Parent as Panel;
        menuPos = Location;

        ERForm.MainForm.AddComponent(this);
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left && !dragging)
        {
            dragging = true;
            dStart = e.Location;
        }
    }

    protected override void OnMouseMove(MouseEventArgs e)
    {
        if (dragging)
        {
            int newX = Left + e.X - dStart.X;
            int newY = Top + e.Y - dStart.Y;
            Location = new(newX, newY);

            // è uscito dal menù?
            if (IsMenu && Parent != null && !Parent.Bounds.IntersectsWith(Bounds) && Parent.Controls.Contains(this))
            {
                // rimuovi l'elemento dal menù e assegnalo al form
                Parent.Controls.Remove(this);
                ERForm.MainForm.Controls.Add(this);
                ERForm.MainForm.PerformLayout();
                ERForm.MainForm.ResumeLayout(false);
            }
        }
    }

    protected override void OnMouseUp(MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left && dragging)
        {
            dragging = false;

            if (IsMenu)
            {
                // crea un nuovo elemento con lo stesso tipo dell'elemento del menù
                BaseComponent createdEntity = (BaseComponent)Activator.CreateInstance(GetType())!;
                createdEntity.Left = Left;
                createdEntity.Top = Top;
                createdEntity.Width = Width;
                createdEntity.Height = Height;
                createdEntity.Location = Location;
                ERForm.MainForm.Controls.Add(createdEntity);

                // riporta l'elemento originale al menù
                Location = menuPos;
                ERForm.MainForm.Controls.Remove(this);
                menu!.Controls.Add(this);
            }
        }
    }
}