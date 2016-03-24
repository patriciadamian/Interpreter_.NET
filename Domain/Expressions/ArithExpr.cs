using System;
//using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interpretor.Domain.DataStructures;





namespace Interpretor.Domain.Expressions
{
    [Serializable]
    public class ArithExpr:Expr
    {
        private Expr e1;
        private Expr e2;
        private String op;
        /*
        *  +
        *  -
        *  *
        *  /
         */

        public ArithExpr(Expr ex1, Expr ex2, String opt)
        {
            e1 = ex1;
            e2 = ex2;
            op = opt;


        }

        public int eval(IDictionary<string, int> tbl, IHeap<int> heap)
        {
            if (op == "+") return (e1.eval(tbl, heap) + e2.eval(tbl, heap));
            if (op == "-") return (e1.eval(tbl, heap) - e2.eval(tbl, heap));
            if (op == "*") return (e1.eval(tbl, heap) * e2.eval(tbl, heap));
           if (op == "/")
            {
                if(e2.eval(tbl, heap) == 0)
                {
                    throw new DivideByZeroException();
                    
                }
                return (e1.eval(tbl, heap) / e2.eval(tbl, heap));
            }
            return eval(tbl, heap);

        }


        public override string ToString()
        {
            if (op == "+") return "( " + e1.ToString() + " + " + e2.ToString() + " ) ";
            if (op == "-") return "( " + e1.ToString() + " - " + e2.ToString() + " ) ";
            if (op == "*") return "( " + e1.ToString() + " * " + e2.ToString() + " ) ";
            if (op == "/") return "( " + e1.ToString() + " / " + e2.ToString() + " ) ";
            return ToString();
        }

       


        public Expr getE1()
        {
            return e1;
        }

        public void setE1(Expr e1)
        {
            this.e1 = e1;
        }

        public Expr getE2()
        {
            return e2;
        }

        public void setE2(Expr e2)
        {
            this.e2 = e2;
        }

        public String getOp()
        {
            return op;
        }

        public void setOp(String op)
        {
            this.op = op;
        }
    }
}
