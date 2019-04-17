using SharpEngine.Solids;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpEngine.GameManager
{
    class GameObjectManager
    {
        public List<ASolid> GameSolids { get; private set; }
        public GameObjectManager()
        {
            this.GameSolids = new List<ASolid>();
        }

        public void Add(ASolid gameObject)
        {
            this.GameSolids.Add(gameObject);
        }

        public void CheckCollisions()
        {
            for(int i = 0; i < GameSolids.Count; i++)
            {
                 for(int j = 0; j < GameSolids.Count; j++)
                 {
                     if(i != j)
                     {
                         GameSolids[i].Collide(GameSolids[j]);
                     }
                 }
            }
        }

        public void SetDebugMode(bool debug)
        {
            foreach(ASolid solid in GameSolids)
            {
                if(debug) solid.hitbox.visible = true;
                else solid.hitbox.visible = false;
            }
        }

        public void RenderAll()
        {
            foreach (ASolid solid in GameSolids)
            {
                solid.Render();
            }
        }
    }
}
