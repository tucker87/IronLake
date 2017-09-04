using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace IronLake
{
    public class GameObject
    {
        public List<Component> Components { get; set; }
        
        public Transform Transform => GetComponent<Transform>();

        private bool isActive;

        public GameObject() : this(Enumerable.Empty<Component>()) { }

        public GameObject(IEnumerable<Component> components)
        {
            Components = new List<Component>(components);
            if (!Components.OfType<Transform>().Any())
                Components.Add(new Transform());
        }

        public GameObject SetPosition(Vector2 position)
        {
            Transform.Position = position;
            return this;
        }

        public void Activate()
        {
            isActive = true;
            Components.ForEach(c => c.Activate());
            OnActivate();
        }

        public GameObject Add(Component component)
        {
            Components.Add(component);
            component.GameObject = this;

            if (isActive)
                component.Activate();

            return this;
        }

        public T GetComponent<T>() where T : Component
        {
            return (T)Components.First(c => c is T);
        }

        public virtual void Update(double elapsedSeconds, (int Width, int Height) viewport) { }
        public virtual void OnActivate() { }
    }

    public abstract class Component
    {
        public GameObject GameObject { get; set; }

        public Transform Transform => GameObject.Transform;

        public virtual void Activate() { }
    }

    public class Transform : Component
    {
        public Vector2 Position { get; set; }
    }

    public class SpriteRenderer : Component
    {
        public Texture2D Texture2D { get; set; }

        public SpriteRenderer(Texture2D texture2D)
        {
            Texture2D = texture2D;
        }
    }

    public class Collider : Component
    {
        public Action<BoxCollider> OnCollision { get; set; } = collider => { };

        public virtual void BeforePhysics()
        {
        }
    }

    public class BoxCollider : Collider
    {
        public Rectangle BoundingBox { get; set; }

        public BoxCollider(int width, int height)
        {
            BoundingBox = new Rectangle(0, 0, width, height);
        }

        public override void BeforePhysics()
        {
            var boundingBox = BoundingBox;
            boundingBox.X = (int) Transform.Position.X;
            boundingBox.Y = (int) Transform.Position.Y;
            BoundingBox = boundingBox;

            base.BeforePhysics();
        }
    }
}