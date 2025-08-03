using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameDataManager : MonoBehaviour
{
    public static GameDataManager Instance;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void initialize()
    {
        if (Instance == null)
        {
            GameObject go = new GameObject(nameof(GameDataManager));
            Instance = go.AddComponent<GameDataManager>();
            DontDestroyOnLoad(go);
            Instance.LoadGameData();
        }
    }

    public List<CharacterData> Characters { get; private set; }
    public List<CharacterSkillData> ChacterSkills { get; private set; }
    public List<ProjectileData> Projectiles { get; private set; }

    void LoadGameData()
    {
        Characters = Utils.ConvertCsvToJson<CharacterData>(Resources.Load<TextAsset>("Gamedata/Character").text);
        ChacterSkills = Utils.ConvertCsvToJson<CharacterSkillData>(Resources.Load<TextAsset>("Gamedata/CharacterSkill").text);
        Projectiles = Utils.ConvertCsvToJson<ProjectileData>(Resources.Load<TextAsset>("Gamedata/Projectile").text);
    }

    public CharacterData GetCharacterData(string name)
    {
        return Characters.Single(c => c.Name == name);
    }

    public CharacterData GetCharacterDataOrDefault(string name)
    {
        foreach (var character in Characters)
        {
            if (character.Name == name)
            {
                return character;
            }
        }
        return null;
    }

    public CharacterSkillData GetCharacterSkillData(string skillName)
    {
        return ChacterSkills.Single(c => c.Name == skillName);
    }

}