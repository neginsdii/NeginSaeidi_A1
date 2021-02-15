using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetBehaviour : MonoBehaviour
{
    [SerializeField]
    private float move;
    private Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        move = 0.01f;
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > 5 || transform.position.x < -5)
            move *= -1;
        pos.x += move;
        transform.position = pos;
    }
}
