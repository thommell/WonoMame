using System.Collections.Generic;
using WonoMane.WonoEngine.Core.SceneHandling;

namespace WonoMane.WonoEngine.Core.Components;

//TODO: FOR NOW THIS IS DEPRECATED, THIS LEVEL OF ABSTRACTION WILL HAPPEN UNTIL I FIX COLLISION DETECTION COMPLETELY OTHERWISE I WILL NOT SURVIVE
public abstract class WonoComponent
{
    // protected GameObject owner;
    // protected Scene activeScene;
    // public GameObject SetObjectOwner(GameObject pOwner) => owner = pOwner;
    // public Scene SetActiveScene(Scene pScene) => activeScene = pScene;
    // public T GetComponent<T>() where T : WonoBehaviour
    // {
    //     return owner.GetComponent<T>();
    // }
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
    // public Dictionary<GameObject, T> GetObjectsOfType<T>() where T : WonoBehaviour
    // {
    //     Dictionary<GameObject, T> behavioursOfType = [];
    //     foreach (GameObject go in activeScene.ObjectsInScene)
    //     {
    //         if (go.GetComponent<T>() is { } obj) 
    //             behavioursOfType.Add(go, obj);
    //     }
    //     return behavioursOfType;
    // }
}