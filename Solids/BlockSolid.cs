using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL;
using OpenTK;

namespace OpenGLCamera.Solids
{
    class BlockSolid : ASolid
    {
        public int width { get; private set; }
        public int height { get; private set; }
        public int depth { get; private set; }

        public float[] color { get; set; }
        public BlockSolid(Vector3 pos, int width, int height, int depth)
        {
            this.pos = pos;
            this.width = width;
            this.height = height;
            this.depth = depth;
            this.color = new float[3] { 1.0f, 1.0f, 1.0f };
        }

        public override void Render()
        {
            GL.Color3(color) ;

            GL.Begin(PrimitiveType.Quads);

            GL.Normal3(-1.0, 0.0, 0.0);
            GL.Vertex3(pos.X + -width / 2, pos.Y + height / 2, pos.Z + depth / 2);
            GL.Vertex3(pos.X + -width / 2, pos.Y + height / 2, pos.Z + -depth / 2);
            GL.Vertex3(pos.X + -width / 2, pos.Y + -height / 2, pos.Z + -depth / 2);
            GL.Vertex3(pos.X + -width / 2, pos.Y + -height / 2, pos.Z + depth / 2);

            GL.Normal3(1.0, 0.0, 0.0);
            GL.Vertex3(pos.X + width / 2, pos.Y + height / 2, pos.Z + depth / 2);
            GL.Vertex3(pos.X + width / 2, pos.Y + height / 2, pos.Z + -depth / 2);
            GL.Vertex3(pos.X + width / 2, pos.Y + -height / 2, pos.Z + -depth / 2);
            GL.Vertex3(pos.X + width / 2, pos.Y + -height / 2, pos.Z + depth / 2);

            GL.Normal3(0.0, -1.0, 0.0);
            GL.Vertex3(pos.X + width / 2, pos.Y + -height / 2, pos.Z + depth / 2);
            GL.Vertex3(pos.X + width / 2, pos.Y + -height / 2, pos.Z + -depth / 2);
            GL.Vertex3(pos.X + -width / 2, pos.Y + -height / 2, pos.Z + -depth / 2);
            GL.Vertex3(pos.X + -width / 2, pos.Y + -height / 2, pos.Z + depth / 2);

            GL.Normal3(0.0, 1.0, 0.0);
            GL.Vertex3(pos.X + width / 2, pos.Y + height / 2, pos.Z + depth / 2);
            GL.Vertex3(pos.X + width / 2, pos.Y + height / 2, pos.Z + -depth / 2);
            GL.Vertex3(pos.X + -width / 2, pos.Y + height / 2, pos.Z + -depth / 2);
            GL.Vertex3(pos.X + -width / 2, pos.Y + height / 2, pos.Z + depth / 2);

            GL.Normal3(0.0, 0.0, -1.0);
            GL.Vertex3(pos.X + width / 2, pos.Y + height / 2, pos.Z + -depth / 2);
            GL.Vertex3(pos.X + width / 2, pos.Y + -height / 2, pos.Z + -depth / 2);
            GL.Vertex3(pos.X + -width / 2, pos.Y + -height / 2, pos.Z + -depth / 2);
            GL.Vertex3(pos.X + -width / 2, pos.Y + height / 2, pos.Z + -depth / 2);

            GL.Normal3(0.0, 0.0, 1.0);
            GL.Vertex3(pos.X + width / 2, pos.Y + height / 2, pos.Z + depth / 2);
            GL.Vertex3(pos.X + width / 2, pos.Y + -height / 2, pos.Z + depth / 2);
            GL.Vertex3(pos.X + -width / 2, pos.Y + -height / 2, pos.Z + depth / 2);
            GL.Vertex3(pos.X + -width / 2, pos.Y + height / 2, pos.Z + depth / 2);

            GL.End();
        }
    }
}
