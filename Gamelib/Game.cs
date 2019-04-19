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
using SharpEngine.GameManager;
using OpenTK.Input;
using SharpEngine.Physics;

namespace SharpEngine.Gamelib
{
    class Game
    {
        public GameWindow gw { get; private set; }
        public double frameRate { get; private set; }



        public Camera camera { get; private set; }

        public KeyboardProcessor keyboardProcessor { get; private set; }
        public MouseProcessor mouseProcessor { get; private set; }

        public GameObjectManager GameObjectManager { get; private set; }



        public Solid spider;
        public Game(GameWindow gw, double frameRate)
        {
            this.gw = gw;
            this.frameRate = frameRate;

            this.camera = new Camera();
            this.keyboardProcessor = new KeyboardProcessor();
            this.mouseProcessor = new MouseProcessor();

            this.GameObjectManager = new GameObjectManager();

            GameObjectManager.Add(new BlockSolid(new Vector3(0, 0, 0), 10, 14, 8));
            GameObjectManager.Add(new CubeSolid(new Vector3(0, 0, 20), 10) { color = new float[] { 0.4f, 0.8f, 0.2f, 0.5f }});
            BlockSolid platform = new BlockSolid(new Vector3(0, -80, 0), 400, 2, 400);
            platform.color = new float[4] { 0.2f, 0.6f, 0.2f, 1.0f };

            platform.Collision += (o, e) =>
            {
                (e.solid.physicElements[0] as RigidBody).Gravity = false;
            };

            GameObjectManager.Add(platform);

            spider = ObjLoader.ObjLoader.LoadObj(@"C:\Users\Marián Trpkoš\source\repos\OpenGLmov2\SharpEngine\TestModels\Spider", "spider.obj", new Vector3(-80, 0, 0));
            spider.physicElements.Add(new RigidBody());
            (spider.physicElements[0] as RigidBody).Gravity = false;
            GameObjectManager.Add(spider);
        }

        public void Start()
        {
            this.gw.CursorVisible = false;

            this.gw.Load += Loaded;
            this.gw.UpdateFrame += UpdateF;
            this.gw.Resize += Resized;

            this.gw.KeyDown += (o, e) => this.keyboardProcessor.AddKey(e.Key);
            this.gw.KeyUp += (o, e) => this.keyboardProcessor.RemoveKey(e.Key);

            this.gw.KeyPress += (o, e) =>
            {
                switch (e.KeyChar)
                {
                    case 'h':
                        this.GameObjectManager.SetDebugMode(true);
                        break;
                    case 'j':
                        this.GameObjectManager.SetDebugMode(false);
                        break;
                    case 'g':
                        (spider.physicElements[0] as RigidBody).Gravity = true;
                        break;
                    case 't':
                        spider.pos += new Vector3(0, 100, 0);
                        break;
                }
            };

            this.gw.Run(1 / this.frameRate);
        }

        private void Resized(object sender, EventArgs e)
        {
            GL.Viewport(0, 0, gw.Width, gw.Height);
        }

        private void CreatePerspectiveProjection(float angle)
        {
            GL.MatrixMode(MatrixMode.Projection);
            Matrix4 perspective = Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(angle), (float)gw.Width / (float)gw.Height, 1.0f, 10000.0f);
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

            this.GameObjectManager.CheckCollisions(); // polish later!
            this.GameObjectManager.UpdateAll();
            this.GameObjectManager.RenderAll();

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
            GL.Light(LightName.Light0, LightParameter.Ambient, new float[] { 0.6f, 0.6f, 0.6f });

            GL.Enable(EnableCap.Light0);
            GL.Enable(EnableCap.Texture2D);

            GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);
        }
    }
}
