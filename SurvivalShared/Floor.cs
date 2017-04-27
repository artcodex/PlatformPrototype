using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace SurvivalShared
{
	public class Floor : BaseGameObject
	{
		private Tile _floorTile;
		public Floor()
		{
		}

		public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
		{
			_floorTile.Draw(gameTime, spriteBatch);
		}

		public override void LoadContent(ContentManager manager)
		{
			Texture2D floorTex = manager.Load<Texture2D>("Tiles/BlockB0");
			int windowWidth = Utilities.Window.ClientBounds.Width;
			int windowHeight = Utilities.Window.ClientBounds.Height;

			int startingY = windowHeight - (3 * floorTex.Height);
			int tileWidth = (int)Math.Ceiling(windowWidth / (float)floorTex.Width);

			_floorTile = new Tile(floorTex, new Vector2(0f, startingY), tileWidth, 3);
		}
	}
}
