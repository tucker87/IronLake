using System;

namespace IronLake
{
    public class Collider : Component
    {
        public Action<BoxCollider> OnCollision { get; set; } = collider => { };

        public virtual void BeforePhysics()
        {
        }
    }
}