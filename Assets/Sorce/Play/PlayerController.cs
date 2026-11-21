using UnityEngine;

public class PlayerController : MonoBehaviour
{
    protected PlayerInputData inputData_ = new PlayerInputData();

    public PlayerInputData currentInput_ {  get { return inputData_; } }
}
