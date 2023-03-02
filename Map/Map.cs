using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content ; 

using Comora ;

using System.Collections.Generic ;
using PrototypeRPG2D.Entities ;
using PrototypeRPG2D.Maps ;


namespace PrototypeRPG2D.Maps {
    public class Map : IMap {
        public string name {get;set;}
        public List<IObject> Entities {get; set;}
        public Texture2D background {get; set;}
        public Vector2 spawnPoint {get; set;}
        public Player player {get; set;}

        public MapSize mapSize {get; set;}

        public Camera camera {get; set;}


         public Map(string name, Texture2D background, Dictionary<TextureTypes, Texture2D> skin, MapSize mapSize, GraphicsDevice graphics) {
            this.name = name ;
            this.Entities = new() ; 
            this.background = background ;
            this.mapSize = mapSize ;

            this.player = new Player(skin) ;
            this.camera = new Camera(graphics) ; 
         }

         public void LoadContent(ContentManager content) {

            player.LoadContent(content) ;

            foreach ( IObject obj in Entities) {
                obj.LoadContent(content) ; 
            }
            /*
            Dictionary<TextureTypes, Texture2D> textureEntite = new() {
                [TextureTypes.OnSite] = content.Load<Texture2D>("ball") 
            } ;

            */ 
         }



         /*
          On dessine et met a jour toutes les entitités 
         */

         public void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Begin(this.camera) ;
            foreach ( IObject obj in Entities ) {
                obj.Draw(spriteBatch) ; 
            }
           player.Draw(spriteBatch) ;
           spriteBatch.End() ;  
         }

         public void Update(GameTime gameTime) {
            foreach (IObject obj in Entities) {
                obj.Update(gameTime) ; 
            }
            player.Update(gameTime) ; 
            this.camera.Position = player.position ;
            this.camera.Update(gameTime) ;

         }


         // Pour récupérer toutes les entités du monde 
        public List<IObject> GetEntities()
        {
            return Entities ; 
        }
    }
}