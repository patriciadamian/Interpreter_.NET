using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interpretor.Domain.DataStructures;

namespace Interpretor.Domain.Expressions
{
    [Serializable]
    public class ReadExpr:Expr
    {
        private int nr;


        public ReadExpr(int n)
        {
            this.nr = n;
        }


        
        public int eval(IDictionary<string, int> tbl, IHeap<int> heap)
        {
            return nr;
        }

        public override string ToString()
        {
            return "read()";
        }


        public int getNr()
        {
            return nr;
        }

        public void setNr(int nr)
        {
            this.nr = nr;
        }
    }
}
