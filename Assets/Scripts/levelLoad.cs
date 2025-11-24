using UnityEngine;
using UnityEngine.SceneManagement;

public class levelLoad : MonoBehaviour
{
    public GameObject bossDead;

    public GameObject levelExitObj;
    // public Collider2D levelExitCollider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (bossDead == null){
            levelExitObj.SetActive(true);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")){
            SceneManager.LoadScene(0, LoadSceneMode.Single);
        }
    }


}
