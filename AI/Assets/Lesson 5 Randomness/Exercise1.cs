/*
using UnityEngine;

//exercise1: create a random population of 100 characters whose height follows a normal distribution in unity.
//You can use any object to represent the characters such as cubes or cylinders
public class Exercise1 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private GameObject prefab;

    
    void Awake()
    {
        for (int i = 0; i < 100; i++)
        {
            float randomHeight = AwfulRandomness.NextGaussian(5,1,1,1);
            
            Vector3 newSize = new Vector3(i * 1.5f, 0, 0);
            GameObject newObject = Instantiate(prefab, newSize, Quaternion.identity);
        }
    }
}
*/
