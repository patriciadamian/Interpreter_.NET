using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpretor.Domain.DataStructures
{
    [Serializable]
    public class MyLibStack<T>:IStack<T>
    {
        private Stack<T> elems;

        public MyLibStack()
        {
            elems = new Stack<T>();
        }

        public T pop()
        {
            if (this.isEmpty()) throw new EmptyStackException();
            return elems.Pop();
        }

        public void push(T e)
        {
            elems.Push(e);
        }


        public bool isEmpty()
        {
            return elems.Count == 0;

        }

        public T peek()
        {
            if (this.isEmpty()) throw new EmptyStackException();
            return elems.Peek();
        }

        public int Count()
        {
            return elems.Count;
        }

        public override string ToString()
        {
            return " " + string.Join("\n", elems) + " ";
            /*
            string res = "";
            foreach (T elem in elems)
            {
                res = elem.ToString() + " " + res;
            }

            return res;
            */
        }
        

    }
}
