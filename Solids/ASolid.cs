using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpEngine.Gamelib;
using SharpEngine.GameManager;
using OpenTK;
using SharpEngine.ObjLoader;
using SharpEngine.Physics;

namespace SharpEngine.Solids
{
    abstract class ASolid : AGameObject
    {
        public delegate void CollisionEventHandler(object sender, CollisionEventArgs e);
        public event CollisionEventHandler Collision;

        // Render
        public bool visible { get; set; }
        public bool debug { get; set; }
        public float[] color { get; set; }


        // Body
        protected Face3[] faces;
        public AHitbox hitbox { get; set; }


        // Physics
        public List<APhysicElement> physicElements { get; set; }

        public ASolid(Vector3 pos)
        {
            this.pos = pos;
            this.hitbox = null;
            this.visible = true;
            this.physicElements = new List<APhysicElement>();

            this.color = new float[4] { 1.0f, 1.0f, 1.0f, 1.0f };
        }

        public void Render()
        {
            if (visible) RenderBody();
            if (hitbox != null && hitbox.visible)
            {
                hitbox.Render();
            }
        }

        protected abstract Hitbox UpdateHitbox(ref Face3[] faces);
        public void Update()
        {
            this.hitbox = UpdateHitbox(ref faces);
            foreach(APhysicElement element in this.physicElements)
            {
                element.Update(this);
            }
        }

        protected abstract void RenderBody();

        public bool Collide(ASolid solid)
        {
            bool collision = this.hitbox.Collide(solid.hitbox);
            if(collision)
            {
                if(this.Collision != null)
                {
                    Collision(this, new CollisionEventArgs(solid));
                }
            }
            return collision;
        }
    }
}
