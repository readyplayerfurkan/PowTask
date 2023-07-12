using System.Collections;
using UnityEngine;

namespace PowTask.Management
{
    public abstract class ManagementBase : MonoBehaviour
    {
        public abstract IEnumerator InitProgress();
        
        public IEnumerator Init()
        {
            yield return InitProgress();
        }
    }
}
