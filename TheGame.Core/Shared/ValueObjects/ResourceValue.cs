namespace TheGame.Core.Entities;

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
    
    public static ResourceValue operator -(ResourceValue x, ResourceValue y)
    {
        x.Energy -= y.Energy;
        x.Fuel -= y.Fuel;
        x.Material -= y.Material;
        x.Alloy -= y.Alloy;
        x.Polonium -= y.Polonium;
        x.Technetium -= y.Technetium;
        x.Actinium -= y.Actinium;
        x.Plutonium -= y.Plutonium;
        
        return x;
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
    
    public ResourceValue MultiplySpecialResources(double y)
    {
        Polonium = (long)(Polonium * y);
        Technetium = (long)(Technetium * y);
        Actinium = (long)(Actinium * y);
        Plutonium = (long)(Plutonium * y);
        
        return this;
    }  
    
}