using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
using UnityEditor;

public class BaseMonster : MonoBehaviour
{
    public float health;

    public BehaviorTree behaviorTree;

    private LayerMask garbageLayer;

    private void Awake()
    {
        behaviorTree = GetComponent<BehaviorTree>(); // BehaviorTree 컴포넌트를 찾음
    }

    private void Start()
    {
        garbageLayer = LayerMask.GetMask("Garbage");
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        Debug.Log($"Health: {health}");
    }

    protected void Update()
    {
        if (behaviorTree != null && behaviorTree.GetVariable("health") != null)
        {
            behaviorTree.SetVariableValue("health", health);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(IsInLayerMask(other.gameObject, garbageLayer))
        {
            // 몬스터의 체력을 감소
            TakeDamage(1);

            // 충돌한 투척물 제거
            Destroy(other.gameObject);
        }
    }

    public bool IsInLayerMask(GameObject obj, LayerMask layerMask)
    {
        return (layerMask.value & (1 << obj.layer)) > 0;
    }
}
