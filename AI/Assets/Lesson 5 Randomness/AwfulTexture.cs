using UnityEngine;

public class AwfulTexture : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Texture2D texture = new Texture2D(128, 128);
        GetComponent<Renderer>().material.mainTexture = texture;
        for (int x = 0; x < 300; x++)
        {
            texture.SetPixel((int)AwfulRandomness.NextGaussian(64, 10, 0, 128),
                (int)AwfulRandomness.NextGaussian(64, 10, 0, 128),
                Color.black);
        }
        texture.Apply();
    }
}
