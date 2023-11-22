using UnityEngine;


namespace Heyipomoea
{
    /// <summary>
    /// 打擊系統
    /// </summary>
    public class HitSystem : MonoBehaviour
    {
        [SerializeField, Header("上方區域位移")]
        private Vector3 offsetUp;
        [SerializeField, Header("上方區域尺寸")]
        private Vector3 sizeUp = Vector3.one;
        [SerializeField, Header("下方區域位移")]
        private Vector3 offsetDown;
        [SerializeField, Header("下方區域尺寸")]
        private Vector3 sizeDown = Vector3.one;
        [SerializeField, Header("可以打擊圖層")]
        private LayerMask layerHit;

        private Vector3 pointUp => transform.position + transform.TransformDirection(offsetUp);
        private Vector3 pointDown => transform.position + transform.TransformDirection(offsetDown);

        private bool isHitUp;

        private void OnDrawGizmos()
        {
            Gizmos.matrix = Matrix4x4.TRS(
                pointUp, 
                transform.rotation, 
                transform.localScale);

            Gizmos.color = new Color(0.5f, 1, 0.5f, 0.7f);
            Gizmos.DrawCube(Vector3.zero, sizeUp);

            Gizmos.matrix = Matrix4x4.TRS(
                pointDown,
                transform.rotation,
                transform.localScale);

            Gizmos.color = new Color(0.8f, 0.8f, 0.5f, 0.7f);
            Gizmos.DrawCube(Vector3.zero, sizeDown);
        }

        private void Update()
        {
            CheckHitFlow();
        }

        private void CheckHitFlow()
        {
            if (!isHitUp) isHitUp = CheckHit(pointUp, sizeUp);
            else if (CheckHit(pointDown, sizeDown))
            {
                ScoreManager.instance.AddScoreAndPlaySound(1.5f, 2.5f);
                Destroy(gameObject);
            }
        }

        /// <summary>
        /// 打擊判定
        /// </summary>
        /// <param name="center">中心點</param>
        /// <param name="size">尺寸</param>
        /// <returns>是否被打到</returns>
        private bool CheckHit(Vector3 center, Vector3 size)
        {
            Collider[] hits = Physics.OverlapBox(center, size / 2, transform.rotation, layerHit);
            return hits.Length > 0;
        }
    }
}

