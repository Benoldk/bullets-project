using game.package.utilities;

namespace game.package.bullets
{
    public class BulletFactoryManager
    {
        protected static BulletFactoryManager _instance;
        public static BulletFactoryManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new BulletFactoryManager();
                return _instance;
            }
        }

        public virtual BulletFactoryBase GetBulletFactory(BulletFormation bulletFormation, GameObjectPoolBase gameObjectPool)
        {
            if (bulletFormation == BulletFormation.Single)
                return new SingleBulletFactory(gameObjectPool);

            if (bulletFormation == BulletFormation.Line)
                return new LineBulletFactory(gameObjectPool);

            if (bulletFormation == BulletFormation.Circle)
                return new CircleBulletFactory(gameObjectPool);

            return null;
        }
    }
}