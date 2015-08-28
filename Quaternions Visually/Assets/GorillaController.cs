using UnityEngine;
using System.Collections;

public class GorillaController : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    // Stuff to do with quaternions
    public void SetRotation(Vector3 axis, float angle)
    {
        transform.rotation = Quaternion.AngleAxis(angle, axis);
    }

    public void OnDrawGizmos()
    {

    }
}
