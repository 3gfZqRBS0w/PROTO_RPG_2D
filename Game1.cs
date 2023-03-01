using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using PrototypeRPG2D.Entities ;
using PrototypeRPG2D.Map ; 
using Comora ;
using System.Collections.Generic;
using System ;


namespace PROTO_RPG_2D;

public class Game1 : Game
{

    private Random rnd = new Random();


    private Map map ; 
    private Player player ;
    private List<Entity> entities ; 
    private GraphicsDeviceManager _graphics;

    private Camera camera ; 
    private SpriteBatch _spriteBatch;


    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        entities = new() ;



    }



    public bool CheckCollideWithEntities() {
        foreach ( Entity ent in entities ) {
            if ( player.collision.Intersects(ent.collision) ) {
                return true ; 
            }
        }
        return false ; 
    }



    protected override void Initialize()
    {

        // La taille de la fenêtre 
        _graphics.PreferredBackBufferWidth = 1280 ;
        _graphics.PreferredBackBufferHeight = 720 ; 
        _graphics.ApplyChanges() ;

        this.camera = new Camera(GraphicsDevice) ;

        
        base.Initialize();
    }

    protected override void LoadContent()
    {

        Dictionary<TextureTypes, Texture2D> textureEntite = new() {
            [TextureTypes.OnSite] = Content.Load<Texture2D>("ball") 
        } ; 

        Dictionary<TextureTypes, Texture2D> texturePlayer = new()
        {
            [TextureTypes.OnSite] = Content.Load<Texture2D>("Player/player"),
            [TextureTypes.WalkDown] = Content.Load<Texture2D>("Player/walkDown"),
            [TextureTypes.WalkUP] = Content.Load<Texture2D>("Player/walkUp"),
            [TextureTypes.WalkRight] = Content.Load<Texture2D>("Player/walkRight"),
            [TextureTypes.WalkLeft] = Content.Load<Texture2D>("Player/walkLeft")
        };

        player = new Player(texturePlayer) ;

        


        for (int i=0 ; i < 10 ; ++i) {
            entities.Add(new Entity(textureEntite) {
                position = new Vector2(rnd.Next(-500,500), rnd.Next(-500,500))
            })  ;
        }


        _spriteBatch = new SpriteBatch(GraphicsDevice);

        player.LoadContent(this.Content) ; 

       base.LoadContent() ;

        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();


            this.camera.Position = player.position ;
            this.camera.Update(gameTime) ;
            player.Update(gameTime) ;
      

            foreach ( Entity ent in entities ) {
                ent.Update(gameTime) ; 
            }
        // TODO: Add your update logic here

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Black);

        _spriteBatch.Begin(this.camera) ;

        player.Draw(_spriteBatch) ;

        foreach ( Entity ent in entities ) {
            ent.Draw(_spriteBatch) ; 
        }


        _spriteBatch.End() ; 

        // TODO: Add your drawing code here

        base.Draw(gameTime);
    }
}
