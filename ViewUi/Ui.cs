using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interpretor.Contrl;
using Interpretor.Domain;
using Interpretor.RepositoryStore;
using Interpretor.Domain.Stmt;
using Interpretor.Domain.Expressions;
using Interpretor.Domain.DataStructures;


namespace Interpretor.ViewUi
{
    public class Ui
    {
        private Controller ctrl;
        //private IRepository repo;
        //private Scanner scanner;
        //private PrgState currPrg;

        public Ui()
        { }


        private string mainMenu = "\n----MAIN MENU----\n" +
                "1. Input a program.\n" +
                "2. One step execution.(only when debug is true)\n" +
                "3. Complete execution.\n" +
                "4. Serialize program.\n" +
                "5. Deserialize program.\n" +
                "6. Write to file.\n" +
                "0. Exit. Bye bye... \n";

        private string stmtMenu = "----\nSTATEMENT MENU----\n" +
                "1. COMPOUND statement.\n" +
                "2. ASSIGN statement.\n" +
                "3. IF statement. \n" +
                "4. PRINT statement. \n" +
                "5. WHILE statement. \n" +
                "6. SWITCH statement. \n" +
                "7. IF SKIP statement. \n" +
                "8. NEW statement. \n" +
                "9. WRITE HEAP statement. \n" ;



        private string expMenu = "\n----EXPRESSION MENU----\n" +
                "1. Arithmetical expression. \n" +
                "2. Constant expression.\n" +
                "3. Variable expression. \n" +
                "4. Boolean expression.\n" +
                "5. Logical expression. \n" +
                "6. Read expression. \n" +
                "7. Read heap expression. \n" ;



        private void oneStepUi()
        {
            try
            {
                ctrl.oneStep();
            }
            catch (StmtExcecutionException)
            {
                print("\nFINISHED\n");
            }
            catch (NotKeyException)
            {
                print("Key not found one\n ");
            }
            catch (VarNotDefinedException)
            {
                print("Var not defined\n");
            }
            catch (IsFullListException)
            {
                print("Full aoutput list\n");
            }
            catch (DivideByZeroException)
            {
                print("Division by 0!\n");
            }
            catch (RepoException)
            {
                print("No program state\n");
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
                print("\nFINISHED\n");
            }
            catch (VarNotDefinedException)
            {
                print("Variable not defined!");
            }
            catch (DivideByZeroException)
            {
                print("Division by zero!");
            }
            catch (IsFullListException)
            {
                print("Full output list!");
            }
            
            catch (NotKeyException)
            {
                print("Key not found! all");
            }
            

        }



        private void toggleWriteFlag()
        {
            if (ctrl.isWriteFlag()) { print("Write mode: ON"); }
            else { print("Write mode: OFF"); }
            print("1. Change Write Flag");
            print("0. Do not change Write Flag");
        }


        private void print(String message)
        {
            Console.WriteLine(message);
        }

        private String readString(String message)
        {
            try
            {
                print(message);
                return Console.ReadLine();
            }
            catch
            {
                print("something went wrong while reading string");
            }
            return "";
        }

        private int readInteger(String message)
        {
            try
            {
                return Convert.ToInt32(readString(message));
            }
            catch
            {
                throw new WrongDataTypeException();
            }
        }



