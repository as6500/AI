using UnityEngine;

//exercise 2 step1: write a small script that runs on Awake function and generates 100 random 0 or 1 numbers. It
//should have a 50 % chance of each
//step2: take out a coin and start flipping it, recording the sequence of heads and tails as 0s and 1s. 
//Flip it 100 times and write the results.
//step3: compare the two lists you made that have the same 50% chance of either 0 or 1. what are the
//differences between the hand-generated list, the coin flip list and the computer generated one?
public class randomnessExercise2 : MonoBehaviour
{
    private int[] randomList = new int[100];
    private int[] coinFlipList = new int[100];
    void Awake()
    {
        //make 100 1s or 0s
        for (int i = 0; i < 100; i++)
        {
            randomList[i] = FlipCoin();
        }
        
        for (int i = 0; i < 100; i++)
        {
            coinFlipList[i] = FlipCoin();
        }
        
        Debug.Log("Random List:");
        PrintList(randomList);

        Debug.Log("Coin Flip List:");
        PrintList(coinFlipList);
    }

    int FlipCoin()
    {
        float gaussianValue = AwfulRandomness.NextGaussian(0f, 1f);
        return (gaussianValue >= 0) ? 1 : 0;
    }
    
    void PrintList(int[] list)
    {
        string result = "";
        foreach (var value in list)
        {
            result += value + " ";
        }
        Debug.Log(result);
    }
}
