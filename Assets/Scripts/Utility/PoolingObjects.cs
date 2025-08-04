using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class PoolingObject
{
    private readonly int PoolSize;

    private GameObject _preFab;
    private GameObject _parent;
    private Dictionary<bool, List<GameObject>> _objects = new Dictionary<bool, List<GameObject>>();

    public PoolingObject(int createCount, string prefabsPath, string objectName)
    {
        PoolSize = createCount;
        _preFab = Resources.Load<GameObject>(prefabsPath);
        GameObject found = GameObject.Find(objectName);
        if (found != null)
            _parent = found;
        else
            _parent = new GameObject(objectName);

        CreateObjects();
    }
    public PoolingObject(int createCount, GameObject prefabsObj, string objectName)
    {
        PoolSize = createCount;
        _preFab = prefabsObj;
        GameObject found = GameObject.Find(objectName);
        if (found != null)
            _parent = found;
        else
            _parent = new GameObject(objectName);

        CreateObjects();
    }

    public GameObject Objects
    {
        get 
        { 
            if(_objects[false].Count == 0)
                return _objects[true][0];
            else
                return _objects[false][0];
        }
    }

    public GameObject ActiveObject(Vector3 position, Quaternion rotation)
    {
        if (_objects[false].Count == 0) return null;

        GameObject obj = _objects[false][0];
        obj.SetActive(true);
        obj.transform.position = position;
        obj.transform.rotation = rotation;

        _objects[false].Remove(obj);
        _objects[true].Add(obj);
        return obj;
    }
    public GameObject ActiveObject(Vector3 position)
    {
        if (_objects[false].Count == 0) return null;

        GameObject obj = _objects[false][0];
        obj.SetActive(true);
        obj.transform.position = position;

        _objects[false].Remove(obj);
        _objects[true].Add(obj);
        return obj;
    }
    public GameObject ActiveObject()
    {
        if (_objects[false].Count == 0) return null;

        GameObject obj = _objects[false][0];
        obj.SetActive(true);

        _objects[false].Remove(obj);
        _objects[true].Add(obj);
        return obj;
    }
    public bool DisableObject(GameObject obj)
    {
        if (!_objects[true].Contains(obj)) return false;

        obj.SetActive(false);
        _objects[true].Remove(obj);
        _objects[false].Add(obj);
        return true;
    }
    private void CreateObjects()
    {
        _objects[true] = new List<GameObject>();
        _objects[true].Capacity = PoolSize;
        _objects[false] = new List<GameObject>();
        _objects[false].Capacity = PoolSize;


        for (int i = 0; i < PoolSize; i++)
        {
            GameObject obj = UnityEngine.Object.Instantiate(_preFab, _parent.transform);
            obj.SetActive(false);
            _objects[false].Add(obj);
        }
    }
}

