using System;
using UnityEngine;

[Serializable]
public class WaterDeath : MonoBehaviour
{
    public GameObject ripple;

    public virtual void OnTriggerEnter(Collider other)
    {
        if (other.name == "BottomMesh")
        {
            other.SendMessage("killsmoke");
        }
        if (other.name == "MainBoxCol")
        {
            UnityEngine.Object.Instantiate(ripple, new Vector3(other.transform.position.x, 11.5f, other.transform.position.z), Quaternion.Euler(0f, 0f, 0f));
        }
    }

    public virtual void OnTriggerExit(Collider other)
    {
        
        if (other.name == "MainBoxCol")
        {
            UnityEngine.Object.Instantiate(ripple, new Vector3(other.transform.position.x, 11.5f, other.transform.position.z), Quaternion.Euler(0f, 0f, 0f));
        }
    }

    public virtual void Main()
    {
    }
}