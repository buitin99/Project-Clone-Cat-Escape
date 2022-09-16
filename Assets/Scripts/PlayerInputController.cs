using UnityEngine;

public class PlayerInputController : MonoBehaviour
{
    private CharacterController _controller;
    public FloatingJoystick joystick;
    public float speed = 5f;

    private bool isCheck;

    
    private void Awake() 
    {
        _controller = GetComponent<CharacterController>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate() {
        if(joystick.isDrag)
        {
            Move(joystick.direction);
        }
    }

    // Update is called once per frame
    void Update()
    {
        var check = FieldOfView.isWin ? isCheck = true : isCheck = false;
        if (check)
        {
        //    CheckToWin();
            Debug.Log("Win");
        }
    }

    public void Move(Vector2 dir)
    {
        Vector3 move = new Vector3(dir.x, 0, dir.y);
        _controller.Move(move*speed);
    }

    private void CheckToWin()
    {
        Debug.Log("Win");
    }
}
