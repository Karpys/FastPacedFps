using KarpysDev.Fps.Bullet;
using UnityEngine;

namespace KarpysDev.Fps.Enemy
{
    public class CriticSpotEnemy : MonoBehaviour
    {
        [SerializeField] private CriticSpotBulletCollision[] m_CriticSpotCollisions = null;

        private CriticSpotCollisionGroup m_CriticGroup = null;

        public void Awake()
        {
            m_CriticGroup = new CriticSpotCollisionGroup(m_CriticSpotCollisions);
            m_CriticGroup.OnAllCriticSpotExploded += () => Destroy(gameObject);
        }
    }
}