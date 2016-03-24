using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interpretor.Domain.DataStructures;

namespace Interpretor.Domain.Expressions
{
    [Serializable]
    public class LogicalExpr:Expr
    {
        private string op;
        private Expr e1;
        private Expr e2;


        /*
        * &&
        * ||
        * !
         */


        public LogicalExpr(Expr ex1, Expr ex2, string o)
        {
            this.op = o;
            this.e1 = ex1;
            this.e2 = ex2;

        }

        public LogicalExpr(Expr exp1, string o)
        {
            this.e1 = exp1;
            this.op = o;
        }
        
    public int eval(IDictionary<string, int> tbl, IHeap<int> heap) {
        switch (op){
            case "&&":
                if (e1.eval(tbl, heap) !=0 && e2.eval(tbl, heap) !=0) {
                    return 1;
                }
                return 0;
            case "||":
                if (e1.eval(tbl, heap) !=0 || e2.eval(tbl, heap) !=0){
                    return 1;
                }
                return 0;
            case "!":
                if (e1.eval(tbl, heap) == 0){
                    return 1;
                }
                return 0;
            default:
                return eval(tbl, heap);
    }

}


        public override string ToString()
        {
            switch (op)
            {
                case "&&": return "( " + e1.ToString() + " && " + e2.ToString() + " ) ";
                case "||": return "( " + e1.ToString() + " || " + e2.ToString() + " ) ";
                case "!": return " !( " + e1.ToString() + " ) ";
                default: return ToString();
            }
        }

       
    }
}
