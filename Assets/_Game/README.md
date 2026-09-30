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

## Character and deck workflow
Character prefabs live under `Assets/_Game/Prefabs/Characters/`. Example character content is under `Assets/_Game/Prefabs/Characters/Examples/`.

Curated character decks are ScriptableObjects under `Assets/_Game/ScriptableObjects/Decks/`. A `CharacterDeckDefinition` references its character and its editable card list, allowing multiple curated decks per character without duplicating character data.

Example workflow: `Mosswarden` uses `Grovewatch`, containing `Strike`, `Spore Burst`, and `Strike`.

`CharacterDeckSelector` accepts editor-authored character and deck arrays, populates the character dropdown, and filters the deck dropdown to decks belonging to the selected character.

The Deck Builder and Battle scenes currently display the example character/loadout so the authored data path is visible before the final dropdown presentation is expanded.
