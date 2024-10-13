using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using WonoMane.WonoEngine.Components;
using WonoMane.WonoEngine.Core.Behaviours;
using WonoMane.WonoEngine.Core.Behaviours.BehaviourHandlers;
using WonoMane.WonoEngine.Core.SceneHandling;
using WonoMane.WonoEngine.Debug;

namespace WonoMane.WonoEngine.Core;

public class GameObject
{
    #region Fields
    
    private Transform _transform;
    private string _name;
    private List<WonoBehaviour> _behaviours = [];
    private List<IComponentDrawer> _componentDrawers = [];
    private List<IComponentUpdater> _componentUpdaters = [];
    protected CollisionLogic collisionLogic;
    #endregion
    #region Properties

    public List<WonoBehaviour> Behaviours => _behaviours;
    public Transform Transform => _transform;
    public string Name => _name;

    #endregion
    public GameObject(string pObjectName, Transform pTransform, params WonoBehaviour[] pBehaviours)
    {
        _name = pObjectName;
        _transform = pTransform;
        _behaviours.Add(pTransform);
        SetBehaviour(pBehaviours.ToList(), ref _behaviours);
        //Dont fuck with this here flimsy asf
        _behaviours.ForEach(wonoBehaviour => SetOwner(ref wonoBehaviour, this));
        _behaviours.ForEach(wonoBehaviour => SetScene(ref wonoBehaviour, SceneManager.Instance.ActiveScene));
    }

    public void LoadContent()
    {
        for (int i = _behaviours.Count - 1; i >= 0; i--)
        {
            _behaviours[i].LoadContent();
        }
    }
    public void Update(GameTime pGameTime)
    {
        for (int i = _componentUpdaters.Count - 1; i >= 0; i--)
        {
            _componentUpdaters[i].Update(pGameTime);
        }
    }
    public void Draw(SpriteBatch pSpriteBatch)
    {
        for (int i = _componentDrawers.Count - 1; i >= 0; i--)
        {
            _componentDrawers[i].Draw(pSpriteBatch);
        } 
    }
    private void SetBehaviour(List<WonoBehaviour> pBehaviour, ref List<WonoBehaviour> pBehaviourList)
    {
        for (int i = pBehaviour.Count - 1; i >= 0; i--) 
        {
            pBehaviourList.Add(pBehaviour[i]);
            if (pBehaviour[i] is BoxCollider2D)
                pBehaviourList.Add(new CollisionLogic());
            SetComponent(pBehaviour[i]);
        }

        return;

        void SetComponent(WonoBehaviour pBehaviour)
        {
            if (pBehaviour is IComponentDrawer drawer)
            {
                _componentDrawers.Add(drawer);
            }
            if (pBehaviour is IComponentUpdater updater)
            {
                _componentUpdaters.Add(updater);
            }
        }
    }
    private void SetOwner(ref WonoBehaviour pBehaviour, GameObject pOwner)
    {
        pBehaviour.SetObjectOwner(pOwner);
    }
    private void SetScene(ref WonoBehaviour pBehaviour, Scene pScene)
    {
        pBehaviour.SetActiveScene(pScene);
    }
    public T GetComponent<T>() where T : WonoBehaviour
    {
        for (int i = 0; i < _behaviours.Count; i++)
        {
            if (_behaviours[i] is T behaviour)
                return behaviour;
        }
        return null;
    }
}