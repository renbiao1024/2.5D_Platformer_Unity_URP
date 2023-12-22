using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer_Game
{
    public enum TransitionParameter
    {
        Move,
        Jump,
        ForceTransition,
        Grounded,
    }
    public class CharacterControl : MonoBehaviour
    {
        [SerializeField] Material material;
        public bool MoveRight;
        public bool MoveLeft;
        public bool Jump;
        private Rigidbody rb;
        public Rigidbody RB
        {
            get
            {
                if(rb == null)
                    rb = GetComponent<Rigidbody>();
                return rb;
            }
        }
        [HideInInspector] public List<GameObject> bottomSphereLst = new List<GameObject>();
        [HideInInspector] public List<GameObject> frontSphereLst = new List<GameObject>();
        [SerializeField] GameObject colliderEdgePrefab;

        void Awake()
        {
            var box = GetComponent<BoxCollider>();
            var center = box.bounds.center;
            var extents = box.bounds.extents;
            float bottom = center.y - extents.y;
            float top = center.y + extents.y;
            float back = center.x - extents.x;
            float front = center.x + extents.x;

            CreateBottomEdgeSphere(back, front, bottom, 4);
            CreateForwardEdgeSphere(bottom, top, front, 8);

        }

        void CreateBottomEdgeSphere(float back, float front, float bottom, int count)
        {
            Vector3 bottomBack = new Vector3(back, bottom, 0f);
            Vector3 bottomFront = new Vector3(front, bottom, 0f);
            GameObject bottomBackSphere = CreateEdgeSphere(bottomBack);
            bottomBackSphere.transform.parent = transform;
            bottomSphereLst.Add(bottomBackSphere);
            var delta = (front - back) / count;
            for (int i = 1; i < count; ++i)
            {
                GameObject go = CreateEdgeSphere(new Vector3(back + i * delta, bottom, 0f));
                go.transform.parent = transform;
                bottomSphereLst.Add(go);
            }
            GameObject bottomFrontSphere = CreateEdgeSphere(bottomFront);
            bottomFrontSphere.transform.parent = transform;
            bottomSphereLst.Add(bottomFrontSphere);
            frontSphereLst.Add(bottomFrontSphere);
        }

        void CreateForwardEdgeSphere(float bottom, float top, float front, int count)
        {
            Vector3 frontTop = new Vector3(front, top, 0f);

            var delta = (top - bottom) / count;
            for (int i = 1; i < count; ++i)
            {
                GameObject go = CreateEdgeSphere(new Vector3(front, bottom + i * delta, 0f));
                go.transform.parent = transform;
                frontSphereLst.Add(go);
            }
            GameObject frontTopSphere = CreateEdgeSphere(frontTop);
            frontTopSphere.transform.parent = transform;
            bottomSphereLst.Add(frontTopSphere);
        }

        GameObject CreateEdgeSphere(Vector3 pos)
        {
            GameObject obj = Instantiate(colliderEdgePrefab, pos, Quaternion.identity);
            return obj;
        }

        public void ChangeMaterial()
        {
            if(material == null)
            {
                Debug.LogError("no material specified");
                return;
            }

            Renderer[] arrMaterial = gameObject.GetComponentsInChildren<Renderer>();

            foreach(var  renderer in arrMaterial)
            {
                renderer.material = material;
            }
        }
    }

}
