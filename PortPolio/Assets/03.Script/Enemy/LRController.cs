using UnityEngine;

public class LRController : MonoBehaviour
{
    Move fire;

    public float leftPosition;
    public float RightPosition;

    void Start()
    {
        fire = GetComponentInChildren<Move>();
    }

    void Update()
    {
        if (fire.transform.localPosition.x <= leftPosition) fire.direction = -1;
        else if(fire.transform.localPosition.x >= RightPosition) fire.direction = 1;
    }
}
