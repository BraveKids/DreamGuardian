==============
UTILIZZO
==============
----PUNTI DI SALVATAGGIO

	- script SetYume() assegnato al protagonista

	- oggetto save point nei prefab, trascinarlo e assegnare al gamecomponent GUI text una stringa che lo identifichi es. mondo 0 livello 0 salvataggio 1 -> 0.0.1, per ogni nuovo salvataggio trascinato

	- ogni Save Point ha uno script SavePoint che deve rimanere disabilitato (viene abilitato dal padre SavingPoints quando tutto è stato caricato)

	- tutti i salvataggi devono essere nodi figli di Saving Points, nodo vuoto (sempre nei prefab) cui è attaccato uno script

	- per il corretto funzionamento del sistema di salvataggio si deve iniziare dalla scena GameTemplate, altrimenti Yume verrà spawnato al punto 0.0.0 della mappa. Per evitare questo in fase di programmazione disabilitare lo script SetYume assegnato a Yume


----NEXT LEVEL
	
	- Ogetto LevelEnd in Prefab>SavingSystem. Trascinarlo e assegnarvi il punto di salvataggio da collegare. 

=============================
DETTAGLI IMPLEMENTATIVI
=============================

----SALVATAGGIO

	Il sistema di salvataggio si basa sui metodi serialize e deserialize della classe BinaryFormatter.

	La classe Game viene utilizzata per salvare la x e la y del giocatore, un' istanza di Game è in SaveLoad, la classe dove ci sono tutti i metodi principali.

	-Quando inizio un nuovo gioco il metodo NewGame() elimina i file di salvataggio precedenti e scrive le posizioni di inizio gioco nell'istanza di GAME.
	Quando yume viene attivato richiama il metodo GetYume che permette a SaveLoad di ottenere il GameObject di yume (non posso farlo automaticamente da SaveLoad perchè Yume potrebbe non essere ancora stato caricato), poi chiama il metodo Spawn() che posiziona il player sulle cordinate salvate nell' istanza di Game().

	- Al passaggio su un savepoint prima aggiornerò l'instanza di Game, poi la salvo serializzandola.

	- Se invece continuo la partita deserializzo e setto x e y in base ai valori dell'istanza


	La classe SavingPoints gestisce i punti di salvataggio. Un punto di salvataggio si registra nel dizionario, se non presente. Questa struttura viene serializzata e salvata. I punti di salvataggio già utilizzati vengono resi inutilizzabili.
 
 
 ----NEXT LEVEL	
 
	Avendo già implementato una struttura di save point abbastanza versatile, il passaggio al nuovo livello viene effettuato collegando all'oggetto EndLevel un punto di salvataggio. Questo alla collisione col player setterà x e y di savedGame alla posizione del punto di salvataggio, per poi richiamare il metodo Spawn().
	All'arrivo nel punto di salvataggio il gioco verrà salvato per il semplice contatto con l'oggetto.