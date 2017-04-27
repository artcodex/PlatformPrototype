using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SurvivalShared
{
	/// <summary>
	/// This is the main type for your game.
	/// </summary>
	public class Game1 : Game
	{
		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;
		private Player _player;
		private LayeredBackground _background;
		private Floor _floor;

		public LayeredBackground Background
		{
			get
			{
				return _background;
			}

			set
			{
				_background = value;
			}
		}

		public Game1()
		{
			graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
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

			float width = (float)GraphicsDevice.DisplayMode.Width;
			float height = (float)(GraphicsDevice.DisplayMode.Height);
			int heightInt = (int)(height / 1.3f);
			int widthInt = (int)(width / 1.3f);
			graphics.PreferredBackBufferWidth = widthInt;
			graphics.PreferredBackBufferHeight = heightInt;
			graphics.IsFullScreen = false;
			graphics.ApplyChanges(); 

			Vector2 position = new Vector2(this.Window.ClientBounds.Width / 2,
			this.Window.ClientBounds.Height / 2);

			Utilities.Initialize(graphics, Window);

			var tex = Content.Load<Texture2D>("Tiles/BlockB0");

			Background = new LayeredBackground();
			_player = new Player(position);
			_floor = new Floor();
			_floor.LoadContent(Content);
			_player.LoadContent(Content);
			Background.LoadContent(Content);
		}
		/// <summary>
		/// Allows the game to run logic such as updating the world,
		/// checking for collisions, gathering input, and playing audio.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Update(GameTime gameTime)
		{
			// For Mobile devices, this logic will close the Game when the Back button is pressed
			// Exit() is obsolete on iOS
#if !__IOS__ && !__TVOS__
			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
				Exit();
#endif

			// TODO: Add your update logic here
			Background.Update(gameTime);
			_player.Update(gameTime);
			base.Update(gameTime);
		}

		/// <summary>
		/// This is called when the game should draw itself.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Draw(GameTime gameTime)
		{
			graphics.GraphicsDevice.Clear(Color.Black);

			//TODO: Add your drawing code here
			spriteBatch.Begin(SpriteSortMode.BackToFront, null, SamplerState.LinearWrap);
			Background.Draw(spriteBatch);
			_floor.Draw(gameTime, spriteBatch);
			_player.Draw(gameTime, spriteBatch);

			spriteBatch.End();

			base.Draw(gameTime);
		}
	}
}
