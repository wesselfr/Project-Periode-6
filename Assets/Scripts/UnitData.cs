using UnityEngine;

public enum UnitType
{
    Gatherer,
    Warrior,
    Archer,
    Abilties,
    Tower
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
    public Sprite UiImage;
    public GameObject Unitprefab;

}
