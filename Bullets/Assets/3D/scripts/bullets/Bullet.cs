using UnityEngine;

namespace game.package.bullets
{
    public class Bullet : BulletBase
    {
        private void Update()
        {
            UpdateLifeTime();
            Move();
        }

        protected override void Move()
        {
            transform.position += direction * Speed * Time.deltaTime;
        }

        public override void ReactToCollision()
        {
        }
    }
}