        private void printmainMenu()
        {
            int option = -1;
            print(mainMenu);
            try
            {
                option = readInteger("Choose an option:");

                if (option != 0)
                {
                    switch (option)
                    {
                        case 1:
                            {
                                inputPrg();
                                printmainMenu();
                                break;
                            }

                        case 2:
                            {
                                this.toggleWriteFlag();
                                try
                                {
                                    int op;
                                    op = readInteger("Choose an option:");
                                    if (op == 1)
                                    {
                                        ctrl.changeWrite();
                                    }
                                    else { break; }
                                }
                                catch (WrongDataTypeException)
                                {
                                    print("Input invalid");
                                }
                                finally
                                {
                                    oneStepUi();
                                    if (ctrl.isWriteFlag()) { ctrl.getRepo().writeToFile(); }
                                    else {
                                        //print(ctrl.getRepo().States.ToString());
                                        foreach (PrgState x in ctrl.getRepo().States)
                                        {
                                            print(x.ToString());
                                        }
                                    }

                                }
                                break;
                            }

                        case 3:
                            {
                                this.toggleWriteFlag();
                                try
                                {
                                    int op;
                                    op = readInteger("Choose an option:");
                                    if (op == 1)
                                    {
                                        ctrl.changeWrite();
                                    }
                                    else { break; }
                                }
                                catch (WrongDataTypeException)
                                {
                                    print("Input invalid");
                                }
                                finally
                                {
                                    allStepUi();
                                    if (ctrl.isWriteFlag()) { ctrl.getRepo().writeToFile(); }
                                    else { //print(ctrl.getRepo().States.ToString());
                                        foreach (PrgState x in ctrl.getRepo().States)
                                        {
                                            print(x.ToString());
                                        }
                                    }

                                }
                                break;
                            }

                        case 4:
                            {
                                ctrl.getRepo().serializePrg();
                                print("Serialized!");
                                printmainMenu();
                                break;
                            }

                        case 5:
                            {
                                System.Collections.Generic.List<PrgState> prgStaes;
                                prgStaes = ctrl.getRepo().deserializePrg();
                                foreach (PrgState x in prgStaes)
                                {
                                    print(x.ToString());
                                }
                                //print(prgStaes.ToString());
                                //print(currPrg.ToString());
                                break;
                            }
                        case 6:
                            {
                                ctrl.getRepo().writeToFile();
                                break;
                            }

                        case 0:
                            {
                                break;
                            }
                        default:
                            Console.WriteLine("Invalid option! Please try again.\n");
                            break;

                    }
                }
                printmainMenu();
            }
            catch (WrongDataTypeException)
            {
                print("Please insert an integer!");
                this.printmainMenu();
            }
            catch (RepoException)
            {
                print("No program state added");
            }
        }



