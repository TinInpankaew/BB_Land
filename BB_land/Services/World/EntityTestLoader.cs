﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using BB_land.Data;
using BB_land.Inputs;
using BB_land.World;
using BB_land.World.Components;
using BB_land.World.Components.Animations;
using BB_land.World.Components.Movements;
using Microsoft.Xna.Framework;

namespace BB_land.Services.World
{
    internal class EntityTestLoader : IEntityLoader
    {
        public IList<Entity> LoadEntities(string mapName, IList<ICollisionObject> collisionObjects)
        {
            var entity = new Entity("MyFirstEntity");
            entity.AddComponent(new Sprite(entity, new SpriteData
            {
                Color = Color.White,
                Height = 19,
                Width = 15,
                TextureName = "BB/main_character",
                XTilePosition = 1,
                YTilePosition = 1
            }, new Rectangle(0, 0, 16, 19)));
            entity.AddComponent(new MovementPlayer(entity, 1, new InputKeyboard()));
            entity.AddComponent(new Animation(entity));
            entity.AddComponent(new Collision(entity, new ReadOnlyCollection<ICollisionObject>(collisionObjects)));
            return new List<Entity> { entity };
        }
    }
}

