using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpEngine.ObjLoader;
using OpenTK.Graphics.OpenGL;
using SharpEngine.Gamelib;
using OpenTK;

namespace SharpEngine.Solids
{
    class Solid : ASolid
    {
        // field used for storing pos deviation
        private Vector3 prevPos;

        public Solid(Face3[] faces, Vector3 pos) : base(pos)
        {
            // deviation = pos, reason for 0 0 0 
            this.prevPos = new Vector3(0, 0, 0);
            this.faces = faces;

            this.UpdateHitbox();
        }

        protected override void UpdateHitbox()
        {
            // maybe add some checking if update is really needed? Won't implement this until rotation via pivot is implemented tho...
            float left = faces[0].vertices[0].X;
            float right = faces[0].vertices[0].X;
            float top = faces[0].vertices[0].Y;
            float bottom = faces[0].vertices[0].Y;
            float close = faces[0].vertices[0].Z;
            float distant = faces[0].vertices[0].Z;

            foreach (Face3 face in faces)
            {
                foreach (Vector3 vertex in face.vertices)
                {
                    if (vertex.X > left) left = vertex.X;
                    if (vertex.X < right) right = vertex.X;
                    if (vertex.Y > top) top = vertex.Y;
                    if (vertex.Y < bottom) bottom = vertex.Y;
                    if (vertex.Z < close) close = vertex.Z;
                    if (vertex.Z > distant) distant = vertex.Z;
                }
            }

            this.hitbox = new Hitbox(new Vector3(left, bottom, close), new Vector3(right, top, distant), this.debug);
        }

        protected override void UpdateVertices()
        {
            Vector3 dev = pos - prevPos;
            if(dev != new Vector3(0, 0, 0))
            {
                for (int i = 0; i < this.faces.Length; i++)
                {
                    for (int j = 0; j < this.faces[i].vertices.Length; j++)
                    {
                        faces[i].vertices[j] += dev;
                    }
                }
                prevPos = pos;
            }
        }

        protected override void RenderBody()
        {
            GL.PushMatrix();

            GL.Color4(color);

            foreach (Face3 face in faces)
            {
                face.Render();
            }

            GL.PopMatrix();
        }
    }
}
