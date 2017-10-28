using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BB_land.Services.Content;
using Microsoft.Xna.Framework.Graphics;

namespace BB_land.World
{
    internal abstract class Component
    {
        protected IComponentOwner Owner;
        public bool Killed { get; protected set; }

        public Component(IComponentOwner owner)
        {
            Owner = owner;
        }

        public virtual void LoadContent(IContentLoader contentLoader) { }
        public abstract void Update(double geamTime);
        public abstract void Draw(SpriteBatch spriteBatch);
    }
}
