# Könyvtári nyilvántartó

> Egy könyvtárban működő kliens - szerver alkalmazás implementálása.

## Könyvtáros kliens - .NET WPF vagy Blazor frontent

> A könyvtáros pultján működik.

### Látja a könyvtárban lévő könyvek listáját
ha != "" a borrowername,  akkor kell a plusz 3 értéket listázni

- Állapot
    - Bent van vagy ki van kölcsönözve
    - Kinél van kikölcsönözve
    - Mikorra kell visszavinnie

### Az érkező ügyfélhez ki tud adni könyvet
kölcsönző neve megadása, dátum, határidő

- Csak bent lévő könyveket tud kiadni  -> borrowerName == ""
- A könyv állapota megváltozik kölcsönzöttre
- Letárolódnak az ügyfél adatai
    - Név
        - Validáció
            - Nem lehet: üres, whitespace, különleges karakterek szűrése pl !?_-:;#
        - UNIT teszt a validáló fv-re
    - Visszahozás határideje
        - Validáció
            - Későbbi mint a kölcsönzés ideje, valós dátum (pl: DateTime típus használata)
        - UNIT teszt a validáló fv-re

## Ügyfél kliens - .NET WPF vagy Blazor frontend

> A könyvtárban lévő ügyfelek szmára fenntartott gépeken működik.

### Lekérheti a kölcsönözhető könyvek listáját
ahol a borrowername üres

### Név megadásával tájékoztatást kap a kölcsönzéseiről
egyenlő a borrowernamemel azt listázza ki az alábbi adatokkal:

- Könyv adatai
- Határidő
- Időrendi sorrendben dátum és idő szerint

## Szerver - .NET WEB API alkalmazás (önálló konzol alkalmazás)

### Tárolja és szolgáltatja a bevitt adatokat

- Könyvtárban lévő könyvek (cím, esetleg darabszám, stb.)
- Kölcsönzött könyvek esetén további adatok
    - Kölcsönző neve
    - Kölcsönzés dátuma
    - Visszaadás határideje
- Adatok tárolása: JSON, XML vagy adatbázis(Entity FWK)
- Indításkor betölti a korábbi adatokat

## Egyéb követelmények

- Git repo
    - Rendszeres commit minden csapattagtól
- Egy solution használata
- Egy haladó technológia használata a felsoroltak közül (Entity FWK, Blazor, Async, MVVM)
- Konvenciók alkalmazása: [NI C# Style Guide](https://github.com/ni/csharp-styleguide)
    - Java, Python stílusú elnvezéseket ne használjatok
