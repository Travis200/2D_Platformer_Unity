using UnityEngine;
using TMPro;

public class Character2DController : MonoBehaviour
{
    [SerializeField] private LayerMask groundPlatformLayerMask;
    public float MovementSpeed = 3.5f;
    public float SingleJumpForce = 4f;
    public float DoubleJumpForce = 5f;
    public Transform TransformPlayer;

    private int JumpCount = 0;
    public Rigidbody2D rb;
    public BoxCollider2D bc;
    public Animator animator;
    public TextMeshProUGUI PowerupText;


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

    public void ResetPlayerStats()
    {
        MovementSpeed = 3.5f;
        SingleJumpForce = 4f;
        DoubleJumpForce = 5f;
        JumpCount = 0;
        TransformPlayer.localScale = new Vector3(6f, 6f, 6f);
        PowerupText.text = "Powerup: none";
    }
}
