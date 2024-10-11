using System.Reflection.Metadata;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using WonoMane.Core.Behaviours;
using WonoMane.WonoEngine.Core;
using WonoMane.WonoEngine.Core.Behaviours;

namespace WonoMane;

public class Game1 : Game
{
    private GameObject _object;
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }
    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        Utility.GameInstance = this;
        Utility.FontInstance = Content.Load<SpriteFont>("Font");
        _object = new GameObject("Enemy", new Transform(new Vector2(400, 200)), new SpriteRenderer("Enemy"));
        _object.LoadContent();
    }
    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();
        _object.Update(gameTime);
        base.Update(gameTime);
    }
    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        _spriteBatch.Begin();
        _object.Draw(_spriteBatch);
        _spriteBatch.End();
        base.Draw(gameTime);
    }
}