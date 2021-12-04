using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PickUpEvents : MonoBehaviour
{
  [SerializeField]  private UnityEvent _coinPicked;
    public static UnityEvent OnCoinPicked;

    private void Start()
    {
        OnCoinPicked = _coinPicked;
    }
}
