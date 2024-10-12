using Microsoft.Xna.Framework;
using WonoMane.WonoEngine.Components;

namespace WonoMane.WonoEngine.Core.Data;

//TODO: Read this class (Struct later? better performance)
//TODO: Implement on CollisionLogic a call from here to read collision information from the current target.
public class Collision
{
    private readonly Rectangle _hitBox;
    private readonly GameObject _gameObject;
    private readonly Transform _transform;

    public Rectangle HitBox => _hitBox;
    public GameObject GameObject => _gameObject;
    public Transform Transform => _transform;

    public Collision(Rectangle pHitBox, GameObject pGameObject, Transform pTransform)
    {
        _hitBox = pHitBox;
        _gameObject = pGameObject;
        _transform = pTransform;
    }
}