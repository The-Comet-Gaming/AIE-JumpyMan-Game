﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace AIEJumpyMan
{
    class MegaHP
    {
        //keep a reference to the Game object to check for collisions on the map
        Game1 game = null;

        Sprite sprite = new Sprite();

        Vector2 position = Vector2.Zero;
        Vector2 velocity = Vector2.Zero;

        public Vector2 Position
        {
            get { return sprite.position; }
            set { sprite.position = value; }
        }

        public Rectangle Bounds
        {
            get { return sprite.Bounds; }
        }

        public MegaHP(Game1 game)
        {
            this.game = game;
            position = Vector2.Zero;
            velocity = Vector2.Zero;
        }

        public void Load(ContentManager content)
        {
            AnimatedTexture animation = new AnimatedTexture(Vector2.Zero, 0, 1, 1);
            animation.Load(content, "MegaHealthHeart", 1, 5);

            sprite.Add(animation, 0, 0);
        }

        public void Update(float deltaTime)
        {
            sprite.Update(deltaTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch);
        }
    }
}