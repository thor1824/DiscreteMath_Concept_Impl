using System.Collections.Generic;
using System.Linq;
using DiscreteMath.Set;

namespace DiscreteMath.MultiSet
{
    

    public class MultiSet
    {
        public MultiSet(int[] values)
        {
            AddRange(values);
        }

        private Dictionary<int, int> _dic = new();
        public void Add(int value)
        {
            if (_dic.ContainsKey(value))
            {
                _dic[value] = _dic[value] + 1;
                return;
            }
            _dic.Add(value, 1);
        }

        public void AddRange(int[] values)
        {
            foreach (var value in values)
            {
                Add(value);   
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
            var list = new List<int>();
            foreach (var key in _dic.Keys)
            {
                for (int i = 0; i < _dic[key]; i++)
                {
                    list.Add(key);
                }
            }

            return list.ToArray();
        }

        public bool IsMember(int member)
        {
            return _dic.ContainsKey(member);
        }

        public MultiSet UnionWith(MultiSet setB)
        {
            return new MultiSet(ToArray().Concat(setB.ToArray()).ToArray());
        }

        public MultiSet IntersectsWith(MultiSet setB)
        {
            var intersect = new List<int>();
            foreach (var key in _dic.Keys)
            {
                if (!(IsMember(key) && setB.IsMember(key)))
                {
                    continue;
                }

                var instances = _dic[key] >= setB.InstancesOfMember(_dic[key]) ? _dic[key] :  setB.InstancesOfMember(_dic[key]);
                for (var i = 0; i < instances; i++)
                {
                    intersect.Add(key);  
                }
            }

            return new MultiSet(intersect.ToArray());
        }

        public int Cardinality()
        {
            return ToArray().Length;
        }

        public int InstancesOfMember(int member)
        {
            return _dic.ContainsKey(member) ? _dic[member] : 0;
        }
    }
}