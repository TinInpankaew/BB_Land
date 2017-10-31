using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BB_land.Data;
using BB_land.Inputs;
using BB_land.Services.Content;
using BB_land.Services.World;
using BB_land.World;
using BB_land.World.Components;
using BB_land.World.Components.Animations;
using BB_land.World.Components.Movements;
using BB_land.World.Tiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BB_land.Pokeboom
{
    internal class Boom : IBoom
    {
        private readonly SpriteData spriteData;
        private const int TextureWidth = 16;
        private const int TextureHeight = 16;
        private Texture2D texture;
        public Vector2 PositionOffset { get; private set; }
        public Vector2 CurrentPosition => new Vector2(spriteData.XTilePosition * Tile.Width + PositionOffset.X, spriteData.YTilePosition * Tile.Height + PositionOffset.Y);

        public void UpdateBoomPosition(int x, int y)
        {
            spriteData.XTilePosition = x;
            spriteData.YTilePosition = y;
        }



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
