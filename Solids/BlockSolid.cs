﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpEngine.Gamelib;
using OpenTK.Graphics.OpenGL;
using OpenTK;

namespace SharpEngine.Solids
{
    class BlockSolid : ASolid
    {
        public int width { get; private set; }
        public int height { get; private set; }
        public int depth { get; private set; }
        public BlockSolid(Vector3 pos, int width, int height, int depth) : base(pos)
        {
            this.width = width;
            this.height = height;
            this.depth = depth;

            this.hitbox = new Hitbox(new Vector3(pos.X + width / 2, pos.Y - height/2, pos.Z - depth / 2), new Vector3(pos.X - width / 2, pos.Y + height / 2, pos.Z + depth / 2));
        }

        protected override void RenderBody()
        {
            GL.PushMatrix();

            GL.Scale(this.scale);

            GL.Rotate(this.angles.X, Vector3.UnitY);
            GL.Rotate(this.angles.Y, Vector3.UnitX);
            GL.Rotate(this.angles.Z, Vector3.UnitZ);

            GL.Color4(color) ;

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

            GL.PopMatrix();
        }
    }
}
