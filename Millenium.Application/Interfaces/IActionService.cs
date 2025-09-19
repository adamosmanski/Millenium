using Millenium.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Millenium.Application.Interfaces
{
    public interface IActionService
    {
        IEnumerable<string> GetAllowedActions(CardDetails card);
    }
}
