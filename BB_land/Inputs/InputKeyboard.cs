using BB_land.Inputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;

namespace BB_land.Inputs
{
    internal class InputKeyboard : Input
    {
        private KeyboardState keyboardState;
        private KeyboardState LasKeyboardState;
        private Keys lastKey;


        protected override void CheckInput(double gameTime)
        {
            keyboardState = Keyboard.GetState();
            if(keyboardState.IsKeyUp(lastKey) && lastKey != Keys.None)
            {
                SendNewInput(Common.Inputs.None);
            }

            CheckKeyState(Keys.Left, Common.Inputs.Left);
            CheckKeyState(Keys.Up, Common.Inputs.Up);
            CheckKeyState(Keys.Right, Common.Inputs.Right);
            CheckKeyState(Keys.Down, Common.Inputs.Down);
            CheckKeyState(Keys.Z, Common.Inputs.Z);

            LasKeyboardState = keyboardState;

        }

        private void CheckKeyState(Keys key, Common.Inputs sendInputs)
        {
            if(keyboardState.IsKeyDown(key))
            {
                SendNewInput(sendInputs);
                lastKey = key;
            }
        }
    }
}
