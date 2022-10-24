// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SqlClient;

var list = FillTree();
foreach (var item in list)
    Console.WriteLine(item.ToString());

var root = list.BuildTree();
Console.WriteLine("ok");

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
    return tree;
}