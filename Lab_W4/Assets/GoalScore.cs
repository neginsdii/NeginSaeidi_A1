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
        //Check for a match with the specified name on any GameObject that collides with your GameObject
        if (collision.gameObject.name == "Ball")
        {
            //If the GameObject's name matches the one you suggest, output this message in the console
            Debug.Log("Do something here");
            ScoreText.scoreValue += 10;
        }

        //Check for a match with the specific tag on any GameObject that collides with your GameObject
    }
}
