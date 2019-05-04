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
                    this.UpdatePos(value - _pos);
                    _pos = value;
                }
            } }

        protected abstract void UpdatePos(Vector3 dev);
    }
}
