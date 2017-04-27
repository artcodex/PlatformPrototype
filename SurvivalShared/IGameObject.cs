using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace SurvivalShared
{
	public interface IGameObject
	{
		void LoadContent(ContentManager manager);
		void Update(GameTime gameTime);
		void Draw(GameTime gameTime, SpriteBatch spriteBatch);
		T GetComponent<T>() where T : class;
		List<IComponent> GetComponents<T>() where T : class;
		void AddComponent(IComponent component);
		void Start();
		Transform2D Transform { get; }
	}
}
