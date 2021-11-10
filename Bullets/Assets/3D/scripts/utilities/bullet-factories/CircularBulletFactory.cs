using game.package.utilities;
using UnityEngine;

namespace game.package.bullets
{
    public class CircularBulletFactory : BulletFactoryBase
    {
        public CircularBulletFactory(GameObjectPoolBase _gameObjectPool) : base(_gameObjectPool) { }

        public override void CreateBullets(BulletFactoryProfile profile)
        {
            float slice = 2 * Mathf.PI / profile.count;
            for (int i = 0; i < profile.count; i++)
            {
                float angle = slice * i;
                var bullet = GetBulletGameObject(profile);
                Vector3 position = new Vector3
                {
                    x = profile.parentTransform.position.x + profile.distance * Mathf.Cos(angle),
                    y = profile.parentTransform.position.y,
                    z = profile.parentTransform.position.z + profile.distance * Mathf.Sin(angle)
                };
                bullet.transform.position = position;
                bullet.GetComponent<BulletBase>().direction = (bullet.transform.position - profile.parentTransform.position).normalized;
                bullet.SetActive(true);
            }
        }
    }
}