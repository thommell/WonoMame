using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using WonoMane.WonoEngine.Core;
using WonoMane.WonoEngine.Core.Behaviours.BehaviourHandlers;

namespace WonoMane.WonoEngine.Components;

public class SpriteRenderer : WonoBehaviour, IComponentDrawer
{
    #region Fields
    
    private Texture2D _texture;
    private Transform _transform;
    private Color _color = Color.White;
    
    #endregion
    
    #region Properties
    
    public Texture2D Texture => _texture;
    public Color Color => _color;

    #endregion

    public SpriteRenderer(string pSpriteName) => _texture = Utility.GameInstance.Content.Load<Texture2D>(pSpriteName);
    public override void LoadContent()
    {
        _transform = GetComponent<Transform>();
        _transform.Origin = _transform.GetOrigin(_texture);
    }
    public void Draw(SpriteBatch pSpriteBatch)
    {
        pSpriteBatch.Draw(_texture, _transform.Position, _color);
        pSpriteBatch.DrawString(Utility.FontInstance, owner.Name, new Vector2(_transform.Position.X + _transform.Origin.X - GetNameWidth().X * 0.5f, _transform.Position.Y + _transform.Origin.Y + GetNameWidth().Y), Color);
    } 
    private Vector2 GetNameWidth() => Utility.FontInstance.MeasureString(owner.Name);
}