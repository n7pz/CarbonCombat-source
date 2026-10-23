using System;
using UnityEngine;

[Serializable]
public class autoDestroy : MonoBehaviour
{
    public float life;

    private float destroyTime;

    public virtual void Start()
    {
        destroyTime = Time.time + life;
    }

    public virtual void Update()
    {
        if (!(Time.time <= destroyTime))
        {
            UnityEngine.Object.Destroy(gameObject);
        }
    }

    public virtual void Main()
    {
    }
}
[Serializable]
public class AutoDestroy : MonoBehaviour
{
    public float time;

    public virtual void Update()
    {
        time -= Time.deltaTime;
        if (!(time >= 0f))
        {
            UnityEngine.Object.Destroy(gameObject);
        }
    }
}