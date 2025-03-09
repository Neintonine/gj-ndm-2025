using System;
using UnityEngine;

namespace Developer.Michel.Scripts
{
    public sealed class Drop : MonoBehaviour
    {
        private void Update()
        {
            transform.Translate(Vector3.down * Time.deltaTime);
        }
    }
}