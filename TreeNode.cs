namespace TreeBuilder;

public class TreeNode
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid? ParentId { get; set; }

    public List<TreeNode> Children { get; set; } = new();

    public void Visit(Action<TreeNode, string> visitor, string prefix)
    {
        visitor(this, prefix);
        foreach (var child in Children)
            child.Visit(visitor, prefix + "\t");
    }

    public override string ToString()
    {
        return $"{Name}  -- {(ParentId is null ? string.Empty : ParentId.ToString())}";
    }
}

