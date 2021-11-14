using game.package.utilities;
using UnityEngine;

namespace game.package.bullets
{
    public class LineBulletFactory : BulletFactoryBase
    {
        public LineBulletFactory(GameObjectPoolBase _gameObjectPool) : base(_gameObjectPool) { }

        public override void CreateBullets(BulletFactoryProfile profile)
        {
            float offset = (profile.bulletSpacing * profile.bulletCount + profile.prefab.transform.localScale.x * profile.bulletCount) * 0.5f;
            var lastPosition = profile.parentTransform.position;
            float step = profile.bulletSpacing + profile.prefab.transform.localScale.x;
            lastPosition.x -= offset - (step * 0.5f);
            GameObject[] bullets = new GameObject[profile.bulletCount];
            for (int i = 0; i < profile.bulletCount; i++)
            {
                var bullet = GetBulletGameObject(profile);
                if(i > 0)
                    lastPosition.x += step;
                bullet.transform.position = lastPosition + profile.muzzleOffset;
                bullet.transform.RotateAround(profile.parentTransform.position, Vector3.up, profile.areaAngle);
                bullet.SetActive(true);
            }
        }
    }
}