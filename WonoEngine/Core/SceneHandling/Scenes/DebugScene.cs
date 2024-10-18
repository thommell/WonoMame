using Microsoft.Xna.Framework;
using WonoMane.WonoEngine.Components;
using WonoMane.WonoEngine.Core.Components;

namespace WonoMane.WonoEngine.Core.SceneHandling.Scenes;

public class DebugScene : Scene
{
    private GameObject _obj1;
    public DebugScene(string pName) : base(pName)
    { }

    public override void LoadScene()
    {
        
        var animator = new AnimatedSpriteRenderer("Megaman", 140f, 140f, 1.5f, 5, 2);
        _obj1 = new GameObject("EnemyLeft", new Transform(new Vector2(200, 200)), new SpriteRenderer("Enemy"), new BoxCollider2D());
        var obj2 = new GameObject("EnemyRight", new Transform(new Vector2(300, 200)), new SpriteRenderer("Enemy"), new BoxCollider2D());
        var obj3 = new GameObject("EnemyAnimator", new Transform(new Vector2(300, 200)), animator);
        AddGameObjects(_obj1, obj2, obj3);
        base.LoadScene();
    }

    public override void UpdateScene(GameTime pGameTime)
    {
        _obj1.Transform.Translate(new Vector2(1, 0));
        base.UpdateScene(pGameTime);
    }
}