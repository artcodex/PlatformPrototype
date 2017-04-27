using System;
using Microsoft.Xna.Framework;

namespace SurvivalShared
{
	public static class Utilities
	{
		private static GraphicsDeviceManager _graphicsManager;
		private static GameWindow _window;

		public static void Initialize(GraphicsDeviceManager graphicsManager, GameWindow window)
		{
			_graphicsManager = graphicsManager;
			_window = window;
		}

		public static GraphicsDeviceManager GraphicsManager
		{
			get
			{
				return _graphicsManager;
			}
		}

		public static GameWindow Window
		{
			get
			{
				return _window;
			}
		}
	}
}
