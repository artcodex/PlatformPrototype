using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PlatformerPrototype
{
	public class Background
	{
		protected Texture2D _backgroundTexture;
		public Background(Texture2D bgTexture)
		{
			_backgroundTexture = bgTexture;
		}

		public virtual Rectangle? GetSource()
		{
			return null;
		}

		public virtual void Update(GameTime gameTime)
		{
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			float scale = Utilities.GraphicsManager.PreferredBackBufferWidth / (float)_backgroundTexture.Width;
			float middleX = _backgroundTexture.Width / 2.0f;
			float middleY = 0f;
			Rectangle sourceRectangle = new Rectangle((int)middleX, (int)middleY, (int)(Utilities.GraphicsManager.GraphicsDevice.Viewport.Width / scale), (int)(Utilities.GraphicsManager.GraphicsDevice.Viewport.Height / scale));
			spriteBatch.Draw(_backgroundTexture, new Vector2(0f, 0f), GetSource(), Color.White, 0f, new Vector2(0f, 0f), scale, SpriteEffects.None, 0);
		}
	}
}
