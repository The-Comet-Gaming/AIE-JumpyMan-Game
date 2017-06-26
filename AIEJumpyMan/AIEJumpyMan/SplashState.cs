using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;


namespace AIEJumpyMan
{
    class SplashState : AIE.State
    {
        SpriteFont font = null;
        float timer = 3;

        public SplashState() : base()
        {

        }

        public override void Update(ContentManager content, GameTime gameTime)
        {
            if (font == null)
            {
                font = content.Load<SpriteFont>("Agency_FB");
            }

            timer -= (float)gameTime.ElapsedGameTime.TotalSeconds;

            

            if (timer <= 0 && "LOADING1" == AIE.StateManager.StateStackCurrent)
            {
                AIE.StateManager.ChangeState("GAME");
                timer = 3;
            }

            if (timer <= 0 && "LOADING2" == AIE.StateManager.StateStackCurrent)
            {
                AIE.StateManager.ChangeState("LEVEL2");
                timer = 3;
            }

            else if (timer <= 0)
            {
                AIE.StateManager.ChangeState("MAINMENU");
                timer = 3;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.DrawString(font, "Loading...", new Vector2(20, 20), Color.White);
            spriteBatch.End();
        }

        public override void CleanUp()
        {
            font = null;
            timer = 6;
        }
    }
}
