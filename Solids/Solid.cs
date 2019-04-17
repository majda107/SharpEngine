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
        private Face3[] faces;
        public Solid(Face3[] faces, Vector3 pos) : base(pos)
        {
            this.faces = faces;
            this.hitbox = CreateHitbox(ref faces);
        }

        public Hitbox CreateHitbox(ref Face3[] faces)
        {
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

            return new Hitbox(new Vector3(left, bottom, close) + pos, new Vector3(right, top, distant) + pos);
        }

        protected override void RenderBody()
        {
            GL.PushMatrix();

            GL.Scale(this.scale);

            GL.Rotate(this.angles.X, Vector3.UnitY);
            GL.Rotate(this.angles.Y, Vector3.UnitX);
            GL.Rotate(this.angles.Z, Vector3.UnitZ);

            GL.Color4(color);

            foreach (Face3 face in faces)
            {
                if (face.material != null) face.material.Load(); // load material values
                GL.BindTexture(TextureTarget.Texture2D, face.material.textureID); // bind material texture

                GL.Begin(PrimitiveType.Triangles); // begin polygon drawing

                for (int i = 0; i < 3; i++)
                {
                    GL.Normal3(face.normals[i]);
                    GL.TexCoord2(face.textures[i]);
                    GL.Vertex3(face.vertices[i] + pos);
                }

                GL.End();

                GL.BindTexture(TextureTarget.Texture2D, 0);
            }

            GL.PopMatrix();
        }
    }
}
