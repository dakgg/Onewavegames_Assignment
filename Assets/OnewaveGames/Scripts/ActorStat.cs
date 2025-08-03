
using System.Data;

public class ActorStat
{
    public uint Hp { get; private set; }
    public uint Mp { get; private set; }
    public uint MoveSpeed { get; private set; }

    public void SetStat(CharacterData data)
    {
        SetStat(data.Hp, data.Mp, data.MoveSpeed);
    }

    void SetStat(uint hp, uint mp, uint moveSpeed)
    {
        Hp = hp;
        Mp = mp;
        MoveSpeed = moveSpeed;
    }

    public void UpdateHp(int hp) => Hp += (uint)hp;

    public void UpdateMp(int mp) => Mp += (uint)mp;
}