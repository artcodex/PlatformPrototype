using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace PlatformerPrototype
{
	public class LayeredBackground
	{
		List<Background> _backgrounds;

		public LayeredBackground()
		{
			_backgrounds = new List<Background>();
		}

		public void LoadContent(ContentManager contentManager)
		{
			_backgrounds.Add(new ParallaxBackground(contentManager.Load<Texture2D>("Backgrounds/Layer0_0"), 1, 30.0f));
			_backgrounds.Add(new Background(contentManager.Load<Texture2D>("Backgrounds/Layer1_0")));
			_backgrounds.Add(new Background(contentManager.Load<Texture2D>("Backgrounds/Layer2_0")));
		}

		public void Update(GameTime gameTime)
		{
			foreach (Background bg in _backgrounds)
			{
				bg.Update(gameTime);
			}
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			foreach (var background in _backgrounds)
			{
				background.Draw(spriteBatch);
			}
		}
	}
}
