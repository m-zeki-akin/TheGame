using TheGame.Core.Shared.Enums;

namespace TheGame.Core.Entities;

public class Resource
{
    public long Id { get; set; }
    public string Name { get; set; }
    public ResourceType Type { get; set; }
}