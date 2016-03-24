using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpretor.Domain.DataStructures
{
    [Serializable]
    public class MyLibList<T>:IList<T>
    {
        private List<T> list;

        public MyLibList()
        {
            this.list = new List<T>();
        }

        public void add(T e)
        {
            if (this.list.Count == 10) throw new IsFullListException();
            list.Add(e);
            //this.list.Add(e);
        }

       public bool isEmpty()
        {
            
            return this.list.Count == 0;
        }

        public T getElemAtPos(int i) 
        {
            if ((i >= 0) && (i < this.list.Count))
            {
                return list.ElementAt(i);
            }
            throw new IndexOutOfRangeException();
        }

        public int size()
        {
            return list.Count;
        }

        public override string ToString()
       
        {
            return "[ " + string.Join(", ", list) + " ]";
        }

        public bool Contains(T e)
        {
            return list.Contains(e);
        }
    }
}
