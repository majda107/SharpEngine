using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Input;

namespace SharpEngine.Processors
{
    class KeyboardProcessor : AKeyProcessor
    {
        public void AddKey(Key key)
        {
            if (!this.keysDown.Contains(key)) this.keysDown.Add(key);
        }

        public void RemoveKey(Key key)
        {
            if (this.keysDown.Contains(key)) this.keysDown.Remove(key);
        }
    }
}
