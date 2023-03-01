using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content ; 
using System.Collections.Generic ;
using PrototypeRPG2D.Entities ;

namespace PrototypeRPG2D.Entities {
    public class Entity : IEntity {


        public Vector2 position {get; set;}
        public Direction direction {get; set;}

        public Rectangle collision {get; set; }
        public double speed {get; set;}

        public  int radius {get; set;}
        public int life {get; set;}
        public bool isdead {get; set;}

        public bool isMoving {get; set; }

        public SpriteAnimation anim {get; set;}
        public SpriteAnimation[] animations {get; set;}


        public Dictionary<TextureTypes, Texture2D> Textures {get;}


        public Entity(Dictionary<TextureTypes, Texture2D> textures) {
            isMoving = false ; 
            position = new Vector2(0,0) ;
            Textures = textures ;
            animations = new SpriteAnimation[4];
            direction = Direction.Up ;
            speed = 100 ;
            life = 100 ;
            radius = 100;

            collision = new Rectangle((int)position.X, (int)position.Y, 10*radius, 10*radius) ;

        }


        public virtual void SetPos(Vector2 dest) {
            position = dest ; 
        }

        public virtual void SetDirection(Direction nouvelleDestination) {
            direction = nouvelleDestination ; 
        }

        public virtual void LoadContent(ContentManager content) {
            
        }
        public virtual void Kill() {

            isdead = true ; 
        }

        public virtual void Spawn() {            
            isdead = false ;
        }


        public virtual void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(Textures[TextureTypes.OnSite], position, Color.White);


        }

        public virtual void Use() {

        }

        public virtual void Update(GameTime gameTime) {
        
        }
    }
}

