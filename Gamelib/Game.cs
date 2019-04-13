using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using SharpEngine.Render;
using SharpEngine.Solids;
using SharpEngine.Processors;
using SharpEngine.ObjLoader;
using OpenTK.Input;

namespace SharpEngine.Gamelib
{
    class Game
    {
        public GameWindow gw { get; private set; }
        public double frameRate { get; private set; }



        public Camera camera { get; private set; }

        public KeyboardProcessor keyboardProcessor { get; private set; }
        public MouseProcessor mouseProcessor { get; private set; }


        public BlockSolid testSolid { get; private set; }
        public CubeSolid testCube { get; private set; }
        public Solid testObject { get; private set; }

        public Game(GameWindow gw, double frameRate)
        {
            this.gw = gw;
            this.frameRate = frameRate;

            this.camera = new Camera();
            this.keyboardProcessor = new KeyboardProcessor();
            this.mouseProcessor = new MouseProcessor();

            this.testSolid = new BlockSolid(new Vector3(0, 0, 0), 10, 14, 8);
            this.testCube = new CubeSolid(new Vector3(20, 0, 0), 10);
            this.testCube.color = new float[]{ 0.4f, 0.8f, 0.2f, 0.5f};

            this.testObject = ObjLoader.ObjLoader.LoadObj(@"C:\Users\Marián Trpkoš\source\repos\OpenGLmov2\SharpEngine\spider.obj", new Vector3(-1000, 0, 0));
            this.testObject.scale = new Vector3(0.05f, 0.05f, 0.05f);
        }

        public void Start()
        {
            this.gw.CursorVisible = false;

            this.gw.Load += Loaded;
            this.gw.UpdateFrame += UpdateF;
            this.gw.Resize += Resized;

            this.gw.KeyDown += (o, e) => this.keyboardProcessor.AddKey(e.Key);
            this.gw.KeyUp += (o, e) => this.keyboardProcessor.RemoveKey(e.Key);

            this.gw.Run(1 / this.frameRate);
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

            this.mouseProcessor.Update(Mouse.GetState());

            this.camera.ProcessMouse(this.mouseProcessor);
            this.camera.ProcessKeys(this.keyboardProcessor);
            this.camera.Update();

            this.testSolid.visible = true;
            this.testSolid.hitbox.visible = true;
            this.testSolid.Render();   

            this.testCube.Render();

            this.testObject.Render();

            gw.SwapBuffers();
        }

        private void Loaded(object sender, EventArgs e)
        {
            GL.ClearColor(0.8f, 0.0f, 0.0f, 0.0f);

            GL.Enable(EnableCap.DepthTest);
            GL.Enable(EnableCap.Blend);
            GL.Enable(EnableCap.ColorMaterial);
            GL.Enable(EnableCap.Lighting);

            GL.Light(LightName.Light0, LightParameter.Position, new float[] { 20.0f, 0.0f, -10.0f });
            GL.Light(LightName.Light0, LightParameter.Diffuse, new float[] { 0.8f, 0.8f, 0.8f });
            GL.Light(LightName.Light0, LightParameter.Ambient, new float[] { 0.9f, 0.6f, 0.6f });

            GL.Enable(EnableCap.Light0);

            GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);
        }
    }
}
