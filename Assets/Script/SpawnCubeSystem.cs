using System.Collections;
using UnityEngine;



namespace Heyipomoea
{
    /// <summary>
    /// 生成方塊系統
    /// </summary>
    public class SpawnCubeSystem : MonoBehaviour
    {
        [SerializeField, Header("歌曲資料")]
        private DataMusic dataMusic;
        [SerializeField, Header("生成位置藍色")]
        private Transform pointSpawnBlue;
        [SerializeField, Header("生成位置紅色")]
        private Transform pointSpawnRed;
        [SerializeField, Header("預製物藍色")]
        private GameObject prefabCubeBlue;
        [SerializeField, Header("預製物紅色")]
        private GameObject prefabCubeRed;

        private void Awake()
        {
            StartCoroutine(SpawnCube());
        }

        private IEnumerator SpawnCube()
        {
            for(int i = 0; i < dataMusic.musicCubesBlue.Length; i++) 
            {
                PerCube(prefabCubeBlue, pointSpawnBlue, dataMusic.musicCubesBlue[i]);
                PerCube(prefabCubeRed, pointSpawnRed, dataMusic.musicCubesRed[i]);
                yield return new WaitForSeconds(dataMusic.interval);
            }
        }

        private void PerCube(GameObject prefab, Transform point, MusicCube musicCube)
        {
            CubePosition cubePosition = musicCube.cubePosition;
            CubeRotation cubeRotation = musicCube.cubeRotation;

            if (cubePosition == CubePosition.None) return;

            Instantiate(prefab, point.position + GetPosition(cubePosition), GetRotation(cubeRotation));
        }

        /// <summary>
        /// 獲取方塊座標
        /// </summary>
        /// <param name="position">方塊座標類型</param>
        /// <returns>該方塊的座標位移資訊</returns>
        private Vector3 GetPosition(CubePosition position)
        {
            Vector3 positionNew = Vector3.one;

            switch (position)
            {
                case CubePosition.None:
                    break;
                case CubePosition.Up:
                    positionNew = new Vector3(0, 0.5f, 0);
                    break;
                case CubePosition.Down:
                    positionNew = new Vector3(0, -0.5f, 0);
                    break;
                case CubePosition.Left:
                    positionNew = new Vector3(-0.5f, 0, 0);
                    break;
                case CubePosition.Right:
                    positionNew = new Vector3(0.5f, 0, 0);
                    break;
                case CubePosition.Middle:
                    positionNew = Vector3.zero;
                    break;
                default: 
                    break;
            }
            return positionNew;
        }

        /// <summary>
        /// 獲取方塊角度
        /// </summary>
        /// <param name="rotation">方塊角度類型</param>
        /// <returns>該方塊角度旋轉資訊</returns>
        private Quaternion GetRotation(CubeRotation rotation) 
        {
            Quaternion rotationNew = Quaternion.identity;

            switch (rotation)
            {
                case CubeRotation.None:
                    break;
                case CubeRotation.Up:
                    rotationNew = Quaternion.Euler(0, 0, 180);
                    break;
                case CubeRotation.Down:
                    rotationNew = Quaternion.Euler(0, 0, 0);
                    break;
                case CubeRotation.Left:
                    rotationNew = Quaternion.Euler(0, 0, 270);
                    break;
                case CubeRotation.Right:
                    rotationNew = Quaternion.Euler(0, 0, 90);
                    break;
            }
            return rotationNew;
        }
    }
}

