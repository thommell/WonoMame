using System;
using System.Net;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using WonoMane.WonoEngine.Core;
using WonoMane.WonoEngine.Core.Behaviours.BehaviourHandlers;
using WonoMane.WonoEngine.Core.Data;
using WonoMane.WonoEngine.Debug;

namespace WonoMane.WonoEngine.Components;

public class BoxCollider2D : WonoBehaviour, IComponentUpdater, IComponentDrawer
{
    #region Fields

    private Rectangle _hitBox = Rectangle.Empty;
    private Transform _transform;
    private SpriteRenderer _spriteRenderer;
    private CollisionLogic _collision;
    private bool _isColliding;
    private Collision _colliderInfo;

    public delegate void OnCollisionHandler(Collision pCollision);
    public event OnCollisionHandler OnCollisionEnter;
    public event OnCollisionHandler OnCollisionExit;
    #endregion
    
    #region Properties

    public Rectangle Hitbox {get => _hitBox; set => _hitBox = value; }
    public bool IsColliding { get => _isColliding; }
    
    #endregion

    public override void LoadContent()
    {
        _transform = GetComponent<Transform>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _collision = GetComponent<CollisionLogic>();
        _transform.OnPositionChanged += SetHitBox;
        OnCollisionEnter += OnCollisionEnter2D;
        OnCollisionExit += OnCollisionExit2D;
        OnCollisionExit += DumpCollisionInfo;
        SetHitBox();
    }
    private void SetHitBox()
    {
        _hitBox = new Rectangle((int)_transform.Position.X, (int)_transform.Position.Y, _spriteRenderer.Texture.Width, _spriteRenderer.Texture.Height);
    }
    public void Update(GameTime gameTime)
    {
        CheckCollision();
    }
    public void Draw(SpriteBatch pSpriteBatch)
    {
        pSpriteBatch.DrawRectangle(Hitbox, Color.Yellow);
    }
    private void CheckCollision()
    {
        foreach (var colliderKey in _collision.Colliders.Keys)
        {
            BoxCollider2D other = _collision.Colliders[colliderKey];
            if (ReferenceEquals(owner, other.owner)) continue;
            if (_collision.AreObjectsColliding(owner, other.owner))
            {
                _isColliding = true;
                _colliderInfo = new Collision(other.Hitbox, other.owner, other.owner.Transform);
                OnCollisionEnter?.Invoke(_colliderInfo);
            }
            else if (_isColliding && !_collision.AreObjectsColliding(owner, other.owner))
            {
                _isColliding = false;
                OnCollisionExit?.Invoke(_colliderInfo);
            }
        }
    }
    public override void OnCollisionEnter2D(Collision pCollision)
    {
        Console.WriteLine($"{owner.Name} is interacting with {pCollision.GameObject.Name}");
    }
    public override void OnCollisionExit2D(Collision pCollision)
    { 
        Console.WriteLine($"{owner.Name} has stopped interacting with {pCollision.GameObject.Name}!");
    }
    /// <summary>
    /// Dumps the current <see cref="Collision"/> data.
    /// </summary>
    private void DumpCollisionInfo(Collision pCollision)
    {
        _colliderInfo = default;
    }
}