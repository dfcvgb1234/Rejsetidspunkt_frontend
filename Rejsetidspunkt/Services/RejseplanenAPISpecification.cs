using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rejsetidspunkt.Services
{
    public abstract class RejseplanenAPISpecification
    {
        protected string RejseplanenBaseURL { get; } = "https://xmlopen.rejseplanen.dk/bin/rest.exe";
    }
}
