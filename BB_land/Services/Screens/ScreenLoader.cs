using System;
using BB_land.Screens;
using BB_land.Screens.ScreenTransitionEffects;
using BB_land.Services.Content;
using Microsoft.Xna.Framework.Graphics;

namespace BB_land.Services.Screens
{
    internal class ScreenLoader : IScreenLoader
    {

        private Screen previousScreen;
        private Screen currentScreen;
        private Screen tempScreen;
        private readonly IScreenTransitionEffect _previousScreenTransitionEffect;
        private readonly IScreenTransitionEffect newScreenTransitionEffect;
        private readonly IContentLoader contentLoader;
        private enum Phases {  ClosingPreviousScreen, SettingUpNewScreen, Running}

        private Phases currentPhases;

        public ScreenLoader(IScreenTransitionEffect previousScreenTransitionEffect,
            IScreenTransitionEffect newScreenTransitionEffect, IContentLoader contentLoader)
        {
            this._previousScreenTransitionEffect = previousScreenTransitionEffect;
            this.newScreenTransitionEffect = newScreenTransitionEffect;
            this.contentLoader = contentLoader;
            currentPhases = Phases.Running;
        }

        public void LoadContent()
        {
            _previousScreenTransitionEffect.LoadContent(contentLoader);
            newScreenTransitionEffect.LoadContent(contentLoader);
        }

        public void Update(double gameTime)
        {
            switch (currentPhases)
            {
                case Phases.ClosingPreviousScreen:
                    _previousScreenTransitionEffect.Update(gameTime);
                    if (_previousScreenTransitionEffect.IsDone)
                    {
                        PrepareNewScreen();
                    }
                    break;
                case Phases.SettingUpNewScreen:
                    newScreenTransitionEffect.Update(gameTime);
                    if (newScreenTransitionEffect.IsDone)
                    {
                        currentPhases = Phases.Running;
                    }
                    break;
                case Phases.Running:
                    currentScreen?.Update(gameTime);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void LoadScreen(Screen screen)
        {
            currentPhases = Phases.ClosingPreviousScreen;
            _previousScreenTransitionEffect.Start();
            tempScreen = screen;
        }

        public void PrepareNewScreen()
        {
            previousScreen = currentScreen;
            currentScreen = tempScreen;
            currentScreen.LoadContent(contentLoader);
            newScreenTransitionEffect.Start();
            currentPhases = Phases.SettingUpNewScreen;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            currentScreen?.Draw(spriteBatch);
            _previousScreenTransitionEffect.Draw(spriteBatch);
            newScreenTransitionEffect.Draw(spriteBatch);
        }
    }
}
