using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SharpEngine.ObjLoader
{
    class MtlLoader
    {
        public static MaterialBuffer LoadMaterial(string path, string fileName)
        {
            MaterialBuffer materialBuffer = new MaterialBuffer();
            Material tempMaterial = null;

            List<float> materialParams = new List<float>();

            string[] lines = File.ReadAllLines(path + "/" + fileName);

            foreach(string line in lines)
            {
                string[] split = line.Split(' ');

                materialParams = new List<float>();
                for (int i = 1; i < split.Length; i++)
                {
                    float val;
                    if(float.TryParse(split[i], out val))
                    {
                        materialParams.Add(val);
                    }
                }

                switch(split[0])
                {
                    case "newmtl":
                        tempMaterial = new Material(split[1]);
                        materialBuffer.Add(tempMaterial);
                        break;
                    case "Ka":
                        tempMaterial.Ka = materialParams.ToArray();
                        break;
                    case "Kd":
                        tempMaterial.Kd = materialParams.ToArray();
                        break;
                    case "Ks":
                        tempMaterial.Ks = materialParams.ToArray();
                        break;
                    case "d":
                        tempMaterial.d = materialParams.ToArray()[0];
                        break;
                    case "Tr":
                        tempMaterial.d = materialParams.ToArray()[0];
                        break;
                    case "s":
                        tempMaterial.d = materialParams.ToArray()[0];
                        break;
                    case "map_Kd":
                        tempMaterial.textureID = TextureLoader.LoadFromPath(path + "/" + split[1].Replace(@".\", ""));
                        break;
                }
            }

            return materialBuffer;
        }
    }
}
