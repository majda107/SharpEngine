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
    abstract class ACamera : Gamelib.AGameObject
    {
        /// <summary>
        /// Main LookAt camera matrix
        /// </summary>
        protected Matrix4 lookAt;
        /// <summary>
        /// Yaw angle of the camera in space
        /// </summary>
        public float yaw;
        /// <summary>
        /// Pitch angle of the camera in space
        /// </summary>
        public float pitch;

        /// <summary>
        /// Mouse sensitivity
        /// </summary>
        public float sensitivity;

        public abstract void Update();
    }
}
