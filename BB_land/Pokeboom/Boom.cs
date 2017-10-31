using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BB_land.Services.Content;
using BB_land.Services.World;
using BB_land.World;
using BB_land.World.Tiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BB_land.Pokeboom
{
    internal class Boom : IBoom
    {



        public IList<TileGraphic> LoadGraphicTiles(string mapName)
        {
            throw new NotImplementedException();
        }

        public IList<ICollisionObject> LoadCollisionBoom(string mapName)
        {
            throw new NotImplementedException();
        }
    }
    
}
