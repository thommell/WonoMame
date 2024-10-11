using WonoMane.WonoEngine.Core;

namespace WonoMane.Core;

public abstract class MonoBehaviour
{
    #region Fields

    protected GameObject owner;

    #endregion
    
    public abstract void LoadContent();
    public virtual void Awake() {}
    public GameObject SetObjectOwner(GameObject pOwner) => owner = pOwner;
}