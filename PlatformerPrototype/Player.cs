using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace PlatformerPrototype
{
	public class Player
	{
		private Dictionary<String, Animation> _animations;
		private Animation _currentAnimation;
		private Vector2 _position;

		public Player(Vector2 startingPosition)
		{
			_position = startingPosition;
			_animations = new Dictionary<string, Animation>();
		}

		public void LoadContent(ContentManager contentManager)
		{
			_animations.Add("Run", new Animation(contentManager.Load<Texture2D>("Sprites/Player/Run"), 64, 0.1f, 10));
			_animations.Add("Idle", new Animation(contentManager.Load<Texture2D>("Sprites/Player/Idle"), 64, 0.1f, 1));
			_animations.Add("Jump", new Animation(contentManager.Load<Texture2D>("Sprites/Player/Jump"), 64, 0.1f, 11));
			_animations.Add("Celebrate", new Animation(contentManager.Load<Texture2D>("Sprites/Player/Celebrate"), 64, 0.1f, 11));
			_animations.Add("Die", new Animation(contentManager.Load<Texture2D>("Sprites/Player/Die"), 64, 0.1f, 12));

			_currentAnimation = _animations["Celebrate"];
		}

		public void Update(GameTime gameTime)
		{
			_currentAnimation.Advance(gameTime);
		}

		public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
		{
			_currentAnimation.DrawFrame();

			float scale = (Utilities.GraphicsManager.PreferredBackBufferWidth / 15.0f) / (float)_currentAnimation.FrameDimension;
			// Draw the current frame.
			spriteBatch.Draw(_currentAnimation.AnimationSheet, _position, _currentAnimation.Source, Color.White, 0.0f,
			                 _currentAnimation.Origin, scale, SpriteEffects.None, 0.0f);
		}

		Animation CurrentAnimation
		{
			get
			{
				return _currentAnimation;
			}
		}

		Vector2 Position
		{
			get
			{
				return _position;
			}
		}
	}
}
