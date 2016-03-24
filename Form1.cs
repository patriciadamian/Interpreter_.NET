using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Interpretor.Contrl;
using Interpretor.Domain;
using Interpretor.Domain.DataStructures;
using Interpretor.Domain.Expressions;
using Interpretor.Domain.Stmt;
using Interpretor.RepositoryStore;
using Interpretor.ViewUi;
using Microsoft.VisualBasic;
using GUI_Interpreter.Domain.Stmt;

namespace GUI_Interpreter
{
    public partial class MainWindow : Form
    {
        private Controller ctrl;

        public MainWindow()
        {
            InitializeComponent();
            /*
            IStmt st1 = new AssignStmt("v", new ConstExpr(10));
            IStmt st2 = new NewStmt("a", new ConstExpr(22));
            IStmt st3 = new AssignStmt("v", new ConstExpr(32));
            IStmt st4 = new PrintStmt(new VarExpr("v"));
            IStmt st5 = new PrintStmt(new ReadHeapExpr("a"));
            IStmt st8 = new ForkStmt(new CompStmt(new WriteHeapStmt("a", new ConstExpr(30)), new CompStmt(st3, new CompStmt(st4, st5))));
            IStmt st6 = new PrintStmt(new VarExpr("v"));
            IStmt st7 = new PrintStmt(new ReadHeapExpr("a"));
            IStmt prgStatement = new CompStmt(st1, new CompStmt(st2, new CompStmt(st8, new CompStmt(st6, new CompStmt(st7, new CompStmt(new SkipStmt(), new CompStmt(new SkipStmt(), new SkipStmt())))))));
            */
            IStmt st1 = new AssignStmt("v", new ConstExpr(0));
            IStmt st2 = new ForkStmt(new CompStmt(new PrintStmt(new VarExpr("v")), new AssignStmt("v", new ArithExpr(new VarExpr("v"), new ConstExpr(1), "+"))));
            //IStmt st2 = new ForkStmt(new CompStmt(new PrintStmt(new VarExpr("v")), new AssignStmt("v", new ArithExpr(new VarExpr("v"), new ConstExpr(1), "+"))));

            IStmt st3 = new RepeatStmt(new BoolExpr(new VarExpr("v"), new ConstExpr(3), "=="), new CompStmt(st2, new AssignStmt("v", new ArithExpr(new VarExpr("v"), new ConstExpr(1), "+"))));
            IStmt st4 = new PrintStmt(new ArithExpr(new VarExpr("v"), new ConstExpr(10), "*"));
            IStmt prgStatement = new CompStmt(st1, new CompStmt(st3, new CompStmt(new SkipStmt(), new CompStmt(new SkipStmt(), new CompStmt(new SkipStmt(), st4)))));

            //IStmt prgStatement = inputStmt();
            List<PrgState> programs = new List<PrgState>();
            programs.Add(new PrgState(new MyLibStack<IStmt>(), new MyLibMap<string, int>(), new MyLibList<int>(), new MyLibHeap<int>(), prgStatement));
            programs.ForEach(p => rtxtOneStep.AppendText(p.ToString() + "\n"));

            ctrl = new Controller(new Repository(programs));
            ctrl.serializeProgramState();
        }



        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnClickInputPrg(object sender, EventArgs e)
        {
            //IStmt prgStmt = inputStmt();
            /*
            IStmt st1 = new AssignStmt("v", new ConstExpr(10));
            IStmt st2 = new NewStmt("a", new ConstExpr(22));
            IStmt st3 = new AssignStmt("v", new ConstExpr(32));
            IStmt st4 = new PrintStmt(new VarExpr("v"));
            IStmt st5 = new PrintStmt(new ReadHeapExpr("a"));
            IStmt st8 = new ForkStmt(new CompStmt(new WriteHeapStmt("a", new ConstExpr(30)), new CompStmt(st3, new CompStmt(st4, st5))));
            IStmt st6 = new PrintStmt(new VarExpr("v"));
            IStmt st7 = new PrintStmt(new ReadHeapExpr("a"));
            IStmt prgStatement = new CompStmt(st1, new CompStmt(st2, new CompStmt(st8, new CompStmt(st6, new CompStmt(st7, new CompStmt(new SkipStmt(), new CompStmt(new SkipStmt(), new SkipStmt())))))));
            */
            /*
            IStmt st1 = new AssignStmt("v", new ConstExpr(0));
            IStmt st2 = new ForkStmt(new CompStmt(new PrintStmt(new VarExpr("v")),new AssignStmt("v", new ArithExpr(new VarExpr("v"), new ConstExpr(1), "+"))));
            IStmt st3 = new RepeatStmt(new BoolExpr(new VarExpr("v"), new ConstExpr(3), "=="), st2);
            IStmt st4 = new PrintStmt(new ArithExpr(new VarExpr("v"), new ConstExpr(10), "*"));
            IStmt prgStatement = new CompStmt(st1, new CompStmt(st3, new CompStmt(new SkipStmt(), new CompStmt(new SkipStmt(), new CompStmt(new SkipStmt(), st4)))));
            */
            IStmt st1 = new AssignStmt("v", new ConstExpr(0));
            IStmt st2 = new ForkStmt(new CompStmt(new PrintStmt(new VarExpr("v")), new AssignStmt("v", new ArithExpr(new VarExpr("v"), new ConstExpr(1), "+"))));
            //IStmt st2 = new ForkStmt(new CompStmt(new PrintStmt(new VarExpr("v")), new AssignStmt("v", new ArithExpr(new VarExpr("v"), new ConstExpr(1), "+"))));

            IStmt st3 = new RepeatStmt(new BoolExpr(new VarExpr("v"), new ConstExpr(3), "=="), new CompStmt(st2, new AssignStmt("v", new ArithExpr(new VarExpr("v"), new ConstExpr(1), "+"))));
            IStmt st4 = new PrintStmt(new ArithExpr(new VarExpr("v"), new ConstExpr(10), "*"));
            IStmt prgStatement = new CompStmt(st1, new CompStmt(st3, new CompStmt(new SkipStmt(), new CompStmt(new SkipStmt(), new CompStmt(new SkipStmt(), st4)))));


            /*
            new ConstExp(1), new CompStmt(new AssignStmt("a", new VarExp("v")), new PrintStmt(new ArithExp(new VarExp("a"), new ConstExp(1), "+"))));
            tbl.add(new ConstExp(5), new CompStmt(new AssignStmt("a", new ArithExp(new VarExp("v"), new ConstExp(1), "+")), new PrintStmt(new ArithExp(new VarExp("a"), new ConstExp(1), "+"))));
            tbl.add(new ConstExp(2), new CompStmt(new AssignStmt("a", new ArithExp(new VarExp("v"), new ConstExp(2), "+")), new PrintStmt(new ArithExp(new VarExp("a"), new ConstExp(1), "+"))))
            
            */
            List<PrgState> programs = new List<PrgState>();
            programs.Add(new PrgState(new MyLibStack<IStmt>(), new MyLibMap<string, int>(), new MyLibList<int>(), new MyLibHeap<int>(), prgStatement));
            programs.ForEach(p => rtxtOneStep.AppendText(p.ToString() + "\n"));
            rtxtInput.Text = prgStatement.ToString();
            
            


        }

