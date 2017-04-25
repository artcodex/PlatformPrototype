using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PlatformerPrototype
{
	public class ParallaxBackground : Background
	{
		private int _direction;
		private float _speed;
		private Vector2 _offset;

		public ParallaxBackground(Texture2D bgTexture, int direction, float speed) : base(bgTexture)
		{
			_direction = direction;
			_speed = speed;
		}

		public override void Update(GameTime gameTime)
		{
			float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
			Vector2 distance = new Vector2(_direction * _speed * elapsed, 0f);
			_offset += distance;
		}

		public override Rectangle? GetSource()
		{
			return new Rectangle((int)_offset.X, (int)_offset.Y, _backgroundTexture.Width, _backgroundTexture.Height);
		}
	}
}
