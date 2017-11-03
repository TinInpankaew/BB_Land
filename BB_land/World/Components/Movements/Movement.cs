using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using BB_land.Common;
using BB_land.Data;
using BB_land.Services;
using BB_land.Services.World;
using BB_land.World.Components.Animations;
using BB_land.World.Tiles;
using Microsoft.Xna.Framework;
using BB_land.World.Boom;

namespace BB_land.World.Components.Movements
{
    internal abstract class Movement : Component
    {
        private Vector2 wantedPosition;
        private readonly float speed;
        protected bool InMovement;
        protected bool InBoom;
        TileTestLoader x = new TileTestLoader();
        private readonly AnimationWalking animationWalking;
        private Booms booms;
        

        public Movement(IComponentOwner owner, float speed) : base(owner)
        {
            this.speed = speed;
            InMovement = false;
            InBoom = false;
            animationWalking = new AnimationWalking(16, 19 ,2, Directions.Down);
        }
        
        protected void Move(Directions direction)
        {
            var sprite = Owner.GetComponent<Sprite>();
            var wantedXTilePosition = (int)sprite.TilePosition.X;
            var wantedYTilePostion = (int)sprite.TilePosition.Y;
            switch (direction)
            {
                case Directions.Left:
                    wantedXTilePosition--;
                    break;
                case Directions.Up:
                    wantedYTilePostion--;
                    break;
                case Directions.Right:
                    wantedXTilePosition++;
                    break;
                case Directions.Down:
                    wantedYTilePostion++;
                    break;
                case Directions.Z:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
            }
            if (Collision(wantedXTilePosition, wantedYTilePostion))
                return;
            wantedPosition = new Vector2(wantedXTilePosition * Tile.Width, wantedYTilePostion * Tile.Height);
            InMovement = true;
            animationWalking.ChangeDirection(direction);
            Owner.GetComponent<Animation>().PlayAnimation(animationWalking);
        }

        public float XPosition()
        {
            var sprite = Owner.GetComponent<Sprite>();
            var currentPosition = sprite.CurrentPosition;
            return currentPosition.X;
        }

        public float YPosition()
        {
            var sprite = Owner.GetComponent<Sprite>();
            var currentPosition = sprite.CurrentPosition;
            return currentPosition.Y;
        }



        private bool Collision(int wantedXTilePosition, int wantedYTilePosition)
        {
            var collision = Owner.GetComponent<Collision>();
            return collision != null && collision.CollideOnTile(wantedXTilePosition, wantedYTilePosition);
        }

        public override void Update(double gameTime)
        {
            if (!InMovement)
                return;
            var sprite = Owner.GetComponent<Sprite>();
            var currentPosition = sprite.CurrentPosition;
            if (UtilityService.GetDistance(currentPosition, wantedPosition) < speed)
            {
                FinishMovement();
            }
            if (currentPosition.X < wantedPosition.X)
            {
                sprite.IncreasePositionOffset(speed, 0);
            }
            if (currentPosition.X > wantedPosition.X)
            {
                sprite.IncreasePositionOffset(speed * -1, 0);
            }
            if (currentPosition.Y < wantedPosition.Y)
            {
                sprite.IncreasePositionOffset(0, speed);
            }
            if (currentPosition.Y > wantedPosition.Y)
            {
                sprite.IncreasePositionOffset(0, speed * -1);
            }
            if (InBoom == true)
            {
       //         LoadEntities()
         //       InBoom = false;
            }
        }

        public IList<Entity> LoadEntities(IList<ICollisionObject> collisionObjects)
        {
            var sprite = Owner.GetComponent<Sprite>();
            var currentPosition = sprite.CurrentPosition;
            var entity = new Entity("Boom");
            entity.AddComponent(new Sprite(entity, new SpriteData
            {
                Color = Color.White,
                Height = 16,
                Width = 16,
                TextureName = "Pokeball/pokeball_1",
                XTilePosition = (int)currentPosition.X,
                YTilePosition = (int)currentPosition.Y,
            }, new Rectangle(0, 0, 16, 16)));
            entity.AddComponent(new Collision(entity, new ReadOnlyCollection<ICollisionObject>(collisionObjects)));
            return new List<Entity> { entity };
        }



        private void FinishMovement()
        {
            var sprite = Owner.GetComponent<Sprite>();
            sprite.UpdateTilePosition((int)(wantedPosition.X / Tile.Width), (int)(wantedPosition.Y / Tile.Height));
            sprite.ResetPositionOffset();
            InMovement = false;
            var animation = Owner.GetComponent<Animation>();
            animation.StopAnimation();
        }
    }
}
