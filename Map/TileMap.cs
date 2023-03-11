using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;


namespace PrototypeRPG2D.Maps {
    public class TileMap {
        private readonly Texture2D texture ;
        private readonly Point position ;

        public readonly static int sideSize = 100 ; // 100x100



        public TileMap(Texture2D texture, Point position ) {
            this.texture = texture ;
            this.position = position ;

        }


        public static int GetNumberOfTile( MapSize ms ) => (((int)ms.MaxPoint.X-(int)ms.MinPoint.X)*((int)ms.MaxPoint.Y)-(int)ms.MinPoint.Y)/sideSize ;
        



        public void Draw(SpriteBatch spriteBatch, GraphicsDevice device) {

        }
        public void Update(GameTime gameTime) {

        }
        
    }
}