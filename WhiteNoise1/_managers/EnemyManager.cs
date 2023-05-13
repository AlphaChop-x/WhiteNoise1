using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhiteNoise;

namespace WhiteNoise1;

public static class EnemyManager
{
    public static List<Enemy> Enemyes { get; } = new();
    public static List<Enemy2> Enemyes2 { get; } = new();

    private static Texture2D _texture;
    private static Texture2D _texture2;
    public static float _spawnCooldown;
    public static float _spawnCooldown2;
    public static float _spawnTime;
    private static Random _random;
    private static int _padding;

    public static void Init()
    {
        _texture = Globals.Content.Load<Texture2D>("obychny");
        _texture2 = Globals.Content.Load<Texture2D>("zhir");
        _spawnCooldown = 0.3f;
        _spawnCooldown2 = 1.5f;
        _spawnTime = _spawnCooldown;
        _random = new();
        _padding = _texture.Width / 2;
    }

    private static System.Numerics.Vector2 RandomPositions()
    {
        float w = Globals.Bounds.X;
        float h = Globals.Bounds.Y;

        System.Numerics.Vector2 pos = new();

        if (_random.NextDouble() < w / (w + h))
        {
            pos.X = (int)(_random.NextDouble() * w);
            pos.Y = (int)(_random.NextDouble() < 0.5 ? -_padding : h + _padding);
        }
        else
        {
            pos.Y = (int)(_random.NextDouble() * h);
            pos.X = (int)(_random.NextDouble() < 0.5 ? -_padding : w + _padding);
        }
        return pos;
    }
    
    public static void AddEnemy()
    {
        Enemyes.Add(new(_texture, RandomPositions()));              
    }
    public static void AddEnemy2()
    {
        Enemyes2.Add(new(_texture2, RandomPositions()));
    }

    public static void Update(Player player)
    {
        _spawnTime -= Globals.TotalSeconds;
        if (_spawnTime <= 0)
        {
            _spawnTime += _spawnCooldown;
            AddEnemy();
            _spawnTime += _spawnCooldown2;
            AddEnemy2();
        }

        foreach (var e in Enemyes)
        {
            e.Update(player);
        }

        foreach (var e in Enemyes2)
        {
            e.Update(player);
        }
        Enemyes.RemoveAll((e) => e.HP <= 0);
        Enemyes2.RemoveAll((e) => e.HP <= 0);
    }

    public static void Draw()
    {
        foreach (var e in Enemyes)
        {
            e.Draw();
        }
        foreach (var e in Enemyes2)
        {
            e.Draw();
        }
    }

}