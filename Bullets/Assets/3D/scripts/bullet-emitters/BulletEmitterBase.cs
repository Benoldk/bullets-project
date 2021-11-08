using UnityEngine;

namespace game.package.bullets
{
    public abstract class BulletEmitterBase : MonoBehaviour
    {
        public BulletBase bullet;
        [SerializeField] protected int bulletCount = 1;
        [SerializeField] protected float fireRate;

        public abstract void CreateBullet();
    }
}