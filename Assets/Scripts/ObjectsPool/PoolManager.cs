using System;
using System.Collections.Generic;
using UnityEngine;

public static class PoolManager
{
	static List<ObjectsPool> pools;

	public static void AddObjectsPool(ObjectsPool objectsPool)
    {
        if (objectsPool is null)
            throw new ArgumentNullException(nameof(objectsPool));

        if (pools == null)
            pools = new List<ObjectsPool>();
        pools.Add(objectsPool);
    }
	public static void RemoveObjectsPool(ObjectsPool objectsPool)
	{
		if (pools != null)
			pools.Remove(objectsPool);
	}

	public static GameObject GetGameObject(string name, Vector3 position)
	{
		GameObject gameObject = null;
		for (int i = 0; i < pools?.Capacity; i++)
			if (pools[i].ObjectName == name)
			{
				gameObject = pools[i].GetObject();
				gameObject.transform.position = position;
				gameObject.SetActive(true);
				break;
			}
		if (gameObject == null)
			throw new System.ArgumentException("No gameObject with such name was found", name);
		return gameObject;
	}
}
