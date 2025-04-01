using UnityEngine;
using UnityEngine.SceneManagement;

// Управление персонажем в 2D
[RequireComponent(typeof(Rigidbody2D))]
public class Player2D : MonoBehaviour
{
    public Transform groundCheckPoint;
    public Transform attackPoint;

    public float speed = 5f;
    public float jumpForce = 7f;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public int attackDamage = 1;
    private Rigidbody2D rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(move * speed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Attack();
        }
    }

    bool IsGrounded()
    {
        var hit = Physics2D.Raycast(groundCheckPoint.position, Vector2.down, 0.1f);

        return hit.collider != null;
    }

    void Attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            if (!enemy.isTrigger) continue;
            
            var delta = attackPoint.position.x - enemy.transform.position.x;
            var flipFactor = -Mathf.Sign(delta);

            var force = 3f;

            enemy.GetComponent<Rigidbody2D>().AddForce(new Vector2(flipFactor * force, force), ForceMode2D.Impulse);
            enemy.GetComponent<Enemy2D>().TakeDamage(attackDamage);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name.Equals("Door"))
        {
            Curtain.Instance.Show();
            SceneManager.LoadScene("Gameplay3D");
        }
    }
}
