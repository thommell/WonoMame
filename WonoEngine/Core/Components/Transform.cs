using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WonoMane.WonoEngine.Core.Components;

public class Transform : WonoComponent
{
    private Vector2 _position;
    private Vector2 _origin;
    private float _rotation;
    public Vector2 Position => _position;
    public float Rotation => _rotation;
    public delegate void OnPositionChange();
    public event OnPositionChange OnPositionChanged;
    public Vector2 Origin
    {
        get => _origin;
        set => _origin = value;
    }
    public Transform(Vector2 pPosition)
    {
        _position = pPosition;
    }
    public void Translate(Vector2 pPosition)
    {
        _position += pPosition;
        OnPositionChanged?.Invoke();
    }
    public void SetPosition(Vector2 pPosition)
    {
        _position = pPosition;
        OnPositionChanged?.Invoke();
    }
    public Vector2 GetOrigin(Texture2D pTexture) => new (pTexture.Width * 0.5f, pTexture.Height * 0.5f);
}