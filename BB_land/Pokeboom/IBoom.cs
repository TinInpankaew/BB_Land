using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BB_land.World;
using BB_land.World.Tiles;

namespace BB_land.Pokeboom
{
    internal interface IBoom
    {
        IList<TileGraphic> LoadGraphicTiles(string mapName);
        IList<ICollisionObject> LoadCollisionBoom(string mapName);
    }
}
