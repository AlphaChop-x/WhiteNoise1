using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System.Reflection.Metadata;
using WhiteNoise;
using WhiteNoise1;

namespace WhiteNoise;

public class Game1 : Game
{
    private readonly GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private GameManager _gameManager;
    SpriteFont textBlock;
    Texture2D fon;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }
   
    protected override void Initialize()
    {
        Globals.Bounds = new(1600, 900);
        _graphics.PreferredBackBufferWidth = Globals.Bounds.X;
        _graphics.PreferredBackBufferHeight = Globals.Bounds.Y;
        _graphics.ApplyChanges();

        Globals.Content = Content;
        _gameManager = new();

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        Globals.SpriteBatch = _spriteBatch;
        textBlock = Content.Load<SpriteFont>("File");
        fon = Content.Load<Texture2D>("fon");
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        Globals.Update(gameTime);
        _gameManager.Update();

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {


        _spriteBatch.Begin();
        _spriteBatch.Draw(fon, Vector2.Zero, Color.White);
        GraphicsDevice.Clear(Color.Blue);
        _gameManager.Draw();
   
        _spriteBatch.End();
        

        base.Draw(gameTime);
    }
}
