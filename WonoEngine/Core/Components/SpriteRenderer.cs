using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using WonoMane.WonoEngine.Core;
using WonoMane.WonoEngine.Core.Behaviours.BehaviourHandlers;
using WonoMane.WonoEngine.Core.Components;

namespace WonoMane.WonoEngine.Components;

public class SpriteRenderer : Renderer, IComponentDrawer
{
    #region Fields
    private Color _color = Color.White;
    
    #endregion
    
    #region Properties
    

    public Color Color
    {
        get => _color;
        set => _color = value;
    }

    #endregion

    public SpriteRenderer(string pSpriteName) : base(pSpriteName) {}
    protected override void LoadRenderer()
    {
        transform.Origin = transform.GetOrigin(texture);
    }
    public void Draw(SpriteBatch pSpriteBatch)
    {
        pSpriteBatch.Draw(texture, transform.Position, _color);
        pSpriteBatch.DrawString(Utility.FontInstance, owner.Name, new Vector2(transform.Position.X + transform.Origin.X - GetNameWidth().X * 0.5f, transform.Position.Y + transform.Origin.Y + GetNameWidth().Y), Color);
    } 
    private Vector2 GetNameWidth() => Utility.FontInstance.MeasureString(owner.Name);
}