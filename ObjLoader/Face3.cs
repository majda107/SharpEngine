using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace SharpEngine.ObjLoader
{
    struct Face3
    {
        public Vector3[] vertices;
        public Vector2[] textures;
        public Vector3[] normals;
        public Face3(Vector3[] vertices, Vector2[] textures, Vector3[] normals)
        {
            this.vertices = vertices;
            this.textures = textures;
            this.normals = normals;
        }
    }
}
