using System.Collections;
using TMPro;
using UnityEngine;

public class ShopUpgrade : MonoBehaviour {
    [SerializeField] StatsUpgradeData hpData;
    [SerializeField] StatsUpgradeData atkData;
    StatsInfor hpInfor;
    StatsInfor atkInfor;
    [SerializeField] PlayerData playerData;
    [SerializeField] TextMeshProUGUI coinsValue;

    [SerializeField] TextMeshProUGUI atk;
    [SerializeField] TextMeshProUGUI atkBonus;
    [SerializeField] TextMeshProUGUI coinsUpAtk;
    [SerializeField] TextMeshProUGUI atkLv;

    [SerializeField] TextMeshProUGUI hp;
    [SerializeField] TextMeshProUGUI hpBonus;
    [SerializeField] TextMeshProUGUI coinsUpHp;
    [SerializeField] TextMeshProUGUI hpLv;
    [SerializeField] GameObject kDuXu;
    [SerializeField] GameObject daMaxLv;
    private void Start() {
        hpInfor = new(hpData);
        atkInfor = new(atkData);
        LoadInfoShop();
    }

    public void LoadInfoShop(){
        LoadInfoCoin();
        LoadInforAtk();
        LoadInforHp();
    }

    public void LoadInfoCoin(){
        coinsValue.SetText($"Coins: {GameManager.Instance.data.xu}");
    }
    public void LoadInforAtk(){
        atk.SetText($"Atk: {playerData.atk}");
        atkBonus.SetText($"+{atkInfor.StatsEachLv}");
        atkLv.SetText($"Lv: {atkInfor.currentLv}");
        if(atkInfor.currentLv < atkInfor.maxLv)
            coinsUpAtk.SetText($"{atkInfor.currentXuToUp} Coins");
        else
            coinsUpAtk.SetText($"You maxed atk");
    }

    public void LoadInforHp(){
        hp.SetText($"Hp: {playerData.hpMax}");
        hpBonus.SetText($"+{hpInfor.StatsEachLv}");
        hpLv.SetText($"Lv: {hpInfor.currentLv}");
        if(hpInfor.currentLv < hpInfor.maxLv)
            coinsUpHp.SetText($"{hpInfor.currentXuToUp} Coins");
        else
            coinsUpHp.SetText($"You maxed hp");
    }

    public void UpgradeAtkBtn(){
        if(!atkInfor.LevelUp()){
            StartCoroutine(DisplayIn(daMaxLv, 3));
            return;
        }
        else if(GameManager.Instance.data.xu < atkInfor.currentXuToUp){
            StartCoroutine(DisplayIn(kDuXu, 3));
            return;
        }
        GameManager.Instance.data.xu -= atkInfor.currentXuToUp;
        atkInfor.UpdateChangeCoinsToUp();
        playerData.atk += atkInfor.StatsEachLv;
        LoadInforAtk();
        LoadInfoCoin();
    }

    public void UpgradeHpBtn(){
        
        if(!hpInfor.LevelUp()){
            StartCoroutine(DisplayIn(daMaxLv, 3));
            return;
        }
        else if(GameManager.Instance.data.xu < hpInfor.currentXuToUp){
            StartCoroutine(DisplayIn(kDuXu, 3));
            return;
        }
        playerData.hpMax += hpInfor.StatsEachLv;
        GameManager.Instance.data.xu -= hpInfor.currentXuToUp;
        hpInfor.UpdateChangeCoinsToUp();
        LoadInforHp();
        LoadInfoCoin();
    }

    private IEnumerator DisplayIn(GameObject obj, float seconds)
    {
        obj.SetActive(true);
        yield return new WaitForSeconds(seconds);
        obj.SetActive(false);
    }
}