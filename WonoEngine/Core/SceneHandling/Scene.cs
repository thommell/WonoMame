using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WonoMane.WonoEngine.Core.SceneHandling;

public abstract class Scene
{
    protected bool IsLoaded { get; private set; }
    public string Name { get; }
    public List<GameObject> ObjectsInScene { get; protected set; } = [];
    public Scene(string pName)
    {
        Name = pName;
    }
    public virtual void LoadScene()
    {
        for (int i = 0; i < ObjectsInScene.Count; i++)
        {
            ObjectsInScene[i].LoadContent();
        }
        IsLoaded = true;
    }
    public virtual void UpdateScene(GameTime pGameTime)
    {
        for (int i = 0; i < ObjectsInScene.Count; i++)
        {
            ObjectsInScene[i].Update(pGameTime);
        }
    }
    public virtual void DrawScene(SpriteBatch pSpriteBatch)
    {
        for (int i = 0; i < ObjectsInScene.Count; i++)
        {
            ObjectsInScene[i].Draw(pSpriteBatch);
        }
    }

    protected virtual void AddGameObject(GameObject pObject)
    {
        ObjectsInScene.Add(pObject);
    }
    protected virtual void AddGameObjects(params GameObject[] pObjects)
    {
        ObjectsInScene.AddRange(pObjects);
    }
}