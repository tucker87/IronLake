using Microsoft.Xna.Framework;

namespace IronLake
{
    public abstract class GameObject : Element
    {
        public new GameObject SetPosition(Vector2 position)
        {
            return (GameObject) base.SetPosition(position);
        }

        public new GameObject AddComponent(Component component)
        {
            base.AddComponent(component);

            if (IsActive)
                component.Activate();

            return this;
        }
        
        
    }
}