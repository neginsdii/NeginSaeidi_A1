using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetBehaviour : MonoBehaviour
{
    public float SpeedMove = 1;
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
        Debug.Log(move);
        if (transform.position.x > 6 || transform.position.x < -6)
            move *= -1.0f;
        checkScore();
        pos.x += (move*SpeedMove);
        transform.position = pos;
       
       
    }

   
   private void checkScore()
    {
        switch (ScoreText.scoreValue) {
            case 0:
                SpeedMove = 1;
                break;
            case 10:
                SpeedMove = 1.5f ;
                break;
            case 20:
                SpeedMove = 1.8f;
                break;
            default:
                SpeedMove = 2.0f;
                break; }
    }
}
