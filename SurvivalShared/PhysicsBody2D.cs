using System;
using FarseerPhysics.Dynamics;
using FarseerPhysics.Factories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SurvivalShared
{
	public class PhysicsBody2D : BaseComponent
	{
		private Body _body;
		public PhysicsBody2D(Body body)
		{
			_body = body;
		}

		public Body Body
		{
			get
			{
				return _body;
			}
		}

		public override bool AllowsMutiple
		{
			get
			{
				return false;
			}
		}

		public override void Update(IGameObject gameObject, GameTime gameTime)
		{
			gameObject.Transform.Position = PhysicsSystem.Instance.ConvertToGameWorld(_body.Position);
		}
	}
}
