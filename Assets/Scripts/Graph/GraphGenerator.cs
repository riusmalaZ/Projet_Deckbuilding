using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class GraphGenerator : MonoBehaviour
{
    public Node[,] graph = new Node[5,7];
    Node lastNodeCreated;
    void Start()
    {
        int n = UnityEngine.Random.Range(0, 5);
        graph[n,0] = new Node(new Vector2Int(n, 0));

        CreateNextNode(graph[n, 0]);
    }

    void CreateNextNode(Node node)
    {
        if (node._pos.y == 6) return;

        bool nodeCreated = false;
        while (!nodeCreated)
        {
            for (int i = Math.Max(node._pos.x - 1, 0); i < Math.Min(node._pos.x + 1, 6); i++)
            {
                int n = UnityEngine.Random.Range(0, 10);
                if (n <= 3)
                {
                    
                    if (graph[i, node._pos.y + 1] == null)
                    {
                        
                        nodeCreated = true;
                        graph[i, node._pos.y + 1] = new Node(new Vector2Int(i, node._pos.y +1));
                        graph[i, node._pos.y + 1].previousNodes.Add(node);
                        print("node created on " + i + ", " +(node._pos.y + 1));
                        CreateNextNode(graph[i, node._pos.y + 1]);

                    }
                    //PROBLEME INFINI ICI : A LA DEUXIEME ITERATION DE LA FONCTION RECURSIVE YA IL VA TOUJOURS DANS LE ELSE (CONDITION DU DESSUS JAMAIS VALIDE)
                    else 
                    {
                        graph[i, node._pos.y + 1].previousNodes.Add(node);
                    }
                }
            }
        }
    }

    // List<Vector2Int> PossibleNextNodes(Vector2Int node._pos)
    // {
    //     List<Vector2Int> posNextNodes = new();

    //     int n = (int)UnityEngine.Random.Range(Math.Max(node._pos.x - 1, 0), Math.Min(node._pos.x + 1, 6));
    // }

    // Update is called once per frame
    void Update()
    {
        
    }
}
