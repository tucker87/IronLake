using Microsoft.Xna.Framework;

namespace IronLake
{
    public class UiElement : Element
    {
        public new UiElement AddComponent(Component component)
        {
            return (UiElement)base.AddComponent(component);
        }

        public new UiElement SetPosition(Vector2 position)
        {
            return (UiElement)base.SetPosition(position);
            
        }
    }
}