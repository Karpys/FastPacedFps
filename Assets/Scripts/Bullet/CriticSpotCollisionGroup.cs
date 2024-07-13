using System;
using System.Collections.Generic;

namespace KarpysDev.Fps.Bullet
{
    public class CriticSpotCollisionGroup
    {
        private CriticSpotBulletCollision[] m_CriticSpotCollisions = null;
        private Action m_OnAllCriticSpotExploded = null;
        private Dictionary<CriticSpotBulletCollision, bool> m_CriticSpotState = new Dictionary<CriticSpotBulletCollision, bool>();
        private int m_CriticSpotCount = 0;
        
        public Action OnAllCriticSpotExploded
        {
            get => m_OnAllCriticSpotExploded;
            set => m_OnAllCriticSpotExploded = value;
        }

        public CriticSpotCollisionGroup(CriticSpotBulletCollision[] criticSpotCollisions)
        {
            m_CriticSpotCollisions = criticSpotCollisions;
            m_CriticSpotCount = criticSpotCollisions.Length;

            foreach (CriticSpotBulletCollision criticSpotCollision in criticSpotCollisions)
            {
                m_CriticSpotState.Add(criticSpotCollision,true);
                criticSpotCollision.AssignGroup(this);
            }
        }

        public void RemoveSpot(CriticSpotBulletCollision criticSpotBulletCollision)
        {
            if (m_CriticSpotState.TryGetValue(criticSpotBulletCollision, out bool isActive) && isActive)
            {
                m_CriticSpotCount -= 1;
                m_CriticSpotState[criticSpotBulletCollision] = false;
            }
            
            if(m_CriticSpotCount == 0)
                OnAllCriticSpotExploded?.Invoke();
        }
    }
}