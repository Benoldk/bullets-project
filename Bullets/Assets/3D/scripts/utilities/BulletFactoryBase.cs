using game.package.utilities;
using UnityEngine;

namespace game.package.bullets
{
    public abstract class BulletFactoryBase
    {
        protected GameObjectPoolBase gameObjectPool;

        protected BulletFactoryBase(GameObjectPoolBase _gameObjectPool)
        {
            gameObjectPool = _gameObjectPool;
        }

        public abstract void CreateBullets(BulletFactoryProfile profile);

        protected virtual GameObject GetBulletGameObject(BulletFactoryProfile profile)
        {
            var bulletClone = gameObjectPool.GetGameObject(profile.prefab);
            bulletClone.transform.rotation = profile.parentTransform.rotation;
            bulletClone.transform.position = profile.parentTransform.position;
            bulletClone.GetComponent<BulletBase>().direction = Vector3.forward;
            return bulletClone;
        }
    }
}