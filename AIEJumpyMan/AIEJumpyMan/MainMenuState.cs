using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace AIEJumpyMan
{
    public class MainMenuState : AIE.State
    {
        bool isLoaded = false;
        SpriteFont font = null;
        public int menuSelection = 1;
        KeyboardState oldState;

        public MainMenuState() : base()
        {

        }

        public override void Update(ContentManager content, GameTime gameTime)
        {
            if (isLoaded == false)
            {
                isLoaded = true;
                font = content.Load<SpriteFont>("Agency_FB");
                oldState = Keyboard.GetState();
            }

            KeyboardState newState = Keyboard.GetState();

            if ("MAINMENU" == AIE.StateManager.StateStackCurrent)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Enter) == true && menuSelection == 1)
                {
                    AIE.StateManager.ChangeState("LEVELSELECT");
                }

                if (Keyboard.GetState().IsKeyDown(Keys.Enter) == true && menuSelection == 2)
                {
                    AIE.StateManager.ChangeState("HOW2PLAYMENU");
                }
            }

            if ("LEVELSELECT" == AIE.StateManager.StateStackCurrent)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Enter) == true && menuSelection == 1)
                {
                    // checking the old state ensures that we only process new key
                    //presses (incase the key was held down from the last state
                    if (oldState.IsKeyDown(Keys.Enter) == false)
                    {
                        AIE.StateManager.ChangeState("LOADING1");
                    }                        
                }

                if (Keyboard.GetState().IsKeyDown(Keys.Enter) == true && menuSelection == 2)
                {
                    // checking the old state ensures that we only process new key
                    //presses (incase the key was held down from the last state
                    if (oldState.IsKeyDown(Keys.Enter) == false)
                    {
                        AIE.StateManager.ChangeState("LOADING2");
                        
                    }
                }
                if (Keyboard.GetState().IsKeyDown(Keys.Back) == true)
                {
                    // checking the old state ensures that we only process new key
                    //presses (incase the key was held down from the last state
                    if (oldState.IsKeyDown(Keys.Back) == false)
                    {
                        AIE.StateManager.ChangeState("MAINMENU");
                    }
                }
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Up) == true && menuSelection > 1)
            {
                menuSelection -= 1;         
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Down) == true && menuSelection < 2)
            {
                menuSelection += 1;
            }
            oldState = newState;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if ("MAINMENU" == AIE.StateManager.StateStackCurrent)
            {
                spriteBatch.Begin();
                spriteBatch.DrawString(font, "JUMPY MC JUMP MAN", new Vector2(20, 20), Color.White);
                if (menuSelection == 1)
                {
                    spriteBatch.DrawString(font, "Select Level", new Vector2(20, 60), Color.Silver);
                }
                else
                {
                    spriteBatch.DrawString(font, "Select Level", new Vector2(20, 60), Color.White);
                }
                if (menuSelection == 2)
                {
                    spriteBatch.DrawString(font, "How to Play", new Vector2(20, 80), Color.Silver);
                }
                else
                {
                    spriteBatch.DrawString(font, "How to Play", new Vector2(20, 80), Color.White);
                }
                spriteBatch.DrawString(font, "Press ESC to Close Game", new Vector2(20, 110), Color.White);
                spriteBatch.End();
            }
            
            if ("LEVELSELECT" == AIE.StateManager.StateStackCurrent)
            {
                spriteBatch.Begin();
                spriteBatch.DrawString(font, "LEVEL SELECT", new Vector2(20, 20), Color.White);
                if (menuSelection == 1)
                {
                    spriteBatch.DrawString(font, "Level 1", new Vector2(20, 60), Color.Silver);
                }
                else
                {
                    spriteBatch.DrawString(font, "Level 1", new Vector2(20, 60), Color.White);
                }
                if (menuSelection == 2)
                {
                    spriteBatch.DrawString(font, "Level 2", new Vector2(20, 80), Color.Silver);
                }
                else
                {
                    spriteBatch.DrawString(font, "level 2", new Vector2(20, 80), Color.White);
                }
                spriteBatch.DrawString(font, "Press Backspace to return to Main Menu", new Vector2(20, 110), Color.White);
                spriteBatch.End();
            }            
        }

        public override void CleanUp()
        {
            font = null;
            isLoaded = false;
        }
    }
}
