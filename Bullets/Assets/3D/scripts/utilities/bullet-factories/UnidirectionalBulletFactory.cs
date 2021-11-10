using game.package.utilities;
using UnityEngine;

namespace game.package.bullets
{
    public class UnidirectionalBulletFactory : BulletFactoryBase
    {
        public UnidirectionalBulletFactory(GameObjectPoolBase _gameObjectPool) : base(_gameObjectPool) { }

        public override void CreateBullets(BulletFactoryProfile profile)
        {
            bool isOdd = profile.count % 2 > 0;
            if (isOdd)
                CreateBulletsOddCount(profile);
            else
                CreateBulletsEvenCount(profile);
        }

        private void CreateBulletsOddCount(BulletFactoryProfile profile)
        {
            var bulletClone = GetBulletGameObject(profile);
            bulletClone.SetActive(true);

            int batchCount = profile.count / 2;
            for (int i = 0; i < batchCount; i++)
            {
                var bulletCloneLeft = GetBulletGameObject(profile);
                bulletCloneLeft.transform.position = profile.parentTransform.position + (Vector3.left * profile.distance * (i + 1));
                bulletCloneLeft.SetActive(true);

                var bulletCloneRight = GetBulletGameObject(profile);
                bulletCloneRight.transform.position = profile.parentTransform.position + (Vector3.right * profile.distance * (i + 1));
                bulletCloneRight.SetActive(true);
            }
        }

        private void CreateBulletsEvenCount(BulletFactoryProfile profile)
        {
            var normalizedRight = profile.parentTransform.right.normalized;
            var offset = normalizedRight * profile.distance * 0.5f;
            var bulletCloneLeft = CreateandPositionBullet(profile, profile.parentTransform.position - offset);
            var bulletCloneRight = CreateandPositionBullet(profile, profile.parentTransform.position + offset);

            var leftTransform = bulletCloneLeft.transform;
            var rightTransform = bulletCloneRight.transform;

            int batchCount = profile.count / 2;
            for (int i = 1; i < batchCount; i++)
            {
                offset = normalizedRight * profile.distance;
                bulletCloneLeft = CreateandPositionBullet(profile, leftTransform.position - offset);
                bulletCloneRight = CreateandPositionBullet(profile, rightTransform.position + offset);
                leftTransform = bulletCloneLeft.transform;
                rightTransform = bulletCloneRight.transform;
            }
        }

        private GameObject CreateandPositionBullet(BulletFactoryProfile profile, Vector3 position)
        {
            var bulletClone = GetBulletGameObject(profile);
            bulletClone.transform.position = position;
            bulletClone.SetActive(true);
            return bulletClone;
        }
    }
}