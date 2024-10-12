using System.Collections.Generic;
using Microsoft.Xna.Framework;
using WonoMane.WonoEngine.Components;
using WonoMane.WonoEngine.Core.Behaviours.BehaviourHandlers;
using WonoMane.WonoEngine.Core.Components;
using WonoMane.WonoEngine.Core.SceneHandling;

namespace WonoMane.WonoEngine.Core;

//If a collision happens between the "_colliders" I want to be able to handle it here, get the "Collision" information from the Collision class.
//TODO: Implement logic for CollisionDetection (all _colliders)
//TODO: Implement logic for getting the collision info (OnCollisionEnter to make it easier to use.)

public class CollisionLogic : WonoBehaviour, IComponentUpdater
{
    private Scene _currentActiveScene;
    private Dictionary<GameObject, BoxCollider2D> _colliders;
    public override void LoadContent()
    {
        _colliders = GetObjectsOfType<BoxCollider2D>();
    }
    public void Update(GameTime gameTime) {}
}