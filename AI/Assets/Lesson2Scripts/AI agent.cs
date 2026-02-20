using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIAgent : MonoBehaviour
{
    
    //create a function to find the closest node to use as starts and goal nodes.
    //private Graph graph;
    
    [SerializeField] private GraphNode startNode;
    [SerializeField] private GraphNode goalNode;
    [SerializeField] private NavMeshAgent agent;
    public List<Transform> goals;
    public Transform goal;

    void Update()
    {
        if (goal == null && goals.Count >= 0)
        {
            goal = goals[0];
            goals.RemoveAt(0);
            agent.destination = goal.position;
        }

        if (agent.remainingDistance < 0.5f && agent != null)
        {
            goal = null;
        }
    }
    
    //fazer uma lista de goals

    //private float speed = 5f;
    //private Rigidbody rb;
    //private void Awake()
    //{
        //freeze physics
        //rb = GetComponent<Rigidbody>();
        //if (rb != null)
        //{
        //rb.constraints = RigidbodyConstraints.FreezeRotationX | 
        //RigidbodyConstraints.FreezeRotationZ | 
        //RigidbodyConstraints.FreezePositionY;
        //}
        //
        
        //graph = FindFirstObjectByType<Graph>();
        //var listOfNodesThatWeShouldVisit = graph.FindPath(startNode, goalNode);
        //foreach (GraphNode node in listOfNodesThatWeShouldVisit)
        //{
        //Debug.Log(node.name, node.gameObject);
        //}
        //StartCoroutine(MoveToStartNode(startNode, speed));
        //}
    
        //private IEnumerator MoveToStartNode(GraphNode startNode, float speed)
        //{
        //while (Vector3.Distance(transform.position, startNode.transform.position) > 0.1f)
        //{
        //transform.position = Vector3.MoveTowards(
        //transform.position, 
        //startNode.transform.position, 
        //speed * Time.deltaTime
        //);
        //transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);

        //yield return null; // wait for next frame
        //}
        //transform.position = startNode.transform.position;
        //transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
        //Debug.Log("Reached the start node!");
        //StartCoroutine(FollowPath(graph.FindPath(startNode, goalNode), speed));

        //}
    
        //private IEnumerator FollowPath(List<GraphNode> path, float speed)
        //{
        //foreach (GraphNode node in path)
        //{
            // Skip null nodes just in case
            //if (node == null) 
            //continue;

            //while (Vector3.Distance(transform.position, node.transform.position) > 0.1f)
            //{
            //transform.position = Vector3.MoveTowards(
            //transform.position,
            //node.transform.position,
            //speed * Time.deltaTime
            //);

                // Keep upright
                //transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);

                //yield return null;
                //}

            // Snap exactly
            //transform.position = node.transform.position;
            //transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
            //}

            //Debug.Log("Reached the goal node!");
            //}

    
    //homework: create a context menu that makes sure that all nodes have a connection both ways
    //homework: move character to start node and make it do the path
    //homework: raycast (ray from one point to the other) from the sky to the ground and check where is colliding to the terrain and adding nodes automatically and not colliding with the wall.
}
