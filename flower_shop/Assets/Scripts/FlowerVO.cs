using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

[Serializable]
public class FlowerVO 
{
    public string name;
    public FlowerEnum.kind kind;
    public Texture2D single_image;
    public Texture2D multiple_image;
    public PointEnum.kind point_kind;
} 

public class FlowerEnum 
{
    public enum kind {
        CARNATION, // カーネーション
        ROSE, // 薔薇
        TULIP, // チューリップ
        BABY_BREATH, // かすみ草
        SUNFLOWER, // ひまわり
        LISIANTHUS, // トルコキキョウ
        //GERBERA, // ガーベラ
        //LILY, // ユリ
    }
}

public class PointEnum
{
    public enum kind {
        LOVE, // 好意
        THANK, // 感謝
        RESPECT, // 尊敬
    }
}