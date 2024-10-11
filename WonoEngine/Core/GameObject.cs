using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using WonoMane.Core;
using WonoMane.Core.Behaviours;
using WonoMane.WonoEngine.Core.Behaviours.BehaviourHandlers;

namespace WonoMane.WonoEngine.Core;

public class GameObject
{
    #region Fields
    
    private Transform _transform;
    private string _name;
    private List<MonoBehaviour> _behaviours = [];
    private List<IComponentDrawer> _componentDrawers = [];
    private List<IComponentUpdater> _componentUpdaters = [];
    #endregion
    
    #region Properties
    
    public Transform Transform => _transform;
    public string Name => _name;

    #endregion
    
    public GameObject(string pObjectName, Transform pTransform, params MonoBehaviour[] pBehaviours)
    {
        _name = pObjectName;
        _transform = pTransform;
        _behaviours.Add(pTransform);
        GetBehaviours(pBehaviours, ref _behaviours);
        _behaviours.ForEach(a => a.SetObjectOwner(this));
    }
    public void LoadContent() => _behaviours.ForEach(behaviour => behaviour.LoadContent());
    public void Update(GameTime pGameTime) => _componentUpdaters.ForEach(updater => updater.Update(pGameTime));
    public void Draw(SpriteBatch pSpriteBatch) => _componentDrawers.ForEach(drawer => drawer.Draw(pSpriteBatch));
   
    private void GetBehaviours(MonoBehaviour[] pBehaviours, ref List<MonoBehaviour> pBehaviourList)
    {
        foreach (MonoBehaviour behaviour in pBehaviours)
        {
            pBehaviourList.Add(behaviour);
            if (behaviour is IComponentDrawer drawer)
                _componentDrawers.Add(drawer);
            if (behaviour is IComponentUpdater updater)
                _componentUpdaters.Add(updater);
            behaviour.SetObjectOwner(this);
        }
    }
    public T GetComponent<T>() where T : MonoBehaviour
    {
        for (int i = 0; i < _behaviours.Count; i++)
        {
            if (_behaviours[i] is T behaviour)
                return behaviour;
        }
        return null;
    }
}