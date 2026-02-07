using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private float speed = 0.1f;
    
    void Awake()
    {
        Debug.Log("Hello World!");
    }
    void Start()
    {
        Debug.Log("Start!");
    }

    void OnPunch()
    {
        Debug.Log("Get his ass!");
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position += new Vector3(speed, 0, 0);
        
    }
}
