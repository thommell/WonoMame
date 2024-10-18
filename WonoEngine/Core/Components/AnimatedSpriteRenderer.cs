using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using WonoMane.WonoEngine.Core;
using WonoMane.WonoEngine.Core.Behaviours.BehaviourHandlers;
using WonoMane.WonoEngine.Core.Components;

public class AnimatedSpriteRenderer : Renderer, IComponentUpdater, IComponentDrawer
{

    private Vector2 _origin;
    
    private Rectangle[] _sourceRectangles;
    private Rectangle _currentSourceRectangle;
    private int _currentSpriteIndex;
    private float _widthOfSprite;
    private float _heightOfSprite;
    private readonly float _timeForCompletion;

    private readonly int _rows;
    private readonly int _columns;
    private float _elapsedTime;

    public AnimatedSpriteRenderer(string pTextureName, float pWidthOfSprite, float pHeightOfSprite, float pTime, int pNumberOfRows, int pNumberOfColumns) : base(pTextureName)
    {
        _widthOfSprite = pWidthOfSprite;
        _heightOfSprite = pHeightOfSprite;
        _timeForCompletion = pTime;
        _rows = pNumberOfRows;
        _columns = pNumberOfColumns;
        _sourceRectangles = new Rectangle[_rows * _columns];
    }
    protected override void LoadRenderer()
    {
        int currentColumn = 0;
        int currentRow = 0;
        for (int i = 0; i < _rows * _columns; i++)
        {
            _sourceRectangles[i] = new Rectangle(
                currentRow * (int)_widthOfSprite,
                currentColumn * (int)_heightOfSprite,
                (int)_widthOfSprite,
                (int)_heightOfSprite
            );
            currentRow += 1;
            if (currentRow != _rows) continue;
            currentColumn += 1;
            currentRow = 0;
        }
        _origin = GetOrigin(_widthOfSprite, _heightOfSprite);
    }
    public void Update(GameTime pGameTime) => PlayAnimation(pGameTime);
    private void PlayAnimation(GameTime pGameTime)
    {
        for (int i = 0; i < _sourceRectangles.Length; i++)
        {
            _elapsedTime += 0 +(float)pGameTime.ElapsedGameTime.TotalSeconds;      
            if (_elapsedTime >= _timeForCompletion)
            {
                _elapsedTime = 0f;
                _currentSpriteIndex += 1;
                if (_currentSpriteIndex >= _sourceRectangles.Length)
                    _currentSpriteIndex = 0;
            }
            _currentSourceRectangle = _sourceRectangles[_currentSpriteIndex]; 
        }
    }
    public void Draw(SpriteBatch pSpriteBatch) => pSpriteBatch.Draw(texture, transform.Position, _currentSourceRectangle, Color.White, MathHelper.ToRadians(transform.Rotation), _origin, Vector2.One, SpriteEffects.None, 0f);
    public Vector2 GetOrigin(float pX, float pY)
    {
        return new Vector2(pX * 0.5f, pY * 0.5f); // not the same as SpriteRenderer but wasn't possible how I designed my structure :(
    }

}
