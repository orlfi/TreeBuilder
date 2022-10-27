namespace TreeBuilder;

public static class TreeExtensions
{
    public static TreeNode BuildTree(this List<TreeNode> nodes)
    {
        if (nodes == null) throw new ArgumentNullException("nodes");

        if (!nodes.Any(n => n.ParentId is null)) throw new ArgumentNullException("Root nodes not found");

        if (nodes.Count(n => n.ParentId is null) > 1)
        {
            var newRoot = new TreeNode() { Name = "All" };
            
            foreach (var item in nodes.Where(n => n.ParentId is null))
                item.ParentId = newRoot.Id;

            return newRoot.BuildTree(nodes);
        }

        var root = nodes.Single(n => n.ParentId is null);
        nodes.Remove(root);
        return root.BuildTree(nodes);
    }

    private static TreeNode BuildTree(this TreeNode root, List<TreeNode> nodes)
    {
        if (nodes.Count == 0) { return root; }

        var children = root.FetchChildren(nodes).ToList();
        root.Children.AddRange(children);
        root.RemoveChildren(nodes);

        for (int i = 0; i < children.Count; i++)
        {
            children[i] = children[i].BuildTree(nodes);
            if (nodes.Count == 0) { break; }
        }

        return root;
    }
    public static IEnumerable<TreeNode> FetchChildren(this TreeNode root, List<TreeNode> nodes)
    {
        return nodes.Where(n => n.ParentId == root.Id);
    }

    public static void RemoveChildren(this TreeNode root, List<TreeNode> nodes)
    {
        foreach (var node in root.Children)
        {
            nodes.Remove(node);
        }
    }
}
