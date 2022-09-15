using UnityEngine;

public class PlayerInputController : MonoBehaviour
{
    public FloatingJoystick joystick;
    public float speed = 5f;
    CharacterController Controller;
    private void Awake() {
        Controller = GetComponent<CharacterController>();
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
        
    }

    public void Move(Vector2 dir)
    {
        Vector3 move = new Vector3(dir.x, 0, dir.y);
        Controller.Move(move*speed);
    }
}
