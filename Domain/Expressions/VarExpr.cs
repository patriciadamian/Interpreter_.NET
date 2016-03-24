using System;
//using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interpretor.Domain.DataStructures;

namespace Interpretor.Domain.Expressions
{
    [Serializable]
    public class VarExpr:Expr
    {
        private string id;

        public VarExpr(string i)
        {

            this.id = i;
        }

        
    public int eval(IDictionary<string, int> tbl, IHeap<int> heap)
        {

            if (tbl.isKey(id))
                return (int)tbl.getValue(id);
            throw new VarNotDefinedException();

        }

     /*   
    public string toString()
        {
            return " " + id + " ";
        }
        */
    public override string ToString()
        {
            return " " + id + " ";
        }


    public string getId()
        {
            return id;
        }

    public void setId(string id)
        {
            this.id = id;
        }
    }
}
