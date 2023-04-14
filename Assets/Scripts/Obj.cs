using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obj : MonoBehaviour
{
    private Vector2 newPosition;
    public void StartObject()
    {
        newPosition = new Vector2(Random.Range(-8.0f, 8.0f), Random.Range(-4.0f, 4.0f));

        transform.position = newPosition;
    }
}
