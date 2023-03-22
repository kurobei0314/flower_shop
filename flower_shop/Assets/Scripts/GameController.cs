using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private List<FlowerVO> flowers;

    [SerializeField]
    private GameObject flower_group;

    private List<FlowerVO> display_flower_kind;
    // 売られる花の数（表示される花の数）
    private int sell_flower_num;

    // Start is called before the first frame update
    void Start()
    {
        sell_flower_num = flower_group.transform.childCount;
        int kind_num = Enum.GetNames(typeof(FlowerEnum.kind)).Length;
        display_flower_kind = SellFlowerRandom(kind_num, sell_flower_num);

        for (int i = 0; i < sell_flower_num; i++)
        {
            Flower child_flower = flower_group.transform.GetChild(i).gameObject.GetComponent<Flower>();
            child_flower.Initialize(display_flower_kind[i]);
            Debug.Log(display_flower_kind[i].point_kind);
        }
    }

    /// <summary>
    /// 売る花の種類をランダムに決める
    /// </summary>
    /// <param name="kind_num">花の種類の数</param>
    /// <param name="sell_num">売る花の種類の数</param>
    /// <returns></returns>
    /// MEMO:同じ花が出てもいっかなという思想でいく
    private List<FlowerVO> SellFlowerRandom(int kind_num, int sell_num)
    {
        List<FlowerVO> display_kind = new List<FlowerVO>();
        for (int i=0; i < sell_num; i++)
        {
            int num = UnityEngine.Random.Range(0, kind_num);
            display_kind.Add(flowers[num]);
        }
        return display_kind;
    }

    /// <summary>
    /// 作った花束からどのエンドにするのか決める
    /// </summary>
    public void OnClickDecideButton()
    {
        List<Flower> selected_flowers = new List<Flower>();
        int[] point = new int[3]{0,0,0};
        for(int i = 0; i < sell_flower_num; i++) 
        {
            Flower child_flower = flower_group.transform.GetChild(i).gameObject.GetComponent<Flower>();
            if (child_flower.IsSelected) 
            {
                point[(int)child_flower.FlowerVO.point_kind] += 1;
            }
        }
        int max_point = point.Max();
        // Array.IndexOfは最初に見つかったものを返すらしいので、表示されてほしい順番でenumを作る
        switch(Array.IndexOf(point, max_point))
        {
            case (int)PointEnum.kind.THANK:
                Debug.Log("THANK");
                break;
            case (int)PointEnum.kind.RESPECT:
                Debug.Log("RESPECT");
                break;
            case (int)PointEnum.kind.LOVE:
                Debug.Log("LOVE");
                break;
        }
    }
}
