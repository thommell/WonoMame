using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using WonoMane.WonoEngine.Core.SceneHandling.Scenes;

namespace WonoMane.WonoEngine.Core.SceneHandling;

//TODO: Make an event for when you switch a scene. (mostly for other objects to use)
public class SceneManager
{
    private static SceneManager _instance;
    private List<Scene> _scenes = [];
    private Scene _activeScene;
    public Scene ActiveScene => _activeScene;

    public static SceneManager Instance => _instance ??= new SceneManager();

    public void Load()
    {
        CreateScene(ref _scenes);
        _activeScene.LoadScene();
    }
    public void Update(GameTime pGameTime)
    {
        _activeScene.UpdateScene(pGameTime);
    }
    public void Draw(SpriteBatch pSpriteBatch)
    {
        _activeScene.DrawScene(pSpriteBatch);
    }
    private void CreateScene(ref List<Scene> pScenes)
    {
        List<Scene> scenesList = [
            new DebugScene(GetType().Name)
        ];
        pScenes.AddRange(scenesList);
        _activeScene = scenesList[0];
    }
    
}