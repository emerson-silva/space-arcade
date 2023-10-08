using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegueMouse : MonoBehaviour
{
    void Update()
    {
        this.transform.position = (Vector2) Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
