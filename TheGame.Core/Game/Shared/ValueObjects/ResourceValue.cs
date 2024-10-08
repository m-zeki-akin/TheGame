using Serilog;

namespace TheGame.Core.Game.Shared.ValueObjects;

public class ResourceValue
{
    public long Fuel { get; set; }
    public long Material { get; set; }
    public long Energy { get; set; }
    public long Alloy { get; set; }
    public long Polonium { get; set; }
    public long Technetium { get; set; }
    public long Actinium { get; set; }
    public long Plutonium { get; set; }

    public static ResourceValue operator +(ResourceValue x, ResourceValue y)
    {
        x.Energy += y.Energy;
        x.Fuel += y.Fuel;
        x.Material += y.Material;
        x.Alloy += y.Alloy;
        x.Polonium += y.Polonium;
        x.Technetium += y.Technetium;
        x.Actinium += y.Actinium;
        x.Plutonium += y.Plutonium;

        return x;
    }

    public static (ResourceValue, HashSet<string>) operator -(ResourceValue x, ResourceValue y)
    {
        // List to register resources that become negative
        var negativeResources = new HashSet<string>();

        x.Energy -= y.Energy;
        if (x.Energy < 0)
            negativeResources.Add("Energy");

        x.Fuel -= y.Fuel;
        if (x.Fuel < 0)
            negativeResources.Add("Fuel");

        x.Material -= y.Material;
        if (x.Material < 0)
            negativeResources.Add("Material");

        x.Alloy -= y.Alloy;
        if (x.Alloy < 0)
            negativeResources.Add("Alloy");

        x.Polonium -= y.Polonium;
        if (x.Polonium < 0)
            negativeResources.Add("Polonium");
        
        x.Technetium -= y.Technetium;
        if (x.Technetium < 0)
            negativeResources.Add("Technetium");

        x.Actinium -= y.Actinium;
        if (x.Actinium < 0)
            negativeResources.Add("Actinium");

        x.Plutonium -= y.Plutonium;
        if (x.Plutonium < 0)
            negativeResources.Add("Plutonium");

        return (x, negativeResources);
    }

    public static ResourceValue operator *(ResourceValue x, int y)
    {
        x.Energy *= y;
        x.Fuel *= y;
        x.Material *= y;
        x.Alloy *= y;
        x.Polonium *= y;
        x.Technetium *= y;
        x.Actinium *= y;
        x.Plutonium *= y;

        return x;
    }

    public static ResourceValue operator *(ResourceValue x, double y)
    {
        x.Energy = (long)(x.Energy * y);
        x.Fuel = (long)(x.Fuel * y);
        x.Material = (long)(x.Material * y);
        x.Alloy = (long)(x.Alloy * y);
        x.Polonium = (long)(x.Polonium * y);
        x.Technetium = (long)(x.Technetium * y);
        x.Actinium = (long)(x.Actinium * y);
        x.Plutonium = (long)(x.Plutonium * y);

        return x;
    }

    public static bool operator <(ResourceValue x, ResourceValue y)
    {
        return x.Energy < y.Energy &&
               x.Fuel < y.Fuel &&
               x.Material < y.Material &&
               x.Alloy < y.Alloy &&
               x.Polonium < y.Polonium &&
               x.Technetium < y.Technetium &&
               x.Actinium < y.Actinium &&
               x.Plutonium < y.Plutonium;
    }

    public static bool operator >(ResourceValue x, ResourceValue y)
    {
        return x.Energy > y.Energy &&
               x.Fuel > y.Fuel &&
               x.Material > y.Material &&
               x.Alloy > y.Alloy &&
               x.Polonium > y.Polonium &&
               x.Technetium > y.Technetium &&
               x.Actinium > y.Actinium &&
               x.Plutonium > y.Plutonium;
    }

    public ResourceValue MultiplySpecialResources(double y)
    {
        return new ResourceValue
        {
            Fuel = Fuel,
            Energy = Energy,
            Material = Material,
            Alloy = Alloy,
            Polonium = (long)(Polonium * y),
            Technetium = (long)(Technetium * y),
            Actinium = (long)(Actinium * y),
            Plutonium = (long)(Plutonium * y)
        };
    }

    public long Total()
    {
        return Fuel + Energy + Material + Alloy + Polonium + Technetium + Actinium + Plutonium;
    }
    
    public ResourceValue Sqrt()
    {
        return new ResourceValue
        {
            Fuel = (long)Math.Sqrt(Fuel),
            Energy = (long)Math.Sqrt(Energy),
            Material = (long)Math.Sqrt(Material),
            Alloy = (long)Math.Sqrt(Alloy),
            Polonium = (long)Math.Sqrt(Polonium),
            Technetium = (long)Math.Sqrt(Technetium),
            Actinium = (long)Math.Sqrt(Actinium),
            Plutonium = (long)Math.Sqrt(Plutonium)
        };
    }
}