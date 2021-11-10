using game.package.utilities;

namespace game.package.bullets
{
    public class BulletFactoryManager
    {
        private static BulletFactoryManager _instance;
        public static BulletFactoryManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new BulletFactoryManager();
                return _instance;
            }
        }

        public BulletFactoryBase GetBulletFactory(BulletFormation bulletFormation, GameObjectPoolBase gameObjectPool)
        {
            if (bulletFormation == BulletFormation.Single)
                return new SingleBulletFactory(gameObjectPool);

            if (bulletFormation == BulletFormation.UniDirectional)
                return new UnidirectionalBulletFactory(gameObjectPool);

            if (bulletFormation == BulletFormation.Circular)
                return new CircularBulletFactory(gameObjectPool);

            return null;
        }
    }
}