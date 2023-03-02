using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input ; 
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content ; 
using System.Collections.Generic ;
using System;
using System.Linq ;
using PROTO_RPG_2D;

namespace PrototypeRPG2D.Entities {
    public class Player : Entity {


        private KeyboardState keyboardStateOld = Keyboard.GetState();
        public Player( Dictionary<TextureTypes, Texture2D> textures) : base(textures) {
            
        }

        public override void LoadContent(ContentManager content)
        {


            this.animations[(int)Direction.Down] = new SpriteAnimation(Textures[TextureTypes.WalkDown], 4, 8);
            this.animations[(int)Direction.Up] = new SpriteAnimation(Textures[TextureTypes.WalkUP], 4, 8);
            this.animations[(int)Direction.Left] = new SpriteAnimation(Textures[TextureTypes.WalkLeft], 4, 8);
            this.animations[(int)Direction.Right] = new SpriteAnimation(Textures[TextureTypes.WalkRight], 4, 8);
            base.LoadContent(content);
        }

        public override void Update(GameTime gameTime) {
            KeyboardState keyboardState = Keyboard.GetState();
            double realSpeed = speed * gameTime.ElapsedGameTime.TotalSeconds;
            isMoving = false;
            if (keyboardState.IsKeyDown(Keys.Right))
            {
                direction = Direction.Right;
                isMoving = true;
            }
            if (keyboardState.IsKeyDown(Keys.Left))
            {
                direction = Direction.Left;
                isMoving = true;
            }
            if (keyboardState.IsKeyDown(Keys.Up))
            {
                direction = Direction.Up;
                isMoving = true;
            }
            if (keyboardState.IsKeyDown(Keys.Down))
            {
                direction = Direction.Down;
                isMoving = true;
            }

            if (keyboardState.IsKeyDown(Keys.Space))
            {
                isMoving = false;
            }

            if (isdead)
            {
                isMoving = false;
            }
            
            if (isMoving) 
            {
                switch (direction)
                {
                    case Direction.Down:
                            position =  new Vector2(position.X, position.Y + (float)realSpeed) ;
                        break;
                    case Direction.Up:
                            position = new Vector2(position.X, position.Y - (float)realSpeed ) ; 
                        break;
                    case Direction.Left:
                            position = new Vector2(position.X - (float)realSpeed, position.Y ) ; 
                    
                        break;
                    case Direction.Right:
                            position = new Vector2(position.X + (float)realSpeed, position.Y) ;
                       
                        break;
                    default:
                        break;
                }
            }


        
            anim = animations[(int)direction];
        
            anim.Position = new Vector2(position.X - 48, position.Y - 48);

        
            
            if (keyboardState.IsKeyDown(Keys.Space))
            {
                anim.setFrame(0);
            }
            else if (isMoving)
            {
                anim.Update(gameTime);
            }
            else
            {
                anim.setFrame(1);
            }
        


            keyboardStateOld = keyboardState;
        
        }


        public override void Draw(SpriteBatch spriteBatch) {
            this.anim.Draw(spriteBatch);
        }

    }
}