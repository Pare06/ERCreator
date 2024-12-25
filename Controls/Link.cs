namespace ERCreator.Controls;

/// <summary>
/// Rappresenta un collegamento tra un'entità e una relazione.
/// </summary>
public class Link
{
    /// <summary>
    /// L'entità collegata.
    /// </summary>
    public Entity? LinkedEntity { get; set; }
    /// <summary>
    /// La relazione collegata.
    /// </summary>
    public Relationship? LinkedRelationship { get; set; }
    /// <summary>
    /// Indica se il collegamento è temporaneo, ovvero se ha solo un elemento collegato.
    /// </summary>
    public bool IsTemporary { get; set; }
    /// <summary>
    /// La cardinalità del collegamento.
    /// </summary>
    public Cardinality Cardinality { get; set; }

    public Link(Entity? e, Relationship? r) : this(e, r, false)
    {

    }

    public Link(Entity? e, Relationship? r, bool temp)
    {
        LinkedEntity = e;
        LinkedRelationship = r;
        IsTemporary = temp;
    }
}