using System.Threading;
using Unity.Mathematics;
using UnityEngine;

public class enemyProjectile : MonoBehaviour
{

    private Rigidbody2D rb;
    private GameObject player;

    public float force;
    private float timer;

    public int damage;

    public float despawnAfterSeconds;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        Vector3 direction = player.transform.position - transform.position;
        rb.linearVelocity = new Vector2(direction.x, direction.y).normalized * force;

        float rotation = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = quaternion.Euler(0, 0, rotation);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > despawnAfterSeconds)
        {
            timer = 0;
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player.GetComponent<playerHealth>().takeDamage(damage);
            Destroy(gameObject);
        }
        else if (collision.CompareTag("Ground") || collision.CompareTag("Wall") || collision.CompareTag("playerProjectile"))
        {
            Destroy(gameObject);
        }
    }
}
