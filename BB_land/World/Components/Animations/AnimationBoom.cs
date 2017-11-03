using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace BB_land.World.Components.Animations
{
    internal class AnimationBoom : IAnimation
    {
        private const int Width = 16;
        private const int Height = 16;
        private int animationindex;
        public int AnimationSpeed { get; set; }

        public AnimationBoom()
        {
            AnimationSpeed = 30;
            animationindex = 0;
        }


        public Rectangle GetNewAnimationState()
        {
            if (animationindex < 2)
            {
                animationindex++;
            }
            return new Rectangle(Width*animationindex, 0 , Width, Height);
        }
    }
}
/*    internal class AnimationEmotion : IAnimation
    {
        private const int Width = 16;
        private const int Height = 16;
        private int animationindex; 
        public int AnimationSpeed { get; set; }

        public AnimationEmotion()
        {
            AnimationSpeed = 25; 
            animationindex = 0; 
        }

        public Rectangle GetNewAnimationState()
        {
            if (animationindex < 2)
            {
                animationindex++;
            }
            return new Rectangle(Width*animationindex, 0, Width, Height);
        }
    }*/
