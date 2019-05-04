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
        public Solid(Face3[] faces, Vector3 pos) : base(pos, faces)
        {

        }

        protected override void UpdateHitbox()
        {
            // maybe add some checking if update is really needed? Won't implement this until rotation via pivot is implemented tho...
            if(this.Faces != null)
            {
                float left = Faces[0].vertices[0].X;
                float right = Faces[0].vertices[0].X;
                float top = Faces[0].vertices[0].Y;
                float bottom = Faces[0].vertices[0].Y;
                float close = Faces[0].vertices[0].Z;
                float distant = Faces[0].vertices[0].Z;

                foreach (Face3 face in Faces)
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

                this.hitbox = new Hitbox(new Vector3(left, bottom, close), new Vector3(right, top, distant), this.Debug);
            }
        }

        protected override void UpdateVertices(Vector3 dev)
        {
            if(dev != new Vector3(0, 0, 0))
            {
                if(this.Faces != null)
                {
                    for (int i = 0; i < this.Faces.Length; i++)
                    {
                        for (int j = 0; j < this.Faces[i].vertices.Length; j++)
                        {
                            Faces[i].vertices[j] += dev;
                        }
                    }
                }
            }
        }

        protected override void RenderBody()
        {
            GL.PushMatrix();

            GL.Color4(color);

            foreach (Face3 face in Faces)
            {
                face.Render();
            }

            GL.PopMatrix();
        }
    }
}
