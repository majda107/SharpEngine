using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Input;

namespace OpenGLCamera.Gamelib
{
    abstract class AKeyProcessor
    {
        public List<Key> keysDown{ get; private set; }
        public AKeyProcessor()
        {
            this.keysDown = new List<Key>();
        }
    }
}
