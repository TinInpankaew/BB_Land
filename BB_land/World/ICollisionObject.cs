﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BB_land.World
{
    internal interface ICollisionObject
    {
        bool Collide(int xTilePosition, int yTilePosition);
    }
}
