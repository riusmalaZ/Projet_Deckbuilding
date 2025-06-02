using UnityEngine;
using System.Collections.Generic;

public class GraphGenerator : MonoBehaviour
{
    [SerializeField] int _depth = 6;        // longueur
    [SerializeField] int _width = 3;        // largeur
    [SerializeField] float _connectionChance = 0.6f;
    [SerializeField] float _nodeSpawnChance = 0.66f;

    public Graph Generate()
    {
        Graph graph = new Graph();

        // création des nodes
        for (int i = 0; i < _depth; i++)
        {
            List<Node> layer = new List<Node>();

            // unique node en haut et en bas
            if (i == 0 || i == _depth - 1)
            {
                Node node = new Node { Layer = i, Column = _width / 2 };
                layer.Add(node);
            }
            else
            {
                for (int j = 0; j < _width; j++)
                {
                    if (Random.value < _nodeSpawnChance)
                    {
                        Node node = new Node { Layer = i, Column = j };
                        layer.Add(node);
                    }
                }

                // on verifie qu'au moins un noeud existe sur la largeur
                if (layer.Count == 0)
                {
                    Node node = new Node { Layer = i, Column = _width / 2 };
                    layer.Add(node);
                }
            }

            graph.Layers.Add(layer);
        }

        // liens
        for (int i = 0; i < _depth - 1; i++)
        {
            List<Node> current = graph.Layers[i];
            List<Node> next = graph.Layers[i + 1];

            foreach (Node node in current)
            {
                if (i == 0)
                {
                    foreach (Node target in next)
                    {
                        node.Neighbors.Add(target);
                    }
                }

                else
                {
                    foreach (Node target in next)
                    {
                        int colDiff = Mathf.Abs(node.Column - target.Column);
                        if (colDiff <= 1 && Random.value < _connectionChance)
                        {
                            node.Neighbors.Add(target);
                        }
                    }
                }

                // verifie qu'au moins une connexion est créé
                if (node.Neighbors.Count == 0)
                {
                    // cherche les autres nodes sur sa colonne, la colonne -1 et la +1
                    List<Node> candidates = next.FindAll(n =>
                        Mathf.Abs(n.Column - node.Column) <= 1);

                    if (candidates.Count > 0)
                        node.Neighbors.Add(candidates[Random.Range(0, candidates.Count)]);
                    else
                        node.Neighbors.Add(next[Random.Range(0, next.Count)]); // fallback
                }
            }
        }

        //on marque les nodes toute reliée directement ou indirectement par la node de start
        MarkReachableNodes(graph.Layers[0][0]);
        // on supprime les non marquées car elles ne sont pas reliées au start (donc inaccessible)
        RemoveUnreachableNodes(graph);
        // on cree les types des nodes
        AssignTypes(graph);
        
        return graph;
    }

    void AssignTypes(Graph graph)
    {
        foreach (var layer in graph.Layers)
        {
            foreach (var node in layer)
            {
                node.Type = GetRandomNodeType(node.Layer, graph.Layers.Count);
            }
        }

        // Dernier nœud est toujours un boss
        foreach (var node in graph.Layers[^1])
        {
            node.Type = NodeType.Boss;
        }
    }

    NodeType GetRandomNodeType(int layer, int totalLayers)
    {

        if (layer == 0)
            return NodeType.Start;

        if (layer == totalLayers - 1)
            return NodeType.Boss;

        // Exemple simple de pondération
        float rand = Random.value;
        if (rand < 0.5f) return NodeType.Combat;
        if (rand < 0.75f) return NodeType.Treasure;
        return NodeType.Shop;
    }
    void MarkReachableNodes(Node start)
    {
        
        Queue<Node> queue = new Queue<Node>();
        start.Visited = true;
        queue.Enqueue(start);

        while (queue.Count > 0)
        {
            Node current = queue.Dequeue();
            foreach (var neighbor in current.Neighbors)
            {
                if (!neighbor.Visited)
                {
                    neighbor.Visited = true;
                    queue.Enqueue(neighbor);
                }
            }
        }
    }
    private void RemoveUnreachableNodes(Graph graph)
    {
        foreach (var layer in graph.Layers)
        {
            layer.RemoveAll(node => !node.Visited);
        }

        // Nettoie les liens vers des nœuds supprimés
        foreach (var layer in graph.Layers)
        {
            foreach (var node in layer)
            {
                node.Neighbors.RemoveAll(n => !n.Visited);
            }
        }
    }

}
