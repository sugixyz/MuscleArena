using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerGymController : PlayerController
{
    public void OnMove(InputAction.CallbackContext context)
    {
        inputData_.move_ = context.ReadValue<Vector2>();
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if(context.started) inputData_.interact_ = true;
        else if (context.canceled) inputData_.interact_ = false;
    }
}
