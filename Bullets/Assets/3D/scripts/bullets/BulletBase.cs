using UnityEngine;

namespace game.package.bullets
{
    public abstract class BulletBase : MonoBehaviour
    {
        [SerializeField] protected float Speed;
        [SerializeField] protected float LifeTime = 3;
        [HideInInspector] public Vector3 direction;

        private float lifeTimeElapsedTime;

        protected abstract void Move();
        public abstract void ReactToCollision();

        protected virtual void UpdateLifeTime()
        {
            lifeTimeElapsedTime += Time.deltaTime;

            if (lifeTimeElapsedTime > LifeTime)
                gameObject.SetActive(false);
        }

        private void OnDisable()
        {
            lifeTimeElapsedTime = 0;
        }
    }
}