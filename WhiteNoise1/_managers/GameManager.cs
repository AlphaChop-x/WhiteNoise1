using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhiteNoise1;

namespace WhiteNoise;

public class GameManager
{
    private readonly Player _player;
    public GameManager()
    {
        ProjectileManager.Init();
        _player = new(Globals.Content.Load<Texture2D>("character"), new(Globals.Bounds.X / 2, Globals.Bounds.Y ));
        EnemyManager.Init();
        EnemyManager.AddEnemy();     
    }

    public void Update()
    {
        InputManager.Update();
        _player.Update();
        EnemyManager.Update(_player);
        ProjectileManager.Update(EnemyManager.Enemyes);
        ProjectileManager.Update(EnemyManager.Enemyes2);
    }

    public void Draw()
    {
        ProjectileManager.Draw();
        _player.Draw();
        EnemyManager.Draw();
        UIManager.Draw();
    }
}
