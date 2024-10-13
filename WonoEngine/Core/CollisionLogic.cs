using System.Collections.Generic;
using WonoMane.WonoEngine.Components;
using WonoMane.WonoEngine.Core.Components;

namespace WonoMane.WonoEngine.Core;

public class CollisionLogic : WonoBehaviour
{
    
    #region Fields
    
    private Dictionary<GameObject, BoxCollider2D> _colliders;
    
    #endregion
    
    #region Properties
    
    public Dictionary<GameObject, BoxCollider2D> Colliders => _colliders;
    
    #endregion
    public override void LoadContent()
    {
        _colliders = GetObjectsOfType<BoxCollider2D>();
    }
    /// <summary>
    /// Collision check with the 2 given GameObjects.
    /// </summary>
    /// <returns>Returns true on intersection, false if not or if there are no <see cref="BoxCollider2D"/>'s on any GameObject.</returns>
    public bool AreObjectsColliding(GameObject obj1, GameObject obj2)
    {
        if (_colliders.TryGetValue(obj1, out BoxCollider2D collider1) &&
            _colliders.TryGetValue(obj2, out BoxCollider2D collider2))
            return collider1.Hitbox.Intersects(collider2.Hitbox);
        return false;
    }
}