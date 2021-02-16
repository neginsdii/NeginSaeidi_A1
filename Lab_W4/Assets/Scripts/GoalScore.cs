using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScore : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private BallPhysics ball;
   
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        if (ball == null)
            ball = FindObjectOfType<BallPhysics>();
    }

    void OnCollisionEnter(Collision collision)
    {
        //Check for a match with the specified name on any GameObject that collides with collision box
        if (collision.gameObject.name == "Ball")
        {
            //If the GameObject's name matches the one you suggest, update the score
        
            ScoreText.scoreValue += 10;
        }

     
    }
}
