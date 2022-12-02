using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawRay : MonoBehaviour
{
    LineRenderer lineRenderer;
    public float linewidth;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.startWidth = linewidth;
        lineRenderer.endWidth = linewidth;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = PlayerC.Instance.transform.position - transform.position;

        //== 타겟 방향으로 회전함 ==//
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);

        //라인렌더러
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, PlayerC.Instance.transform.position);
    }
}
