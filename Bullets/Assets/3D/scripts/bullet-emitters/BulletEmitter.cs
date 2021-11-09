using game.package.utilities;
using UnityEngine;

namespace game.package.bullets
{
    public class BulletEmitter : BulletEmitterBase
    {
        private void Start()
        {
            gameObjectPool = GameObjectPool.Instance;
        }

        public override void CreateBullet()
        {
            var bulletClone = GetBulletGameObject();
            bulletClone.gameObject.SetActive(true);
            print("bullet created");
        }
    }
}