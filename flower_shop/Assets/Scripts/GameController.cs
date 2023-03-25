using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using UniRx;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private List<FlowerVO> flowers;

    [SerializeField]
    private GameObject flower_group;

    [SerializeField]
    private Animator anim;

    [SerializeField]
    private GameObject decide_button;

    private List<FlowerVO> display_flower_kind;
    // 売られる花の数（表示される花の数）
    private int sell_flower_num;
    private int select_num;

    // Start is called before the first frame update
    void Start()
    {
        sell_flower_num = flower_group.transform.childCount;
        display_flower_kind = SellFlowerRandom(sell_flower_num);

        for (int i = 0; i < sell_flower_num; i++)
        {
            Flower child_flower = flower_group.transform.GetChild(i).gameObject.GetComponent<Flower>();
            child_flower.Initialize(display_flower_kind[i]);
            child_flower.OnClickFlower.Subscribe(num => {
                select_num += num;
                if(select_num <= 0){
                    decide_button.SetActive(false);
                } else {
                    decide_button.SetActive(true);
                }
            }).AddTo(this);
        }
        decide_button.SetActive(false);
        anim.SetTrigger("initialize");
    }

    /// <summary>
    /// 売る花の種類をランダムに決める
    /// </summary>
    /// <param name="sell_num">売る花の種類の数</param>
    /// MEMO:同じ花が出てもいっかなという思想でいく
    private List<FlowerVO> SellFlowerRandom(int sell_num)
    {
        List<FlowerVO> random_flowers = new List<FlowerVO>();
        random_flowers.AddRange(flowers);
        List<FlowerVO> display_kind = new List<FlowerVO>();
        for (int i=0; i < sell_num; i++)
        {
            int random_num = random_flowers.Count;
            int num = UnityEngine.Random.Range(0, random_num);
            display_kind.Add(random_flowers[num]);
            random_flowers.RemoveAt(num);
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
        switch(Array.IndexOf(point, max_point))
        {
            case (int)PointEnum.kind.RESPECT:
                Debug.Log("RESPECT");
                anim.SetTrigger("respect");
                break;
            case (int)PointEnum.kind.LOVE:
                Debug.Log("LOVE");
                anim.SetTrigger("love");
                break;
            case (int)PointEnum.kind.THANK:
                Debug.Log("THANK");
                anim.SetTrigger("thank");
                break;
        }
    }
}
