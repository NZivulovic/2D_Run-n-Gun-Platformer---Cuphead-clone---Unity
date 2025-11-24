using Unity.Mathematics;
using UnityEngine;

public class playerProjectile : MonoBehaviour
{
    private Rigidbody2D rb;
    private GameObject enemy;
    private GameObject player;

    public float force;

    private float timer;

    public int damage;

    public float despawnAfterSeconds;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        enemy = GameObject.FindGameObjectWithTag("Enemy");

        rb = GetComponent<Rigidbody2D>();

        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.AddForce(Vector2.up * force, ForceMode2D.Impulse);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddForce(Vector2.left * force, ForceMode2D.Impulse);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddForce(Vector2.right * force, ForceMode2D.Impulse);
        }

    }

    void Update()
    {
        timer += Time.deltaTime;
        if(timer > despawnAfterSeconds)
        {
            timer = 0;
            Destroy(gameObject);
        }
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            enemy.GetComponent<enemyHealth>().takeDamageEnemy(damage);
            Destroy(gameObject);
        }
        else if (other.CompareTag("Wall") || other.CompareTag("Ground") || other.CompareTag("Projectile") || other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
