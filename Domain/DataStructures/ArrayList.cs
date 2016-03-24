using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpretor.Domain.DataStructures
{
    [Serializable]
    public class ArrayList:IList<string>

    {
        private string[] list;
        private int nrElems;

        public ArrayList()
        {
            nrElems = 0;
            list = new string[20];
        }


       
    public void add(string e)
        {
            if (nrElems == list.Length)
                resize();
            list[nrElems] = e;
            nrElems++;

        }

      
    public bool isEmpty()
        {
            return nrElems == 0;
        }

    
    public int size()
        {
            return nrElems;
        }

    
    public string toString()
        {
            string res = "";
            for (int i = 0; i < nrElems; i++) res = res + " " + list[i];
            return res;
        }

        public void resize()
        {
            string[] temp = new string[list.Length * 2];

            for (int i = 0; i < nrElems; i++)
            {
                temp[i] = list[i];
            }
            list = temp;
        }

        public string getElemAtPos(int i)
        {
            if (i < nrElems)
                return list[i];
            return null;
        }

        public bool Contains(string e)
        {
            return true;
        }


    }



    /*
    private Object[] elem;
    private int nrElem;
    public ArrayList()
    {
        elem = new Object[10];
        nrElem = 0;
    }

    public void Add(Object o)
    {
        if (nrElem == elem.Length)
        {
            resize();
        }
        elem[nrElem++] = o;

    }

    private void resize()
    {
        Object[] temp = new Object[2 * elem.Length];
        for (int i = 0; i < elem.Length; i++)
            temp[i] = elem[i];
        elem = temp;
    }

    public int Length
    {
        get { return nrElem; }
    }

    public Object this[int index]
    {
        get
        {
            if (index < nrElem && index >= 0)
                return elem[index];
            return null;
        }
        set
        {
            if (index < nrElem && index >= 0)
                elem[index] = value;
            else
                elem[nrElem++] = value;
        }
    }

    public IEnumerator GetEnumerator()
    {
        return new ALEnumerator(this);
    }

    private class ALEnumerator : IEnumerator
    {
        private int cursor;
        private ArrayList al;

        public ALEnumerator(ArrayList al)
        {
            this.al = al;
            cursor = -1;
        }

        public bool MoveNext()
        {
            cursor++;
            return cursor < al.nrElem;
        }

        public Object Current
        {
            get
            {
                return al.elem[cursor];
            }
        }

        public void Reset()
        {
            cursor = -1;
        }
    }
     */


}

