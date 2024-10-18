using System;
using System.Transactions;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using WonoMane.WonoEngine.Components;
using WonoMane.WonoEngine.Core.Behaviours.BehaviourHandlers;
using WonoMane.WonoEngine.Core.Data;
using WonoMane.WonoEngine.Debug;

namespace WonoMane.WonoEngine.Core.Components;

public class BoxCollider2D : WonoComponent, IComponentUpdater, IComponentDrawer
{
    #region Fields

    private Rectangle _hitBox = Rectangle.Empty;
    private Transform _transform;
    private SpriteRenderer _spriteRenderer;
    private CollisionLogic _collision;
    private Collision _colliderInfo;

    public delegate void OnCollisionHandler(Collision pCollision);
    public event OnCollisionHandler OnCollisionEnter;
    public event OnCollisionHandler OnCollisionExit;
    public event OnCollisionHandler OnCollisionStay;
    #endregion
    
    #region Properties

    public Rectangle Hitbox {get => _hitBox; set => _hitBox = value; }
    
    #endregion

    public override void LoadComponent()
    {
        _transform = GetComponent<Transform>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _collision = GetComponent<CollisionLogic>();
        _transform.OnPositionChanged += SetHitBox;
        OnCollisionEnter += OnCollisionEnter2D;
        OnCollisionStay += OnCollisionStay2D;
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
        //Loops through every found BoxCollider2D in the scene
        foreach (var other in _collision.Colliders.Values)
        {
            //Continue through if it's checking its own instance.
            if (ReferenceEquals(owner, other.owner)) continue;
            //Check if the owner's BoxCollider2D is colliding with any other
            var areObjectsColliding = _collision.AreObjectsColliding(owner, other.owner);
            //On first collision
            if (!_collision.IsColliding&& areObjectsColliding)
            {
                _collision.IsColliding = true;
                _colliderInfo = new Collision(other.Hitbox, other.owner, other.owner.Transform);
                OnCollisionEnter?.Invoke(_colliderInfo);
            }
            //On each collision except first one
            else if (_collision.IsColliding && areObjectsColliding)
            {
                OnCollisionStay?.Invoke(_colliderInfo);
            }
            //After last collision
            else if (_collision.IsColliding && !areObjectsColliding)
            {
                _collision.IsColliding = false;
                OnCollisionExit?.Invoke(_colliderInfo);
            }
        }
    }
    public override void OnCollisionEnter2D(Collision pCollision)
    {
        _spriteRenderer.Color = Color.Red;
        Console.WriteLine($"{owner.Name} started interacting with {pCollision.GameObject.Name}");
    }
    public override void OnCollisionStay2D(Collision pCollision)
    {
        _spriteRenderer.Color = Color.Blue;
        Console.WriteLine($"{owner.Name} is interacting with {pCollision.GameObject.Name}");
    }
    public override void OnCollisionExit2D(Collision pCollision)
    { 
        _spriteRenderer.Color = Color.White;
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