using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;


namespace PrototypeRPG2D.Maps {
    public class TileMap {
        private Texture2D texture  ;

        public readonly static int sideSize = 100 ; // 100x100






        public TileMap(Texture2D texture ) {
            this.texture = texture ;

        }

        public Texture2D Texture {
            get {
                return texture ; 
            }
        }


        public static int GetNumberOfTile( MapSize ms ) => (int)((ms.MaxPoint.X - ms.MinPoint.X) * (ms.MaxPoint.Y - ms.MinPoint.Y) / (sideSize*sideSize)) ; 





        public void Draw(SpriteBatch spriteBatch, GraphicsDevice device) {

        }
        public void Update(GameTime gameTime) {

        }
        
    }
}