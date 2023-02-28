using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content ; 
using System.Collections.Generic ;

namespace PrototypeRPG2D.Entities {
    public class Entity : IEntity {


        public Vector2 position {get; set;}
        public Direction direction {get; set;}
        public double speed {get; set;}

        public  int radius {get; set;}
        public int life {get; set;}
        public bool isdead {get; set;}

        public bool isMoving {get; set; }

        public SpriteAnimation anim {get; set;}
        public SpriteAnimation[] animations {get; set;}


        public Dictionary<TextureTypes, Texture2D> Textures {get;}


        public Entity() {
            isMoving = false ; 
            position = new Vector2(0,0) ;


            Textures = new Dictionary<TextureTypes, Texture2D>() ;
            animations = new SpriteAnimation[4];



            direction = Direction.Up ;
            speed = 100 ;
            life = 100 ;
            radius = 100;

        }



        public virtual void SetPos(Vector2 dest) {
            position = dest ; 
        }

        public virtual void SetDirection(Direction nouvelleDestination) {
            direction = nouvelleDestination ; 
        }

        public virtual void LoadContent(ContentManager content) {

            Textures[TextureTypes.OnSite] = content.Load<Texture2D>("Player/player") ;
            Textures[TextureTypes.WalkDown] = content.Load<Texture2D>("Player/walkDown") ; 
            Textures[TextureTypes.WalkUP] = content.Load<Texture2D>("Player/walkUp") ;
            Textures[TextureTypes.WalkRight] = content.Load<Texture2D>("Player/walkRight") ; 
            Textures[TextureTypes.WalkLeft] = content.Load<Texture2D>("Player/walkLeft") ;


            this.animations[(int)Direction.Down] = new SpriteAnimation(Textures[TextureTypes.WalkDown], 4, 8);
            this.animations[(int)Direction.Up] = new SpriteAnimation(Textures[TextureTypes.WalkUP], 4, 8);
            this.animations[(int)Direction.Left] = new SpriteAnimation(Textures[TextureTypes.WalkLeft], 4, 8);
            this.animations[(int)Direction.Right] = new SpriteAnimation(Textures[TextureTypes.WalkRight], 4, 8);
        }
        public virtual void Kill() {

            isdead = true ; 
        }

        public virtual void Spawn() {
            isdead = false ;
        }


        public virtual void Draw(SpriteBatch spriteBatch) {
            this.anim.Draw(spriteBatch);
        }

        public virtual void Update(GameTime gameTime) {
            
        }
    }
}

