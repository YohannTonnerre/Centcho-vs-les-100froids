using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stairs : MonoBehaviour
{
    public float coef;
    private Dictionary<string, Vector3> gameObjectsLastPosition = new Dictionary<string, Vector3>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("Trigger");
        GameObject obj = other.gameObject;

        if (gameObjectsLastPosition.ContainsKey(obj.name))
        {
            Vector3 lastPosition;
            bool succes = gameObjectsLastPosition.TryGetValue(obj.name, out lastPosition);
            if (succes)
            {
                float xDiff = lastPosition.x - obj.transform.position.x;
                obj.transform.position += new Vector3(0, coef * xDiff, 0);
                Debug.Log(lastPosition.x + " " +  obj.transform.position.x);
            }
        }
        gameObjectsLastPosition.Remove(obj.name);
        gameObjectsLastPosition.Add(obj.name, obj.transform.position);
    }
}
