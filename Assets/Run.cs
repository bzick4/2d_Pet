using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run : MonoBehaviour
{
    [SerializeField] private float _Speed;
    private Rigidbody2D bicycle;
    private float _currentSpeed;
    private Animator animator;

    private bool isMove;

    [SerializeField] private float _lerpSpeed ;



 private void Awake() {
    
    animator = GetComponentInChildren<Animator>();
    bicycle = GetComponent<Rigidbody2D>();
    _currentSpeed = _Speed;
 }
    private void Update() 
    {    
       Move(direction:0f);
    }

    private void HorizontalMovement(float direction)
    { 
        float lerpFactor = _lerpSpeed * Time.deltaTime;
        bicycle.velocity = new Vector2(Mathf.Lerp(bicycle.velocity.x, _currentSpeed * direction, lerpFactor),bicycle.velocity.y
);

       //bicycle.velocity = new Vector2(Mathf.Lerp(bicycle.velocity.x,_currentSpeed*direction,Time.fixedDeltaTime), bicycle.velocity.y);
    }

    public void Move(float direction)
    {
        if (Mathf.Abs(direction) > 0.1f)
        {
            HorizontalMovement(direction);
            animator.SetFloat("Run",bicycle.velocity.magnitude);
        }
        if(!isMove && direction < 0 || isMove && direction >0)
        {
            Flip();
        }
    } 

    private void Flip()
    {
        isMove = !isMove;
        transform.Rotate(0f, 180f, 0f);
    }
}
