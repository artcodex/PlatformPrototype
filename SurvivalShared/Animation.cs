using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SurvivalShared
{
	public class Animation
	{
		private Texture2D _animationSheet;
		private int _frameDimension;
		private float _frameTime;

		private int _currentFrame;
		private int _totalFrames;
		private float _time;

		private Rectangle _source;
		private Vector2 _origin;

		public Animation(Texture2D animationSheet, int frameDimension, float frameTime, int totalFrames) 
		{
			_animationSheet = animationSheet;
			_frameTime = frameTime;
			_frameDimension = frameDimension;
			_currentFrame = 0;
			_totalFrames = totalFrames;
			_time = 0f;
		}

		public int CurrentFrame
		{
			get
			{
				return _currentFrame;
			}
		}

		public Texture2D AnimationSheet
		{
			get
			{
				return _animationSheet;
			}
		}

		public int FrameDimension
		{
			get
			{
				return _frameDimension;
			}
		}

		public float FrameTime
		{
			get
			{
				return _frameTime;
			}
		}

		public int TotalFrames
		{
			get
			{
				return _totalFrames;
			}
		}

		public void Advance(GameTime gameTime)
		{
			_time += (float)gameTime.ElapsedGameTime.TotalSeconds;

			if (_time >= _frameTime)
			{
				_currentFrame = (_currentFrame + 1) % _totalFrames;
				_time = 0f;
			}
		}

		public void Reset()
		{
			_currentFrame = 0;
			_time = 0f;
		}

		public Rectangle Source
		{
			get
			{
				return _source;
			}
		}

		public Vector2 Origin
		{
			get
			{
				return _origin;
			}
		}

		public void DrawFrame()
		{
			// Calculate sprite source rectangle in the sheet and origin
			_source = new Rectangle(_currentFrame * _frameDimension,
											 0, _frameDimension, _frameDimension);
			_origin = new Vector2(_frameDimension / 2.0f, _frameDimension);
		}
	}
}
