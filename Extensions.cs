namespace ERCreator;

public static class Extensions
{
    public static Point RotateAroundPoint(this Point origin, Point pivot, double theta)
    {
        int x = (int)(Math.Cos(theta) * (pivot.X - origin.X) - Math.Sin(theta) * (pivot.Y - origin.Y) + pivot.X);
        int y = (int)(Math.Sin(theta) * (pivot.X - origin.X) + Math.Cos(theta) * (pivot.Y - origin.Y) + pivot.Y);

        return new(x, y);
    }

    public static Point FindMiddle(this Point origin, Point other)
    {
        return new((origin.X + other.X) / 2, (origin.Y + other.Y) / 2);
    }

    public static Cardinality ToCardinality(this string str)
    {
        return str switch
        {
            "Zero a uno" => Cardinality.ZeroToOne,
            "Zero a molti" => Cardinality.ZeroToMany,
            "Uno a uno" => Cardinality.OneToOne,
            "Uno a molti" => Cardinality.OneToMany,
            "Molti a molti" => Cardinality.ManyToMany,
            _ => throw new NotImplementedException() // impossibile
        };
    }

    public static string ConvertToText(this Cardinality c) // ToString() c'è già :(
    {
        return c switch
        {
            Cardinality.ZeroToOne => "Zero a uno",
            Cardinality.ZeroToMany => "Zero a molti",
            Cardinality.OneToOne => "Uno a uno",
            Cardinality.OneToMany => "Uno a molti",
            Cardinality.ManyToMany => "Molti a molti",
            _ => throw new NotImplementedException() // impossibile
        };
    }

    public static string ConvertToModel(this Cardinality c)
    {
        return c switch
        {
            Cardinality.ZeroToOne => "0, 1",
            Cardinality.ZeroToMany => "0, N",
            Cardinality.OneToOne => "1, 1",
            Cardinality.OneToMany => "1, N",
            Cardinality.ManyToMany => "N, N",
            _ => throw new NotImplementedException() // impossibile
        };
    }
}