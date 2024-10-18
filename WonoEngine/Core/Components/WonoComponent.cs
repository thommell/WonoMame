using System.Collections.Generic;
using WonoMane.WonoEngine.Core.Data;
using WonoMane.WonoEngine.Core.SceneHandling;

namespace WonoMane.WonoEngine.Core.Components;

public abstract class WonoComponent
{
    protected GameObject owner;
    protected Scene activeScene;
    public virtual void LoadComponent() {}
    public GameObject SetObjectOwner(GameObject pOwner) => owner = pOwner;
    public Scene SetActiveScene(Scene pScene) => activeScene = pScene;
    public T GetComponent<T>() where T : WonoComponent
    {
        return owner.GetComponent<T>();
    }

    // public T GetBehaviour<T>() where T : WonoBehaviour
    // {
    //     return owner.GetBehaviour<T>();
    // }
    public Dictionary<GameObject, T> GetObjectsOfType<T>() where T : WonoComponent
    {
        Dictionary<GameObject, T> behavioursOfType = [];
        foreach (GameObject go in activeScene.ObjectsInScene)
        {
            if (go.GetComponent<T>() is { } obj) 
                behavioursOfType.Add(go, obj);
        }
        return behavioursOfType;
    }
    public virtual void OnCollisionEnter2D(Collision pCollision) {}
    public virtual void OnCollisionStay2D(Collision pCollision) {}
    public virtual void OnCollisionExit2D(Collision pCollision) {}
}