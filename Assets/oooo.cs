using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oooo : MonoBehaviour
{
    public Transform m_transform;
    void start()
    {
        m_transform = this.transform;
    }
    private void LAMouse()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - m_transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        m_transform.rotation = rotation;
    }

    void Update()
    {
        LAMouse();
    }
}