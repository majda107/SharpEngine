using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpEngine.Gamelib;
using OpenTK.Graphics.OpenGL;
using OpenTK;
using SharpEngine.ObjLoader;

namespace SharpEngine.Solids
{
    class BlockSolid : ASolid
    {
        public int width { get; private set; }
        public int height { get; private set; }
        public int depth { get; private set; }
        public BlockSolid(Vector3 pos, int width, int height, int depth) : base(pos, null)
        {
            this.width = width;
            this.height = height;
            this.depth = depth;

            this.UpdateHitbox();
        }

        protected override void RenderBody()
        {
            GL.PushMatrix();

            GL.Color4(color);

            GL.Begin(PrimitiveType.Quads);

            GL.Normal3(-1.0, 0.0, 0.0);
            GL.TexCoord2(1, 1); // debug
            GL.Vertex3(this.Pos.X + -width / 2, this.Pos.Y + height / 2, this.Pos.Z + depth / 2);
            GL.TexCoord2(1, 0); // debug
            GL.Vertex3(this.Pos.X + -width / 2, this.Pos.Y + height / 2, this.Pos.Z + -depth / 2);
            GL.TexCoord2(0, 1); // debug
            GL.Vertex3(this.Pos.X + -width / 2, this.Pos.Y + -height / 2, this.Pos.Z + -depth / 2);
            GL.TexCoord2(0, 0);  // debug
            GL.Vertex3(this.Pos.X + -width / 2, this.Pos.Y + -height / 2, this.Pos.Z + depth / 2);

            GL.Normal3(1.0, 0.0, 0.0);
            GL.Vertex3(this.Pos.X + width / 2, this.Pos.Y + height / 2, this.Pos.Z + depth / 2);
            GL.Vertex3(this.Pos.X + width / 2, this.Pos.Y + height / 2, this.Pos.Z + -depth / 2);
            GL.Vertex3(this.Pos.X + width / 2, this.Pos.Y + -height / 2, this.Pos.Z + -depth / 2);
            GL.Vertex3(this.Pos.X + width / 2, this.Pos.Y + -height / 2, this.Pos.Z + depth / 2);

            GL.Normal3(0.0, -1.0, 0.0);
            GL.Vertex3(this.Pos.X + width / 2, this.Pos.Y + -height / 2, this.Pos.Z + depth / 2);
            GL.Vertex3(this.Pos.X + width / 2, this.Pos.Y + -height / 2, this.Pos.Z + -depth / 2);
            GL.Vertex3(this.Pos.X + -width / 2, this.Pos.Y + -height / 2, this.Pos.Z + -depth / 2);
            GL.Vertex3(this.Pos.X + -width / 2, this.Pos.Y + -height / 2, this.Pos.Z + depth / 2);

            GL.Normal3(0.0, 1.0, 0.0);
            GL.Vertex3(this.Pos.X + width / 2, this.Pos.Y + height / 2, this.Pos.Z + depth / 2);
            GL.Vertex3(this.Pos.X + width / 2, this.Pos.Y + height / 2, this.Pos.Z + -depth / 2);
            GL.Vertex3(this.Pos.X + -width / 2, this.Pos.Y + height / 2, this.Pos.Z + -depth / 2);
            GL.Vertex3(this.Pos.X + -width / 2, this.Pos.Y + height / 2, this.Pos.Z + depth / 2);

            GL.Normal3(0.0, 0.0, -1.0);
            GL.Vertex3(this.Pos.X + width / 2, this.Pos.Y + height / 2, this.Pos.Z + -depth / 2);
            GL.Vertex3(this.Pos.X + width / 2, this.Pos.Y + -height / 2, this.Pos.Z + -depth / 2);
            GL.Vertex3(this.Pos.X + -width / 2, this.Pos.Y + -height / 2, this.Pos.Z + -depth / 2);
            GL.Vertex3(this.Pos.X + -width / 2, this.Pos.Y + height / 2, this.Pos.Z + -depth / 2);

            GL.Normal3(0.0, 0.0, 1.0);
            GL.Vertex3(this.Pos.X + width / 2, this.Pos.Y + height / 2, this.Pos.Z + depth / 2);
            GL.Vertex3(this.Pos.X + width / 2, this.Pos.Y + -height / 2, this.Pos.Z + depth / 2);
            GL.Vertex3(this.Pos.X + -width / 2, this.Pos.Y + -height / 2, this.Pos.Z + depth / 2);
            GL.Vertex3(this.Pos.X + -width / 2, this.Pos.Y + height / 2, this.Pos.Z + depth / 2);

            GL.End();

            GL.PopMatrix();
        }

        protected override void UpdateHitbox()
        {
            this.hitbox = new Hitbox(new Vector3(this.Pos.X + width / 2, this.Pos.Y - height / 2, this.Pos.Z - depth / 2), new Vector3(this.Pos.X - width / 2, this.Pos.Y + height / 2, this.Pos.Z + depth / 2), this.Debug);
        }

        protected override void UpdateVertices()
        {
            // implement later
        }
    }
}
