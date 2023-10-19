using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    [SerializeField]
    PlayerController playerController;

    public void OnMove(InputAction.CallbackContext context) 
    {
        playerController.SetDirection(context.ReadValue<Vector2>());
    }
}
