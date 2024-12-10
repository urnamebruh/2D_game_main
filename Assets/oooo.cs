using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oooo : MonoBehaviour
{    
    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        
        Vector2 direction = new Vector2(mousePosition.x, mousePosition.y);

        transform.up = direction;
    }
}
