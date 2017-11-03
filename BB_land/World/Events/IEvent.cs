using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BB_land.Services.Content;
using Microsoft.Xna.Framework.Graphics;

namespace BB_land.World.Events
{
        internal interface IEvent
        {
            bool IsDone { get; }
            void Initialize();
            void LoadContent(IContentLoader contentLoader);
            void Update(double gameTime);
            void Draw(SpriteBatch spriteBatch);
        }
}
