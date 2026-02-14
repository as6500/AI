using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Graph : MonoBehaviour
{
    public GraphNode[] Nodes;

    //this is a simple heuristic, calculate the distance between two nodes
    private float Heuristic(GraphNode a, GraphNode b)
    {
        return Vector3.Distance(a.transform.position, b.transform.position);
    }
    
    [ContextMenu("Find All Nodes")]
    public void FindAllNode()
    {
        Debug.Log("Finding all nodes...");
        Nodes = FindObjectsByType<GraphNode>(FindObjectsSortMode.None);
        //mark as dirty so it shows if it needs to be saved
        UnityEditor.EditorUtility.SetDirty(this);
    }

    private void OnValidate() //this is bad for performance, but every time there's a change on the scene it will call it
    {
        FindAllNode();
    }
    
      private List<GraphNode> ReconstructPath(Dictionary<GraphNode, GraphNode> cameFrom, GraphNode current,
        GraphNode start)
    {
        List<GraphNode> totalPath = new List<GraphNode>();
        totalPath.Add(current);
        while (current != start)
        {
            if (!cameFrom.TryGetValue(current, out GraphNode previous))
                return new List<GraphNode>();

            current = previous;
            totalPath.Add(current);
        }

        totalPath.Reverse();
        return totalPath;
    }

    public List<GraphNode> FindPath(GraphNode start, GraphNode goal)
    {
        if (start == null || goal == null)
            return new List<GraphNode>();

        HashSet<GraphNode> closedNodes = new HashSet<GraphNode>();
        PriorityQueue<GraphNode> openNodes = new PriorityQueue<GraphNode>();

        openNodes.Enqueue(start, Heuristic(start, goal)); //throw the first node to the queue so it can be explored

        Dictionary<GraphNode, GraphNode> cameFrom = new Dictionary<GraphNode, GraphNode>();
        Dictionary<GraphNode, float> gScore = new Dictionary<GraphNode, float>();  //gscore is the cost of jumping cost + heuristic
        gScore[start] = 0;

        while (openNodes.Count > 0) //contains all nodes to explore, if not zero there more to explore, cycling until we find location or have no nodes to explore
        {
            GraphNode current = openNodes.Dequeue();
            if (!closedNodes.Add(current)) //if i was already here i dont want to go here
                continue;

            if (current == goal) // yay!
                return ReconstructPath(cameFrom, current, start);

            if (current.Edges == null) //dont care about it
                continue;

            foreach (GraphNode neighbor in current.Edges) 
            {
                if (neighbor == null || closedNodes.Contains(neighbor)) //keep going if its a closed node(already visited) or if there's no edge to go to 
                    continue;

                float tentativeGScore = gScore[current] + Heuristic(current, neighbor);

                if (gScore.TryGetValue(neighbor, out float existingGScore) && tentativeGScore >= existingGScore) //dont consider the node if the value is bigger than a smaller one
                    continue;

                cameFrom[neighbor] = current;
                gScore[neighbor] = tentativeGScore;

                float priority = tentativeGScore + Heuristic(neighbor, goal);
                if (openNodes.Contains(neighbor))
                    openNodes.UpdatePriority(neighbor, priority);
                else
                    openNodes.Enqueue(neighbor, priority);
            }
        }

        return new List<GraphNode>();
    }
    [ContextMenu("Ensure Bidirectional Connections")]
    public void EnsureBidirectionalConnections()
    {
        if (Nodes == null || Nodes.Length == 0)
        {
            Debug.LogWarning("No nodes found to process.");
            return;
        }

        int addedConnections = 0;

        foreach (GraphNode node in Nodes)
        {
            if (node.Edges == null) continue;

            foreach (GraphNode neighbor in node.Edges)
            {
                if (neighbor == null) continue;

                // If the neighbor does not already have this node as an edge, add it
                bool alreadyConnected = false;
                if (neighbor.Edges != null)
                {
                    foreach (GraphNode n in neighbor.Edges)
                    {
                        if (n == node)
                        {
                            alreadyConnected = true;
                            break;
                        }
                    }
                }

                if (!alreadyConnected)
                {
                    // Create new edge array with extra slot
                    int oldLength = neighbor.Edges != null ? neighbor.Edges.Length : 0;
                    GraphNode[] newEdges = new GraphNode[oldLength + 1];
                    if (neighbor.Edges != null)
                        neighbor.Edges.CopyTo(newEdges, 0);
                    newEdges[oldLength] = node;
                    neighbor.Edges = newEdges;

                    addedConnections++;
                }
            }
        }

        Debug.Log($"Bidirectional connections ensured. {addedConnections} new connections added.");

        // Mark scene dirty so changes are saved
        EditorUtility.SetDirty(this);
    }
}
