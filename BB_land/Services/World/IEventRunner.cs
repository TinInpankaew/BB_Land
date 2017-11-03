using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BB_land.World.Events;

namespace BB_land.Services.World
{
    internal interface IEventRunner
    {
        void RunEvents(IList<IEvent> events);
    }
}
