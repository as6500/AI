using UnityEngine;
//exercise1: create a random population of 100 characters whose height follows a normal distribution in unity.
//You can use any object to represent the characters such as cubes or cylinders
public class Exercise1 : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    
    void Awake()
    {
        SpawnGuys();
    }

    void SpawnGuys()
    {
        for (int i = 0; i < 100; i++)
        {
            float randomHeight = AwfulRandomness.NextGaussian(1.8f,0.25f,1f,2.6f);
            Vector3 position = new Vector3(i * 1.5f, 0, 0);
            GameObject newObject = Instantiate(prefab, position, Quaternion.identity);
            
            Vector3 scale = newObject.transform.localScale;
            scale.y = randomHeight;
            newObject.transform.localScale = scale;
        }
    }
}

