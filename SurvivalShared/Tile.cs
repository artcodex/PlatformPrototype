using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace SurvivalShared
{
	public class Tile : BaseGameObject
	{
		private Texture2D _tileTexture;
		private int _width;
		private int _height;
		private Vector2 _position;

		public Tile(Texture2D tileTex, Vector2 position, int width, int height)
		{
			_width = width;
			_height = height;
			_tileTexture = tileTex;
			_position = position;
		}


		public float ActualWidth
		{
			get
			{
				return _width * _tileTexture.Width;
			}
		}

		public float ActualHeight
		{
			get
			{
				return _height * _tileTexture.Height;
			}
		}

		public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
		{
			Vector2 startPos = _position;

			for (int i = 0; i < _height; i++)
			{
				for (int j = 0; j < _width; j++)
				{
					Vector2 position = new Vector2(startPos.X + (_tileTexture.Width * j), startPos.Y + (_tileTexture.Height * i));
					spriteBatch.Draw(_tileTexture, position, Color.White);
				}
			}
		}
	}
}
