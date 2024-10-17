using System;
using UnityEngine;

namespace Physics
{
    public class JellySimulation : MonoBehaviour
    {
        [SerializeField] private float intensity = 1f;
        [SerializeField] private float mass = 1f;
        [SerializeField] private float stiffness = 1f;
        [SerializeField] private float damping = 0.75f;
        
        private Mesh _originalMesh;
        private Mesh _meshClone;
        private MeshRenderer _meshRenderer;
        private JellyVertex[] _jellyVertices;
        private Vector3[] vertexArray;
        private void Start()
        {
            _originalMesh = GetComponent<MeshFilter>().sharedMesh;
            _meshClone = Instantiate(_originalMesh);
            GetComponent<MeshFilter>().sharedMesh = _meshClone;
            _meshRenderer = GetComponent<MeshRenderer>();

            _jellyVertices = new JellyVertex[_meshClone.vertices.Length];
            for (int i = 0; i < _meshClone.vertices.Length; i++)
            {
                _jellyVertices[i] = new JellyVertex(i, transform.TransformPoint(_meshClone.vertices[i]));
            }
        }
        private void FixedUpdate()
        {
            vertexArray = _originalMesh.vertices;
            for (int i = 0; i < _jellyVertices.Length; i++)
            {
                var target = transform.TransformPoint(vertexArray[_jellyVertices[i].ID]);
                var updatedIntensity = (1 - (_meshRenderer.bounds.max.y - target.y) 
                                           / _meshRenderer.bounds.size.y) * intensity;
                
                _jellyVertices[i].Shake(target, mass, stiffness, damping);
                target = transform.InverseTransformPoint(_jellyVertices[i].Position);
                vertexArray[_jellyVertices[i].ID] = Vector3.Lerp(vertexArray[_jellyVertices[i].ID], target, updatedIntensity);
            }
            _meshClone.vertices = vertexArray;
        }
        
    }
}
