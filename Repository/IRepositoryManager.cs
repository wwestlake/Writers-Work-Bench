using LagDaemon.WWB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagDaemon.WWB.Repository
{
    public interface IRepositoryManager
    {
        IItemManager<Project> ProjectManager { get; }
        IItemManager<Character> CharacterManager { get; }
    }
}
