using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDestroy : MonoBehaviour
{
    [SerializeField]
    private float destroyTime = 2.0f;

    void Start()
    {
        Destroy(gameObject, destroyTime);
    }
}
