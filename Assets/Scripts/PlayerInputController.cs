using UnityEngine;

public class PlayerInputController : MonoBehaviour
{
    private CharacterController _controller;
    public FloatingJoystick joystick;
    public float speed = 5f;

    private void Awake() 
    {
        _controller = GetComponent<CharacterController>();
        FieldOfView.onLose += CheckToWin;
    }

    private void FixedUpdate() {
        if(joystick.isDrag)
        {
            Move(joystick.direction);
        }

        if (FieldOfView.isAddListenner)
            FieldOfView.onLose -= CheckToWin;
    }


    public void Move(Vector2 dir)
    {
        Vector3 move = new Vector3(dir.x, 0, dir.y);
        _controller.Move(move*speed);
    }

    private void CheckToWin()
    {
       Debug.Log("Lose");
    }
}
