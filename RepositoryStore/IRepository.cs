using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interpretor.Domain.DataStructures;
using Interpretor.Domain;
namespace Interpretor.RepositoryStore
{
    public interface IRepository
    {
        
        System.Collections.Generic.List<PrgState> States { get; set; }
        void serializePrg();
        System.Collections.Generic.List<PrgState> deserializePrg();
        void writeToFile() ;
        
    }
}
