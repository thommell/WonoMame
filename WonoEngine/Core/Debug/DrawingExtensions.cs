using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WonoMane.WonoEngine.Core.Debug;

internal static class DrawingExtensions {
    /*
     * NOTE: This is for test purposes only, if you ever experience issues related to collision you can use this.
     */
    public static void DrawRectangle(this SpriteBatch spriteBatch, Rectangle rectangle, Color color) {
        var texture = new Texture2D(spriteBatch.GraphicsDevice, 1, 1);
        texture.SetData([color]);
        spriteBatch.Draw(texture, new Rectangle(rectangle.Left, rectangle.Top, rectangle.Width, 1), color);
        spriteBatch.Draw(texture, new Rectangle(rectangle.Left, rectangle.Bottom, rectangle.Width, 1), color);
        spriteBatch.Draw(texture, new Rectangle(rectangle.Left, rectangle.Top, 1, rectangle.Height), color);
        spriteBatch.Draw(texture, new Rectangle(rectangle.Right, rectangle.Top, 1, rectangle.Height + 1), color);
    }
}