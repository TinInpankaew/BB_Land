using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BB_land.World
{
    internal interface IComponentOwner
    {
        string Id { get; }
        T Component<T>() where T : Component;
    }
}
