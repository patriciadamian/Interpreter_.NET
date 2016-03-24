using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpretor.Domain.DataStructures
{
    [Serializable]
    public class MyLibHeap<T> : IHeap<T>
    {
        private Dictionary<int, T> elems;
        private int next;

        public MyLibHeap()
        {
            this.elems = new Dictionary<int, T>();
            this.next = 1;
        }

        public int add(T e)
        {
            if (this.elems.Count == 30) throw new IsFullDictException();
            this.elems.Add(this.next, e);
            return this.next++;
        }
        

        public T get(int address)
        {
            T value;
            if (!this.elems.ContainsKey(address)) throw new NotKeyException();
            elems.TryGetValue(address, out value);
            return value;

        }

        public void update(int address, T value)
        {
            if (!this.elems.ContainsKey(address)) throw new NotKeyException();
            this.elems[address] = value;

        }

        public override string ToString()
        {
            string res = "";
            foreach (int el in this.elems.Keys)
            {
                res += el.ToString() + " -> " + elems[el] + "; " ;
            }
            return res;
        }

    }
}
