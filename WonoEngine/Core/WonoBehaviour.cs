using System;
using System.Collections.Generic;
using WonoMane.WonoEngine.Core.Components;
using WonoMane.WonoEngine.Core.Data;
using WonoMane.WonoEngine.Core.SceneHandling;

namespace WonoMane.WonoEngine.Core;

public abstract class WonoBehaviour : WonoComponent
{
    public abstract void LoadContent();
    public virtual void OnCollisionEnter2D(Collision pCollision) {}
    public virtual void OnCollisionStay2D(Collision pCollision) {}
    public virtual void OnCollisionExit2D(Collision pCollision) {}
}