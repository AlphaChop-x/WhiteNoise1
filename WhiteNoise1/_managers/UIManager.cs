using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;
using WhiteNoise;
using Color = Microsoft.Xna.Framework.Color;

namespace WhiteNoise1;

public class UIManager : Game1
{
    public static int Score;
    public static Vector2 Position;
    public static SpriteFont textBlock;
    private SpriteBatch _spriteBatch;

    public static void Update()
    {

    }
    public static void Draw()
    {
        Vector2 position = new Microsoft.Xna.Framework.Vector2(100, 50);
        Microsoft.Xna.Framework.Color color = new Microsoft.Xna.Framework.Color(255, 255, 0);
        var textBlock = Globals.Content.Load<SpriteFont>("File");
        Globals.SpriteBatch.DrawString(textBlock, "Score: " + Score, position, color);
    }

}

