using System.Configuration;
using System.Text;
using ERCreator.Controls;
using Timer = System.Windows.Forms.Timer;

namespace ERCreator;

public partial class ERForm : Form
{
    public static ERForm MainForm { get; private set; } = null!; // ignora CS8618 - MainForm verrà sempre impostato prima che venga chiamato
    public static BaseComponent? Active { get; set; } // l'elemento che sta venendo modificato
    public static bool IsCreatingLink { get; set; } // c'è un collegamento temporaneo?

    private readonly List<BaseComponent> allComponents = []; // tutti gli elementi
    private readonly List<Link> links = []; // collegamenti
    private readonly List<AttributeLink> attrLinks = []; // collegamenti form
    private readonly Graphics g;
    private Dictionary<BaseComponent, Point> componentLocations = []; // posizioni degli elementi nel form

    public ERForm()
    {
        InitializeComponent();

        g = CreateGraphics();
        MainForm = this;

        // ogni millisecondo, disegna i collegamenti sul form
        Timer linkTimer = new();
        linkTimer.Interval = 1; // ms
        linkTimer.Tick += DrawLinks;
        linkTimer.Start();
    }

    private static int frameCount = 0;

    public void DrawLinks(object? sender, EventArgs e)
    {
        if (frameCount % 2 == 0 && IsCreatingLink || allComponents.Any(c => !c.IsMenu && componentLocations.ContainsKey(c) && componentLocations[c] != c.Location))
        {
            Invalidate();
        }

        frameCount++;

        componentLocations = allComponents.Select(c => (c, c.Location)).ToDictionary();

        // rimuovi i collegamenti temporanei rimasti
        if (!IsCreatingLink)
        {
            links.RemoveAll(l => l.IsTemporary);
        }

        foreach (Link l in links)
        {
            if (l.IsTemporary)
            {
                // disegna il collegamento dall'elemento al cursore se non esiste un secondo elemento collegato
                g.DrawLine(new Pen(Settings.LinkColor), PointToClient(Cursor.Position), l.LinkedEntity == null ? l.LinkedRelationship!.CenterPoint : l.LinkedEntity!.CenterPoint);
            }
            else
            {
                // disegna il collegamento tra i due elementi, e scrive la sua cardinalità al centro
                g.DrawLine(new Pen(Settings.LinkColor), l.LinkedEntity!.CenterPoint, l.LinkedRelationship!.CenterPoint);
                g.DrawString(l.Cardinality.ConvertToModel(), new Font(Settings.FontFamily, 8), new SolidBrush(Settings.FontColor), l.LinkedEntity.Location.FindMiddle(l.LinkedRelationship.Location));
            }
        }

        foreach (AttributeLink l in attrLinks)
        {
            // disegna il collegamento tra entità e attributo
            g.DrawLine(new Pen(Settings.LinkColor), l.Entity.CenterPoint, l.CenterPoint);
            // scrivi la cardinalità in base alla posizione dell'attributo rispetto all'entità
            g.DrawString(l.Name, new Font(Settings.FontFamily, 10), new SolidBrush(Settings.FontColor), l.CenterPoint with { Y = l.Location.Y + (Math.Sign(l.Location.Y - l.Entity.Location.Y)) * 40 });
            if (l.Optional || l.Multiple)
            {
                g.DrawString($"{(l.Optional ? "0" : "1")}, {(l.Multiple ? "N" : "1")}", new Font(Settings.FontFamily, 10), new SolidBrush(Settings.FontColor), l.Entity.Location.FindMiddle(l.Location));
            }
        }
    }

    public void AddComponent(BaseComponent c)
    {
        allComponents.Add(c);
    }

    public IEnumerable<Link> GetLinks(Relationship r)
    {
        return links.Where(l => l.LinkedRelationship == r);
    }

    public void AddLink(Link link)
    {
        // non permettere di collegare più volte gli stessi elementi
        if (!links.Any(l => l.LinkedEntity == link.LinkedEntity && l.LinkedRelationship == link.LinkedRelationship))
        {
            links.Add(link);
        }
    }

    public void AddAttributeLink(AttributeLink l)
    {
        attrLinks.Add(l);
        Controls.Add(l);
    }

    public void DeleteAttributeLinks(Entity e)
    {
        List<AttributeLink> toRemove = [];
        foreach (AttributeLink l in attrLinks.Where(a => a.Entity == e))
        {
            toRemove.Add(l);
        }

        foreach (AttributeLink l in toRemove)
        {
            Controls.Remove(l);
            attrLinks.Remove(l);
        }
    }

