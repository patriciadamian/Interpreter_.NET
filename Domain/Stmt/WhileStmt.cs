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
    public class WhileStmt:IStmt
    {
        private Expr exp;
        private IStmt stmt;

        public WhileStmt(Expr e, IStmt s)
        {
            this.exp = e;
            this.stmt = s;
        }

        public override string ToString()
        {
            return "WHILE( " + exp.ToString() + " ) { " + stmt.ToString() + " } "; 
        }

        
        public Expr getEx()
        {
            return exp;
        }

        public void setEx(Expr ex)
        {
            this.exp = ex;
        }

        public IStmt getStmt()
        {
            return stmt;
        }

        public void setStmt(IStmt stmt)
        {
            this.stmt = stmt;
        }

        public PrgState eval(PrgState state)
        {
            IDictionary<string, int> symTbl = state.getSymTable();
            IHeap<int> heap = state.getHeapTable();
            if(this.getEx().eval(symTbl, heap) != 0)
            {
                IStmt stmt = this.getStmt();
                state.getExeStack().push(this);
                state.getExeStack().push(stmt);
            }
            return null;

        }
    }
}
