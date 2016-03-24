using Interpretor.Domain.Expressions;
using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interpretor.Domain.DataStructures;

namespace Interpretor.Domain.Stmt
{
    [Serializable]
    public class IfSkipStmt:IStmt
    {
        private Expr expr;
        private IStmt thenS;
        private IStmt elseS;
        private IDictionary<string, int> symTbl;

        public IfSkipStmt(Expr e, IStmt t)
        {
            this.expr = e;
            this.thenS = t;
            this.elseS = null;
        }

        public override string ToString()
        {
            try
            {
                return "IF (" + expr.ToString() + ") THEN (" + thenS.ToString() + ") ELSE (" + elseS.ToString() + ")";
            }catch (NullReferenceException)
            {
                
            }
            return "IF (" + expr.ToString() + ") THEN (" + thenS.ToString() + ") ELSE (" + elseS.ToString() + ")"; 
        }


        public Expr getExpr()
        {
            return expr;
        }

        public void setExpr(Expr exp)
        {
            this.expr = exp;
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
            //state.getExeStack().push(new IfStmt(getExpr(), getThenS(), new SkipStmt()));
            return state;
        }
    }
}
