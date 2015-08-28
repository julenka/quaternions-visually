using UnityEngine;
using System.Collections;
using System;

public class AngleAxisController : MonoBehaviour
{
    private GorillaController m_Gorilla;
    private GameObject m_sphere;
    private float m_height;

    // Use this for initialization
    void Start()
    {
        GameObject cylinder = GameObject.Find("Cylinder");
        m_height = cylinder.transform.localScale.y * 2;

        m_sphere = GameObject.Find("Sphere");
        m_Gorilla = FindObjectOfType<GorillaController>();
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 rotationAxis = getRotationAxis();
        float angle = getAngle();
        m_Gorilla.SetRotation(rotationAxis, angle);
    }

    private float getAngle()
    {
        Vector3 currentTransform = m_sphere.transform.localPosition;
        float cylinderBottom = -m_height / 2f;
        float positionAlongCylinder = currentTransform.y - cylinderBottom;
        // Normalize
        positionAlongCylinder /= m_height;
        positionAlongCylinder = Mathf.Clamp(positionAlongCylinder, 0, 1);
        // Normalize the position so it goes from -1 to 1
        return Mathf.Lerp(-180f, 180f, positionAlongCylinder);
    }

    private Vector3 getRotationAxis()
    {
        return transform.rotation * Vector3.up;
    }
}
