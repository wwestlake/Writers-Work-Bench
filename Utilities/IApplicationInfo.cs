using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagDaemon.WWB.Utilities
{
    public interface IApplicationInfo
    {
        Version Version { get; }
        string Title { get; }
        string ProductName { get; }
        string Description { get; }
        string CopyrightHolder { get; }
        string CompanyName { get; }
        string ApplicationDataDirectory { get; }
        string ApplicationLogDirectory { get; }
        string ApplicationProjectDirectory { get; }
        string ApplicationConfigurationDirectory { get; }
        string ApplicationResourcesDirectory { get; }
    }
}
