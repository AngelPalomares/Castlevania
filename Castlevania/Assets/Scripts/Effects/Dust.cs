using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dust : MonoBehaviour
{
    private void OnDestroy()
    {
        Destroy(gameObject);
    }
}
