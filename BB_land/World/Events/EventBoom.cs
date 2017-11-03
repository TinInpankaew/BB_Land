using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BB_land.Services.Content;
using BB_land.World.Boom;
using BB_land.World.Components;
using Microsoft.Xna.Framework.Graphics;

namespace BB_land.World.Events
{
    internal class EventBoom : IEvent
    {
        private readonly string entityId;
        private readonly IReadOnlyList<Entity> entities;
        private readonly IBoom boom;
        public bool IsDone { get; private set; }

        public EventBoom(string entityId, IReadOnlyList<Entity> entities, IBoom boom)
        {
            this.entityId = entityId;
            this.entities = entities;
            this.boom = boom;
        }

        public void Initialize()
        {
            var entity = entities.FirstOrDefault(e => e.Id == entityId);
            if (entity == null)
            {
                IsDone = true;
            }
            else
            {
                var sprite = entity.GetComponent<Sprite>();
                boom.PlayEmotion((int)sprite.TilePosition.X, (int)sprite.TilePosition.Y);
            }
        }

        public void LoadContent(IContentLoader contentLoader)
        {
            boom.LoadContent(contentLoader);
        }

        public void Update(double gameTime)
        {
            boom.Update(gameTime);
            if (boom.IsBlowUp)
            {
                IsDone = true;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            boom.Draw(spriteBatch);
        }
    }
}