    // TODO è necessario?
    public new void Invalidate()
    {
        base.Invalidate();
        allComponents.ForEach(c => c.Invalidate());
    }

    protected override void OnMove(EventArgs e)
    {
        base.OnMove(e);

        allComponents.ForEach(c => c.Invalidate());
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
        base.OnMouseDown(e);

        if (IsCreatingLink)
        {
            IsCreatingLink = false;
            Active = null;
        }
    }

    private void settingsButton_Click(object sender, EventArgs e)
    {
        new SettingsForm().ShowDialog();
    }

    private void exportSqlButton_Click(object sender, EventArgs e)
    {
        if (saveSqlDialog.ShowDialog() == DialogResult.OK)
        {
            TextWriter defaultOut = Console.Out;
            string path = Path.GetFullPath(saveSqlDialog.FileName);

            using (StreamWriter outStream = new StreamWriter(path))
            {
                Console.SetOut(outStream);
                WriteSQL(false);
            }

            Console.SetOut(defaultOut);
        }
    }

    // r-click

    // collega entità
    private void CreateLinkE(object sender, EventArgs e)
    {
        IsCreatingLink = true;
        AddLink(new Link((Entity)Active!, null, true));
    }

    // modifica entità
    private void EditE(object sender, EventArgs e)
    {
        new EntityForm().ShowDialog();
    }

    // collega relazione
    private void CreateLinkR(object sender, EventArgs e)
    {
        IsCreatingLink = true;
        AddLink(new Link(null, (Relationship)Active!, true));
    }

    // modifica relazione
    private void EditR(object sender, EventArgs e)
    {
        RelationshipForm rf = new();

        if (rf.Valid)
        {
            rf.ShowDialog();
        }
        Active = null;
    }

    // elimina entità/relazione
    private void DeleteER(object sender, EventArgs e)
    {
        links.RemoveAll(l => l.LinkedEntity == Active! || l.LinkedRelationship == Active!);

        allComponents.Remove(Active!);
        Controls.Remove(Active);

        List<AttributeLink> toRemove = [];
        foreach (AttributeLink l in attrLinks)
        {
            if (l.Entity == Active)
            {
                toRemove.Add(l);
            }
        }

        foreach (AttributeLink l in toRemove)
        {
            attrLinks.Remove(l);
            Controls.Remove(l);
        }

        Active = null;
    }

    // chiudi
    private void CloseActionMenu(object sender, ToolStripDropDownClosedEventArgs e)
    {
        if (e.CloseReason != ToolStripDropDownCloseReason.ItemClicked && !IsCreatingLink)
        {
            Active = null;
        }
    }

    // +-------------------+
    // |                   |
    // |    SEZIONE SQL    |
    // |                   |
    // +-------------------+

    private IEnumerable<Entity> entities;
    private IEnumerable<Relationship> relationships;

    private void CreateSQL(object sender, EventArgs eA)
    {
        WriteSQL(true);
    }

