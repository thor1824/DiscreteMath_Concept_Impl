using System.Collections.Generic;
using System.Linq;

namespace DiscreteMath.Set
{
    public class Set : ISet
    {
        private readonly BinaryTree _tree = new BinaryTree();

        public Set(int[] values)
        {
            AddRange(values);
        }

        public void Add(int value) {
            _tree.Add(value);
        }

        public void AddRange(int[] value)
        {
            foreach (var t in value)
            {
                Add(t);
            }
        }

        public override string ToString()
        {
            const char start = '[';
            const char end = ']';
            const string separator = ", ";
            var valueString = "";
            var members = ToArray();
            
            foreach (var (value, index) in members.Select((item, index) => (item, index)))
            {
                if (index == members.Length - 1)
                {
                    valueString += value;        
                    continue;
                }

                valueString += value + separator;
            }

            return start + valueString + end;
        }
        
        public int[] ToArray()
        {
            var members = _tree.ToArray();
            return members;
        }
        
        // memberOf
        public bool IsMember(int member)
        {
            var node = _tree.Find(member);
            return node is not null;
        }

        // union
        public ISet UnionWith(ISet setB)
        {
            var union = setB.ToArray().Concat(ToArray()).ToArray();
            return new Set(union);
        }
        
        // intersect
        public ISet IntersectsWith(ISet setB)
        {
            var intersectsWith = new List<int>();
            var thisAsArray = ToArray();
            foreach (var member in thisAsArray)
            {
                if (setB.IsMember(member))
                {
                    intersectsWith.Add(member);
                }
            }

            return new Set(intersectsWith.ToArray());
        }
        
        // cadinality
        public int Cardinality()
        {
            return ToArray().Length;
        }
        
        // complement
        // product
        // power set
    }
}