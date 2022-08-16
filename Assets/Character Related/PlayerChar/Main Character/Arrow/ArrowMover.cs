using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ArrowMover : MonoBehaviour
{
    void Awake()
    {
        transform.DOShakePosition(1f, strength: new Vector3(0, 0.2f, 0), vibrato: 5, randomness: 1, snapping: false, fadeOut: true);
    }
}
