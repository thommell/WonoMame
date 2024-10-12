using Microsoft.Xna.Framework;
using WonoMane.WonoEngine.Components;

namespace WonoMane.WonoEngine.Core.SceneHandling.Scenes;

public class DebugScene : Scene
{
    private GameObject obj1;
    public DebugScene(string pName) : base(pName)
    { }

    public override void LoadScene()
    {
        obj1 = new GameObject("EnemyLeft", new Transform(new Vector2(200, 200)), new SpriteRenderer("Enemy"), new BoxCollider2D());
        ObjectsInScene.Add(obj1);
        ObjectsInScene.Add(new GameObject("EnemyRight", new Transform(new Vector2(300, 200)), new SpriteRenderer("Enemy"), new BoxCollider2D()));
        base.LoadScene();
    }

    public override void UpdateScene(GameTime pGameTime)
    {
        obj1.Transform.Translate(new Vector2(1, 0));
        base.UpdateScene(pGameTime);
    }
}