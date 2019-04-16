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
        public static MaterialBuffer LoadMaterial(string path)
        {
            List<Material> materials = new List<Material>();

            string[] lines = File.ReadAllLines(path);
            foreach(string line in lines)
            {
                string[] split = line.Split(' ');

                List<float> materialParams = new List<float>();

                for(int i = 1; i < split.Length; i++)
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
                        materials.Add(new Material(split[1]));
                        break;
                    case "Ka":
                        materials.Last().Ka = materialParams.ToArray();
                        break;
                    case "Kd":
                        materials.Last().Kd = materialParams.ToArray();
                        break;
                    case "Ks":
                        materials.Last().Ks = materialParams.ToArray();
                        break;
                    case "d":
                        materials.Last().d = materialParams.ToArray()[0];
                        break;
                    case "Tr":
                        materials.Last().d = materialParams.ToArray()[0];
                        break;
                    case "s":
                        materials.Last().d = materialParams.ToArray()[0];
                        break;
                }
            }

            return new MaterialBuffer(materials.ToArray());
        }
    }
}
