using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Topic_9___Making_Player_Class
{
    internal class Player
    {

        enum PlayerLevel
        {
            level1,
            level2,
            level3,
            level4,
            level5,
        }

        private int _maxHealth;
        private int _health;
        private int _baseAttack;
        private int _attack;
        private int _baseDefence;
        private int _defense;
        private int _level;


        private Texture2D _texture;
        private Rectangle _location;
        private Vector2 _speed;

        public Player(Texture2D texture, int x, int y)
        {
            _texture = texture;
            _location = new Rectangle(x, y, 30, 30);
            _speed = new Vector2();
            _health = 100;
        }

        public float HSpeed
        {
            get { return _speed.X; }
            set { _speed.X = value; }
        }

        public float VSpeed
        {
            get { return _speed.Y; }
            set { _speed.Y = value; }
        }

        public int Health
        {
            get { return _health; }
            set { _health = value; }
        }

        private void Move()
        {
            _location.X += (int)_speed.X;
            _location.Y += (int)_speed.Y;
        }

        public void Update()
        {
            Move();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _location, Color.White);
        }

        public bool Collide(Rectangle item)
        {
            return _location.Intersects(item);
        }

        public void UndoMove()
        {
            _location.X -= (int)_speed.X;
            _location.Y -= (int)_speed.Y;
        }



    }
}
