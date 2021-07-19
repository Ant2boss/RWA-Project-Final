Aplikacija koristi SQL bazu podataka.

Za korištenje aplikacije potrebno je pripremiti bazu podataka sa procedurama.
Skripta za inicijalizaciju se nalazi u "RWA-DataLayer/DataRepository/SQL_Script"; pokretanjem skripte u SQL editoru, trbeala bi se baza pripremiti za korištenje.
( Nadam se barem da će stvoriti sve što treba :-) )

Također meni je SQL server malo drukčije namiješten, to jest potrebno je popraviti connection stringove za spajanje na baze.

U WebForms projektu su dva connection string-a: "RWA-WebForms/Web.config"

U MVC projektu su dva connection string-a: "RWA-Project/Web.config"

Potrebno je promijeniti odredište i (ukoliko je potrebno) username i password za prijavu