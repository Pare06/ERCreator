namespace ERCreator;

/// <summary>
/// Rappresenta un attributo.
/// </summary>
public class Attribute
{
    public bool Primary { get; set; }
    public bool Optional { get; set; }
    public string Type { get; set; }
    public bool AutoIncrement { get; set; }
    public int Length { get; set; }

    public Attribute(bool primary, bool optional, string type, bool autoIncrement, int length)
    {
        Primary = primary;
        Optional = optional;
        Type = type;
        AutoIncrement = autoIncrement;
        Length = length;
    }
}