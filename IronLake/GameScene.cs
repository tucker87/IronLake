using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;

namespace IronLake
{
    public class GameScene
    {
        public Game Game { get; set; }
        public List<GameObject> GameObjects { get; set; } = new List<GameObject>();
        public List<UiElement> UiElements { get; set; } = new List<UiElement>();

        public GameScene(Game game)
        {
            Game = game;
        }

        public IEnumerable<GameObject> CheckCollision(Rectangle sourceBoundingBox)
        {
            return GameObjects
                .Where(go =>
                {
                    var targetCollider = go.GetComponent<BoxCollider>();
                    return targetCollider != null
                        && targetCollider.BoundingBox.Intersects(sourceBoundingBox);
                });
        }
    }
}