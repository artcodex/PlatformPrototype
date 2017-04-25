using System;
using Microsoft.Xna.Framework;

namespace PlatformerPrototype
{
	public static class Utilities
	{
		private static GraphicsDeviceManager _graphicsManager;

		public static void Initialize(GraphicsDeviceManager graphicsManager)
		{
			_graphicsManager = graphicsManager;
		}

		public static GraphicsDeviceManager GraphicsManager
		{
			get
			{
				return _graphicsManager;
			}
		}
	}
}
