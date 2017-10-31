using System.Collections.Generic;
using BB_land.World;

namespace BB_land.Services.World
{
    internal interface IEntityLoader
    {
        IList<Entity> LoadEntities(string mapName, IList<ICollisionObject> collisionObjects);
    }
}