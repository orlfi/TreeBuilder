using TreeBuilder;

var list = FillTree();

var root = list.BuildTree();
root.Visit((node, prefix) => Console.WriteLine(prefix + node.Name), "");
Console.WriteLine("\r\nOk. Press any key...");
Console.ReadKey();

static List<TreeNode> FillTree()
{
    List<TreeNode> tree = new();

    var root = new TreeNode { Id = Guid.NewGuid(), Name = "Меню", ParentId = null };
    tree.Add(root);
    var file = new TreeNode { Id = Guid.NewGuid(), Name = "File", ParentId = root.Id };
    tree.Add(file);
    var open = new TreeNode { Id = Guid.NewGuid(), Name = "Open", ParentId = file.Id };
    tree.Add(open);
    var save = new TreeNode { Id = Guid.NewGuid(), Name = "Save", ParentId = file.Id };
    tree.Add(save);
    var edit = new TreeNode { Id = Guid.NewGuid(), Name = "Edit", ParentId = root.Id };
    tree.Add(edit);
    var cut = new TreeNode { Id = Guid.NewGuid(), Name = "Cut", ParentId = edit.Id };
    tree.Add(cut);
    var copy = new TreeNode { Id = Guid.NewGuid(), Name = "Copy", ParentId = edit.Id };
    tree.Add(copy);
    var paste = new TreeNode { Id = Guid.NewGuid(), Name = "Paste", ParentId = edit.Id };
    tree.Add(paste);

    var root2 = new TreeNode { Id = Guid.NewGuid(), Name = "Меню2", ParentId = null };
    tree.Add(root2);
    return tree;
}