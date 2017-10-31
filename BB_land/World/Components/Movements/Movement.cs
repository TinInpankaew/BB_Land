using System;
using BB_land.Common;
using BB_land.Services;
using BB_land.World.Components.Animations;
using BB_land.World.Tiles;
using Microsoft.Xna.Framework;

namespace BB_land.World.Components.Movements
{
    internal abstract class Movement : Component
    {
        private Vector2 wantedPosition;
        private readonly float speed;
        protected bool InMovement;
        private readonly AnimationWalking animationWalking;

        public Movement(IComponentOwner owner, float speed) : base(owner)
        {
            this.speed = speed;
            InMovement = false;
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
