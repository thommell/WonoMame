using Microsoft.Xna.Framework;
using WonoMane.WonoEngine.Components;

namespace WonoMane.WonoEngine.Core.SceneHandling.Scenes;

public class DebugScene : Scene
{
    public DebugScene(string pName) : base(pName)
    { }

    public override void LoadScene()
    {
        ObjectsInScene.Add(new GameObject("Enemy", new Transform(new Vector2(100, 200)), new SpriteRenderer("Enemy"), new BoxCollider2D()));
        ObjectsInScene.Add(new GameObject("Enemy2", new Transform(new Vector2(200, 200)), new SpriteRenderer("Enemy"), new BoxCollider2D()));
        ObjectsInScene.Add(new GameObject("Enemy3", new Transform(new Vector2(300, 200)), new SpriteRenderer("Enemy"), new BoxCollider2D()));
        ObjectsInScene.Add(new GameObject("Enemy4", new Transform(new Vector2(400, 200)), new SpriteRenderer("Enemy"), new BoxCollider2D()));
        base.LoadScene();
    }
}