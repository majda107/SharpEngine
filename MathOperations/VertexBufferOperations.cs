using OpenTK;
using SharpEngine.ObjLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpEngine.MathOperations
{
    static class VertexBufferOperations
    {
        static public void MultiplyBufferByMatrix(Matrix3 matrix, ref Face3[] faces, Vector3 pivot)
        {
            if(faces != null)
            {
                Vector3 vectorTmp;
                Face3 faceTmp;
                for (int i = 0; i < faces.Length; i++)
                {
                    faceTmp = faces[i];
                    for (int j = 0; j < faces[i].vertices.Length; j++)
                    {
                        vectorTmp = faceTmp.vertices[j];

                        vectorTmp -= pivot;
                        vectorTmp *= matrix;
                        vectorTmp += pivot;

                        faceTmp.vertices[j] = vectorTmp;
                    }
                }
            }
        }

        static public Vector3 GetCenterPivot(ref Face3[] faces)
        {
            if(faces != null)
            {
                int count = 0;
                Vector3 sum = new Vector3(0, 0, 0);
                foreach (var face in faces)
                {
                    foreach (var vertex in face.vertices)
                    {
                        count += 1;
                        sum += vertex;
                    }
                }
                return sum / count;
            }
            return new Vector3(0, 0, 0);
        }
    }
}
