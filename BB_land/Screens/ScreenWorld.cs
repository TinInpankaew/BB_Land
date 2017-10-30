using System.Collections.Generic;
using BB_land.Services.Content;
using BB_land.Services.Screens;
using BB_land.Services.World;
using BB_land.World;
using Microsoft.Xna.Framework.Graphics;
namespace BB_land.Screens
{
    internal class ScreenWorld : Screen
    {
        private readonly ITileLoader tileLoader;
        private readonly IEntityLoader entityLoader;
        public List<IWorldObject> worldObjects;

        public ScreenWorld(IScreenLoader screenLoader, ITileLoader tileLoader, IEntityLoader entityLoader) : base(screenLoader)
        {
            this.tileLoader = tileLoader;
            this.entityLoader = entityLoader;
        }

        public override void LoadContent(IContentLoader contentLoader)
        {
            worldObjects = new List<IWorldObject>();
            worldObjects.AddRange((tileLoader.LoadGraphicTiles("")));
            worldObjects.AddRange(entityLoader.LoadEntities(""));
            foreach (var worldObject in worldObjects)
            {
                worldObject.LoadContent(contentLoader);
            }
        }

        public override void Update(double gameTime)
        {
            foreach (var worldObject in worldObjects)
            {
                worldObject.Update(gameTime);
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            foreach (var worldObject in worldObjects)
            {
                worldObject.Draw(spriteBatch);
            }
        }
    }
}