    private bool WriteSQL(bool showConsole)
    {
        entities = allComponents.Where(c => c is Entity && !c.IsMenu).Cast<Entity>().ToList();
        relationships = allComponents.Where(c => c is Relationship && !c.IsMenu).Cast<Relationship>().ToList();

        if (!entities.Any())
        {
            MessageBox.Show("Non ci sono entità!");
            return false;
        }

        foreach (BaseComponent c in allComponents.Where(c => !c.IsMenu))
        {
            if (Settings.AutoCorrect)
            {
                c.Name = AutoCorrect(c.Name);
            }
            if (IsInvalid(c.Name))
            {
                MessageBox.Show($"Caratteri non validi {(c is Entity ? "nell'entità " : "nella relazione ")} {c.Name}!");
                return false;
            }
        }

        foreach (Entity entity in entities)
        {
            if (entity.PrimaryAttributes.Count == 0)
            {
                MessageBox.Show($"L'entità {entity.Name} non ha attributi primari!");
                return false;
            }

            if (Settings.AutoCorrect)
            {
                entity.Attributes = entity.Attributes.Select(a => (AutoCorrect(a.Key), a.Value)).ToDictionary();
            }

            foreach ((string name, _) in entity.Attributes)
            {
                if (IsInvalid(name))
                {
                    MessageBox.Show($"Caratteri non validi nell'attributo {name} dell'entità {entity.Name}!");
                    return false;
                }
            }
        }

        if (showConsole)
        {
            Windows.ShowWindow(Windows.GetConsoleWindow(), Windows.SW_SHOW);
        }

        foreach (Entity entity in entities)
        {
            PrintEntity(entity);
        }

        foreach (Entity entity in entities)
        {
            PrintEntityForeigns(entity);
        }

        foreach (Entity entity in entities)
        {
            PrintMultiples(entity);
        }

        foreach (Relationship relationship in relationships)
        {
            PrintRelationship(relationship);
        }

        if (showConsole)
        {
            // per qualche motivo è completamente impossibile chiudere la console di Windows senza che si chiuda tutto il programma.
            WriteColored("""
                         Per chiudere questa finestra, premi #EINVIO#F.
                         #4NON#F chiuderla premento la X!
                         """);

            Console.ReadLine();
            Console.Clear();
            Windows.ShowWindow(Windows.GetConsoleWindow(), Windows.SW_HIDE);
        }

        return true;
    }

    private static void PrintEntity(Entity e)
    {
        var attributes = e.Attributes.Select(a => (a.Key, a.Value)).Where(a => !a.Value.Multiple).ToList(); // escludi multipli
        var primaries = e.PrimaryAttributes;

        WriteColored($"#9CREATE TABLE #E{CorrectedName(e.Name)} #F(\n");

        for (int i = 0; i < attributes.Count; i++)
        {
            (string name, Attribute attr) = attributes[i];

            Console.Write(Indent());

            WriteColored($"#C{CorrectedName(name)} #9{GetSqlType(attr.Type, attr.Length)}");

            if (attr.Primary && primaries.Count < 2)
            {
                WriteColored(" #9PRIMARY KEY");
            }
            if (attr.AutoIncrement && attr.Type == "Numero intero")
            {
                WriteColored(" #9AUTO_INCREMENT");
            }
            if (!attr.Optional && !attr.Primary)
            {
                WriteColored(" #9NOT NULL");
            }

            if (i != attributes.Count - 1 || primaries.Count > 1)
            {
                Console.Write(',');
            }

            Console.WriteLine();
        }

        if (primaries.Count > 1)
        {
            Console.Write(Indent());
            WriteColored("#CPRIMARY KEY #F(");

            for (int j = 0; j < primaries.ToList().Count; j++)
            {
                WriteColored($"#C{CorrectedName(primaries.ToList()[j].Key)}");

                if (j != primaries.Count - 1)
                {
                    Console.Write(", ");
                }
            }
            Console.Write(')');
            Console.WriteLine();
        }

        Console.WriteLine(");\n");
    }

    private void PrintEntityForeigns(Entity e)
    {
        var linkedRelationships = links.Where(l => l.LinkedEntity == e).Select(l => l.LinkedRelationship).ToList();

        // entità con 0/1 collegamenti di cardinalità 0/1/N, N
        var linkedEntitiesWithoutNewTable = links.Where(l =>
                linkedRelationships.Contains(l.LinkedRelationship) && l.Cardinality != Cardinality.ManyToMany &&
                l.LinkedEntity != e)
            .Where(l => l.Cardinality is Cardinality.ZeroToOne or Cardinality.OneToOne).Select(l => l.LinkedEntity!).ToList();

        bool alreadyPrinted = false;
        for (int i = 0; i < linkedEntitiesWithoutNewTable.Count; i++)
        {
            var linked = linkedEntitiesWithoutNewTable[i];
            var primaries = e.PrimaryAttributes;

            if (!alreadyPrinted)
            {
                WriteColored($"#9ALTER TABLE #E{CorrectedName(linked.Name)}\n");
            }

            foreach (var a in primaries)
            {
                Console.Write(Indent());
                WriteColored($"#9ADD COLUMN #C{CorrectedName($"{e.Name}_{a.Key}")} #9{GetSqlType(a.Value.Type, a.Value.Length)}");
                Console.WriteLine(',');
            }

            Console.Write(Indent());
            WriteColored("#9ADD FOREIGN KEY #F(");

            for (int j = 0; j < primaries.ToList().Count; j++)
            {
                WriteColored($"#C{CorrectedName($"{e.Name}_{primaries.ToList()[j].Key}")}");

                if (j != primaries.Count - 1)
                {
                    Console.Write(", ");
                }
            }

            WriteColored($") #9REFERENCES #E{CorrectedName(e.Name)}#F(");

            for (int j = 0; j < primaries.ToList().Count; j++)
            {
                WriteColored($"#C{CorrectedName($"{primaries.ToList()[j].Key}")}");

                if (j != primaries.Count - 1)
                {
                    Console.Write(", ");
                }
            }

            Console.WriteLine(i != linkedEntitiesWithoutNewTable.Count - 1 ? ")," : ");\n");
        }
    }

    private static void PrintMultiples(Entity e)
    {
        var multiples = e.Attributes.Where(a => a.Value.Multiple).ToList();
        var primaries = e.PrimaryAttributes;

        foreach ((string name, Attribute attr) in multiples)
        {
            WriteColored($"#9CREATE TABLE #E{CorrectedName($"{e.Name}_{name}")} #F(\n");

            foreach ((string pName, Attribute pAttr) in primaries)
            {
                Console.Write(Indent());
                WriteColored($"#C{CorrectedName($"{e.Name}_{pName}")} #9{GetSqlType(pAttr.Type, pAttr.Length)} #9NOT NULL#F,\n");
            }

            Console.Write(Indent());
            WriteColored($"#C{CorrectedName(name)} #9{GetSqlType(attr.Type, attr.Length)}");

            if (!attr.Optional)
            {
                WriteColored(" #9NOT NULL");
            }
            Console.WriteLine(',');

            Console.Write(Indent());
            WriteColored("#9FOREIGN KEY #F(");

            for (int i = 0; i < primaries.ToList().Count; i++)
            {
                (string pName, _) = primaries.ToList()[i];
                WriteColored($"#C{CorrectedName($"{e.Name}_{pName}")}");

                if (i != primaries.Count - 1)
                {
                    Console.Write(", ");
                }

            }

            WriteColored($") #9REFERENCES #E{e.Name}#F(");

            for (int i = 0; i < primaries.ToList().Count; i++)
            {
                (string pName, _) = primaries.ToList()[i];
                WriteColored($"#C{CorrectedName($"{pName}")}");

                if (i != primaries.Count - 1)
                {
                    Console.Write(", ");
                }

            }

            Console.WriteLine(')');
            Console.WriteLine(");\n");
        }
    }

    private void PrintRelationship(Relationship r)
    {
        var linkedEntities = links.Where(l => l.LinkedRelationship == r).Select(l => (l.LinkedEntity, l.Cardinality));

        // entità con collegamenti 0/1/N, N
        var neededLinkedEntities = linkedEntities.Where(lE =>
            lE.Cardinality == Cardinality.ManyToMany || linkedEntities.All(lE1 =>
                lE1.Cardinality is Cardinality.OneToMany or Cardinality.ZeroToMany)).ToList();

        if (neededLinkedEntities.Count == 2) // se sono 0, non ci sono collegamenti 0/1/N, N - se è 1, allora non c'è bisogno di una tabella a parte. 
        {
            WriteColored($"#9CREATE TABLE #E{r.Name} #F(\n");

            for (int i = 0; i < neededLinkedEntities.Count; i++)
            {
                var (entity, cardinality) = neededLinkedEntities[i];
                var primaries = entity!.PrimaryAttributes.ToList();
                for (int j = 0; j < primaries.Count; j++)
                {
                    var primary = primaries[j];

                    Console.Write(Indent());
                    WriteColored($" #C{CorrectedName($"{entity.Name}_{primary.Key}")} #9{GetSqlType(primary.Value.Type, primary.Value.Length)}");

                    if (cardinality is Cardinality.OneToMany or Cardinality.ManyToMany)
                    {
                        WriteColored(" #9NOT NULL");
                    }

                    WriteColored($" #9REFERENCES #E{CorrectedName(entity.Name)}#F({CorrectedName(primary.Key)}#F)");

                    if (j != primaries.Count - 1 || i != neededLinkedEntities.Count - 1)
                    {
                        Console.Write(',');
                    }

                    Console.WriteLine();
                }
            }

            Console.WriteLine(");\n");
        }
    }

    private static void WriteColored(string str)
    {
        Console.ForegroundColor = ConsoleColor.White;

        for (int i = 0; i < str.Length; i++)
        {
            if (str[i] == '#')
            {
                Console.ForegroundColor = (ConsoleColor)Convert.ToInt32(str[i + 1].ToString(), 16);
                i++;
            }
            else
            {
                Console.Write(str[i]);
            }
        }

        Console.ForegroundColor = ConsoleColor.White;
    }

    private static string AutoCorrect(string name) => name.Trim().Replace('-', '_').Replace(' ', '_');

    private static string CorrectedName(string name) => Settings.RespectConventions ? name.ToLower() : name;

    private static bool IsInvalid(string name) => name.ToList().Any(c => !char.IsDigit(c) && !char.IsLetter(c) && c != '_');

    private static string Indent() => Settings.UseTabs ? "\t" : "  ";

    private static string GetSqlType(string type, int length)
    {
        return type switch
        {
            "Numero intero" => "INT",
            "Numero decimale" => "DECIMAL",
            "Testo" => $"VARCHAR({length})",
            "Data" => "DATE",
            _ => throw new NotImplementedException()
        };
    }
}