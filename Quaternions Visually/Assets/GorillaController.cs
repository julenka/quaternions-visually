using UnityEngine;
using System.Collections;

public class GorillaController : MonoBehaviour
{
    public GameObject m_RedSpherePrototype;
    public float m_DotSpawnIntervalSeconds = 0.33f;
    public bool m_SpawnDots;

    private float m_lastTimeDotSpawned;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (m_SpawnDots && _IsTimeToSpawnDot())
        {
            _SpawnDot();
        }
    }

    // Stuff to do with quaternions
    public void SetRotation(Vector3 axis, float angle)
    {
        transform.rotation = Quaternion.AngleAxis(angle, axis);
    }

    private void _SpawnDot()
    {
        Instantiate(m_RedSpherePrototype, m_RedSpherePrototype.transform.position, Quaternion.identity);
    }

    private bool _IsTimeToSpawnDot()
    {
        float now = Time.time;
        if (now - m_lastTimeDotSpawned > m_DotSpawnIntervalSeconds)
        {
            m_lastTimeDotSpawned = now;
            return true;
        }
        return false;
    }
}
