using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Semantic.Traits;
using Unity.Entities;
using UnityEngine;

namespace Generated.Semantic.Traits
{
    [ExecuteAlways]
    [DisallowMultipleComponent]
    [AddComponentMenu("Semantic/Traits/cop (Trait)")]
    [RequireComponent(typeof(SemanticObject))]
    public partial class cop : MonoBehaviour, ITrait
    {
        public System.Boolean Ready2steal
        {
            get
            {
                if (m_EntityManager != default && m_EntityManager.HasComponent<copData>(m_Entity))
                {
                    m_p0 = m_EntityManager.GetComponentData<copData>(m_Entity).Ready2steal;
                }

                return m_p0;
            }
            set
            {
                copData data = default;
                var dataActive = m_EntityManager != default && m_EntityManager.HasComponent<copData>(m_Entity);
                if (dataActive)
                    data = m_EntityManager.GetComponentData<copData>(m_Entity);
                data.Ready2steal = m_p0 = value;
                if (dataActive)
                    m_EntityManager.SetComponentData(m_Entity, data);
            }
        }
        public copData Data
        {
            get => m_EntityManager != default && m_EntityManager.HasComponent<copData>(m_Entity) ?
                m_EntityManager.GetComponentData<copData>(m_Entity) : GetData();
            set
            {
                if (m_EntityManager != default && m_EntityManager.HasComponent<copData>(m_Entity))
                    m_EntityManager.SetComponentData(m_Entity, value);
            }
        }

        #pragma warning disable 649
        [SerializeField]
        [InspectorName("Ready2steal")]
        System.Boolean m_p0 = true;
        #pragma warning restore 649

        EntityManager m_EntityManager;
        World m_World;
        Entity m_Entity;

        copData GetData()
        {
            copData data = default;
            data.Ready2steal = m_p0;

            return data;
        }

        
        void OnEnable()
        {
            // Handle the case where this trait is added after conversion
            var semanticObject = GetComponent<SemanticObject>();
            if (semanticObject && !semanticObject.Entity.Equals(default))
                Convert(semanticObject.Entity, semanticObject.EntityManager, null);
        }

        public void Convert(Entity entity, EntityManager destinationManager, GameObjectConversionSystem _)
        {
            m_Entity = entity;
            m_EntityManager = destinationManager;
            m_World = destinationManager.World;

            if (!destinationManager.HasComponent(entity, typeof(copData)))
            {
                destinationManager.AddComponentData(entity, GetData());
            }
        }

        void OnDestroy()
        {
            if (m_World != default && m_World.IsCreated)
            {
                m_EntityManager.RemoveComponent<copData>(m_Entity);
                if (m_EntityManager.GetComponentCount(m_Entity) == 0)
                    m_EntityManager.DestroyEntity(m_Entity);
            }
        }

        void OnValidate()
        {

            // Commit local fields to backing store
            Data = GetData();
        }

#if UNITY_EDITOR
        void OnDrawGizmos()
        {
            TraitGizmos.DrawGizmoForTrait(nameof(copData), gameObject,Data);
        }
#endif
    }
}
