using System;
using FarseerPhysics;
using FarseerPhysics.Dynamics;
using FarseerPhysics.Factories;
using Microsoft.Xna.Framework;

namespace SurvivalShared
{
	public enum PhysicsBodyShape
	{
		Circle,
		Rectangle
	}

	public enum PhysicsBodyType
	{
		Static,
		Dynamic
	}

	public class PhysicsSystem
	{
		private World _world;
		private static PhysicsSystem _instance = new PhysicsSystem();

		public PhysicsSystem()
		{
			_world = new World(new Vector2(0f, 9.8f));
			ConvertUnits.SetDisplayUnitToSimUnitRatio(64f);
		}

		public static PhysicsSystem Instance
		{
			get
			{
				return _instance;
			}
		}

		public Vector2 ConvertToPhysicsWorld(Vector2 coords)
		{
			return ConvertUnits.ToSimUnits(coords);
		}

		public Vector2 ConvertToGameWorld(Vector2 coords)
		{
			return ConvertUnits.ToDisplayUnits(coords);
		}

		public World World
		{
			get
			{
				return _world;
			}
		}
	}
}
