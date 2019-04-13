using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpEngine.ObjLoader;
using OpenTK.Graphics.OpenGL;
using OpenTK;

namespace SharpEngine.Solids
{
    class Solid : ASolid
    {
        private Face3[] faces;
        public Solid(Face3[] faces, Vector3 pos) : base(pos)
        {
            this.faces = faces;
        }
        protected override void RenderBody()
        {
            GL.PushMatrix();

            GL.Scale(this.scale);

            GL.Rotate(this.angles.X, Vector3.UnitY);
            GL.Rotate(this.angles.Y, Vector3.UnitX);
            GL.Rotate(this.angles.Z, Vector3.UnitZ);

            GL.Color4(color);

            GL.Begin(PrimitiveType.Triangles);

            foreach (Face3 face in faces)
            {
                for(int i = 0; i < 3; i++)
                {
                    GL.Vertex3(face.vertices[i] + pos);
                    GL.Normal3(face.normals[i]);
                    GL.TexCoord2(face.textures[i]);
                }
            }

            GL.End();

            GL.PopMatrix();
        }
    }
}
