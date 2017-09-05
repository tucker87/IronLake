using Microsoft.Xna.Framework.Graphics;

namespace IronLake
{
    public class SpriteRenderer : Component
    {
        public SpriteRenderer(Texture2D texture2D)
        {
            Texture2D = texture2D;
        }

        public Texture2D Texture2D { get; set; }
    }
}