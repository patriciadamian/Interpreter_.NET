using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpretor.Domain.DataStructures
{
    public interface IDictionary<K,V>
    {
        bool isEmpty();
        void add(K key, V value);
        V getValue(K key);
        void setValue(K key, V val);
        bool isKey(K key);
        int size();
        void modify(K key, V val);
        List<K> keysDict();
        //IEnumerator GetEnumerator();
        //System.Collections.Generic.List<K> keys();

    }
}
