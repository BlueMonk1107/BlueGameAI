
namespace BlueGOAP
{
    public class Tree<TAction>
    {
        public TreeNode<TAction> CreateNode(IActionHandler<TAction> handler = null)
        {
            return new TreeNode<TAction>(handler);
        }

        public TreeNode<TAction> CreateTopNode()
        {
            return new TreeNode<TAction>(null);
        }
    }
}
