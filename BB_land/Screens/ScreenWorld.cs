using System.Collections.Generic;
using BB_land.Services.Content;
using BB_land.Services.Screens;
using BB_land.Services.World;
using BB_land.World;
using BB_land.World.Boom;
using Microsoft.Xna.Framework.Graphics;
namespace BB_land.Screens
{
    internal class ScreenWorld : Screen
    {
        private readonly ITileLoader tileLoader;
        private readonly IEntityLoader entityLoader;
        private readonly EventRunner eventRunner;
        public List<IWorldObject> worldObjects;
        private readonly Booms booms;

        public ScreenWorld(IScreenLoader screenLoader, ITileLoader tileLoader, IEntityLoader entityLoader, EventRunner eventRunner ) : base(screenLoader)
        {
            this.tileLoader = tileLoader;
            this.entityLoader = entityLoader;
            this.eventRunner = eventRunner;
        }


        public override void LoadContent(IContentLoader contentLoader)
        {
            worldObjects = new List<IWorldObject>();
            worldObjects.AddRange((tileLoader.LoadGraphicTiles("")));
            worldObjects.AddRange( entityLoader.LoadEntities("", tileLoader.LoadCollisionTiles(""), eventRunner));
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
            eventRunner.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            foreach (var worldObject in worldObjects)
            {
                worldObject.Draw(spriteBatch);
            }
            eventRunner.Draw(spriteBatch);
        }
    }
}
