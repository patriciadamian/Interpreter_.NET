using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interpretor.Domain.Expressions;
using Interpretor.Domain.DataStructures;


namespace Interpretor.Domain.Stmt
{
    [Serializable]
    public class PrintStmt:IStmt
    {
        private Expr exp;


        public PrintStmt(Expr e)
        {
            exp = e;
        }

        public override string ToString()
        {
            return "print( " + exp.ToString() + " )";
        }



        public Expr getExp()
        {
            return exp;
        }

        public void setExp(Expr exp)
        {
            this.exp = exp;
        }


        public PrgState eval(PrgState state)
        {
            IList<int> output = state.getOut();
            IDictionary<string, int> symTbl = state.getSymTable();
            IHeap<int> heap = state.getHeapTable();
            output.add(getExp().eval(symTbl, heap));
            return state;
            /*
            state.getOut().add(this.getExp().eval(state.getSymTable(), state.getHeapTable()).ToString());
            return state;
            */
        }
    }
}
