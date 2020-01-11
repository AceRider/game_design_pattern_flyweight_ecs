using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class SpawnProxy : MonoBehaviour, IDeclareReferencedPrefabs, IConvertGameObjectToEntity
{
    public GameObject cube;
    public int rows;
    public int cols;

    public void DeclareReferencedPrefabs(List<GameObject> gameObjects)
    {
        gameObjects.Add(cube);
    }

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        var spawerData = new Spawner
        {
            Prefab = conversionSystem.GetPrimaryEntity(cube),
            Erows = rows,
            Ecols = cols
        };
        dstManager.AddComponentData(entity, spawerData);
    }
}
