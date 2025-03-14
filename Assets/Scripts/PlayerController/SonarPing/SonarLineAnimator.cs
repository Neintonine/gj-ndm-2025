using System;
using UnityEngine;

namespace Developer.Michel.Scripts.Sonar
{
    public sealed class SonarLineAnimator : MonoBehaviour
    {
        private static readonly int ALPHA = Shader.PropertyToID("_Alpha");

        [Range(0f, 1f)]
        public float Alpha = 1;

        public bool Destory = false;
        
        [SerializeField] private LineRenderer lineRenderer;
        
        private void Update()
        {
            this.lineRenderer.material.SetFloat(ALPHA, this.Alpha);

            if (this.Destory)
            {
                Destroy(this.gameObject);
            }
        }
    }
}