namespace DMath.Sets
{
    public interface IMultiSet
    {
        void Add(int value);
        void AddRange(int[] values);
        string ToString();
        int[] ToArray();
        bool IsMember(int member);
        MultiSet UnionWith(MultiSet setB);
        MultiSet IntersectsWith(MultiSet setB);
        int Cardinality();
        int InstancesOfMember(int member);
    }
}