        private void btnClickOneStep(object sender, EventArgs e)
        {
            try
            {
                ctrl.oneStep();
            }
            catch (StmtExcecutionException)
            {
                MessageBox.Show("\nFINISHED\n");
            }
            catch (NotKeyException)
            {
                MessageBox.Show("Key not found one\n ");
            }
            catch (VarNotDefinedException)
            {
                MessageBox.Show("Var not defined\n");
            }
            catch (IsFullListException)
            {
                MessageBox.Show("Full aoutput list\n");
            }
            catch (DivideByZeroException)
            {
                MessageBox.Show("Division by 0!\n");
            }
            catch (RepoException)
            {
                MessageBox.Show("No program state\n");
            }


            if (ctrl.isWriteFlag())
            {
                ctrl.getRepo().writeToFile();
                MessageBox.Show("Am scris in fisier");
            }
            else
            {
                rtxtOneStep.Text = "";
                foreach (PrgState x in ctrl.getRepo().States)
                {
                    rtxtOneStep.AppendText(x.ToString() + "\n");
                }
            }

        }


        private void allStepUi()

        {
            try
            {
                ctrl.allStep();
            }
            catch (StmtExcecutionException)
            {
                MessageBox.Show("\nFINISHED\n");
            }
            catch (VarNotDefinedException)
            {
                MessageBox.Show("Variable not defined!");
            }
            catch (DivideByZeroException)
            {
                MessageBox.Show("Division by zero!");
            }
            catch (IsFullListException)
            {
                MessageBox.Show("Full output list!");
            }

            catch (NotKeyException)
            {
                MessageBox.Show("Key not found! all");
            }


        }

