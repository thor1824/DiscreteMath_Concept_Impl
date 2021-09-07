namespace DMath.Sets
{
    public interface IBinaryTree
    {
        bool Add(int value);
        Node Find(int value);
        void Remove(int value);
        int GetTreeDepth();
        void TraversePreOrder(Node parent);
        void TraverseInOrder(Node parent);
        void TraversePostOrder(Node parent);
        int[] ToArray();
        int[] TraverseInOrderAndReturn(Node parent);
    }
}