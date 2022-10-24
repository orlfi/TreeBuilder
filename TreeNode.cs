namespace SqlClient;

public class TreeNode
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid? ParentId { get; set; }
    // public TreeNode? Parent { get; set; }

    public List<TreeNode> Children { get; set; }

    public override string ToString()
    {
        return $"{Name}  -- {(ParentId is null ? string.Empty : ParentId.ToString())}";
    }
}

