﻿using System;
using BB_land.Inputs;
using BB_land.Services.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using BB_land.Data;
using BB_land.Screens;
using BB_land.Screens.ScreenTransitionEffects;
using BB_land.Services.Screens;
using BB_land.World;
using BB_land.World.Components;
using BB_land.World.Components.Animations;
using BB_land.World.Components.Movements;


namespace BB_land
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class BB_Land : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Entity entity;
        IContentLoader contentLoader;
        private ScreenLoader screenLoader;


        public BB_Land()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 240;
            graphics.PreferredBackBufferHeight = 160;
            Content.RootDirectory = "Content";
            contentLoader = new ContentLoader(Content);
            screenLoader = new ScreenLoader(new ScreenTransitionEffectFadeOut(graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight, 5),
                new ScreenTransitionEffectFadeIn(graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight, 3), contentLoader );
            screenLoader.LoadScreen(new ScreenWorld(screenLoader));
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            screenLoader.LoadContent();
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            screenLoader.Update(gameTime.ElapsedGameTime.Milliseconds);
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();
            screenLoader.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}