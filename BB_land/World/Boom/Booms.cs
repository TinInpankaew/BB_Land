using Windows.Security.Credentials.UI;
using BB_land.Data;
using BB_land.Services.Content;
using BB_land.Services.World;
using BB_land.World.Components;
using BB_land.World.Components.Animations;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BB_land.World.Boom
{
    internal class Booms : IBoom
    {
        private const int EmotionTime = 1000;
        private readonly Entity entity;
        private double counter;
        private float extraY;
        public bool IsBlowUp { get; private set; }
        TileTestLoader Potion = new TileTestLoader();

        public Booms()
        {
            entity = new Entity("Boom");
            entity.AddComponent(new Sprite(entity, new SpriteData
            {
                Color = Color.White,
                Height = 16,
                Width = 16,
                TextureName = "Pokeball/pokeball_1"
            }));
            entity.AddComponent(new Animation(entity));
        }

        public void PlayEmotion(int xTilePosition, int yTilePosition)
        {
            IsBlowUp = false;
            counter = 0;
            entity.GetComponent<Sprite>().UpdateTilePosition(xTilePosition, yTilePosition);
            entity.GetComponent<Animation>().PlayAnimation(new AnimationBoom());
        }

        public void LoadContent(IContentLoader contentLoader)
        {
            entity.LoadContent(contentLoader);
        }

        public void Update(double gametime)
        {
            entity.Update(gametime);
            counter += gametime;
            if (counter > EmotionTime)
            {
                IsBlowUp = true;
                
            }
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            entity.Draw(spriteBatch);
        }
    }
}

