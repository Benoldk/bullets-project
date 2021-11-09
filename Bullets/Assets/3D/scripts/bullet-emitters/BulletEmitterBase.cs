using game.package.utilities;
using UnityEngine;

namespace game.package.bullets
{
    public abstract class BulletEmitterBase : MonoBehaviour
    {
        [SerializeField] protected BulletBase bulletPrefab;
        [SerializeField] protected float fireRate;

        protected GameObjectPoolBase gameObjectPool;
        protected float fireRateElpasedTime;

        public abstract void CreateBullet();

        protected virtual GameObject GetBulletGameObject()
        {
            var bulletClone = gameObjectPool.GetGameObject(bulletPrefab);
            bulletClone.transform.rotation = transform.rotation;
            bulletClone.transform.position = transform.position;
            bulletClone.GetComponent<BulletBase>().direction = Vector3.forward;
            return bulletClone;
        }

        private void Update()
        {
            fireRateElpasedTime += Time.deltaTime;
            if (fireRateElpasedTime > fireRate)
            {
                fireRateElpasedTime = 0;
                CreateBullet();
            }
        }
    }
}