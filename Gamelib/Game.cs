using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenGLCamera.Render;
using OpenGLCamera.Solids;
using OpenTK.Input;

namespace OpenGLCamera.Gamelib
{
    class Game
    {
        public GameWindow gw { get; private set; }
        public double frameRate { get; private set; }
        public Camera camera { get; private set; }

        public BlockSolid testSolid { get; private set; }
        public CubeSolid testCube { get; private set; }

        public List<Key> keysDown { get; private set; }
        public Game(GameWindow gw, double frameRate)
        {
            this.gw = gw;
            this.frameRate = frameRate;
            this.camera = new Camera();
            this.keysDown = new List<Key>();

            this.testSolid = new BlockSolid(new Vector3(0, 0, 0), 10, 14, 8);
            this.testCube = new CubeSolid(new Vector3(20, 0, 0), 10);
            this.testCube.color = new float[]{ 1.0f, 0.2f, 0.2f};
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
            this.camera.ProcessKeys(this.keysDown);
            this.camera.Update();

            this.testSolid.Render();
            this.testCube.Render();

            gw.SwapBuffers();
        }

        private void Loaded(object sender, EventArgs e)
        {
            GL.ClearColor(0.8f, 0.0f, 0.0f, 0.0f);

            GL.Enable(EnableCap.DepthTest);
            GL.Enable(EnableCap.Lighting);

            GL.Light(LightName.Light0, LightParameter.Position, new float[] { 10.0f, 10.0f, -10.0f });
            GL.Light(LightName.Light0, LightParameter.Diffuse, new float[] { 1.0f, 1.0f, 1.0f });
            GL.Light(LightName.Light0, LightParameter.Ambient, new float[] { 1.0f, 1.0f, 1.0f });

            GL.Enable(EnableCap.Light0);
        }
    }
}
