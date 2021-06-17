using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
public class ThirdPersonCharacterController : MonoBehaviour
{
    [Header("Movement Variables")]
    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _jumpHeight = 5f;
    [SerializeField] private float _smoothTurnTime = 0.1f;
    [SerializeField][Range(0f, 5f)] private float _sprintMultiplier = 1.5f;
    [Space]
    [Header("References")]
    [SerializeField] private Camera _cam = null;
    
    private CapsuleCollider _coll = null;
    private Rigidbody _rb = null;

    private Vector3 _velocity = Vector3.zero;
    
    private float _turnSmoothVelocity;
    private float _constSpeed = 0f;

    private bool _isSprinting = false;

    // Start is called before the first frame update
    void Start()
    {
        _coll = GetComponent<CapsuleCollider>();
        _rb = GetComponent<Rigidbody>();

        _constSpeed = _speed;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void FixedUpdate()
    {
    }

    private void Update()
    {
        handleMovement();
        if (Input.GetKeyDown(KeyCode.LeftShift))
            _isSprinting = true;
        else if(Input.GetKeyUp(KeyCode.LeftShift))
            _isSprinting = false;
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded())
            _rb.velocity += Vector3.up * _jumpHeight;
    }

    private void handleMovement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + _cam.transform.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _turnSmoothVelocity, _smoothTurnTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 velocity = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            if(_isSprinting)
                _rb.position += velocity.normalized * _speed * _sprintMultiplier * Time.deltaTime;
            else
                _rb.position += velocity.normalized * _speed * Time.deltaTime;
        }
    }

    private bool isGrounded()
    {
        const float extraHeight = 0.01f;
        if (Physics.Raycast(_coll.bounds.center, Vector3.down, _coll.bounds.extents.y + extraHeight))
            return true;
        return false;
    }
}
