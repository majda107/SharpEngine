using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace SharpEngine.ObjLoader
{
    class Face3
    {
        public Vector3[] vertices;
        public Vector2[] textures;
        public Vector3[] normals;

        public Material material;

        public Face3(Vector3[] vertices, Vector2[] textures, Vector3[] normals)
        {
            this.vertices = vertices;
            this.textures = textures;
            this.normals = normals;

            this.material = null;
        }

        public Face3(Vector3[] vertices, Vector2[] textures, Vector3[] normals, Material material)
        {
            this.vertices = vertices;
            this.textures = textures;
            this.normals = normals;

            this.material = material;
        }

        public void Render()
        {
            if (this.material != null) this.material.Load(); // load material values
            GL.BindTexture(TextureTarget.Texture2D, this.material.textureID); // bind material texture

            GL.Begin(PrimitiveType.Triangles); // begin polygon drawing

            for (int i = 0; i < 3; i++)
            {
                GL.Normal3(this.normals[i]);
                GL.TexCoord2(this.textures[i]);
                GL.Vertex3(this.vertices[i]);
            }

            GL.End();

            GL.BindTexture(TextureTarget.Texture2D, 0);
        }
    }
}
