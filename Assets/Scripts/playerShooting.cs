using Unity.Mathematics;
using UnityEngine;

public class playerShooting : MonoBehaviour
{
    public GameObject projectile;

    public RectTransform projectileStartPosX;
    public RectTransform projectileStartPosXleft;
    public RectTransform projectileStartPosXright;

    public RectTransform projectileStartPosYleft;

    public RectTransform projectileStartPosYright;

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
        if(timer > fireRate){
        shoot();
        }
    }
    
    private void shoot()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && Input.GetKey(KeyCode.RightArrow))
        {
            Instantiate(projectile, projectileStartPosXright.position, quaternion.identity);
            timer = 0;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && Input.GetKey(KeyCode.LeftArrow))
        {
            Instantiate(projectile, projectileStartPosXleft.position, quaternion.identity);
            timer = 0;
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            Instantiate(projectile, projectileStartPosX.position, quaternion.identity);
            timer = 0;
        }
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.UpArrow))
        {
            Instantiate(projectile, projectileStartPosYleft.position, quaternion.identity);
            timer = 0;
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.UpArrow))
        {
            Instantiate(projectile, projectileStartPosYright.position, quaternion.identity);
            timer = 0;
        }
    }
    
}
