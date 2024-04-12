using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Nation
{
    Neutral = 0,
    Britain,
    Pirates,
    France,
    Spain,
    Portuguese,
    Dutch
}

public class Faction : MonoBehaviour
{
    [SerializeField] private Nation nation;
    public Nation Nation { get { return nation; } }

    [Header("Resources")]
    [SerializeField] private int food;
    public int Food { get { return food; } set {  food = value; } }
    [SerializeField] private int wood;
    public int Wood { get { return wood; } set { wood = value; } }
    [SerializeField] private int gold;
    public int Gold { get { return gold; } set { gold = value; } }
    [SerializeField] private int stone;
    public int Stone { get { return stone; } set { stone = value; } }
    
    [SerializeField] private List<Unit> aliveUnits = new List<Unit>();
    public List<Unit> AliveUnits { get { return aliveUnits; } }
    
    //ตัวแปร List ของ Building
    [SerializeField] private List<Building> aliveBuildings = new List<Building>();
    public List<Building> AliveBuildings { get { return aliveBuildings; } }
    
    [SerializeField] private Transform unitsParent;
    public Transform UnitsParent { get { return unitsParent; } }

    [SerializeField] private Transform buildingsParent;
    public Transform BuildingsParent { get { return buildingsParent; } }

    [SerializeField] private Transform ghostBuildingParent;
    public Transform GhostBuildingParent { get { return ghostBuildingParent; } }
    
    //จุดศูนย์กลางฝ่าย Faction นี้
    [SerializeField]
    private Transform startPosition; //start position for Faction
    public Transform StartPosition { get { return startPosition; } }
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public bool IsMyBuilding(Building b)
    {
        return aliveBuildings.Contains(b);
    } //เช็ค Building ของตัวเอง
    
    public bool CheckUnitCost(Unit unit)
    {
        if (food < unit.UnitCost.food)
            return false;

        if (wood < unit.UnitCost.wood)
            return false;

        if (gold < unit.UnitCost.gold)
            return false;

        if (stone < unit.UnitCost.stone)
            return false;

        return true;
    } //เช็คว่าทรัพยากรพอสร้าง Unit ไหม
    
    public void DeductUnitCost(Unit unit)
    {
        food -= unit.UnitCost.food;
        wood -= unit.UnitCost.wood;
        gold -= unit.UnitCost.gold;
        stone -= unit.UnitCost.stone;
    } //การหักทรัพยากร เวลาสั่งสร้าง Unit
    
    public bool IsMyUnit(Unit u)
    {
        return aliveUnits.Contains(u);
    } //เช็คว่า Unit หรือ Building นี้เป็นของฝ่ายนี้ไหม
    
    public bool CheckBuildingCost(Building building)
    {
        if (food < building.StructureCost.food)
            return false;

        if (wood < building.StructureCost.wood)
            return false;

        if (gold < building.StructureCost.gold)
            return false;

        if (stone < building.StructureCost.stone)
            return false;

        return true;
    } // เช็คและหัก BuildingCost
    
    public void DeductBuildingCost(Building building)
    {
        food -= building.StructureCost.food;
        wood -= building.StructureCost.wood;
        gold -= building.StructureCost.gold;
        stone -= building.StructureCost.stone;
    } // เช็คและหัก BuildingCost
    
    public Vector3 GetHQSpawnPos()
    {
        foreach (Building b in aliveBuildings)
        {
            if (b.IsHQ)
                return b.SpawnPoint.position;
        }
        return startPosition.position;
    }
}
