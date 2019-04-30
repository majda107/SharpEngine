using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpEngine.GameManager
{
    abstract class AGameObject
    {
        private Vector3 _pos;

        public Vector3 Pos { get => _pos; set {
                if(_pos != value)
                {
                    _pos = value;
                    this.Update();
                }
            } }

        protected abstract void Update();
    }
}
