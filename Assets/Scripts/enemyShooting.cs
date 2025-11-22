using Unity.Mathematics;
using UnityEngine;

public class enemyShooting : MonoBehaviour
{

    public GameObject projectile;
    public Transform projectileStartPos;

    private float timer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 2)
        {
            timer = 0;
            shoot();
        }
    }
    
    private void shoot()
    {
        Instantiate(projectile, projectileStartPos.position, quaternion.identity);

    }
}
