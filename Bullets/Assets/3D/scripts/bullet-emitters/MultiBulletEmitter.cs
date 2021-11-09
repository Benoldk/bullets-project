using game.package.utilities;
using UnityEngine;

namespace game.package.bullets
{
    public class MultiBulletEmitter : BulletEmitterBase
    {
        [SerializeField] protected int bulletCount = 2;
        [SerializeField] protected float bulletLateralOffset = 0.1f;

        private void Start()
        {
            gameObjectPool = GameObjectPool.Instance;
        }

        public override void CreateBullet()
        {
            bool isOdd = bulletCount % 2 > 0;
            if(isOdd)
                CreateBulletsOddCount();
            else
                CreateBulletsEvenCount();
        }

        private void CreateBulletsOddCount()
        {
            var bulletClone = GetBulletGameObject();
            bulletClone.SetActive(true);

            int batchCount = bulletCount / 2;
            for(int i = 0; i < batchCount; i++)
            {
                var bulletCloneLeft = GetBulletGameObject();
                bulletCloneLeft.transform.position = transform.position + (Vector3.left * bulletLateralOffset * (i + 1));
                bulletCloneLeft.SetActive(true);

                var bulletCloneRight = GetBulletGameObject();
                bulletCloneRight.transform.position = transform.position + (Vector3.right * bulletLateralOffset * (i + 1));
                bulletCloneRight.SetActive(true);
            }
        }

        private void CreateBulletsEvenCount()
        {
            var normalizedRight = transform.right.normalized;
            var offset = normalizedRight * bulletLateralOffset * 0.5f;
            var bulletCloneLeft = CreateandPositionBullet(transform.position - offset);
            var bulletCloneRight = CreateandPositionBullet(transform.position + offset);

            var leftTransform = bulletCloneLeft.transform;
            var rightTransform = bulletCloneRight.transform;

            int batchCount = bulletCount / 2;
            for (int i = 1; i < batchCount; i++)
            {
                offset = normalizedRight * bulletLateralOffset;
                bulletCloneLeft = CreateandPositionBullet(leftTransform.position - offset);
                bulletCloneRight = CreateandPositionBullet(rightTransform.position + offset);
                leftTransform = bulletCloneLeft.transform;
                rightTransform = bulletCloneRight.transform;
            }
        }

        private GameObject CreateandPositionBullet(Vector3 position)
        {
            var bulletClone = GetBulletGameObject();
            bulletClone.transform.position = position;
            bulletClone.SetActive(true);
            return bulletClone;
        }
    }
}