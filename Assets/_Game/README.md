# Fungal Tower Unity-First Architecture

Main is the startup scene. Navigation is the central hub for Campaign, Card Library, Deck Builder, Settings, and future systems.

## Development rule

Prefer Scene GameObjects, Prefabs, and ScriptableObjects whenever a feature can be authored in the Unity Editor. C# should primarily handle interactions, navigation, turn resolution, saving, and other runtime behavior.

## Planned scenes
- Main
- Navigation
- Campaign
- Battle
- CardLibrary
- DeckBuilder

## Reusable data
CardData, EnemyData, CharacterData, RelicData, and EncounterData will be ScriptableObjects so content can be duplicated and edited in the Inspector.