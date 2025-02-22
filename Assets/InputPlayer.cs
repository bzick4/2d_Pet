using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputPlayer : MonoBehaviour
{
    
     private Run _playerMovement;
    private void Awake()
    {
        _playerMovement = GetComponent<Run>();
    }

    private void Update()
    {
        float horizontal =Input.GetAxis(Global.HORIZONTAL_AXIS);
        //float vertical = Input.GetAxis(Global.VERTICAL_AXIS);
        //bool isJumpButton = Input.GetButtonDown(Global.JUMP);
        _playerMovement.Move(horizontal);
    }

}
