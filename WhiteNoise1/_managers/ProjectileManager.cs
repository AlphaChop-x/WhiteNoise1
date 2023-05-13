using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhiteNoise1;

namespace WhiteNoise;

public static class ProjectileManager
{
    private static Texture2D _texture;
    public static List<Projectile> Projectiles { get; } = new();

    public static void Init()
    {
        _texture = Globals.Content.Load<Texture2D>("bullet");
    }

    public static void AddProjectile(ProjectileData data)
    {
        Projectiles.Add(new(_texture, data));
    }

    public static void Update(List<Enemy> enemyes)
    {
        foreach (var p in Projectiles)
        {
            p.Update();
            foreach (var e in enemyes) 
            {
                if (e.HP <= 0) continue;
                if ((p.Position - e.Position).Length() < 64)
                {
                    e.TakingDamage(50);
                    UIManager.Score += 50;
                    p.Destroy();
                    break;
                }
            }
        }
        Projectiles.RemoveAll((p) => p.Lifespan <= 0);
    }
    public static void Update(List<Enemy2> enemyes2)
    {
        foreach (var p in Projectiles)
        {
            p.Update();
            foreach (var e in enemyes2)
            {
                if (e.HP <= 0) continue;
                if ((p.Position - e.Position).Length() < 64)
                {
                    e.TakingDamage(50);
                    UIManager.Score += 20;
                    p.Destroy();
                    break;
                }
            }
        }
        Projectiles.RemoveAll((p) => p.Lifespan <= 0);
    }
    public static void Draw()
    {
        foreach (var p in Projectiles)
        {
            p.Draw();
        }
    }
}
