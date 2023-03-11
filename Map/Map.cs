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
        public List<TileMap> tilemaps {get; set;}
        public Vector2 spawnPoint {get; set;}
        public Player player {get; set;}

        public Vector2 oldPlayerPos ;
        public MapSize mapSize {get; set;}

        public Camera camera {get; set;}

        public bool Debug {get; set; }



         public Map(string name, Texture2D background, Dictionary<TextureTypes, Texture2D> skin, MapSize mapSize, GraphicsDevice graphics) {

            // On met le debug en vrai
            this.Debug = false ; 
            this.name = name ;
            this.Entities = new() ; 
            this.mapSize = mapSize ;

            this.player = new Player(skin, 10) ;
            this.camera = new Camera(graphics) ;

            tilemaps = new() ; 
         }

         public void MapInitialization(SpriteBatch spriteBatch) {

            spriteBatch.Begin() ;
            int texturedId = 0 ; 
            for ( int x = (int)mapSize.MinPoint.X ; x < (int)mapSize.MaxPoint.X ; x+=100 ) {
                for ( int y = (int)mapSize.MinPoint.Y ; y < (int)mapSize.MaxPoint.Y ; y+=100 ) {

                    spriteBatch.Draw(tilemaps[texturedId].Texture , new Vector2(x,y), Color.Blue) ;

                    //Console.WriteLine("ce que je veux : "+texturedId) ; 
                    texturedId++ ;
                } 
            }
            spriteBatch.End() ; 
            
         }

         public void LoadContent(ContentManager content) {
            
            Random rnd = new Random() ;

            // Chargement des tuiles de la map 
            for ( int i = 0; i <= TileMap.GetNumberOfTile( mapSize ); i++) {
                tilemaps.Add(new TileMap(content.Load<Texture2D>("ball"))) ; 
            }

            player.LoadContent(content) ;


            Dictionary<TextureTypes, Texture2D> textureEntite = new() {
                [TextureTypes.OnSite] = content.Load<Texture2D>("ball") 
            } ;


                for (int i=0 ; i < 10 ; ++i) {
                    Entities.Add(new Entity(textureEntite, 50,new Vector2(rnd.Next(-500,500), rnd.Next(-500,500))))  ;
                }


            foreach ( IObject obj in Entities) {
                obj.LoadContent(content) ; 
            }             
         }



         /*
          On dessine et met a jour toutes les entitités 
         */

         public void Draw(SpriteBatch spriteBatch, GraphicsDevice device) {


                Texture2D debug = new Texture2D(device, 1,1) ;
                debug.SetData<Color>(new Color[] {Color.DarkSlateGray }) ;

               


            // Chargement des parties de la MAP


            MapInitialization(spriteBatch) ; 




            // Chargement de la caméra

            spriteBatch.Begin(this.camera) ;

                player.Draw(spriteBatch) ;
                     if ( this.Debug) {
                        spriteBatch.Draw(debug, player.collision,Color.Blue ) ;
                    }



        // Chargement des entités 
            foreach ( IObject obj in Entities ) {
                obj.Draw(spriteBatch) ;
                if (this.Debug) {
                    spriteBatch.Draw(debug, obj.collision, Color.White) ; 
                }
            }
           spriteBatch.End() ;  
         }

         public void Update(GameTime gameTime) {


           Console.WriteLine("ce que je dois dessiner "+Maps.TileMap.GetNumberOfTile(mapSize).ToString())  ; 


            // Mise a jour des entités 
            foreach (IObject obj in Entities) {
                obj.Update(gameTime) ; 
            }

            // Mise a jour du joueur
            player.Update(gameTime) ;
            

            // Collision check
            if ( mapSize.MaxPoint.X < player.position.X || mapSize.MinPoint.X > player.position.X  || mapSize.MaxPoint.Y < player.position.Y || mapSize.MinPoint.Y > player.position.Y || CheckCollideWithEntities() )    {
                player.position = oldPlayerPos ; 
            } else {
                oldPlayerPos = player.position ;
            }
             


             // Mise a jour de la caméra de l'utilisateur 
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