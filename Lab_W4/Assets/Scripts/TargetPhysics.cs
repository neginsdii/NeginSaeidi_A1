using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPhysics : MonoBehaviour
{
    public BallPhysics ball;
    [SerializeField]
    private float range;
    [SerializeField]
    private Vector3 pos;
    private Vector3 prepos;

    // Start is called before the first frame update
    void Start()
    {
        //GetComponent<MeshRenderer>().enabled = false;

        range = 12.4f;
        ball = FindObjectOfType<BallPhysics>();
        pos.x = ball.transform.position.x + ball.transform.forward.x * range;
        pos.y = 3.0f;
        pos.z = ball.transform.position.z + ball.transform.forward.z * range;
        prepos = pos;
        transform.position=pos;
    }

    // Update is called once per frame
    void Update()
    {
        //setting the position of the target based on the ball's forward direction when ball is on the ground

        if (ball.m_bIsGrounded)
        {
           
                pos.x = ball.transform.position.x + ball.transform.forward.x * range;
                pos.y = ball.transform.position.y + ball.transform.forward.y * range;
                pos.z = ball.transform.position.z + ball.transform.forward.z * range;
            //to avoid jittering 
            if (Vector3.Distance(pos, prepos) > 1.2)
            {
                prepos = pos;

                transform.position = pos;
            }
            Debug.Log(pos);
            GetComponent<MeshRenderer>().enabled = true;
		}//making target invisible when ball is not on the ground
		else { GetComponent<MeshRenderer>().enabled = false; }

    }
}
