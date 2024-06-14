using System;
using UnityEngine;

namespace UnityStandardAssets.Effects
{
    public class WaterfallParticle : MonoBehaviour
    {
        public static float lastSoundTime;
        public float force = 1;

        private ParticleCollisionEvent[] m_CollisionEvents;
        private ParticleSystem m_ParticleSystem;

        private void Start()
        {
            m_ParticleSystem = GetComponent<ParticleSystem>();
        }

        private void OnParticleCollision(GameObject other)
        {
            m_CollisionEvents = new ParticleCollisionEvent[m_ParticleSystem.GetSafeCollisionEventSize()];
            int numCollisionEvents = m_ParticleSystem.GetCollisionEvents(other, m_CollisionEvents);
            int i = 0;

            while (i < numCollisionEvents)
            {
                if (Time.time > lastSoundTime + 0.2f)
                {
                    lastSoundTime = Time.time;
                    // 여기에 물소리 효과음을 추가할 수 있습니다.
                }

                var col = m_CollisionEvents[i].colliderComponent;
                var attachedRigidbody = col.GetComponent<Rigidbody>();
                if (attachedRigidbody != null)
                {
                    Vector3 vel = m_CollisionEvents[i].velocity;
                    attachedRigidbody.AddForce(vel * force, ForceMode.Impulse);
                }

                // 폭포에는 필요하지 않을 수 있는 부분입니다.
                // other.BroadcastMessage("Extinguish", SendMessageOptions.DontRequireReceiver);

                i++;
            }
        }
    }
}

