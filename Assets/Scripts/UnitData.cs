using UnityEngine;

public enum UnitType
{
    Gatherer,
    Warrior,
    Archer, //Towers are archers with no movement
    Abilties
}

[CreateAssetMenu(menuName = "Unit")]
public class UnitData : ScriptableObject
{
    public UnitType m_UnitType;
    public float Health;
    public float Damage;
    public float Speed;
    public float AttackSpeed;
    public float Range;
    public float Cost;
    public bool SpawnAtBase;
    public float MoneyReturned;
    public Sprite UiImage;
    public GameObject Unitprefab;

}
