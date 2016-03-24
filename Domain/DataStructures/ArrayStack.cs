using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interpretor.Domain.Stmt;

namespace Interpretor.Domain.DataStructures
{
    [Serializable]
    class ArrayStack:IStack<IStmt>
    {
        private IStmt[] elems;
        private int nrElemns;

        public ArrayStack()
        {
            nrElemns = 0;
            elems = new IStmt[10];

        }


        
    public void push(IStmt e)
        {
            if (nrElemns == elems.Length)
            {
                resize();
            }
            elems[nrElemns++] = e;
        }

        private void resize()
        {
            IStmt[] temp = new IStmt[elems.Length * 2];
            for (int i = 0; i < elems.Length; i++)
                temp[i] = elems[i];
            elems = temp;
        }

       
    public IStmt pop()
        {
            if (nrElemns > 0)
                return elems[--nrElemns];
            return null;
        }

      
    public bool isEmpty()
        {
            return nrElemns == 0;
        }

        

        public string toString()
        {
            string res = "";
            for (int i = 0; i < nrElemns; i++)
            {
                res = elems[i].ToString() + " ";
            }
            return res;
        }

        public IStmt peek()
        {
            return elems[nrElemns];
        }

        public int Count()
        {
            return nrElemns;
        }
    }
}
