using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using WonoMane.WonoEngine.Components;
using WonoMane.WonoEngine.Core.Behaviours.BehaviourHandlers;
using WonoMane.WonoEngine.Core.Components;
using WonoMane.WonoEngine.Core.Data;
using WonoMane.WonoEngine.Core.SceneHandling;

namespace WonoMane.WonoEngine.Core;

//If a collision happens between the "_colliders" I want to be able to handle it here, get the "Collision" information from the Collision class.
//TODO: Implement logic for CollisionDetection (all _colliders)
//TODO: Implement logic for getting the collision info (OnCollisionEnter to make it easier to use.)

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
        
        foreach (KeyValuePair<GameObject, BoxCollider2D> entry in _colliders)
        {
            GameObject obj = entry.Key; 
            BoxCollider2D collider = entry.Value; 
            Console.WriteLine($"GameObject: {obj.Name}, BoxCollider2D: {collider}");
        }  
    }
    //TODO: Fix proper bounds checking, this is currently always true somehow? xD
    public bool AreObjectsColliding(GameObject obj1, GameObject obj2)
    {
        return obj1.GetComponent<BoxCollider2D>().Hitbox.Intersects(obj2.GetComponent<BoxCollider2D>().Hitbox);
    }
}