using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpretor.Domain.DataStructures
{
    [Serializable] public class ArrayDictionary : IDictionary<string,int>
    {
        private int[] values;
        private string[] keys;
        private int nrElems;

        public ArrayDictionary()
        {
            nrElems = 0;
            keys = new string[20];
            values = new int[20];
        }


        public bool isEmpty()
        {
            if (nrElems == 0)
                return true;
            return false;
        }


        public void add(string key, int value)
        {
            if (nrElems == values.Length)
                resize();
            for (int i = 0; i < nrElems; i++)
            {
                if (keys[i] == key)
                {
                    values[i] = value;
                    return;
                }
            }
            values[nrElems] = value;
            keys[nrElems] = key;
            nrElems++;

        }


        public int getValue(string key)
        {
            for (int i = 0; i < nrElems; i++)
            {
                if (keys[i] == key)
                {
                    return this.values[i];
                }
            }
            return 33384365;

        }




        public bool isKey(string key)

        {

            for (int i = 0; i < nrElems; i++)
            {
                if (keys[i] == key)
                    return true;
            }
            return false;
        }


        public int size()
        {
            return nrElems;
        }


        public string toString()
        {
            string res = "";
            for (int i = 0; i < nrElems; i++)
            {
                res = res + keys[i] + " : " + values[i] + " | ";
            }
            return res;
        }

        public void resize()
        {
            int[] tempV = new int[values.Length * 2];
            string[] tempK = new string[values.Length * 2];

            for (int i = 0; i < nrElems; i++)
            {
                tempV[i] = values[i];
                tempK[i] = keys[i];
            }

            values = tempV;
            keys = tempK;
        }

        public void modify(string key, int val)
        {
            for (int i = 0; i < nrElems; i++)
            {
                if (keys[i] == key)
                {
                    values[i] = val;
                    break;
                }
            }
        }

        public List<string> keysDict()
        {
            List<string> arList = new List<string>();
            List<string> keys = new List<string>();
            //keys = hashMap.Keys.ToList();

          
            return arList;
        }

        public void setValue(string key, int val)
        {
            throw new NotImplementedException();
        }
    }
}
