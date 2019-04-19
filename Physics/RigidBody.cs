using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpEngine.Solids;

namespace SharpEngine.Physics
{
    class RigidBody : APhysicElement
    {
        public bool Gravity { get; set; }

        public float speed;
        public float gravity;

        public RigidBody()
        {
            this.Gravity = true;
            this.speed = 0.05f;
            this.gravity = 4f;
        }
        public override void Update(ASolid solid)
        {
            if(Gravity)
            {
                solid.pos.Y -= gravity * speed;
                if (speed < gravity) speed += 0.05f;
            }
        }
    }
}
