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
            this.Pos = new Vector3(0, 0, 0);
            this.yaw = 0;
            this.pitch = 0;
            this.sensitivity = 1;
            UpdatePos(new Vector3(0, 0, 0));
        }

        /// <summary>
        /// Camera update if needed
        /// </summary>
        protected override void UpdatePos(Vector3 dev)
        {
            this.lookAt = Matrix4.LookAt(this.Pos, new Vector3(this.Pos.X, this.Pos.Y, this.Pos.Z + 1), Vector3.UnitY);

            this.lookAt *= Matrix4.CreateRotationY(yaw);
            this.lookAt *= Matrix4.CreateRotationX(pitch);
        }

        /// <summary>
        /// Load camera matrix every frame
        /// </summary>
        public void Render()
        {
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref lookAt);
        }

        public void ProcessMouse(Processors.AMouseProcessor mouseProcessor)
        {
            this.yaw += (float)mouseProcessor.xDev / 400f * sensitivity;
            this.pitch += (float)mouseProcessor.yDev / 400f * sensitivity;
            this.UpdatePos(new Vector3(0, 0, 0)); // POLISH THIS LATER!!!
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

            this.Pos += new Vector3(0.0f, toMove.Y, 0.0f); // sets Y position of the camera

            this.Pos += new Vector3((float)(toMove.Z * Math.Cos(yaw + MathHelper.DegreesToRadians(90))), 0.0f, (float)(toMove.Z * Math.Sin(yaw + MathHelper.DegreesToRadians(90))));

            this.Pos += new Vector3((float)(toMove.X * Math.Cos(yaw)), 0.0f, (float)(toMove.X * Math.Sin(yaw)));
        }
    }
}
