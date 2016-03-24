using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interpretor.Domain.DataStructures;

namespace Interpretor.Domain.Expressions
{
    [Serializable]
    public class ReadHeapExpr : Expr
    {
        private string id;

        public ReadHeapExpr(string id)
        {
            this.id = id;
        }

        public string Id
        {
            get
            {
                return id;
            }
        }


        public int eval(IDictionary<string, int> tbl, IHeap<int> heap)
        {
            return heap.get(tbl.getValue(this.Id));
        }

        public override string ToString()
        {
            return "readHeap( " + id + " ) ";
        }
    }
}
