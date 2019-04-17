using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL;

namespace SharpEngine.ObjLoader
{
    class Material
    {
        public string name { get; private set; }

        public float[] Ka; // ambient
        public float[] Kd; // diffuse
        public float[] Ks; // specular
        public float d; 
        public float Tr;
        public float s;

        public int textureID;

        public Material(string name)
        {
            this.name = name;

            this.Ka = new float[] { 0.2f, 0.2f, 0.2f };
            this.Kd = new float[] { 0.8f, 0.8f, 0.8f };
            this.Ks = new float[] { 1.0f, 1.0f, 1.0f };

            this.d = 1.0f;
            this.Tr = 0;
            this.s = 0;

            this.textureID = 0;
        }
        public void Load()
        {
            GL.Material(MaterialFace.FrontAndBack, MaterialParameter.Ambient, Ka);
            GL.Material(MaterialFace.FrontAndBack, MaterialParameter.Diffuse, Kd);
            GL.Material(MaterialFace.FrontAndBack, MaterialParameter.Specular, Ks);
        }
    }
}
