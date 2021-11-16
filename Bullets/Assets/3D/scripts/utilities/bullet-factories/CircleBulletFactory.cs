using game.package.utilities;
using UnityEditor;
using UnityEngine;

namespace game.package.bullets
{
    public class CircleBulletFactory : BulletFactoryBase
    {
        public CircleBulletFactory(GameObjectPoolBase _gameObjectPool) : base(_gameObjectPool) { }

        public override void CreateBullets(BulletFactoryProfile profile)
        {
            float angle = 0;
            var bullets = new GameObject[profile.bulletCount];
            float slice = profile.areaAngle * Mathf.Deg2Rad / (profile.bulletCount-1);
            for (int i = 0; i < profile.bulletCount; i++)
            {
                angle = slice * i;
                Vector3 position = profile.parentTransform.position;
                position.x += profile.muzzleOffset.x * Mathf.Cos(angle);
                position.z += profile.muzzleOffset.z * Mathf.Sin(angle);
                var bullet = GetBulletGameObject(profile);
                bullet.transform.position = position;
                bullet.SetActive(true);
                bullets[i] = bullet;
            }

            for (int i = 0; i < bullets.Length; i++)
            {
                float thisAngle = profile.areaAngle * 0.5f - 90f;
                bullets[i].transform.RotateAround(profile.parentTransform.position, Vector3.up, thisAngle);
            }

            for (int i = 0; i < bullets.Length; i++)
            {
                bullets[i].transform.RotateAround(profile.parentTransform.position, Vector3.up, profile.orientationAngle);
            }

            EditorApplication.isPaused = true;
        }
    }
}