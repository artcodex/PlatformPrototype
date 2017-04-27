using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace SurvivalShared
{
	public abstract class BaseGameObject : IGameObject
	{
		private Dictionary<Type, List<IComponent>> _components;
		private Transform2D _transform2D;
		public BaseGameObject()
		{
			_components = new Dictionary<Type, List<IComponent>>();

			_transform2D = new Transform2D();
			AddComponent(_transform2D);
		}

		public void AddComponent(IComponent component)
		{
			List<IComponent> components = null;

			if (_components.ContainsKey(component.GetType()))
			{
				if (!component.AllowsMutiple)
				{
					throw new Exception("Cannot add another: " + component.GetType().Name + ", to this game object");
				}

				components = _components[component.GetType()];
			}
			else
			{
				components = new List<IComponent>();
				_components.Add(component.GetType(), components);
			}

			components.Add(component);
			OnAddComponent(component);
		}

		protected virtual void OnAddComponent(IComponent component)
		{
		}

		public T GetComponent<T>()
			where T : class
		{
			if (_components.ContainsKey(typeof(T)))
			{
				return (T)_components[typeof(T)].First();
			}
			else
			{
				return null;
			}
		}

		public List<IComponent> GetComponents<T>()
			where T : class
		{
			if (_components.ContainsKey(typeof(T)))
			{
				return _components[typeof(T)];
			}
			else
			{
				return null;
			}
		}

		public void Start()
		{
			ExecuteOverComponents((component) => component.Load(this));
			OnStart();
		}

		protected void ExecuteOverComponents(Action<IComponent> componentAction)
		{
			foreach (var componentSet in _components)
			{
				foreach (var component in componentSet.Value)
				{
					componentAction(component);
				}
			}
		}

		protected virtual void OnStart()
		{
		}

		public virtual void LoadContent(ContentManager manager) { }

		public virtual void Update(GameTime gameTime) 
		{
			ExecuteOverComponents((component) => component.Update(this, gameTime));
			OnUpdate(gameTime);
		}

		protected virtual void OnUpdate(GameTime gameTime) { } 

		public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch) 
		{
			ExecuteOverComponents((component) => component.Draw(this, gameTime, spriteBatch));
			OnDraw(gameTime, spriteBatch);
		}

		protected virtual void OnDraw(GameTime gameTime, SpriteBatch spriteBatch) { } 

		public Transform2D Transform
		{
			get
			{
				return _transform2D;
			}
		}
	}
}
