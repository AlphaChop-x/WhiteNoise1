using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace WhiteNoise;

public class Player : Sprite
{
    public Player(Texture2D tex, Microsoft.Xna.Framework.Vector2 pos) : base(tex, pos)
    {
    }

    private void Fire()
    {
        ProjectileData pd = new()
        {
            Position = Position,
            Rotation = Rotation,
            Lifespan = 2,
            Speed = 600
        };

        ProjectileManager.AddProjectile(pd);
    }

    public void Update()
    {
        if (InputManager.Direction != Microsoft.Xna.Framework.Vector2.Zero)
        {
            var dir = Microsoft.Xna.Framework.Vector2.Normalize(InputManager.Direction);
            Position = new(
                MathHelper.Clamp(Position.X + (dir.X * Speed * Globals.TotalSeconds), 0, Globals.Bounds.X),
                MathHelper.Clamp(Position.Y + (dir.Y * Speed * Globals.TotalSeconds), 0, Globals.Bounds.Y)
            );
        }
        var toMouse = InputManager.MousePosition - Position;
        Rotation = (float)Math.Atan2(toMouse.Y, toMouse.X);
        
        if (InputManager.MouseClicked)
        {
            Fire();
        }
    }
}
