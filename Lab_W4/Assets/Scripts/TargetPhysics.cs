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
    // Start is called before the first frame update
    void Start()
    {
        range = 5.0f;
        ball = FindObjectOfType<BallPhysics>();
        pos.x = ball.transform.position.x + ball.transform.forward.x * range;
        pos.y = 3.0f;
        pos.z = ball.transform.position.z + ball.transform.forward.z * range;
        transform.position=pos;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetAxisRaw("Vertical") > 0.0f)
        {
            // move forward
         
            range += 0.1f;
        }

        if (Input.GetAxisRaw("Vertical") < 0.0f)
        {
            // move Back
            range -= 0.1f;
        }

        if (ball.m_bIsGrounded)
        {
            
            pos.x = ball.transform.position.x + ball.transform.forward.x * range;
            pos.y = ball.transform.position.y + ball.transform.forward.y * range;
            pos.z = ball.transform.position.z + ball.transform.forward.z * range;
            transform.position = pos;
            GetComponent<MeshRenderer>().enabled = true;
		}
		else { GetComponent<MeshRenderer>().enabled = false; }

    }
}
