using Microsoft.Xna.Framework;
using WonoMane.WonoEngine.Core.Behaviours.BehaviourHandlers;

namespace WonoMane.WonoEngine.Core.Behaviours;

public class BoxCollider2D : MonoBehaviour, IComponentUpdater
{
    #region Fields

    private Rectangle _hitbox = Rectangle.Empty;
    private Transform _transform;
    private SpriteRenderer _spriteRenderer;
    
    #endregion
    
    #region Properties

    public Rectangle Hitbox {get => _hitbox; set => _hitbox = value; }
    
    #endregion

    public override void LoadContent()
    {
        _transform = GetComponent<Transform>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _transform.OnPositionChanged += SetHitBox;
        SetHitBox();
    }
    private void SetHitBox()
    {
        _hitbox = new Rectangle((int)_transform.Position.X, (int)_transform.Position.Y, _spriteRenderer.Texture.Width, _spriteRenderer.Texture.Height);
    }

    public void Update(GameTime gameTime)
    {
        _transform.Translate(new Vector2(1f,1f));
    }
}