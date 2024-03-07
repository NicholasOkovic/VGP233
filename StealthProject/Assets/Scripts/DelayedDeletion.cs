using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayedDeletion : MonoBehaviour
{

    [SerializeField] private float deletionTime;

    private void Awake()
    {
        Invoke(nameof(DestroyObject), deletionTime);
    }
    private void DestroyObject()
    {
        Destroy(gameObject, deletionTime);
    }

}
