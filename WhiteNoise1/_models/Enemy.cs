using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using WhiteNoise;

namespace WhiteNoise1;

public class Enemy : Sprite
{
    public int HP { get; private set; }
    public Enemy(Texture2D tex, Vector2 pos) : base(tex, pos)
    {
        Speed = 250;
        HP = 10;     
    }
    public void TakingDamage(int dmg)
    {
        HP -= dmg;
    }

    public void Update(Player player)
    {
        var toPlayer = player.Position - Position;
        Rotation = (float)Math.Atan2(toPlayer.Y, toPlayer.X);

        if (toPlayer.Length() > 4)
        {
            var dir = Microsoft.Xna.Framework.Vector2.Normalize(toPlayer);
            Position += dir * Speed * Globals.TotalSeconds;
        }
    }
}

public class Enemy2 : Sprite
{
    public int HP { get; private set; }
    public Enemy2(Texture2D tex, Vector2 pos) : base(tex, pos)
    {
        Speed = 100;
        HP = 250;
    }
    public void TakingDamage(int dmg)
    {
        HP -= dmg;
    }

    public void Update(Player player)
    {
        var toPlayer = player.Position - Position;
        Rotation = (float)Math.Atan2(toPlayer.Y, toPlayer.X);

        if (toPlayer.Length() > 4)
        {
            var dir = Microsoft.Xna.Framework.Vector2.Normalize(toPlayer);
            Position += dir * Speed * Globals.TotalSeconds;
        }
    }

}

