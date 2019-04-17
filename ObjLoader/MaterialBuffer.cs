using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpEngine.ObjLoader
{
    class MaterialBuffer
    {
        public List<Material> materials { get; set; }
        public MaterialBuffer()
        {
            this.materials = new List<Material>();  
        }

        public void Add(Material mat)
        {
            this.materials.Add(mat);
        }
    }
}
