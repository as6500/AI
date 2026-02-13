using UnityEngine;

public class AIAgent : MonoBehaviour
{
    //create a function to find the closest node to use as starts and goal nodes.
    private Graph graph;
    
    [SerializeField] private GraphNode startNode;
    [SerializeField] private GraphNode goalNode;
    private void Awake()
    {
        graph = FindFirstObjectByType<Graph>();
        var listOfNodesThatWeShouldVisit = graph.FindPath(startNode, goalNode);
        foreach (GraphNode node in listOfNodesThatWeShouldVisit)
        {
            Debug.Log(node.name, node.gameObject);
        }
    }
    
    //homework: create a context menu that makes sure that all nodes have a connection both ways
    //homework: move character to start node and make it do the path
    //homework: raycast (ray from one point to the other) from the sky to the ground and check where is colliding to the terrain and adding nodes automatically and not colliding with the wall.
}