        private void btnClickAllStep(object sender, EventArgs e)
        {
            allStepUi();
            if (ctrl.isWriteFlag())
            {
                MessageBox.Show("Wrote into file");
                ctrl.getRepo().writeToFile();
            }
            else
            { 
                foreach (PrgState x in ctrl.getRepo().States)
                {
                    rtxtAllStep.AppendText(x.ToString() + "\n");
                }
            }

        }

        private void btnClickSerialize(object sender, EventArgs e)
        {
            ctrl.getRepo().serializePrg();
            MessageBox.Show("Serialized!");
        }

        private void btnClickDeserialize(object sender, EventArgs e)
        {

            List<PrgState> prgStates;
            prgStates = ctrl.getRepo().deserializePrg();
            foreach (PrgState x in prgStates)
            {
                rtxtSerDes.AppendText(x.ToString() + "\n");
            }

        }

        
        private void checkClickLog(object sender, EventArgs e)
        {
            ctrl.changeWrite();
        }

        private ConstExpr cstExp()
        {
            
            int cst = int.Parse(Interaction.InputBox("Constant: ", "Input", null));
            return new ConstExpr(cst);
        }

        private ArithExpr arExp()
        {
            Interaction.MsgBox("Operator: + , - , * , /");

            String op = Interaction.InputBox("Type operator", "Input", null);
            
            Expr left = inputExpr("Left Operand ");
            Expr right = inputExpr("Right Operand ");
            return new ArithExpr(left, right, op);

        }

        private VarExpr varExp()
        {
            String op = Interaction.InputBox("Variable id: ", "Input", null);
            return new VarExpr(op);
        }

        private BoolExpr boolExp()
        {
            Interaction.MsgBox("Operator: <, >, <=, >=, ==, !=");
            String op = Interaction.InputBox("Type operator: ", "Input", null);

            Expr left = inputExpr("Left operand ");
            Expr right = inputExpr("Right operand ");
            return new BoolExpr(left, right, op);

        }

        private LogicalExpr logicalExp()
        {
            Interaction.MsgBox("Options: &&, ||, !");


            String op = Interaction.InputBox("Type operator", "Input", null);

            Expr left = inputExpr("Left operand ");
            if (!op.Equals("!"))
            {
                Expr right = inputExpr("Right operand");
                return new LogicalExpr(left, right, op);
            }
            return new LogicalExpr(left, op);
        }

        private ReadExpr readExpr()
        {
            int op = int.Parse(Interaction.InputBox("Input an integer: ", "Input", null));

            return new ReadExpr(op);
        }

        private ReadHeapExpr readHeap()
        {
            String varname = Interaction.InputBox("Var name: ", "Input", null);

            return new ReadHeapExpr(varname);
        }

        private Expr inputExpr(String inp="")
        {
            Expr exp;
            String option;
            option = Interaction.InputBox(inp + "Expression (const, var, arithexp, bool, logic, readH, readE):", "Input", null);

            switch (option)
            {
                case "arith":
                    {
                        exp = arExp();
                        break;
                    }

                case "const":
                    {
                        exp = cstExp();
                        break;
                    }

                case "var":
                    {
                        exp = varExp();
                        break;
                    }

                case "bool":
                    {
                        exp = boolExp();
                        break;
                    }

                case "logic":
                    {
                        exp = logicalExp();
                        break;
                    }

                case "readE":
                    {
                        exp = readExpr();
                        break;
                    }

                case "readH":
                    {
                        exp = readHeap();
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Invalid option! Please try again.\n");
                        exp = inputExpr();
                        break;
                    }
            }

            return exp;

        }

