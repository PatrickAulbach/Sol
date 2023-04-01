using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RessourceController : MonoBehaviour
{
    private const int MIN_SPAWN_NUM = 10;
    public Ressources CreateRessources(SpaceObjects spaceObject)
    {
        switch (spaceObject)
        {
            case SpaceObjects.MERCURY:
            case SpaceObjects.VENUS:
            case SpaceObjects.EARTH:
            case SpaceObjects.MARS:
            case SpaceObjects.MOON:
            case SpaceObjects.ASTEROID:
                return new Ressources(GetResourceAmount(20), GetResourceAmount(15), GetResourceAmount(0));
            case SpaceObjects.JUPITER:
            case SpaceObjects.URANUS:
            case SpaceObjects.NEPTUNE:
            case SpaceObjects.SATURN:
                return new Ressources(GetResourceAmount(0), GetResourceAmount(-5), GetResourceAmount(20));
            case SpaceObjects.SUN:
                return new Ressources(GetResourceAmount(0), GetResourceAmount(-10), GetResourceAmount(0));
            case SpaceObjects.NEBULA:
                return new Ressources(GetResourceAmount(10), GetResourceAmount(0), GetResourceAmount(10));
            
            default:
                return new Ressources();
        }
    }

    public int GetResourceAmount(int bonus)
    {
        if (Random.Range(0, 101) <= ((int) OptionValues.difficulty + bonus))
        {
            return MIN_SPAWN_NUM + bonus;
        }

        return MIN_SPAWN_NUM;
    }
}
