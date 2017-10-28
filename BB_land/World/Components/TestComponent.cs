using System;
using BB_land.EventArg;
using BB_land.Inputs;
using BB_land.Services.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BB_land.World.Components
{
    class TestComponent : Component
    {
        private Texture2D texture;
        private Vector2 position;
        private readonly Input input;

        public TestComponent(IComponentOwner owner) : base(owner)
        {
            this.input = new InputKeyboard();
            this.input.NewInput += OnNewInput;
            position = new Vector2(100, 100);
        }

        private void OnNewInput(object sender, NewInputEventArgs e)
        {
            switch (e.Inputs)
            {
                case Common.Inputs.Left:
                    position.X--;
                    break;
                case Common.Inputs.Up:
                    position.Y--;
                    break;
                case Common.Inputs.Right:
                    position.X++;
                    break;
                case Common.Inputs.Down:
                    position.Y++;
                    break;
                case Common.Inputs.None:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public override void LoadContent(IContentLoader contentLoader)
        {
            texture = contentLoader.LoadTexture("BB/main_character_single");
        }

        public override void Update(double gameTime)
        {
            input.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, new Rectangle((int)position.X, (int)position.Y, 42, 57), Color.White);
        }
    }
}
