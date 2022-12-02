namespace Spotboard.Shared.Attributes;

public class DescriptionAuxAttribute : Attribute
{
    public readonly string Description;

    public DescriptionAuxAttribute(string description)
    {
        Description = description;
    }
}
