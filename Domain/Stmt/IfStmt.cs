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
    public class IfStmt:IStmt
    {
        private Expr exp;
        private IStmt thenS;
        private IStmt elseS;
        private IDictionary<string, int> symTbl;

        public IfStmt(Expr e, IStmt t, IStmt el)
        {
            this.exp = e;
            this.thenS = t;
            this.elseS = el;
        }

        public override string ToString()
        {
            return "IF( " + exp.ToString() + " )THEN( " + thenS.ToString() + " )ELSE( " + elseS.ToString() + " )";
        }

       

        public Expr getExp()
        {
            return exp;
        }

        public void setExp(Expr exp)
        {
            this.exp = exp;
        }


        public IStmt getThenS()
        {
            return thenS;
        }

        public void setThenS(IStmt thenS)
        {
            this.thenS = thenS;
        }

        public IStmt getElseS()
        {
            return elseS;
        }

        public void setElseS(IStmt elseS)
        {
            this.elseS = elseS;
        }

        public PrgState eval(PrgState state)
        {
            IDictionary<string, int> symTbl = state.getSymTable();
          
            if( exp.eval(symTbl, state.getHeapTable()) != 0)
            {
                state.getExeStack().push(thenS);
            }
            else
            {
                state.getExeStack().push(elseS);
            }
     
            return state;
        }
    }
}
