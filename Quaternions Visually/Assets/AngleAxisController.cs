﻿using UnityEngine;
using System.Collections;
using System;

public class AngleAxisController : MonoBehaviour
{
	/// <summary>
	/// Rotate axis rod around Y axis at a slow pace
	/// </summary>
	public bool m_rotateY;
	public float m_rotateSpeed;

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
		if (m_rotateY) {
			transform.RotateAround(transform.position, Vector3.up, m_rotateSpeed * Time.deltaTime);	
		}

        Vector3 rotationAxis = getRotationAxis();

		// Ensure we are only moving along y axis
		m_sphere.transform.localPosition = new Vector3(0, m_sphere.transform.localPosition.y, 0);

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
