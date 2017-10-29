using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BB_land.Services.Content;
using BB_land.Services.Screens;
using Microsoft.Xna.Framework.Graphics;

namespace BB_land.Screens
{
    internal abstract class Screen
    {
        protected readonly IScreenLoader screenLoader;

        protected Screen(IScreenLoader screenLoader)
        {
            this.screenLoader = screenLoader;
        }

        public abstract void LoadContent(IContentLoader contentLoader);
        public abstract void Update(double gameTime);
        public abstract void Draw(SpriteBatch spriteBatch);
    }
}
