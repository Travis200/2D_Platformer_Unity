using UnityEngine;

public class Character2DController : MonoBehaviour
{
    [SerializeField] private LayerMask groundPlatformLayerMask;
    public float MovementSpeed;
    public Rigidbody2D rb;
    public float SingleJumpForce = 4f;
    public float DoubleJumpForce = 5f;
    public BoxCollider2D bc;
    private int JumpCount = 0;
    public Transform TransformPlayer;
    public Animator animator;


    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        var HorizontalMovement = Input.GetAxis("Horizontal");
        if (HorizontalMovement < 0) {
            animator.SetBool("IsMoving", true);
            Vector3 playerLocalScale = TransformPlayer.localScale;
            if (playerLocalScale.x > 0)
            {
                playerLocalScale.x *= -1;
                TransformPlayer.localScale = playerLocalScale;
            }
        }
        else if (HorizontalMovement > 0)
        {
            animator.SetBool("IsMoving", true);
            Vector3 playerLocalScale = TransformPlayer.localScale;
            if (playerLocalScale.x < 0)
            {
                playerLocalScale.x *= -1;
                TransformPlayer.localScale = playerLocalScale;
            }
        }
        else
        {
            animator.SetBool("IsMoving", false);
        }

        transform.position += new Vector3(HorizontalMovement, 0f, 0f) * Time.deltaTime * MovementSpeed;
        if (Input.GetButtonDown("Jump"))
        {
            if (TouchingGround()) {
                rb.AddForce(Vector2.up * SingleJumpForce, ForceMode2D.Impulse);
                JumpCount = 1;
                animator.SetBool("IsJumping", true);
            }
            else if(JumpCount < 2)
            {
                animator.SetBool("IsJumping", true);
                rb.AddForce(Vector2.up * DoubleJumpForce, ForceMode2D.Impulse);
                JumpCount += 1;
            }
        }

        if (TouchingGround())
        {
            animator.SetBool("IsJumping", false);
        }

    }


    private bool TouchingGround()
    {   
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(bc.bounds.center, bc.bounds.size, 0f, rb.gravityScale>0 ? Vector2.down : Vector2.up, 0.1f, groundPlatformLayerMask);
        return raycastHit2D.collider != null;
    }
}
