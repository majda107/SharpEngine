using SharpEngine.Solids;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpEngine.Physics
{
    abstract class APhysicElement
    {
        abstract public void Update(ASolid solid);
    }
}
