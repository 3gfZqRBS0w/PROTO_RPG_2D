using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content ; 

using Comora ;

using System ; 
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

        public Vector2 oldPlayerPos ;
        public MapSize mapSize {get; set;}

        public Camera camera {get; set;}

        public bool Debug {get; set; }



         public Map(string name, Texture2D background, Dictionary<TextureTypes, Texture2D> skin, MapSize mapSize, GraphicsDevice graphics) {

            // On met le debug en vrai
            this.Debug = true ; 
            this.name = name ;
            this.Entities = new() ; 
            this.background = background ;
            this.mapSize = mapSize ;

            this.player = new Player(skin) ;
            this.camera = new Camera(graphics) ; 
         }

         public void LoadContent(ContentManager content) {
            
            Random rnd = new Random() ;

            player.LoadContent(content) ;


            Dictionary<TextureTypes, Texture2D> textureEntite = new() {
                [TextureTypes.OnSite] = content.Load<Texture2D>("ball") 
            } ;

                for (int i=0 ; i < 10 ; ++i) {
                    Entities.Add(new Entity(textureEntite, new Vector2(rnd.Next(200,500), rnd.Next(200,500))))  ;
                }
            foreach ( IObject obj in Entities) {
                obj.LoadContent(content) ; 
            }             
         }



         /*
          On dessine et met a jour toutes les entitités 
         */

         public void Draw(SpriteBatch spriteBatch, GraphicsDevice device) {
            
            spriteBatch.Begin(this.camera) ;

          //  if ( this.Debug) {
                Texture2D debug = new Texture2D(device, 1,1) ;
                debug.SetData<Color>(new Color[] {Color.White}) ;
          //  }


            foreach ( IObject obj in Entities ) {
                if (this.Debug) {
                    spriteBatch.Draw(debug, obj.collision, Color.Red) ; 
                }
                obj.Draw(spriteBatch) ;
            }
           player.Draw(spriteBatch) ;
                     if ( this.Debug) {
            spriteBatch.Draw(debug, player.collision,Color.Blue ) ;
           }
 
           spriteBatch.End() ;  
         }

         public void Update(GameTime gameTime) {


            
            foreach (IObject obj in Entities) {
                obj.Update(gameTime) ; 
            }

            player.Update(gameTime) ;

            // Collision check
            if ( mapSize.MaxPoint.X < player.position.X || mapSize.MinPoint.X > player.position.X  || mapSize.MaxPoint.Y < player.position.Y || mapSize.MinPoint.Y > player.position.Y || CheckCollideWithEntities() )    {
                player.position = oldPlayerPos ; 
            } else {
                oldPlayerPos = player.position ;
            }
            /*
            Console.WriteLine($" X {mapSize.MinPoint.X}/{player.position.X}/{mapSize.MaxPoint.X}") ;
            Console.WriteLine($" Y {mapSize.MinPoint.Y}/{player.position.Y}/{mapSize.MaxPoint.Y}") ;
*/
            
             
            this.camera.Position = player.position ;
            this.camera.Update(gameTime) ;

         }




        public bool CheckCollideWithEntities() {
            foreach ( IObject ent in Entities ) {
                if ( player.collision.Intersects(ent.collision) ) {

                    Console.WriteLine($"X : {ent.collision.X} Y : {ent.collision.Y}") ; 
                    return true ; 
                }
            }
            return false ; 
        }


         // Pour récupérer toutes les entités du monde 
        public List<IObject> GetEntities()
        {
            return Entities ; 
        }
    }
}