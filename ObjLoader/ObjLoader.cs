using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using OpenTK;

namespace SharpEngine.ObjLoader
{
    static class ObjLoader
    {
        public static Solids.Solid LoadObj(string pathToObj, Vector3 pos)
        {
            List<Vector3> vertices = new List<Vector3>();
            List<Vector2> textureVertices = new List<Vector2>();
            List<Vector3> normalVertices = new List<Vector3>();

            List<Face3> faces = new List<Face3>();
            string[] lines = File.ReadAllLines(pathToObj);
            foreach(string line in lines)
            {
                // worst possible solution, dont judge me, it's 2:45 AM...
                string[] split = line.Split(' ');
                switch(split[0])
                {
                    case "v":
                        vertices.Add(new Vector3(float.Parse(split[1]), float.Parse(split[2]), float.Parse(split[3])));
                        break;
                    case "vt":
                        textureVertices.Add(new Vector2(float.Parse(split[1]), float.Parse(split[2])));
                        break;
                    case "vn":
                        normalVertices.Add(new Vector3(float.Parse(split[1]), float.Parse(split[2]), float.Parse(split[3])));
                        break;
                    case "f":
                        Vector3[] faceVertices = new Vector3[split.Length - 1];
                        Vector2[] faceTextures = new Vector2[split.Length - 1];
                        Vector3[] faceNormals = new Vector3[split.Length - 1];

                        for (int i = 1; i < split.Length; i++)
                        {
                            string[] index = split[i].Split('/');
                            faceVertices[i - 1] = vertices[int.Parse(index[0]) - 1];
                            if (index.Length > 0) faceTextures[i - 1] = textureVertices[int.Parse(index[1]) - 1];
                            if (index.Length > 1) faceNormals[i - 1] = normalVertices[int.Parse(index[2]) - 1];
                        }
                        faces.Add(new Face3(faceVertices, faceTextures, faceNormals));
                        break;
                }
            }

            return new Solids.Solid(faces.ToArray(), pos);
        }
    }
}
