using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using PrototypeRPG2D.Entities;
using PrototypeRPG2D.Maps;
using System.Collections.Generic;
using System;


namespace PROTO_RPG_2D;

public class Init : Game
{


    private Map map;
    private GraphicsDeviceManager _graphics;


    private SpriteBatch _spriteBatch;


    public Init()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }


    protected override void Initialize()
    {


        // Skin du joueur 
        Dictionary<TextureTypes, Texture2D> texturePlayer = new()
        {
            [TextureTypes.OnSite] = Content.Load<Texture2D>("Player/player"),
            [TextureTypes.WalkDown] = Content.Load<Texture2D>("Player/walkDown"),
            [TextureTypes.WalkUP] = Content.Load<Texture2D>("Player/walkUp"),
            [TextureTypes.WalkRight] = Content.Load<Texture2D>("Player/walkRight"),
            [TextureTypes.WalkLeft] = Content.Load<Texture2D>("Player/walkLeft")
        };

            map = new Map("first_map", Content.Load<Texture2D>("Map/background"), texturePlayer, new MapSize(new Vector2(-1000, -1000), new Vector2(1000, 1000)), GraphicsDevice);


        // La taille de la fenêtre 
        _graphics.PreferredBackBufferWidth = 1280;
        _graphics.PreferredBackBufferHeight = 720;
        _graphics.ApplyChanges();



        base.Initialize();
    }

    protected override void LoadContent()
    {


        _spriteBatch = new SpriteBatch(GraphicsDevice);



        map.LoadContent(Content);

        base.LoadContent();

        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();


        this.map.Update(gameTime);

        //   player.Update(gameTime) ;


        /*
           foreach ( Entity ent in entities ) {
               ent.Update(gameTime) ; 
           }

           */
        // TODO: Add your update logic here

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Black);


        map.Draw(_spriteBatch, GraphicsDevice);
        //   player.Draw(_spriteBatch) ;


        /*

           foreach ( Entity ent in entities ) {
               ent.Draw(_spriteBatch) ; 
           }

           */

        // TODO: Add your drawing code here

        base.Draw(gameTime);
    }
}
