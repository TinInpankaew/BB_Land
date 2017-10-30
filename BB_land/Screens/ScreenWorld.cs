using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BB_land.Data;
using BB_land.Inputs;
using BB_land.Services.Content;
using BB_land.Services.Screens;
using BB_land.World;
using BB_land.World.Components;
using BB_land.World.Components.Animations;
using BB_land.World.Components.Movements;
using BB_land.World.Tiles;
using BB_land.World.Tiles.Test;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BB_land.Screens
{
    internal class ScreenWorld : Screen
    {
        private Entity entity;
        private List<TileGraphic> tiles; // For test!

        public ScreenWorld(IScreenLoader screenLoader) : base(screenLoader)
        {
            entity = new Entity("MyFirstEntity");
            entity.AddComponent(new Sprite(entity, new SpriteData
            {
                Color = Color.White,
                Hight = 19,
                Width = 15,
                TextureName = "BB/main_character",
                XTilePosition = 2,
                YTilePosition = 2
            }, new Rectangle(0, 0, 16, 19)));
            entity.AddComponent(new MovementPlayer(entity, 1, new InputKeyboard()));
            entity.AddComponent(new Animation(entity));
            tiles = TileGenerator.GenerateTiles();
        }

        public override void LoadContent(IContentLoader contentLoader)
        {
            entity.LoadContent(contentLoader);
            foreach (var tileGraphic in tiles)
            {
                tileGraphic.LoadContent(contentLoader);
            }
        }

        public override void Update(double gameTime)
        {
            entity.Update(gameTime);
            foreach (var tileGraphic in tiles)
            {
                tileGraphic.Update(gameTime);
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            foreach (var tileGraphic in tiles)
            {
                tileGraphic.Draw(spriteBatch);
            }
            entity.Draw(spriteBatch);
        }
    }
}
