## **USE CASES**

**UC01: OPRET OPGAVE**

Primær aktør: Chef/Souschef

Aktørmål: Chef/Souschef kan oprette en opgave i systemet.

Precondition: Chef/Souschef har registreret bruger ID.

Hovedscenarie:
1. Chef/Souschef vælger “Opret opgave”.
2. Systemet viser en formular for oprettelse af en ny opgave.
3. Chef/Souschef udfylder formularen og vælger opret.
4. Systemet opretter opgaven med statussen “Afventer”.
5. Systemet bekræfter oprettelse.

 ------
**UC02: TILDEL OPGAVE TIL MEDARBEJDER**

Primær aktør: Chef/Souschef

Aktørmål: Chef/Souschef kan tildele opgaver til medarbejderne i systemet.

Precondition: Chef/Souschef har registreret bruger ID.

Hovedscenarie:
1. Chef/Souschef vælger “Tildel opgave”.
2. Systemet viser en liste over opgaver som ikke er blevet tildelt en medarbejder.
3. Chef/Souschef vælger en opgave.
4. Systemet viser opgavens detaljer samt en medarbejderliste.
5. Chef/Souschef vælger en medarbejder fra listen og gemmer.
6. Systemet registrerer og gemmer, hvilken medarbejder opgaven er tildelt.
7. Systemet bekræfter tildelingen.

 ---
**UC03: OPDATER STATUS PÅ OPGAVE**

Primær aktør: Medarbejder

Aktørmål: Medarbejder kan opdatere status på en opgave i systemet.

Precondition: Medarbejder har registreret bruger ID.

Hovedscenarie:
1. Medarbejder vælger “Mine opgaver”.
2. Systemet viser medarbejderens tildelte opgaver.
3. Medarbejder vælger en opgave.
4. Systemet viser opgavens detaljer.
5. Medarbejder vælger en ny status og gemmer.
6. Systemet opdaterer statussen og gemmer.
----

**UC04: SE OVERBLIK OVER ALLE OPGAVER**

Primær aktør: Chef/Souschef eller medarbejder.

Aktørmål: Chef/Souschef eller medarbejder kan se overblik for både
ikke-afsluttede og afsluttede opgaver i systemet.

Precondition: Chef/Souschef eller medarbejder har registreret bruger ID.

Hovedscenarie:
1. Bruger vælger “Overblik over alle opgaver”.
2. Systemet viser en samlet liste over alle opgaver.
3. Bruger vælger eventuelt filtrering.
4. Systemet opdaterer visningen ud fra de valgte filtre.
5. Bruger får et overblik over relevante opgaver

 ----
**UC05: GODKEND OPGAVE**

Primær aktør: Chef/Souschef.

Aktørmål: Chef/Souschef kan godkende opgaver med statussen “Udført” i systemet.

Precondition: Chef/Souschef eller medarbejder har registreret bruger ID.

Hovedscenarie:
1. Chef/Souschef vælger “Godkend opgave”.
2. Systemet viser en liste over opgaver med statussen “Udført”.

   2a.  (Hvis opgaven ikke skal godkendes).
    1. Chef/Souschef vælger en opgave og vælger “Godkend ikke”.
    2. Systemet beder om en årsag.
    3. Chef/Souschef angiver en årsag og gemmer
    4. Systemet markerer opgaven som “ikke godkendt” og gemmer.
3. Chef/Souschef vælger en opgave og godkender.
4. Systemet markerer opgavens status som “Færdig” og godkender.

---
**UC06: OPRET NY MEDARBEJDER** 

Primær aktør: Chef/Souschef 

Aktørmål: Chef/Souschef kan oprette en ny medarbejder i systemet.

Precondtion: Chef/Souschef har registreret bruger ID.

Hovedscenarie:

1. Chef/Souschef vælger “Opret medarbejder”.
2. Systemet viser en formular for oprettelse af en medarbejder.
3. Chef/Souschef udfylder formularen og vælger opret.
4. Systemet opretter medarbejderen og bekræfter oprettelse.

---
**UC07: GENDAN OPGAVE**

Primær aktør: Chef/Souschef 

Aktørmål: Chef/Souschef kan gendanne opgaver som har statussen “ikke godkendt” i systemet. 

Precondition: Chef/Souschef har registreret bruger ID.

Hovedscenarie:
1. Chef/Souschef vælger “Gendan opgave”.
2. Systemet viser en liste over alle opgaver med statussen “Ikke godkendt”.
3. Chef/Souschef vælger en opgave og vælger gendan.
4. Systemet gendanner opgaven så den findes i “Tildel opgaver”

