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
// OR
var die = new GamblersDie(new int[] {1, 1, 4, 1, 1, 1}); // Arrays work for weights as well

int result = die.Roll(); // the weighted die will most likely return 4
```

## What is happening?

**From [xori/gamblers-dice](https://github.com/xori/gamblers-dice):**

Normally when rolling a 4 sided die, you would have a 25% chance of rolling any
given face, at any time. If you rolled a 4, three times in a row it doesn't make
it any less probable of happening the next time. Further, a 1 is not "more
likely" because "it hasn't been rolled in a while".

This library breaks that standard rule.

| Roll | % of 1 | % of 2 | % of 3 | % of 4 | Actual Roll |
|--- | --- | --- | --- | --- | --- |
| 1 | 25% | 25% | 25% | 25% | 1 (⚀) |

In the above example, we got out our fancy die from its box, and rolled.
Because we are gods, we know the probability of each side being rolled, and see
nothing amiss. Every face has a 25%, and we randomly roll a 1.

| Roll | % of 1 | % of 2 | % of 3 | % of 4 | Actual Roll |
|--- | --- | --- | --- | --- | --- |
| 2 | 14% | 29% | 29% | 29% | 2 (⚁) |
| 3 | 22% | 11% | 33% | 33% | ? |

Whoa, that's different, we are now 11% less likely to roll a 1, and indeed, by
luck, we don't. We instead roll a 2, and when we do, we see the probabilities
shift yet again. Let's roll the die a couple more times.

| Roll | % of 1 | % of 2 | % of 3 | % of 4 | Actual Roll |
|--- | --- | --- | --- | --- | --- |
| 3 | 22% | 11% | 33% | 33% | 3 (⚂) |
| 4 | 30% | 20% | 10% | 40% | 1 (⚀) |
| 5 | 9% | 27% | 18% | 45% | ? |

After four rolls, we've yet to see a 4, it is
[obviously due](https://simple.wikipedia.org/wiki/Gambler%27s_fallacy) and
indeed there is now a 45% chance of rolling a 4. If you were going to do
something rash (like
bet on a 4) now would be the time.
