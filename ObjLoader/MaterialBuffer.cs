using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpEngine.ObjLoader
{
    class MaterialBuffer
    {
        public List<Material> materials { get; set; }
        public MaterialBuffer(Material[] materials)
        {
            this.materials = new List<Material>(materials);  
        }   
    }
}
