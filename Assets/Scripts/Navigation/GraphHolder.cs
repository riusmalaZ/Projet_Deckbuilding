using UnityEngine;
public class GraphHolder : MonoBehaviour
{
    public static GraphHolder Instance;

    public Graph CurrentGraph;
    public Node CurrentNode;
    public Vector2 PlayerPosition;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}