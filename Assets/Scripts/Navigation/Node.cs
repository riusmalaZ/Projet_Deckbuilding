using System.Collections.Generic;
using UnityEngine;

public enum NodeType { Start, Combat, Shop, Treasure, Boss }

public class Node
{
    public int Layer; // position horizontale
    public int Column; // position verticale
    public NodeType Type;
    public List<Node> Neighbors = new List<Node>();
    public bool Visited; 
}

public class Graph
{
    public List<List<Node>> Layers = new List<List<Node>>(); // stocker les profondeurs
}
