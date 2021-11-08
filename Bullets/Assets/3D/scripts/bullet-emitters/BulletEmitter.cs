using game.package.utilities;
using UnityEngine;

namespace game.package.bullets
{
    public class BulletEmitter : BulletEmitterBase
    {
        private GameObjectPoolBase gameObjectPool;

        private float fireRateElpasedTime;

        private void Start()
        {
            gameObjectPool = GameObjectPool.Instance;
        }

        private void Update()
        {
            fireRateElpasedTime += Time.deltaTime;
            if(fireRateElpasedTime > fireRate)
            {
                fireRateElpasedTime = 0;
                CreateBullet();
            }
        }

        public override void CreateBullet()
        {
            for(int i = 0; i < bulletCount; i++)
            {
                var bulletClone = gameObjectPool.GetGameObject(bullet);
                bulletClone.transform.rotation = transform.rotation;
                bulletClone.transform.position = transform.position;
                bulletClone.GetComponent<BulletBase>().direction = Vector3.forward;
                bulletClone.gameObject.SetActive(true);
                print("bullet created");
            }
        }
    }
}