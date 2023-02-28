using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using PrototypeRPG2D.Entities ; 


namespace PROTO_RPG_2D;

public class Game1 : Game
{
    private Player player ; 
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;


    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;

        player = new Player() ; 
    }

    protected override void Initialize()
    {

        // La taille de la fenêtre 
        _graphics.PreferredBackBufferWidth = 1280 ;
        _graphics.PreferredBackBufferHeight = 720 ; 
        _graphics.ApplyChanges() ; 

        
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        player.LoadContent(this.Content) ;

        base.LoadContent() ;

        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

            player.Update(gameTime) ; 

        // TODO: Add your update logic here

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Black);

        _spriteBatch.Begin() ;

        player.Draw(_spriteBatch) ; 
        _spriteBatch.End() ; 

        // TODO: Add your drawing code here

        base.Draw(gameTime);
    }
}
