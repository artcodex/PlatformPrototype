using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SurvivalShared
{
	public interface IComponent
	{
		void Load(IGameObject gameObject);
		bool AllowsMutiple { get; }
		void Update(IGameObject gameObject, GameTime gameTime);
		void Draw(IGameObject gameObject, GameTime gameTime, SpriteBatch spriteBatch);
	}
}