        private AssignStmt assignStmt()
        {
            //Console.WriteLine("Variable name:");
            String id = Interaction.InputBox("Variable Name", "Input", null);
            Expr exp = inputExpr();
            return new AssignStmt(id, exp);
        }

        private CompStmt cmpStmt()
        {
            IStmt first = inputStmt("First");
            IStmt snd = inputStmt("Second");
            return new CompStmt(first, snd);

        }

        private SkipStmt skipStmt()
        {
            return new SkipStmt();
        }

        private IfStmt ifStmt()
        {
            Expr exp = inputExpr();
            IStmt thenS = inputStmt("Then");
            IStmt elseS = inputStmt("Else");
            return new IfStmt(exp, thenS, elseS);
        }

        private PrintStmt printStmt()
        {
            Expr exp = inputExpr();
            return new PrintStmt(exp);
        }

        private WhileStmt whileStmt()
        {
            Expr exp = inputExpr();
            IStmt stmt = inputStmt();
            return new WhileStmt(exp, stmt);
        }

        private SwitchStmt switchStmt()
        {

            String id = Interaction.InputBox("Variable Name", "Input", null);
            Expr exp;
            String opt;
            IStmt stmt;
            Interpretor.Domain.DataStructures.IDictionary<Expr, IStmt> tbl = new MyLibMap<Expr, IStmt>();
            while (true)
            {
                exp = inputExpr("Case expr:");
                stmt = inputStmt();
                try
                {
                    tbl.add(exp, stmt);
                }
                catch (IsFullDictException)
                {
                    Interaction.MsgBox("Full symbol table!");
                }
                opt = Interaction.InputBox("Another CASE? (y/n)", "Input", null);
                if (opt.Equals("n")) { break; }
            }
            stmt = inputStmt("Default ");
            return new SwitchStmt(id, tbl, stmt);
        }

        private IfSkipStmt ifSkipStmt()
        {
            Expr expression = inputExpr();
            IStmt thenS = inputStmt("Then ");
            return new IfSkipStmt(expression, thenS);
        }

        private NewStmt newStmt()
        {
            String name = Interaction.InputBox("Variable Name", "Input", null);
            Expr exp = inputExpr();
            return new NewStmt(name, exp);
        }

        private WriteHeapStmt writeHeapStmt()
        {
            String name = Interaction.InputBox("Variable Name", "Input", null);
            Expr exp = inputExpr();
            return new WriteHeapStmt(name, exp);
        }

        private RepeatStmt repeatStmt()
        {
            Expr exp = inputExpr();
            IStmt stmt = inputStmt();
            return new RepeatStmt(exp, stmt);
        }

        private IStmt inputStmt(String inp="")
        {


            try
            {
                String option = Interaction.InputBox(inp + "Statement (assign, if, print, fork, comp, while, ifskip, new, write, repeat, skip)", "Input", null);
                IStmt crnt;
               
                switch (option)
                {
                    case "comp":
                        {
                            crnt = cmpStmt();
                            break;
                        }

                    case "assign":
                        {
                            crnt = assignStmt();
                            break;
                        }

                    case "if":
                        {
                            crnt = ifStmt();
                            break;
                        }

                    case "print":
                        {
                            crnt = printStmt();
                            break;
                        }


                    case "while":
                        {
                            crnt = whileStmt();
                            break;
                        }

                    case "switch":
                        {
                            crnt = switchStmt();
                            break;
                        }

                    case "ifskip":
                        {
                            crnt = ifSkipStmt();
                            break;
                        }
                    case "new":
                        {
                            crnt = newStmt();
                            break;
                        }

                    case "write":
                        {
                            crnt = writeHeapStmt();
                            break;
                        }
                    case "repeat":
                        {
                            crnt = repeatStmt();
                            break;
                        }

                    case "break":
                        {
                            crnt = skipStmt();
                            break;
                        }

                    default:
                        Console.WriteLine("Invalid option! Please try again.\n");
                        crnt = inputStmt();
                        break;


                }

                return crnt;

            }
            catch (WrongDataTypeException)
            {
                MessageBox.Show("Invalid option, try again!\n");
            }
            return inputStmt();
        }
    }
}
