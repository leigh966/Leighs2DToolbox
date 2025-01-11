using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFieldBehviour : MonoBehaviour
{

    public Vector3 size;
    public float density, maxSize, minSize, posVariation;
    public GameObject objectToSpawnPrefab;

    List<GameObject> objList;
    public bool refresh = false;

    void Refresh()
    {
        Random.InitState((int)(size.x * size.y));
        foreach (GameObject obj in objList)
        {
            Destroy(obj);
        }
        objList = new List<GameObject>();

        for (float y = -size.y / 2f + maxSize; y < size.y / 2f; y += maxSize * 2f * 1f / density)
        {
            for (float x = -size.x / 2f + maxSize; x < size.x / 2f; x += maxSize * 2f * 1f / density)
            {
                var newObj = Instantiate(objectToSpawnPrefab, transform, false);
                newObj.transform.localPosition = new Vector3(x + Random.Range(-posVariation, posVariation), y + Random.Range(-posVariation, posVariation), 1f);
                newObj.transform.localScale = Vector3.one * Random.Range(minSize, maxSize);
                objList.Add(newObj);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        objList = new List<GameObject>();
        Refresh();
    }

    // Update is called once per frame
    void Update()
    {
        if( refresh )
        {
            Refresh();
            refresh = false;
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(transform.position, size);
    }
}
