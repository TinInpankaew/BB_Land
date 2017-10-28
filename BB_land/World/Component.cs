using BB_land.Services.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BB_land.World
{
    internal abstract class Component
    {
        protected IComponentOwner Owner;

        public  bool Killed { get; protected set; }

        public Component(IComponentOwner owner)
        {
            Owner = owner;
        }

        public  virtual void LoadContent(IContentLoader contentLoader) {  }
        public virtual void Update(double gameTime) { }
        public virtual void Draw(SpriteBatch spriteBatch) { }
    }
}
