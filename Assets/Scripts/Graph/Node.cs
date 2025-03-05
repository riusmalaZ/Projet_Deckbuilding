using System.Collections.Generic;
using UnityEngine;

public class Node
{
    public Vector2Int _pos;
    public List<Node> previousNodes = new();

    public Node (Vector2Int Pos){
        Pos = _pos;
    }
}
