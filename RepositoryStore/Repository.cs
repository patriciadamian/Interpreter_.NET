using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using Interpretor.Domain;
using Interpretor.Domain.DataStructures;
//using static System.Net.WebRequestMethods;


namespace Interpretor.RepositoryStore
{
    public class Repository : IRepository
    {
        private System.Collections.Generic.List<PrgState> states;


        public Repository()
        {
            this.states = new System.Collections.Generic.List<PrgState>();
        }

        public Repository(System.Collections.Generic.List<PrgState> st)
        {
            this.states = st;
        }

        public System.Collections.Generic.List<PrgState> States
        {
            get
            {
                return states;
            }

            set
            {
                states = value;
            }
        }


        public void serializePrg()
        {
            IFormatter formatter = new BinaryFormatter();
            using (FileStream s = File.Create("ProgramState.bin"))
            {
                formatter.Serialize(s, states);
            }

        }


        public System.Collections.Generic.List<PrgState> deserializePrg()
        {
            IFormatter formatter = new BinaryFormatter();
            using (FileStream s = File.OpenRead("ProgramState.bin"))
            {
                this.states = (System.Collections.Generic.List<PrgState>)formatter.Deserialize(s);
            }

            return states;
            

        }


        public void writeToFile()
        {
            using (StreamWriter w = File.AppendText("write.txt"))
            {
                foreach(PrgState x in this.states)
                {
                    w.WriteLine(x.ToString());
                    w.WriteLine();
                }
                
            }
           
        }


    }

}
