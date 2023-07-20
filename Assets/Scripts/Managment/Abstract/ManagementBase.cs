using System.Collections;
using UnityEngine;

namespace PowTask.Management
{
    public abstract class ManagementBase : MonoBehaviour
    {
        protected abstract IEnumerator InitProgress();
        
        // ReSharper disable Unity.PerformanceAnalysis
        public IEnumerator Init()
        {
            yield return InitProgress();
        }
    }
}
