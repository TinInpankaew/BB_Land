using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BB_land.Services.Content;
using Microsoft.Xna.Framework.Graphics;

namespace BB_land.World.Boom
{
    internal interface IBoom
    {
        bool IsBlowUp { get; }
        void PlayEmotion(int xTilePosition, int yTilePosition);
        void LoadContent(IContentLoader contentLoader);
        void Update(double gametime);
        void Draw(SpriteBatch spriteBatch);

    }

}

/*    internal interface IEmotion
    {
        bool IsDone { get; }
        void PlayEmotion(int xTilePosition, int yTilePosition);
        void LoadContent(IContentLoader contentLoader);
        void Update(double gameTime);
        void Draw(SpriteBatch spriteBatch);
    }*/
