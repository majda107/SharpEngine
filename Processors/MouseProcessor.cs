using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Input;

namespace SharpEngine.Processors
{
    class MouseProcessor : AMouseProcessor
    {
        private MouseState prevState;

        public override void Update(MouseState currentState)
        {
            this.x = currentState.X;
            this.y = currentState.Y;

            this.xDev = currentState.X - this.prevState.X;
            this.yDev = currentState.Y - this.prevState.Y;

            this.prevState = currentState;
        }
    }
}
