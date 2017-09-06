using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;

namespace IronLake
{
    public abstract class Element
    {
        public bool IsActive { get; set; }

        protected Element() : this(Enumerable.Empty<Component>())
        {
        }

        protected Element(IEnumerable<Component> components)
        {
            Components = new List<Component>(components);
            if (!Components.OfType<Transform>().Any())
                Components.Add(new Transform());
        }

        public List<Component> Components { get; set; }

        public Transform Transform => GetComponent<Transform>();

        public GameScene Scene { get; set; }

        public T GetComponent<T>() where T : Component
        {
            return (T) Components.FirstOrDefault(c => c is T);
        }

        public Element AddComponent(Component component)
        {
            Components.Add(component);
            component.GameObject = this;

            return this;
        }

        public Element SetPosition(Vector2 position)
        {
            Transform.Position = position;
            return this;
        }

        public List<Element> Children { get; set; } = new List<Element>();

        public virtual void Update(double elapsedSeconds)
        {
        }

        public void Activate(GameScene scene)
        {
            IsActive = true;
            Scene = scene;
            Components.ForEach(c => c.Activate());
            OnActivate();
        }


        public virtual void OnActivate()
        {
        }

        public virtual void OnCollision(GameObject collidedWith)
        {
            
        }
    }
}