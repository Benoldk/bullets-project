using game.package.utilities;
using UnityEngine;

namespace game.package.bullets
{
    public abstract class BulletEmitterBase : MonoBehaviour
    {
        [SerializeField] protected BulletBase bulletPrefab;
        [SerializeField] protected float fireRate;
        [SerializeField] protected BulletFormation bulletFormation;

        protected BulletFactoryManager bulletFactoryManager;
        protected BulletFactoryBase bulletFactory;
        protected BulletFactoryProfile bulletFactoryProfile;
        protected GameObjectPoolBase gameObjectPool;
        protected float fireRateElpasedTime;

        protected abstract void Initialize();
        public abstract void CreateBullet();
        
        private void Start()
        {
            Initialize();
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