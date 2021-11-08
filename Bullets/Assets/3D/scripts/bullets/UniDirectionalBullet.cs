using UnityEngine;

namespace game.package.bullets
{
    public class UniDirectionalBullet : BulletBase
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