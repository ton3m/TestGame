using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody))]
public class Player3D : MonoBehaviour
{
    public Transform groundCheckPoint;
    public Transform attackPoint;

    public float rotationSpeed = 120f;
    public float speed = 5f;
    public float jumpForce = 7f;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public int attackDamage = 1;

    private Rigidbody rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Curtain.Instance.Hide();
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        
        Vector3 move = new Vector3(moveX, 0, moveZ) * speed;
        rb.velocity = new Vector3(move.x, rb.velocity.y, move.z);
        
        if (move.magnitude > 0.1f)
        {
            var lookRotation = Quaternion.LookRotation(move);
            
            float step = rotationSpeed * Time.deltaTime;

            transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, step);
        }

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Attack();
        }
    }

    bool IsGrounded()
    {
        return Physics.Raycast(groundCheckPoint.position, Vector3.down, 0.1f);
    }

    void Attack()
    {
        Debug.Log("Attack");
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider enemy in hitEnemies)
        {
            if (!enemy.isTrigger) continue;
            
            Vector3 delta = enemy.transform.position - attackPoint.position;
            Vector3 forceDirection = delta.normalized;
            forceDirection.y = 1f;
            float force = 3f;

            enemy.GetComponent<Rigidbody>().AddForce(forceDirection * force, ForceMode.Impulse);
            enemy.GetComponent<Enemy3D>().TakeDamage(attackDamage);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.name.Equals("Door"))
        {
            SceneManager.LoadScene("Gameplay3D");
        }
    }
}