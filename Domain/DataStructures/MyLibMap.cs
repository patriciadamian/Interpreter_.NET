using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpretor.Domain.DataStructures
{
    [Serializable]
    public class MyLibMap<K, V>:IDictionary<K, V>
    {
        private Dictionary<K, V> hashMap;

        public MyLibMap()
        {
            hashMap = new Dictionary<K, V>();
        }

        public MyLibMap(MyLibMap<K, V> map)
        {
            hashMap = new Dictionary<K, V>(map.hashMap);
        }

        public bool isEmpty()
        {
            return hashMap.Count == 0;
        }

        public void add(K key, V value)
        {
            if (this.hashMap.Count == 16) throw new IsFullDictException();
            if (!this.isKey(key)) { hashMap.Add(key, value); }
            this.hashMap[key] = value;
            /*
            foreach(K k in hashMap.Keys)
            {
                if(k.Equals(key))
                {
                    hashMap[k] = value;
                    return;
                }
            }
          hashMap.Add(key, value);
          */

        }

        public bool isKey(K key)
        {
            return hashMap.ContainsKey(key);
        }

        public V getValue(K key)
        {
            V value;
            if (!this.hashMap.ContainsKey(key)) throw new NotKeyException();
            hashMap.TryGetValue(key, out value);
            return value;
        }

        public void setValue(K key, V val)
        {
            if (!isKey(key))
            {
                throw new NotKeyException();
            }
            hashMap[key] = val;
        }

        public int size()
        {
            return hashMap.Count;
        }

        public override string ToString()
        {
            string res = "";
            foreach (K key in this.hashMap.Keys)
            {
              res +=  key + " : " + hashMap[key] + " , ";
            }
            return res;
        }

        public void modify(K key, V val)
        {
            hashMap.Add(key, val);
        }


        public List<K> keysDict()
        {
            List<K> arList = new List<K>();
            List<K> keys = new List<K>();
            keys = hashMap.Keys.ToList();

            keys.ForEach(delegate (K key) { arList.Add(key); });
            return arList;
            /*
            foreach (K key in keys)
            {
                arList.Add(key);
            }
            return arList;
            */
        }


    }
}
