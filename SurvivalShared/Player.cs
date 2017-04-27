using System;
using System.Collections.Generic;
using FarseerPhysics.Factories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace SurvivalShared
{
	public class Player : BaseGameObject
	{
		private Dictionary<String, Animation> _animations;
		private Animation _currentAnimation;
		private Vector2 _startingPosition;
		private PhysicsBody2D _body2D;

		public Player(Vector2 startingPosition)
		{
			_startingPosition = startingPosition;
			_animations = new Dictionary<string, Animation>();
		}

		public void LoadContent(ContentManager contentManager)
		{
			_animations.Add("Run", new Animation(contentManager.Load<Texture2D>("Sprites/Player/Run"), 64, 0.1f, 10));
			_animations.Add("Idle", new Animation(contentManager.Load<Texture2D>("Sprites/Player/Idle"), 64, 0.1f, 1));
			_animations.Add("Jump", new Animation(contentManager.Load<Texture2D>("Sprites/Player/Jump"), 64, 0.1f, 11));
			_animations.Add("Celebrate", new Animation(contentManager.Load<Texture2D>("Sprites/Player/Celebrate"), 64, 0.1f, 11));
			_animations.Add("Die", new Animation(contentManager.Load<Texture2D>("Sprites/Player/Die"), 64, 0.1f, 12));

			_currentAnimation = _animations["Idle"];

			Vector2 wh = PhysicsSystem.Instance.ConvertToPhysicsWorld(new Vector2(64f, 64f));
			Vector2 position = PhysicsSystem.Instance.ConvertToPhysicsWorld(_startingPosition);
			var playerBody = BodyFactory.CreateRectangle(PhysicsSystem.Instance.World, wh.X, wh.Y, 1f, position); 
			_body2D = new PhysicsBody2D(playerBody);
			AddComponent(_body2D);
		}

		protected override void OnUpdate(GameTime gameTime)
		{
			_currentAnimation.Advance(gameTime);
		}

		protected override void OnDraw(GameTime gameTime, SpriteBatch spriteBatch)
		{
			_currentAnimation.DrawFrame();
			//Vector2 position = 
			float scale = (Utilities.GraphicsManager.PreferredBackBufferWidth / 15.0f) / (float)_currentAnimation.FrameDimension;
			// Draw the current frame.
			spriteBatch.Draw(_currentAnimation.AnimationSheet, _startingPosition, _currentAnimation.Source, Color.White, 0.0f,
			                 _currentAnimation.Origin, scale, SpriteEffects.None, 0.0f);
		}

		Animation CurrentAnimation
		{
			get
			{
				return _currentAnimation;
			}
		}

		Vector2 StartingPosition
		{
			get
			{
				return _startingPosition;
			}
		}
	}
}
