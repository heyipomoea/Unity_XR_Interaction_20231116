using UnityEngine;

namespace Heyipomoea
{
    /// <summary>
    /// 移動系統
    /// </summary>
    public class MoveSystem : MonoBehaviour
    {
        [SerializeField, Header("移動速度"), Range(0, 100)]
        private float speed = 10;

        private void Update()
        {
            Move();
        }

        private void Move()
        {
            transform.Translate(0, 0, -speed * Time.deltaTime);
        }
    }
}

