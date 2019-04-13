using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace SharpEngine.ObjLoader
{
    class VertexBuffer
    {
        public List<Vector3> vertices;
        public List<Vector2> textures;
        public List<Vector3> normals;
        public VertexBuffer()
        {
            this.vertices = new List<Vector3>();
            this.textures = new List<Vector2>();
            this.normals = new List<Vector3>();
        }
    }
}
