using Interpretor.Domain.DataStructures;
using Interpretor.Domain.Expressions;
using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpretor.Domain.Stmt
{
    [Serializable]
    public class NewStmt : IStmt
    {
        private string id;
        private Expr exp;

        public NewStmt(string id, Expr exp)
        {
            this.id = id;
            this.exp = exp;
        }

        public string Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

        public Expr Exp
        {
            get
            {
                return exp;
            }
            set
            {
                exp = value;
            }
        }

        public override string ToString()
        {
            return "new( " + id + ", " + exp.ToString() + ") ";
        }
    

        public PrgState eval(PrgState state)
        {
            IDictionary<string, int> symTbl = state.getSymTable();
            IHeap<int> heap = state.getHeapTable();
            symTbl.add(id, heap.add(exp.eval(symTbl, heap)));
            return state;
        }
    }
}
