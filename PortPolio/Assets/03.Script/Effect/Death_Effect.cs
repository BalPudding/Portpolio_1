using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death_Effect : MonoBehaviour
{ void Update()
    {
        transform.Translate(Vector2.up * 6f * Time.deltaTime);
    }
}
