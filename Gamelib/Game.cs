using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenGLCamera.Render;
using OpenTK.Input;

namespace OpenGLCamera.Gamelib
{
    class Game
    {
        public GameWindow gw { get; private set; }
        public double frameRate { get; private set; }
        public Camera camera { get; private set; }

        public List<Key> keysDown { get; private set; }
        public Game(GameWindow gw, double frameRate)
        {
            this.gw = gw;
            this.frameRate = frameRate;
            this.camera = new Camera();

            this.keysDown = new List<Key>();
        }

        public void Start()
        {
            this.gw.CursorVisible = false;

            this.gw.Load += Loaded;
            this.gw.UpdateFrame += UpdateF;
            this.gw.Resize += Resized;

            this.gw.KeyDown += KeyDown;
            this.gw.KeyUp += KeyUp;

            this.gw.Run(1 / this.frameRate);
        }

        private void KeyUp(object sender, OpenTK.Input.KeyboardKeyEventArgs e)
        {
            if (this.keysDown.Contains(e.Key)) this.keysDown.Remove(e.Key);
        }

        private void KeyDown(object sender, OpenTK.Input.KeyboardKeyEventArgs e)
        {
            if (!this.keysDown.Contains(e.Key)) this.keysDown.Add(e.Key);
        }

        private void Resized(object sender, EventArgs e)
        {
            GL.Viewport(0, 0, gw.Width, gw.Height);
        }

        private void CreatePerspectiveProjection(float angle)
        {
            GL.MatrixMode(MatrixMode.Projection);
            Matrix4 perspective = Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(angle), (float)gw.Width / (float)gw.Height, 1.0f, 100.0f);
            GL.LoadMatrix(ref perspective);
        }

        private void UpdateF(object sender, FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            CreatePerspectiveProjection(45f);

            this.camera.ProcessMouse();
            this.camera.Update(this.keysDown);

            GL.Begin(PrimitiveType.Triangles);
            GL.Vertex3(0, 0, 30);
            GL.Vertex3(10, 0, 30);
            GL.Vertex3(10, 10, 30);
            GL.End();

            gw.SwapBuffers();
        }

        private void Loaded(object sender, EventArgs e)
        {
            GL.Enable(EnableCap.DepthTest);
            GL.ClearColor(0.8f, 0.0f, 0.0f, 0.0f);
        }
    }
}
