using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetBehaviour : MonoBehaviour
{
    public float SpeedMove = 2;
    public float move;
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
       
        if (transform.position.x > 6.4 || transform.position.x < -6.4)
            move *= -1.0f;

        pos.x += (move * SpeedMove);
        transform.position = pos;


    }

   
 
      
}
