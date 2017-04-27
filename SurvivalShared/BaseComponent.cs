using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SurvivalShared
{
	public abstract class BaseComponent : IComponent
	{
		public BaseComponent()
		{
		}

		public abstract bool AllowsMutiple { get; }

		public virtual void Draw(IGameObject gameObject, GameTime gameTime, SpriteBatch spriteBatch) { }

		public virtual void Load(IGameObject gameObject) { }

		public virtual void Update(IGameObject gameObject, GameTime gameTime) { }
	}
}
