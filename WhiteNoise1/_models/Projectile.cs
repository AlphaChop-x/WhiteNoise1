using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhiteNoise;

public class Projectile : Sprite
{
    public Vector2 Direction { get; set; }
    public float Lifespan { get; private set; }

    public Projectile(Texture2D tex, ProjectileData data) : base(tex, data.Position)
    {
        Speed = (int)data.Speed;
        Rotation = data.Rotation;
        Direction = new((float)Math.Cos(Rotation), (float)Math.Sin(Rotation));
        Lifespan = data.Lifespan;
    }

    public void Destroy()
    {
        Lifespan = 0;
    }

    public void Update()
    {
        Position += Direction * Speed * Globals.TotalSeconds;
        Lifespan -= Globals.TotalSeconds;
    }
}
