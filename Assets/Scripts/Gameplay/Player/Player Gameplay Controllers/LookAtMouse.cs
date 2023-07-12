using PowTask.Management;
using PowTask.ScriptableScripts;
using UnityEngine;

namespace PowTask.Gameplay.Player
{
    public class LookAtMouse : MonoBehaviour
    {
        [SerializeField] private PlayerDataSO playerDataSo;
        private Collider[] hitColliders;
        [SerializeField] private float radius = 3f;
        [SerializeField] private LayerMask enemyLayer;
        
        void Update()
        {
            hitColliders = Physics.OverlapSphere(transform.position, radius, enemyLayer);

            if (hitColliders.Length > 0)
            {
                transform.LookAt(hitColliders[0].gameObject.transform);
                playerDataSo.BulletRotation = transform.rotation;
            }
            else
            {
                var dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
                var angle = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.up);
                playerDataSo.BulletRotation = transform.rotation;
            }
        }

        //private void OnDrawGizmos()
        //{
        //    Gizmos.color = Color.yellow;
        //    Gizmos.DrawSphere(transform.position, radius);
        //}
    }
}