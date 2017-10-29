using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace BB_land.World.Components.Animations
{
    internal interface IAnimation
    {
        int AnimationSpeed { get; set; }
        Rectangle GetNewAnimationState();
    }
}
