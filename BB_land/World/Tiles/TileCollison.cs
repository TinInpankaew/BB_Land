﻿namespace BB_land.World.Tiles
{
    class TileCollison :Tile, ICollisionObject
    {
        public bool Collide(int xTilePosition, int yTilePosition)
        {
            return xTilePosition == XTilePosition && yTilePosition == YTilePosition;
        }
    }
}
