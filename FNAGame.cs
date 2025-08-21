using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GamePlayground;

public sealed class FNAGame : Game
{

    private KeyboardState _previousKeyboardState = new();
    private MouseState _previousMouseState = new();
    private GamePadState _previousGamePadState = new();

    private SpriteBatch? _spriteBatch;
    private Texture2D? _texture;

    public FNAGame()
    {
        new GraphicsDeviceManager(this)
        {
            PreferredBackBufferWidth = 800,
            PreferredBackBufferHeight = 600
        };

        Content.RootDirectory = "Content";
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch?.Begin();
        if (_texture != null)
        {
            _spriteBatch?.Draw(_texture, Vector2.Zero, Color.White);
        }
        _spriteBatch?.End();

        base.Draw(gameTime);
    }

    protected override void Initialize()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _texture = Content.Load<Texture2D>("FNATexture.jpg");

        base.LoadContent();
    }

    protected override void UnloadContent()
    {
        _spriteBatch?.Dispose();
        _texture?.Dispose();

        base.UnloadContent();
    }

    protected override void Update(GameTime gameTime)
    {
        //Poll input
        var currentKeyboardState = Keyboard.GetState();
        var currentMouseState = Mouse.GetState();
        var currentGamePadState = GamePad.GetState(PlayerIndex.One);

        // Check for presses
        if (currentKeyboardState.IsKeyDown(Keys.Space) && _previousKeyboardState.IsKeyUp(Keys.Space))
        {
            System.Console.WriteLine("Space key pressed");
        }
        if (currentMouseState.RightButton == ButtonState.Released && _previousMouseState.RightButton == ButtonState.Pressed)
        {
            System.Console.WriteLine("Right mouse button released");
        }
        if (currentGamePadState.Buttons.A == ButtonState.Released && _previousGamePadState.Buttons.A == ButtonState.Pressed)
        {
            System.Console.WriteLine("GamePad A button released");
        }

        _previousKeyboardState = currentKeyboardState;
        _previousMouseState = currentMouseState;
        _previousGamePadState = currentGamePadState;

        base.Update(gameTime);
    }
}
