using System;
using Microsoft.Xna.Framework;

namespace SurvivalShared
{
	public class Transform2D : BaseComponent
	{
		private Vector2 _position;
		private Vector2 _rotation;
		private Vector2 _scale;

		public Transform2D()
		{
			_position = new Vector2(0f, 0f);
			_rotation = new Vector2(0f, 0f);
			_scale = new Vector2(1f, 1f);
		}

		public override bool AllowsMutiple
		{
			get
			{
				return false;
			}
		}

		public Vector2 Position
		{
			get
			{
				return _position;
			}
			set
			{
				_position = value;
			}
		}

		public Vector2 Rotation
		{
			get
			{
				return _rotation;
			}
			set
			{
				_rotation = value;
			}
		}

		public Vector2 Scale
		{
			get
			{
				return _scale;
			}
			set
			{
				_scale = value;
			}
		}
	}
}
