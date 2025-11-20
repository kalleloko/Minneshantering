## Datastrukturer och minne

**1. Hur fungerar stacken och heapen? Förklara gärna med exempel eller skiss på dess grundläggande funktion**

Stack är en datastruktur enligt FILO-princip: Det som läggs där ligger på "en hög", och ska jag plocka något därifrån så plockar jag det översta, alltså det senast tillagda.

Heap är en datastruktur där saker saker som läggs sorteras in på rätt plats. Ett binärt, sorterat träd. Det gör att heapen lätt plockar fram det jag frågar efter.
        2
      /   \
     5     3
    / \   / \
   8   7 6   4


**2. Vad är Value Types respektive Reference Types och vad skiljer dem åt?**

Reference Types är typer som ärver från System.Object, och sparas på heapen.

När de används så hanteras de med en referens, en adress, som pekar mot själva objektet som ligger i heapen. Det innebär att samma objekt kan representeras av olika variabler:
```csharp
O o1 = new O();
O o2 = o1;

o2.Answer = 42;
o1.Answer; // 42
```

Det innebär också att två variabler som skapas separat inte anses identiska, eftersom de pekar mot olika objekt:
```csharp
O o1 = new O(question: null, answer: 42);
O o2 = new O(question: null, answer: 42);

o1 == o2; // false
```

Value Types är enklare typer, som sparar sitt värde direkt i variabeln. Vid jämförelse mellan variabler så kontrolleras värdet istället för det underliggande objektet:
```csharp
int o1 = 42;
int o2 = 42:

o1 == o2; // true! 
```

Och omvänt, om ett värde sätts av ett annat värde, så är koppling till det gamla värdet glömt sedan:
```csharp
int o1 = 42;
int o2 = o1: // 42, men kopplingen till o1 borta

o1 = 43;
o2; // fortfarande 42
```

Value Types sparas antingen i heapen eller i stacken. En lokal variabel i en metod, tex, sparas i stacken, medan ett field i en klass sparas i dess objekt i heapen.

**3. Följande metoder (se bild nedan) genererar olika svar. Den första returnerar 3, den andra returnerar 4, varför?**

I första exemplet är x och y av typen int, som är en Value Type. x och y sparas som två separata värden (`x = y` betyder ge x samma numeriska värde som y har).

I andra exemplet är typen en Reference Type, och en tilldelning innebär att referensen till orginal-objektet kopieras. (`x = y` betyder: x ska numera peka mot samma objekt som y pekar)

## Övning 1: ExamineList()
1. Skriv klart implementationen av ExamineList-metoden så att undersökningen blir genomförbar.
2. När ökar listans kapacitet? (Alltså den underliggande arrayens storlek)
3. Med hur mycket ökar kapaciteten?
4. Varför ökar inte listans kapacitet i samma takt som element läggs till?
5. Minskar kapaciteten när element tas bort ur listan?
6. När är det då fördelaktigt att använda en egendefinierad array istället för en lista?