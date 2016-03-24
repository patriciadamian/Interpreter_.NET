using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interpretor.Domain.DataStructures;

namespace Interpretor.Domain.Expressions
{
    [Serializable]
    public class BoolExpr:Expr
    {
        private String op;
        private Expr e1;
        private Expr e2;

        /*
        * <
        * >
        * <=
        * >=
        * ==
        * !=
         */


        public BoolExpr(Expr ex1, Expr ex2, String o)
        {
            this.op = o;
            this.e1 = ex1;
            this.e2 = ex2;

        }

        
    public int eval(IDictionary<string, int> tbl, IHeap<int> heap)
        {
        switch (op) {
            case "<":
                if (e1.eval(tbl, heap) < e2.eval(tbl, heap)) {
                    return 1;
                }
                return 0;
            case "<=":
                if (e1.eval(tbl, heap) <= e2.eval(tbl, heap)) {
                    return 1;
                }
                return 0;
            case ">=":
                if (e1.eval(tbl, heap) >= e2.eval(tbl, heap)) {
                    return 1;
                }
                return 0;
            case ">":
                if (e1.eval(tbl, heap) > e2.eval(tbl, heap)) {
                    return 1;
                }
                return 0;
            case "==":
                if (e1.eval(tbl, heap) == e2.eval(tbl, heap)) {
                    return 1;
                }
                return 0;
            case "!=":
                if (e1.eval(tbl, heap) != e2.eval(tbl, heap)) {
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
                case "<":
                    return "(" + e1.ToString() + " < " + e2.ToString() + ")";
                case "<=":
                    return "(" + e1.ToString() + " <= " + e2.ToString() + ")";
                case ">=":
                    return "(" + e1.ToString() + " >= " + e2.ToString() + ")";
                case ">":
                    return "(" + e1.ToString() + " > " + e2.ToString() + ")";
                case "==":
                    return "(" + e1.ToString() + " == " + e2.ToString() + ")";
                case "!=":
                    return "(" + e1.ToString() + " != " + e2.ToString() + ")";
                default:
                    return ToString();
            }
        }

        



public String getOp()
{
    return op;
}

public void setOp(String op)
{
    this.op = op;
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

    }
}
