using UnityEditor.Rendering;
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
        if(context.started)
        {
            inputData_.interact_++;
        }
    }
}
