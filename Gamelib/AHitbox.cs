using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace SharpEngine.Gamelib
{
    abstract class AHitbox
    {
        public bool visible { get; set; }
        public AHitbox()
        {
            this.offset = 0.2f;
            this.visible = false;
        }
        /// <summary>
        /// Defines left - bottom - close coord of hitbox 
        /// </summary>
        public Vector3 first { get; protected set; }
        /// <summary>
        /// Defines right - top - distant coord of hitbox
        /// </summary>
        public Vector3 second { get; protected set; }

        public float offset { get; set; }
        public void Render()
        {
            GL.Color4(0.3, 0.3, 0.7, 0.4);

            GL.Begin(PrimitiveType.Quads);

            //front
            GL.Vertex3(first.X, second.Y, first.Z - offset);
            GL.Vertex3(first.X, first.Y, first.Z - offset);
            GL.Vertex3(second.X, first.Y, first.Z - offset);
            GL.Vertex3(second.X, second.Y, first.Z - offset);

            //back
            GL.Vertex3(first.X, second.Y, second.Z + offset);
            GL.Vertex3(first.X, first.Y, second.Z + offset);
            GL.Vertex3(second.X, first.Y, second.Z + offset);
            GL.Vertex3(second.X, second.Y, second.Z + offset);

            //left
            GL.Vertex3(first.X + offset, second.Y, second.Z);
            GL.Vertex3(first.X + offset, first.Y, second.Z);
            GL.Vertex3(first.X + offset, first.Y, first.Z);
            GL.Vertex3(first.X + offset, second.Y, first.Z);

            //right
            GL.Vertex3(second.X - offset, second.Y, second.Z);
            GL.Vertex3(second.X - offset, first.Y, second.Z);
            GL.Vertex3(second.X - offset, first.Y, first.Z);
            GL.Vertex3(second.X - offset, second.Y, first.Z);

            //top
            GL.Vertex3(first.X, second.Y + offset, second.Z);
            GL.Vertex3(first.X, second.Y + offset, first.Z);
            GL.Vertex3(second.X, second.Y + offset, first.Z);
            GL.Vertex3(second.X, second.Y + offset, second.Z);

            //bottom
            GL.Vertex3(first.X, first.Y - offset, second.Z);
            GL.Vertex3(first.X, first.Y - offset, first.Z);
            GL.Vertex3(second.X, first.Y - offset, first.Z);
            GL.Vertex3(second.X, first.Y - offset, second.Z);

            GL.End();
        }
        public bool Collide(AHitbox hitbox)
        {
            // Basically compare first and seconds positions of both hitboxes, too much math to do at 1 AM...
            throw new NotImplementedException();
        }
    }
}
