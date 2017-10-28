using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BB_land.Common;
using BB_land.Services;
using BB_land.World.Tiles;
using Microsoft.Xna.Framework;

namespace BB_land.World.Components.Movements
{
    internal abstract class Movement : Component
    {
        private Vector2 wantedPosition;
        private readonly float speed;
        protected bool InMovement;

        public Movement(IComponentOwner owner, float speed) : base(owner)
        {
            this.speed = speed;
            InMovement = false;
        }

        protected void Move(Directions direction)
        {
            var sprite = Owner.GetComponent<Sprite>();
            switch (direction)
            {
                case Directions.Left:
                    wantedPosition = new Vector2(sprite.TilePosition.X*Tile.Width - Tile.Width, sprite.TilePosition.Y*Tile.Hight);
                    break;
                case Directions.Up:
                    wantedPosition = new Vector2(sprite.TilePosition.X * Tile.Width, sprite.TilePosition.Y*Tile.Hight - Tile.Hight);
                    break;
                case Directions.Right:
                    wantedPosition = new Vector2(sprite.TilePosition.X * Tile.Width + Tile.Width, sprite.TilePosition.Y*Tile.Hight);
                    break;
                case Directions.Down:
                    wantedPosition = new Vector2(sprite.TilePosition.X * Tile.Width, sprite.TilePosition.Y*Tile.Hight + Tile.Hight);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
            }
            InMovement = true;

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
            sprite.UpdateTilePosition((int)(wantedPosition.X / Tile.Width), (int)(wantedPosition.Y / Tile.Hight));
            sprite.ResetPositionOffset();
            InMovement = false;
        }
    }
}
