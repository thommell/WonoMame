using Microsoft.Xna.Framework;
using WonoMane.WonoEngine.Components;

namespace WonoMane.WonoEngine.Core.Data;

//TODO: Read this class (Struct later? better performance)
//TODO: Implement on CollisionLogic a call from here to read collision information from the current target.
public class Collision
{
    private readonly Rectangle _hitRect;
    private readonly GameObject _hitGameObject;
    private readonly Transform _hitTransform;

    public Rectangle HitRect => _hitRect;
    public GameObject HitGameObject => _hitGameObject;
    public Transform HitTransform => _hitTransform;

    public Collision(Rectangle hitRect, GameObject hitGameObject, Transform hitTransform)
    {
        _hitRect = hitRect;
        _hitGameObject = hitGameObject;
        _hitTransform = hitTransform;
    }
    public Collision GetCollision()
    {
        return this;
    }
}