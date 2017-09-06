using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;

namespace IronLake
{
    public class GameObject
    {
        private bool _isActive;

        public GameObject() : this(Enumerable.Empty<Component>())
        {
        }

        public GameObject(IEnumerable<Component> components)
        {
            Components = new List<Component>(components);
            if (!Components.OfType<Transform>().Any())
                Components.Add(new Transform());
        }

        public List<Component> Components { get; set; }

        public Transform Transform => GetComponent<Transform>();

        public GameScene Scene { get; set; }

        public GameObject SetPosition(Vector2 position)
        {
            Transform.Position = position;
            return this;
        }

        public void Activate(GameScene scene)
        {
            _isActive = true;
            Scene = scene;
            Components.ForEach(c => c.Activate());
            OnActivate();
        }

        public GameObject Add(Component component)
        {
            Components.Add(component);
            component.GameObject = this;

            if (_isActive)
                component.Activate();

            return this;
        }

        public T GetComponent<T>() where T : Component
        {
            return (T) Components.FirstOrDefault(c => c is T);
        }

        public virtual void Update(double elapsedSeconds, (int Width, int Height) viewport)
        {
        }

        public virtual void OnActivate()
        {
        }
    }
}