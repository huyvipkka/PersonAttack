using System.Data.Common;
using UnityEngine;

public class StatsInfor{
    public int StatsEachLv;
    public int currentLv;
    public int maxLv;
    private int baseXu;
    private float XuBonusPercent;
    public int currentXuToUp;
    private StatsUpgradeData data;
    public StatsInfor(StatsUpgradeData data){
        this.data = data;
        StatsEachLv = data.StatsEachLv;
        currentLv = data.currentLv;
        maxLv = data.maxLv;
        baseXu = data.baseXu;
        XuBonusPercent = data.XuBonusPercent;
        
        float t = (float)baseXu 
                    * Mathf.Pow(1.0f + XuBonusPercent, (float)currentLv - 1);
        currentXuToUp = Mathf.RoundToInt(t);
    }

    public bool LevelUp(){
        if(currentLv >= maxLv) return false;
        currentLv++;
        Save();
        return true;
    }

    public void UpdateChangeCoinsToUp(){
        currentXuToUp = Mathf.RoundToInt(currentXuToUp * (1 + XuBonusPercent));
    }
    public void Save(){
        data.currentLv = currentLv;
    }
}