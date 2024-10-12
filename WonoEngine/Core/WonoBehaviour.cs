using System.Collections.Generic;
using WonoMane.WonoEngine.Core.Components;
using WonoMane.WonoEngine.Core.Data;
using WonoMane.WonoEngine.Core.SceneHandling;

namespace WonoMane.WonoEngine.Core;

//TODO: Split up Behaviour/Component nicely. -> Behaviour for new objects, Component for Transform, SpriteRenderer, BoxCollider etc.
public abstract class WonoBehaviour 
{
    public abstract void LoadContent();
    protected GameObject owner;
    protected Scene activeScene;
    public GameObject SetObjectOwner(GameObject pOwner) => owner = pOwner;
    public GameObject Owner => owner;
    public Scene SetActiveScene(Scene pScene) => activeScene = pScene;
    public T GetComponent<T>() where T : WonoBehaviour
    {
        return owner.GetComponent<T>();
    }
    // public List<T> GetObjectsOfType<T>() where T : WonoBehaviour
    // {
    //     List<T> behavioursOfType = [];
    //     foreach (GameObject go in activeScene.ObjectsInScene)
    //     {
    //         if (go.GetComponent<T>() is { } obj) 
    //             behavioursOfType.Add(obj);
    //     }
    //     return behavioursOfType;
    // }
    public Dictionary<GameObject, T> GetObjectsOfType<T>() where T : WonoBehaviour
    {
        Dictionary<GameObject, T> behavioursOfType = [];
        foreach (GameObject go in activeScene.ObjectsInScene)
        {
            if (go.GetComponent<T>() is { } obj) 
                behavioursOfType.Add(go, obj);
        }
        return behavioursOfType;
    }
    public virtual void OnCollisionEnter2D(Collision pCollision)
    {
        
    }
}