using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UniRx;
using System;

public class Flower : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI flower_name;

    [SerializeField]
    RawImage image;

    private FlowerVO flower;
    public FlowerVO FlowerVO => flower;
    
    private bool is_selected = false;
    public bool IsSelected => is_selected;

    private Subject<int> onClickFlower = new Subject<int>();
    public IObservable<int> OnClickFlower => onClickFlower;

    /// <summary>
    /// 初期化
    /// </summary>
    /// <param name="flower">表示する花</param>
    public void Initialize(FlowerVO flower)
    {
        this.flower = flower;
        flower_name.text = flower.name;
        image.texture = flower.single_image;

    }

    public void OnClickButton()
    {
        is_selected = !is_selected;
        // TODO: ここに選択したかどうかを表示するようにする
        if (is_selected){
            onClickFlower.OnNext(1);
        } else {
            onClickFlower.OnNext(-1);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
