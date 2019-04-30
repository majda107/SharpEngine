using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using SharpEngine.Solids;

namespace SharpEngine.Physics
{
    class RigidBody : APhysicElement
    {
        private bool _gravity;
        public bool Gravity
        {
            get => _gravity; 
            set
            {
                _gravity = value;
                speed = Speed;
            }
        }

        public float Speed { get; set; }
        private float speed;
        public float gravity;

        public RigidBody()
        {
            this.Gravity = true;
            this.Speed = 0.05f;
            this.speed = Speed;
            this.gravity = 4f;
        }
        public override void Update(ASolid solid)
        {
            if(Gravity)
            {
                solid.Pos = solid.Pos - new Vector3(0.0f, gravity * speed, 0.0f);
                if (speed < gravity) speed += 0.05f;
            }
        }
    }
}
