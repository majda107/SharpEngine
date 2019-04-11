using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Input;
using OpenTK.Graphics.OpenGL;

namespace SharpEngine.Render
{
    class Camera : ACamera
    {
        public Camera()
        {
            this.pos = new Vector3(0, 0, 0);
            this.yaw = 0;
            this.pitch = 0;
            this.sensitivity = 1;
            Update();
        }

        /// <summary>
        /// Camera update each frame
        /// </summary>
        public override void Update()
        {
            this.lookAt = Matrix4.LookAt(pos, new Vector3(pos.X, pos.Y, pos.Z + 1), Vector3.UnitY);

            this.lookAt *= Matrix4.CreateRotationY(yaw);
            this.lookAt *= Matrix4.CreateRotationX(pitch);

            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref lookAt);
        }

        public void ProcessMouse(Processors.AMouseProcessor mouseProcessor)
        {
            this.yaw += (float)mouseProcessor.xDev / 400f * sensitivity;
            this.pitch += (float)mouseProcessor.yDev / 400f * sensitivity;
        }

        public void ProcessKeys(Processors.AKeyProcessor keyProcessor)
        {
            Vector3 toMove = new Vector3(0, 0, 0);
            foreach (Key key in keyProcessor.keysDown)
            {
                switch (key)
                {
                    case Key.W:
                        toMove.Z += 1;
                        break;
                    case Key.S:
                        toMove.Z -= 1;
                        break;
                    case Key.A:
                        toMove.X += 1;
                        break;
                    case Key.D:
                        toMove.X -= 1;
                        break;
                    case Key.Space:
                        toMove.Y += 1;
                        break;
                    case Key.ShiftLeft:
                        toMove.Y -= 1;
                        break;

                    case Key.Left:
                        this.yaw -= MathHelper.DegreesToRadians(1);
                        break;
                    case Key.Right:
                        this.yaw += MathHelper.DegreesToRadians(1);
                        break;
                    case Key.Up:
                        this.pitch -= MathHelper.DegreesToRadians(1);
                        break;
                    case Key.Down:
                        this.pitch += MathHelper.DegreesToRadians(1);
                        break;
                }
            }

            this.pos.Y += toMove.Y; // sets Y position of the camera

            pos.X = pos.X + (float)(toMove.Z * Math.Cos(yaw + MathHelper.DegreesToRadians(90)));
            pos.Z = pos.Z + (float)(toMove.Z * Math.Sin(yaw + MathHelper.DegreesToRadians(90)));

            pos.X = pos.X + (float)(toMove.X * Math.Cos(yaw));
            pos.Z = pos.Z + (float)(toMove.X * Math.Sin(yaw));
        }
    }
}
