using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interpretor.RepositoryStore;
using Interpretor.Domain;
using Interpretor.Domain.Stmt;
using Interpretor.Domain.DataStructures;
using Interpretor.Domain.Expressions;


namespace Interpretor.Contrl
{
    public class Controller
    {
        private IRepository repo;
        //private PrgState crtPrg;
        private bool debugFlag = false;
        private bool writeFlag = false;


        public Controller(IRepository r)
        {
            this.repo = r;
            //crtPrg = repo.getCrtPrg();
        }


        public void changeDebug()
        {
            debugFlag = !debugFlag;
        }


        public void changeWrite()
        {
            writeFlag = !writeFlag;
        }

        public bool isWriteFlag()
        {
            return writeFlag;
        }

        public System.Collections.Generic.List<PrgState> removeCompletedPrg(System.Collections.Generic.List<PrgState> prgList)
        {
            return prgList.Where(p => p.isNotComplete()).ToList();
        }

        public void serializeProgramState()
        {
            repo.serializePrg();
        }

        public void oneStepForAll(System.Collections.Generic.List<PrgState> prgList)
        {
            System.Collections.Generic.List<Task<PrgState>> taskList = (from prg in prgList
                                             select Task<PrgState>.Factory.StartNew(() => prg.oneStep())).ToList();

            try
            {
                System.Collections.Generic.List<PrgState> newPrgList = (from tsk in taskList
                                             where tsk.Result != null
                                             select tsk.Result).ToList();
                newPrgList.AddRange(prgList.Where(p => !newPrgList.Any(q => q.getId() == p.getId())).ToList());
                
                if (writeFlag)
                {
                    repo.writeToFile();
                }
                repo.States = newPrgList;
            }
            catch (Exception e)
            {
                Console.Write("something" + e.StackTrace);
            }

            
        }

        public void oneStep()
        {
            System.Collections.Generic.List<PrgState> prgList = removeCompletedPrg(repo.States);
            oneStepForAll(prgList);
        }

        public void allStep()
        {
            
            while (true)
            {
                System.Collections.Generic.List<PrgState> prgList = removeCompletedPrg(repo.States);
                if (prgList.Count() == 0)
                {
                    return;
                }
                else
                {
                    oneStepForAll(prgList);
                }
            }

        }


        public IRepository getRepo()
        {
            return repo;
        }

        public void setRepo(IRepository repo)
        {
            this.repo = repo;
        }

        public bool isDebugFlag()
        {
            return debugFlag;
        }

        public void setDebugFlag(bool debugFlag)
        {
            this.debugFlag = debugFlag;
        }
    }
}
