# Gambler's Dice

A C# (.Net Standard 2.0) port of [xori/gamblers-dice](https://github.com/xori/gamblers-dice).

## How to Use

```
$ dotnet add package GamblersDice
```

```C#
var die = new GamblersDie(); // d6
// OR
var die = new GamblersDie(20); // d20
// OR
var die = new GamblersDie(1, 1, 1, 4, 1, 1, 1); //d7, with 4 heavily weighted

int result = die.Roll(); // the weighted die will most likely return 4
```

