using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhiteNoise;

public class Sprite
{
    protected readonly Texture2D texture;
    protected readonly Vector2 origin;
    public Vector2 Position { get; set; }
    public int Speed { get; set; }
    public int Speed2 { get; set; }
    public float Rotation { get; set; }

    public Sprite(Texture2D tex, Vector2 pos)
    {
        texture = tex;
        Position = pos;
        Speed = 300;
        origin = new(tex.Width / 2, tex.Height / 2);
    }

    public virtual void Draw()
    {
        Globals.SpriteBatch.Draw(texture, Position, null, Color.White, Rotation, origin, 1, SpriteEffects.None, 1);
    }
}

