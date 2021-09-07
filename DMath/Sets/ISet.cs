namespace DMath.Sets
{
    public interface ISet
    {
        public void Add(int value);
        public void AddRange(int[] value);
        public string ToString();
        public int[] ToArray();
        public bool IsMember(int member);
        public ISet UnionWith(ISet setB);
        public ISet IntersectsWith(ISet setB);
        public int Cardinality();
    }
}