using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public int leftX = 0;
    public int rightX = 7;

    private int _incAmount = 1; // 1 or -1

    public float moveRate = 0.09f; // in seconds
    public float timer = 0f;

    private bool _isStopped = false;


    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {   
        if(Input.GetKeyDown("space"))
            _isStopped = true;
        if(!_isStopped)
            Move();
        
    }

    void Move()
    {
        timer += Time.deltaTime;
        if(timer > moveRate)
        {
            TickMovement();
            timer = 0;
        }
    }

    void TickMovement()
    {
        Vector3 oldPos = transform.position;
        CheckIncAmount(oldPos);
        transform.position = new Vector3((oldPos.x)+_incAmount, oldPos.y, oldPos.z);
    }

    void CheckIncAmount(Vector3 vec)
    {
        int futureX = (int)vec.x + _incAmount;
        if(futureX > rightX || futureX < leftX)
        {
            _incAmount = _incAmount * -1;
        }
    }
}
