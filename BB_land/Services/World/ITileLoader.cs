using System.Collections.Generic;
using BB_land.World;
using BB_land.World.Tiles;

namespace BB_land.Services.World
{
    internal interface ITileLoader
    {
        IList<TileGraphic> LoadGraphicTiles(string mapName);
        IList<ICollisionObject> LoadCollisionTiles(string mapName);
    }
}