        private Expr inputExpr()
        {
            Expr exp;
            int option;
            Console.WriteLine(expMenu);
            Console.WriteLine("");
            option = readInteger("Choose an option: ");

            switch (option)
            {
                case 1:
                    {
                        exp = arExp();
                        break;
                    }

                case 2:
                    {
                        exp = cstExp();
                        break;
                    }

                case 3:
                    {
                        exp = varExp();
                        break;
                    }

                case 4:
                    {
                        exp = boolExp();
                        break;
                    }

                case 5:
                    {
                        exp = logicalExp();
                        break;
                    }

                case 6:
                    {
                        exp = readExpr();
                        break;
                    }

                case 7:
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




        private ArithExpr arExp()
        {
            Console.WriteLine("Operator: 1 for + , 2 or - , 3 for * , 4 for / \n");
            //Console.WriteLine();
            String op = readString("Type operator: ");
            Console.WriteLine("Left operand: ");
            Expr left = inputExpr();
            Console.WriteLine("Right operand: ");
            Expr right = inputExpr();
            return new ArithExpr(left, right, op);

        }

        private ConstExpr cstExp()
        {
            //Console.WriteLine();
            int cst = readInteger("Constant: ");
            return new ConstExpr(cst);
        }

        private VarExpr varExp()
        {
            //Console.WriteLine("Variable id: ");
            String id = readString("Variable id: ");
            return new VarExpr(id);
        }

        private BoolExpr boolExp()
        {
            Console.WriteLine("Operator: <, >, <=, >=, ==, != \n");
            //Console.WriteLine();
            String op = readString("Type operator: ");
            Console.WriteLine("Left operand: ");
            Expr left = inputExpr();
            Console.WriteLine("Right operand: ");
            Expr right = inputExpr();
            return new BoolExpr(left, right, op);

        }

        private LogicalExpr logicalExp()
        {
            print("Options: &&, ||, !\n");
            print("Operator:");
            String op = readString("Operator: ");
            print("Left operand: ");
            Expr left = inputExpr();
            if(! op.Equals("!")){
                print("Right operand: ");
                Expr right = inputExpr();
                return new LogicalExpr(left, right, op);
            }
        return new LogicalExpr(left, op);
        }


        private ReadExpr readExpr() 
        {
           
            int nr = readInteger("Input an integer: ");
            return  new ReadExpr(nr);
        }

        private ReadHeapExpr readHeap()
        {

            String varname = readString("Var name: ");
            return new ReadHeapExpr(varname);
        }


     

        private IStmt inputStmt()
        {


            Console.WriteLine(stmtMenu);
            //Console.WriteLine("Choose an option:");


            try
            {
                int option = readInteger("Chooose an option");
                IStmt crnt;

                switch (option)
                {
                    case 1:
                        {
                            crnt = cmpStmt();
                            break;
                        }

                    case 2:
                        {
                            crnt = assignStmt();
                            break;
                        }

                    case 3:
                        {
                            crnt = ifStmt();
                            break;
                        }

                    case 4:
                        {
                            crnt = printStmt();
                            break;
                        }

                    case 5:
                        {
                            crnt = whileStmt();
                            break;
                        }

                    case 6:
                        {
                            crnt = switchStmt();
                            break;
                        }

                    case 7:
                        {
                            crnt = ifSkipStmt();
                            break;
                        }
                    case 8:
                        {
                            crnt = newStmt();
                            break;
                        }

                    case 9:
                        {
                            crnt = writeHeapStmt();
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
                print("Invalid option, try again!\n");

            }
            return inputStmt();
        }

        private CompStmt cmpStmt()
        {
            Console.WriteLine("First statement:");
            IStmt first = inputStmt();
            Console.WriteLine("Second statement:");
            IStmt snd = inputStmt();
            return new CompStmt(first, snd);

        }

        private AssignStmt assignStmt()
        {
            //Console.WriteLine("Variable name:");
            String id = readString("Variable name:");
            Console.WriteLine("Variable value:");
            Expr exp = inputExpr();
            return new AssignStmt(id, exp);
        }

        private IfStmt ifStmt()
        {
            Console.WriteLine("IF Expression:");
            Expr exp = inputExpr();
            Console.WriteLine("THEN statement:");
            IStmt thenS = inputStmt();
            Console.WriteLine("ELASE statement:");
            IStmt elseS = inputStmt();
            return new IfStmt(exp, thenS, elseS);
        }

        private PrintStmt printStmt()
        {
            Console.WriteLine("Expression:");
            Expr exp = inputExpr();
            return new PrintStmt(exp);
        }

        /*
        private DecStmt decStmt()
        {
            Console.WriteLine("Expression:");
            Expr exp = inputExpr();
            return new DecStmt(exp);
        }
        */

        private WhileStmt whileStmt()
        {
            Console.WriteLine("Expression:");
            Expr exp = inputExpr();
            Console.WriteLine("Statement:");
            IStmt stmt = inputStmt();
            return new WhileStmt(exp, stmt);
        }


        private SwitchStmt switchStmt() 
        {
            
            String varname = readString("Variable name: ");
            Expr exp;
            String opt;
            IStmt stmt;
            Domain.DataStructures.IDictionary<Expr, IStmt> tbl = new MyLibMap<Expr, IStmt>();
        while(true){
                print("CASE expression: ");
                exp = inputExpr();
                print("Statement: ");
                stmt = inputStmt();
                try
                {
                    tbl.add(exp, stmt);
                }
                catch (IsFullDictException)
                {
                    print("Full symbol table!");
                }

                opt = readString("Another CASE? (y/n)");
                if (opt.Equals("n")) { break; }
            }
            print("DEFAULT statement: ");
            stmt = inputStmt();
        return  new SwitchStmt(varname, tbl, stmt);
        }


        private IfSkipStmt ifSkipStmt()
        {
            print("Expression: ");
            Expr expression = inputExpr();
            print("Then statement: ");
            IStmt thenS = inputStmt();
            return new IfSkipStmt(expression, thenS);
        }

        private NewStmt newStmt()
        {
            String name = readString("Var name:");
            print("Expression: ");
            Expr exp = inputExpr();
            return new NewStmt(name, exp);
        }

        private WriteHeapStmt writeHeapStmt()
        {
            String name = readString("Var name:");
            print("Expression: ");
            Expr exp = inputExpr();
            return new WriteHeapStmt(name, exp);
        }



        private void inputPrg()
        {
            IStmt st1 = new AssignStmt("v", new ConstExpr(10));
            IStmt st2 = new NewStmt("a", new ConstExpr(22));
            IStmt st3 = new AssignStmt("v", new ConstExpr(32));
            IStmt st4 = new PrintStmt(new VarExpr("v"));
            IStmt st5 = new PrintStmt(new ReadHeapExpr("a"));
            IStmt st8 = new ForkStmt(new CompStmt(new WriteHeapStmt("a", new ConstExpr(30)), new CompStmt(st3, new CompStmt(st4, st5))));
            IStmt st6 = new PrintStmt(new VarExpr("v"));
            IStmt st7 = new PrintStmt(new ReadHeapExpr("a"));
            IStmt prgStatement = new CompStmt(st1, new CompStmt(st2, new CompStmt(st8, new CompStmt(st6, new CompStmt(st7, new CompStmt(new SkipStmt(), new CompStmt(new SkipStmt(), new SkipStmt())))))));

            List<PrgState> programs = new List<PrgState>();
            programs.Add(new PrgState(new MyLibStack<IStmt>(), new MyLibMap<string, int>(), new MyLibList<int>(), new MyLibHeap<int>(), prgStatement));
            programs.ForEach(p => print(p.ToString()));
            ctrl = new Controller(new Repository(programs));
            ctrl.serializeProgramState();


            //IStmt prgStmt = inputStmt();


            /*
             IStmt prgStmt = new CompStmt(new AssignStmt("v",new ConstExpr(6)),
                new CompStmt(new WhileStmt(new ArithExpr(new VarExpr("v"), new ConstExpr(4), 2),
                        new CompStmt(new PrintStmt(new VarExpr("v")), new AssignStmt("v", new ArithExpr(new VarExpr("v"), new ConstExpr(1), 2)))),
                        new PrintStmt(new VarExpr("v"))));
             */





            /*
            MyLibStack<IStmt> stk = new MyLibStack<IStmt>();
            MyLibMap<string, int> dict = new MyLibMap<string, int>();
            MyLibList<string> output = new MyLibList<string>();
            MyLibHeap<int> heap = new MyLibHeap<int>();
            MyLibMap<Expr, IStmt> tbl = new MyLibMap<Expr, IStmt>();
            IStmt prgStmt = new CompStmt(new NewStmt("a", new ConstExpr(10)), new CompStmt(new WriteHeapStmt("a", new ConstExpr(4)), new CompStmt(new AssignStmt("b", new ConstExpr(5)), new PrintStmt(new ReadHeapExpr("a")))));

            */

            /*
            //switch
            try
            {
                tbl.add(new ConstExpr(1), new CompStmt(new AssignStmt("a", new VarExpr("v")), new PrintStmt(new ArithExpr(new VarExpr("a"), new ConstExpr(1), 1))));
                tbl.add(new ConstExpr(5), new CompStmt(new AssignStmt("a", new ArithExpr(new VarExpr("v"), new ConstExpr(1), 1)), new PrintStmt(new ArithExpr(new VarExpr("a"), new ConstExpr(1), 1))));
                tbl.add(new ConstExpr(2), new CompStmt(new AssignStmt("a", new ArithExpr(new VarExpr("v"), new ConstExpr(2), 1)), new PrintStmt(new ArithExpr(new VarExpr("a"), new ConstExpr(1), 1))));
            }
            catch (IsFullDictException)
            {
                print("Full map");
            }
            


            IStmt prgStmt = new CompStmt(new AssignStmt("v", new ConstExpr(5)),
               new CompStmt(new SwitchStmt("v", tbl, new CompStmt(new AssignStmt("a", new ConstExpr(0)), new PrintStmt(new VarExpr("a")))),
                       new CompStmt(new AssignStmt("c", new ArithExpr(new ReadExpr(0), new BoolExpr(new ConstExpr(2), new ConstExpr(10), "<"), 2)),
                               new AssignStmt("d", new LogicalExpr(new LogicalExpr(new VarExpr("c"), "!"), new BoolExpr(new ConstExpr(10), new ConstExpr(10), "<="), "&&")))));

            */

            /*------------------------------------------------------------------
            IList<PrgState> prgStates = new MyLibList<PrgState>();

            PrgState prgS = new PrgState(1, stk, dict, output, heap, prgStmt);

            try
            {
                prgStates.add(prgS);
            }
            catch (IsFullListException)
            {
                print("Full list");
            }

            ctrl = new Controller(new Repository(prgStates));
            currPrg = ctrl.getRepo().getCrtPrg();
            print(currPrg.ToString());

            */

        }

        public void run()
        {
            printmainMenu();
        }
    }
}
