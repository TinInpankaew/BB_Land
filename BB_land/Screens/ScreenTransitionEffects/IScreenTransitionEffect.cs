using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BB_land.Services.Content;
using Microsoft.Xna.Framework.Graphics;

namespace BB_land.Screens.ScreenTransitionEffects
{
    internal interface IScreenTransitionEffect
    {
        bool IsDone { get; }
        void Start();
        void LoadContent(IContentLoader contentLoader);
        void Update(double gameTime);
        void Draw(SpriteBatch spriteBatch);


    }
}
