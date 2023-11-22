using UnityEngine;



namespace Heyipomoea
{
    /// <summary>
    /// 生成方塊系統
    /// </summary>
    public class SpawnCubeSystem : MonoBehaviour
    {
        [SerializeField, Header("生成位置藍色")]
        private Transform pointSpawnBlue;
        [SerializeField, Header("生成位置紅色")]
        private Transform pointSpawnRed;
        [SerializeField, Header("預製物藍色")]
        private GameObject prefabCubeBlue;
        [SerializeField, Header("預製物紅色")]
        private GameObject prefabCubeRed;
    }
}

