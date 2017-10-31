﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BB_land.World.Components
{
    internal class Collision : Component
    {
        private readonly IReadOnlyList<ICollisionObject> collisionObjects;

        public Collision(IComponentOwner owner, IReadOnlyList<ICollisionObject> collisionObjects) : base(owner)
        {
            this.collisionObjects = collisionObjects;
        }

        public bool CollideOnTile(int xTilePosition, int yTilePosition)
        {
            return collisionObjects.Any(c => c.Collide(xTilePosition, yTilePosition));
        }
    }
}
