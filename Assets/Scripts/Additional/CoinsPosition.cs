using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsPosition : MonoBehaviour
{

    [SerializeField] private GameObject _prefab;
    [SerializeField] Vector2Int _rowsColums = Vector2Int.one;
    [SerializeField] Vector2 _offset = Vector2.one;

    [ContextMenu("InstatiateAsPrefab")]
    void InstatiateAsPrefab()
    {
#if UNITY_EDITOR
        for (int x = 0; x < _rowsColums.x; x++)
        {
            for (int y = 0; y < _rowsColums.y; y++)
            {
                var instance = (UnityEditor.PrefabUtility.InstantiatePrefab(_prefab) as GameObject).transform;

                instance.SetParent(transform);

                Vector3 offset = new Vector3(_offset.x, 0, _offset.y);

                instance.localPosition = Vector3.Scale(new Vector3(x, 0, y), offset);
            }
        }
#endif
    }
}
