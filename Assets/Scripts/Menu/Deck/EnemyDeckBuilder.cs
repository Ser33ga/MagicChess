using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
public class EnemyDeckBuilder : MonoBehaviour
{
    [SerializeField] public List<GameObject> enemyDeck=new List<GameObject>{};
    [SerializeField] public List<GameObject> chosenEnemyDeck=new List<GameObject>{};
    [SerializeField] private ScriptableObject configAsset;
    public DeckConfig config => (DeckConfig)configAsset;
    public int unitsNum => config.deckEnemyCount;
    private static readonly System.Random _rng = new System.Random();
    public void BuildDeck()
    {
        chosenEnemyDeck = enemyDeck.OrderBy(_ => _rng.Next()).Take(unitsNum).ToList();
    }
}
