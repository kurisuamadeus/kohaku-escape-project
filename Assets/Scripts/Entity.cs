using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public float speed;
    public float speedMultiplier = 1f;
    [SerializeField]
    protected Animator anim;
}
