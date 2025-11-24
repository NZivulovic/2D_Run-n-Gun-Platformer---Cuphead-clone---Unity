using Unity.Mathematics;
using UnityEngine;

public class enemyShooting : MonoBehaviour
{

    public GameObject projectile;
    public Transform projectileStartPos;
    public Transform projectileStartPos1;
    public Transform projectileStartPos2;

    private float timer;
    
    public float fireRate;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > fireRate)
        {
            shoot();
            timer = 0;
        }
    }
    
    private void shoot()
    {
        Instantiate(projectile, projectileStartPos.position, quaternion.identity);

        Instantiate(projectile, projectileStartPos1.position, quaternion.identity);

        Instantiate(projectile, projectileStartPos2.position, quaternion.identity);

    }
}
