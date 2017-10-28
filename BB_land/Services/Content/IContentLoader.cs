using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace BB_land.Services.Content
{
    internal interface IContentLoader
    {
        Texture2D LoadTexture(string textureName);
        SpriteFont LoadFont(string frontName);

    }
}
