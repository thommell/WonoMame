using Microsoft.Xna.Framework.Graphics;

namespace WonoMane.WonoEngine.Core.Components;

public class Renderer : WonoComponent
{
    protected Texture2D texture;
    protected Transform transform;
    public Texture2D Texture { get => texture; set => texture = value; }
    protected Renderer(string pTextureName)
    {
        texture = Utility.GameInstance.Content.Load<Texture2D>(pTextureName);
    }

    public override void LoadComponent()
    {
        transform = GetComponent<Transform>();
    }

    protected virtual void LoadRenderer() {}
}