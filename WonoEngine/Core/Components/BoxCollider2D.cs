using System;
using System.Net;
using Microsoft.Xna.Framework;
using WonoMane.WonoEngine.Core;
using WonoMane.WonoEngine.Core.Behaviours.BehaviourHandlers;
using WonoMane.WonoEngine.Core.Data;

namespace WonoMane.WonoEngine.Components;

public class BoxCollider2D : WonoBehaviour, IComponentUpdater
{
    #region Fields

    private Rectangle _hitbox = Rectangle.Empty;
    private Transform _transform;
    private SpriteRenderer _spriteRenderer;
    private CollisionLogic _collision;
    
    #endregion
    
    #region Properties

    public Rectangle Hitbox {get => _hitbox; set => _hitbox = value; }
    
    #endregion

    public override void LoadContent()
    {
        _transform = GetComponent<Transform>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _collision = GetComponent<CollisionLogic>();
        _transform.OnPositionChanged += SetHitBox;
        SetHitBox();
    }
    private void SetHitBox()
    {
        _hitbox = new Rectangle((int)_transform.Position.X, (int)_transform.Position.Y, _spriteRenderer.Texture.Width, _spriteRenderer.Texture.Height);
    }
    public void Update(GameTime gameTime)
    {
        foreach (var colliderKey in _collision.Colliders.Keys)
        {
            BoxCollider2D other = _collision.Colliders[colliderKey];
            if (_collision.AreObjectsColliding(owner, other.owner))
            {
                if (ReferenceEquals(owner, other.owner)) continue;
                owner.GetComponent<BoxCollider2D>().OnCollisionEnter2D(new Collision(other.Hitbox, other.owner, other.GetComponent<Transform>()));
            }
        }
    }
    public override void OnCollisionEnter2D(Collision pCollision)
    {
        Console.WriteLine($"{owner.Name} is interacting with {pCollision.GameObject.Name}");
    }
}