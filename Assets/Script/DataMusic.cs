﻿using UnityEngine;

namespace Heyipomoea
{
    /// <summary>
    /// 音樂資料:設定要生成的方塊位置與角度資訊
    /// </summary>
    [CreateAssetMenu(menuName = "Heyipomoea/Music", fileName = "Music")]
    public class DataMusic : ScriptableObject
    {
        [Header("每一個音樂方塊")]
        public MusicCube[] musicCubes;
    }

    /// <summary>
    /// 音樂方塊:每個方塊的資料
    /// </summary>
    [System.Serializable]
    public class MusicCube
    {
        public CubeRotation cubeRotation;
        public CubePosition cubePosition;
    }

    /// <summary>
    /// 方塊角度:上、下、左、右
    /// </summary>
    public enum CubeRotation
    {
        Up, Down, Left, Right
    }

    /// <summary>
    /// 方塊位置:上、下、左、右、中
    /// </summary>
    public enum CubePosition
    {
        Up, Down, Left, Right, Middle
    }
}

