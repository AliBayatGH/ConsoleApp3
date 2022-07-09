using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIT.Hastim.IDR.Domain.Parties.Enums
{
    //TODO: Change values of state
    public enum PartyRoleState : int
    {
        Draft = 0,
        Sent = 1,
        Publish = 2,
        Block = 3
    }
}