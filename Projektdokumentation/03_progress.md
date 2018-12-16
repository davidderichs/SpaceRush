![spaceRushEmblemV1](images/spaceRushLogo.jpg)

# Projekt-Tagebuch

## 01 Dez 2018 - Spacecraft

## 02 Dez 2018 - Startpoint, Endpoint, Movements, Camera

## 03 Dez 2018 - Planet Rotation

## 04 Dez 2018 - HUD
<p>
	Das HUD ist ein UI_Canvas. Es beinhaltet UI_Panels, die im folgenden beschrieben sind.
	Das HUD ist vom Typ <tt>HUD_Canvas</tt>	
	</br></br>	
	<i> von: David </br>
	Beim Erstellen des UI_Canvas wird auch ein EventSystem erzeugt, dessen Einsatz sich 
	mir noch nicht erschlossen hat. Können wir sicher nutzen, um das Canvas mit 
	bestimmten Events zu verknüpfen oder vom GameManager. 
	Habe noch keine Skripte für das HUD erstellt, da ich noch nicht weiß, ob das nicht 
	einfach der GameManager übernehmen kann.</i>
</p>

### HUD_Live
<p>
	HUD_Live ist von <tt>UI_Panel</tt> abgeleitet.
    Zeigt die aktuellen "Lebenspunkte" des Spielers bzw. seines Raumschiffes an.
    Lebenspunkte haben eine grüne Farbe.
    Beinhaltet Lebenspunkte vom Typ <tt>HUD_Live_Item</tt>.
</p>

### HUD_Live_Item
<p>
	Jedes Item ist abgeleitet von <tt>UI_Image</tt>. Lebenspunkte haben eine grüne Farbe.
</p>

### HUD_Shield
<p>
    HUD_Shield ist von <tt>UI_Panel</tt> abgeleitet.
    Zeigt die aktuellen "Schildpunkte" des Spielers bzw. seines Raumschiffes an. 
</p>

### HUD_Shield_Item
<p>
	Jedes Item ist abgeleitet von <tt>UI_Image</tt>. Schildpunkte haben eine blaue Farbe.
</p>

### HUD_Weapons
<p>
	HUD_Weapons ist von <tt>UI_Panel</tt> abgeleitet.
	Es gibt zwei Waffen-Slots, die anzeigen, welche Waffen der Spieler momentan 
	ausgerüstet hat. Beinhaltet zwei Elemente vom Typ <tt>HUD_Weapon</tt>.
</p>

#### HUD_Weapon
<p>
	Waffenkarte, die nach dem Einsammeln "ausgerüstet" bzw. im Waffenslot sichtbar sind.
	Waffen sind vom Typ <tt>UI_Image</tt> abgeleitet.
</p>

### HUD_Movements
<p>
	Beinhaltet die momentan vom Spieler ausgewählten Bewegungen. 
	Einzelne Bewegungen sind als GameObject vom Typ <tt>HUD_Movement </tt>
</p>

#### HUD_Movement
<p>
    Zeigt die Bewegung an. Wahlweise kann per Text angezeigt werden,  welche 
    Eigenschaft die Bewegung hat. Z.B. Rotationswinkel, Booststärke etc.
</p>

### HUD_Items
<p>
	HUD_Items ist von <tt>UI_Panel</tt> abgeleitet.
	Es gibt zwei Item-Slots, die anzeigen, welche Items der Spieler momentan 
	ausgerüstet hat. Beinhaltet zwei Elemente vom Typ <tt>HUD_Item</tt>.
</p>

#### HUD_Item
<p>
	Itemkarte, die nach dem Einsammeln "ausgerüstet" bzw. im Itemslot sichtbar sind.
	Items im HUD sind vom Typ <tt>UI_Image</tt> abgeleitet.
</p>


## 05.12.2018 HUD-Update
### Sprites
<p>
	Unter <tt>Assets/Materials/HUD/*</tt> abgelegt.
	Jedes Sprite ist als PNG hinterlegt und wird von Unity als <tt>Sprite (2D and UI)</tt> 
	interpretiert. Die Sprites werden von den jeweiligen Elementen als Image source 
	verwendet und können dort z.B. noch einmal mit anderen Farben gefüllt werden.
		</br></br>	
	<i>von: David </br>
	Beim Erstellen des UI_Canvas wird auch ein EventSystem erzeugt, dessen Einsatz sich 
	mir noch nicht erschlossen hat :). Können wir sicher nutzen, um das Canvas mit 
	bestimmten Events zu verknüpfen oder vom GameManager. Schwierig hierbei war, 
	herauszufinden, dass man die Bilder von Unity als Sprite für UI einlesen lassen muss, 
	sonst wurde nichts dargestellt.</i>
</p>

### Erstentwurf
<p>
    Erster Entwurf in Szene gespeichert <tt>Assets/Scenes/HUDScene</tt>
</p>

![HUD](images/Progress/05-Dez-2018/HUD.JPG) <br><br>

## 08.12.2018 HUD-Update
### Abstrakte Klasse HUD_Component_Template
<p>
	<i>von: David </br>
	Anlegen der Abstrakten Klasse war etwas friemelig, da ich nicht so den Durchblick in der 
	C# Syntax hatte. Letztendlich aber hat es funktioniert, die Vererbung zu nutzen. 
	<br><br>
	Wichtig zu Beachten war, dass die Sprites, welche von den jeweiligen Scripten geladen 
	werden unter <tt>/Assets/Resources/Sprites/</tt> abgelegt werden müssen.
	</i>
</p>

<p>
	Für die HUD_Components gibt es nun eine Abstrakte Klasse, die als "Template" genutzt 
	werden kann und alle notwendigen Methoden und Variablen vererbt. 
	So kann ein HUD_Component, der Images bzw. Sprites nutzt und bestimmt Werte des 
	Spielers anzeigen soll, leicht erzeugt werden.
</p>

<p>
	Die Abstrakte Klasse für HUD_Components ist abgelegt unter 
	<tt>Assets/Scripts/HUD/HUD_Component_Template</tt>
</p>

<p>
	Jedes davon abgeleitete HUD_Component hat folgende Eigenschaften.
	<ul>
		<li>
            <tt>item_list : List<KeyValuePair<int,GameObject>></tt> 
            <i>Liste der enthaltenen Indikatoren (Balken, Punkte etc.) </i>
		</li>
		<li>
			<tt>color_active : Color32</tt>
            <i>Farbe aktiver Elemente (z.B. noch verbleibende Lebenspunkte) </i>
        </li>
		<li>
			<tt>color_inactive : Color32</tt>
            <i>Farbe inaktiver Elemente (z.B. verlorenes Leben) </i>
		</li>
		<li>
			<tt>itemNameClass : String</tt>
            <i>Namens_Präfix der einzelnen Indikatoren, danach folgt noch ein Index, der 
            aber innerhalb des HUD_Component_Templates noch angehängt wird, um 
            jedes einzelne Element addressieren zu können. </i>
		</li>
		<li>
			<tt>maxValue : int</tt>
            <i>Maximalwert der HUD_Komponente (z.B. max. 10 Lebenspunkte)</i>
		</li>
		<li>
			<tt>useSprite : bool</tt>
            <i>Legt fest, ob ein Sprite geladen werden soll, wenn ja, muss spritePath 
            festgelegt werden, sonst gibt es einen Fehler.</i>
		</li>
		<li>
			<tt>spritePath : String</tt>
            <i>Gibt den relativen Pfad unter <tt>Assets/Resources</tt> an, wird ein Sprite 
            geladen, müssen die Sprites 
            unter<tt>Assets/Resources/Sprites/_spritename_</tt> 
            abgelegt werden.</i>
		</li>
	</ul>
</p>

### Einbindung in Player_Script

<p>
	<i>von: David </br>
	Habe mich erst einmal gegen ein Event-gesteuertes System entschieden. Das könnten 
	wir später vielleicht einbinden. Stattdessen habe ich die Player-Klasse genutzt, um 
	Updates auf dessen Attribute direkt auf das HUD anzuwenden. Dabei habe ich darauf 
	geachtet, dass das Player_Script nur mit dem HUD_Script bzw. der HUD-Klasse 
	kommuniziert. Die HUD-Klasse stellt momentan einfach public Attribute zur Verfügung, 
	da könnte man sicher noch Setter einbauen und eine gewissen Logik, aber es 
	funktioniert schon sehr gut so.
	</i>
</p>

<p>
    Im Player.cs Script wird das HUD mittels seines Scripts initialisiert. 
    <tt>hud = GameObject.FindWithTag("HUD").GetComponent<HUD>();</tt> 
</p>

<p>
    Danach sind die 
    öffentlichen Attribute des HUD im Player_Script nutzbar. Alle von den Werten des Spieles 
    abhängigen Werte können hier über HUD_Variablen verändert werden und erzeugen 
    eine veränderung des HUDs zur Laufzeit.
</p>

<p>
    Über die HUD_Variablen kann das HUD gesteuert werden, dabei spielt eigentlich nur eine 
    farbliche Kenntzeichnung eine Rolle, bzw. die Anzahl "aktiver" Elemente. Aktiv bedeutet 
    z.B. noch  verfügbarer Lebenspunkt oder nicht verbrauchter Schild etc. <br>
    <tt> this.hud.live.set_ActiveItemsColor(lives); </tt> 
    <tt> this.hud.main_fuel.set_ActiveItemsColor(this.main_fuel);  </tt>
    <tt> this.hud.add_fuel.set_ActiveItemsColor(this.add_fuel); </tt>
    <tt> this.hud.shield.set_ActiveItemsColor(this.shields);</tt> 
</p>

### HUD Screenshots

![HUD](images/Progress/08-Dez-2018/HUD.JPG)
<p><br><br></p>

## 09.12.2018 HUD-Update, JSONSerialization, MovementCards
<p>
	<i>von: David </br>
	Die im HUD angezeigeten "Karten", also Bewegungen, Rotationen etc. können jetzt aus 	Dateien geparsed und serialisiert werden. Die einzelnen <tt>MoveCard</tt> Objekte 
	werden in Listen der Klasse <tt>MoveCards</tt> gespeichert. <br><br>
	Sobald das Player_Script geladen wird, erhält der Spieler (nur temporär und im Moment) 
	Karten aus diesem Stapel zugewiesen. Später kann er aus einem größeren Stapel von 
	Karte auswählen. Allerdings habe ich diese Funktionalität aus Zeitmangel noch nicht 
	implementiert.
	</i>
</p>
### Klasse MoveCards und MoveCard
<p>
	Die Klasse <tt>MoveCards</tt> wird als "Kartenstapel" verwendet. Bei erzeugung kann 
	eine beliebige Stapelgröße gewählt werden.
</p>
<p>
	Die Methode <tt>get_random_Movecards(_anzahl_)</tt> nutzt einen JSON-Parser, um aus 
	einer bereits hinterlegten Liste, einen Stapel zu erzeugen. Momentan ist das ein 
	vorgefertigter Kartenstapel aus 50 Karten verschiedener Bewegungen. Diese "Random" 
	Karten sieht man auch, wenn die Szene gestartet wird. Sie sind jedes Mal anders belegt.
</p>

### JSONParser
<p>
	Die Klasse <tt>JSONParser</tt> kann derzeit Text-Dateien einlesen und, sofern sie in 
	JSON-Format gespeichert sind, Zeilenweise Objekte daraus erzeugen. Die Klasse ist recht 
	klein und erzeugt derzeit nur Objekte vom Typ <tt>MoveCards</tt> also der 
	Kartenstapel-Klasse.
</p>

### HUD_Selected_Movements und HUD_Available_Movements
<p>
	Die Klasse <tt>HUD_Selected_Movements</tt> und <tt>HUD_Available_Movements</tt> 
	sind Unterkomponenten des HUD. Sie können Kartenstapel anzeigen. 
</p>

<p>
	<tt>HUD_Selected_Movements</tt> kann 5 Karten anzeigen, die per Objekt vom Typ 
	<tt>MoveCards</tt> (dem Kartenstapel) übergeben werden.
</p>

<p>
	<tt>HUD_Selected_Movements</tt> kann derzeit 10 Karten anzeigen, die per Objekt vom 	Typ <tt>MoveCards</tt> (dem Kartenstapel) übergeben werden. Allerdings soll dieser 
	Stapel später, beim Einsammeln von Schildpunkten noch auf bis zu 15 Karten erhöht 
	werden können. So weit sind wir aber noch nicht.
</p>

### HUD Screenshots

![HUD](images/Progress/09-Dez-2018/HUD_Szene_nicht_gestartet.JPG) 
<p>Leere Szene (nicht gestartet)<br><br></p>

![HUD](images/Progress/09-Dez-2018/HUD_Szene_gestartet.JPG) 
<p>Sobald die Szene gestartet wird, werden die Daten geladen und das HUD gefüllt.<br><br></p>

![HUD](images/Progress/09-Dez-2018/Movement_Stack_JSON.JPG)
<p>
	Die Objekt-Daten für die Kartenstapel kommen aus einer vorgefertigten Stapel-Datei
</p>


## Update 16.12.2018 HUD, EventManager, SoundManager, GameManager

<p>
	<i>von: David </br>
	ES wurde ein <tt>EventManager</tt> implementiert, um globale Events propagieren und 
	behandeln zu können. Der GameManager ist mit mehreren Listener-Objekten 
	ausgestattet, die das HUD entsprechend aktualisieren. <br>
	Außerdem habe ich einen <tt>SoundManager</tt> eingebaut, der auch auf bestimmte 
	globale Events hört und entsprechende Sounds ausgibt. <br><br>
	<b>Probleme:</b><br>
	Hatte Probleme bei der Methode <tt>invoke()</tt> zum Propagieren von Event-Triggern. 
	Ich habe keine Möglichkeit gefunden, Events mit Zusatz-Informationen auszustatten. 
	Hatte zu diesem Zweck eigentlich eine zusätzliche Klasse geschrieben, die diese 
	Informationen enthalten sollte. Aber nach reichlicher Überlegung brauchen wir diese 
	Informationen letztendlich nicht und nutzen nun einfach nur die Event-Namen.
	</i>
</p>

### HUD
<p>
Das HUD steht mittels des <tt>GameManager</tt>'s in direktem "Kontakt" zum 
<tt>Player</tt>	und seinen aktuellen Werten, die auch die Kartenstapel beinhalten. Es wurde um einige Funktionen erweitert und bietet nun die Möglichkeit, Karten aus dem "Stapel" auszuwählen, die dann in die Karten-Auswahl des Spielers übertragen werden und auch so im HUD angezeigt werden. Auch in die andere Richtung können Karten wieder 	entsprechend aus der Auswahl entfernt und zurück in den "Stapel" gelegt werden. Ist die 	Auswahl getroffen, kann der Spieler einen nun sichtbaren Button betätigen, der dem 	GameManager signalisiert, dass der Spieler mit seinen "Zügen" fertig ist.
</p>

### EventManager
<p>
	Statische Klasse, die es ermöglicht beliebig viele Listener Objekte vom Typ <tt>UnityAction</tt> zu hinterlegen. Diese werden in einem Dictionary gespeichert.
	Angemeldete Listener hören auf das angegebene Event. Ist noch kein Event mit diesem Namen vorhanden, wird dieses erstellt.
</p>

<p>
	Im Projekt können alle Komponenten die Methoden <tt>StartListening(), StopListening(), 
	TriggerEvent()</tt> nutzen, um Listener anzumelden, abzumelden und um globale Events 
	zu triggern.
</p>

### GameManager
<p>
	Der GameManager hört auf globale Events, die z.B. vom Player, Spacecraft oder HUD 
	getriggered werden können und führt entsprechende Methoden aus. So ist z.B. eine 
	bidirektionale Interaktion zwischen Player und HUD möglich.
</p>

### SoundManager
<p>
	Der <tt>SoundManager</tt>  hört auf globale Events, die eine Sound-Ausgabe auslösen 
	sollen. Das GameObjekt SoundManager enthält diverse Komponenten vom Typ 
	<tt>AudioSource</tt>. Diese enthalten die im Projekt enthaltenen Sounds.
</p>

## Layer-Fortschritt

<p>
Der Layer 1 ist abgeschlossen, Layer 2 zum Großteil vervollständigt und der Gamemanager aus Layer 3 implementiert.
</p>

### Raumschiff

![Spacecraft](images\Progress\16-Dez-2018\BasicSpacecraft.png)

<p>
Das Basic Raumschiff ist implementiert und die Steuerung ist wie in Layer 2 beschrieben. Das Raumschiff kann per MoveCards gesteuert werden. Die MoveCards werden in SpacecraftMovements umgewandelt und dem Raumschiff als Aktionen hizugefügt. Der GameManager sorgt dann dafür, dass das Raumschiff während der Simulation die jeweils nächste Aktion ausführt. Der GameManager ist als CollisionListener beim Spacecraft angemeldet und wird bei einer Kollision benachrichtigt. Die Steuerung des Spacecrafts erfolgt über einen Controller. Für Boosts werden Kräfte zum zugehörigen RigidBody hinzugefügt, während die Rotation nicht über den RigidBody abgewickelt wird, sondern animiert ist.
</p>


### Planeten, Monde, Gravitation
![Planets](images\Progress\16-Dez-2018\Planets.png)

<p>
Die Planeten und Monde sowie die dazugehörige Gravitation sind vollständig implementiert. Das Raumschiff und die Planeten interagieren entsprechend ihrer Gravitation. Die Planeten drehen sich um eine festgelegt Rotationsachse mit einer festgelegten Geschwindigkeit. Die Monde können sich über ein Skript im Orbit eines Planeten bewegen. Die Umlaufbahn ist frei einstellbar, sodass man Abstand, Zeit einer Umrundung, Offset, elliptische Verzerrung und Rotation der Umlaufbahn setzten kann.
</p>


### Checkpoints
![Checkpoints](images\Progress\16-Dez-2018\Checkpoints.png)

<p>
Die Checkpoints sind funktionsfähig und es gibt Barriers um die Map. 
</p>

### HUD

![HUD](images/Progress/16-Dez-2018/HUD_Stack.JPG)

<p>
Das HUD ist entsprechend Layer 2 funktionsfähig. Es stellt zu Beginn den aktuellen Karten-Stapel des Spielers dar, aus dem er 5 Karten bzw. Bewegungen auswählen kann. Dabei wird die Karte aus dem Stapel entfernt und in die Auswahl übertragen. Anders herum kann diese Auswahl auch wieder rückgängig gemacht werden. 
</p>

![HUD](images/Progress/16-Dez-2018/HUD_Selection_Complete.JPG)

<p>
Hat der Spieler seine Auswahl getätigt, kann er den dann erschienenen Button "Ready" betätigen, um die Auswahl zu beenden.
</p>

### EventSystem
<p>
Es können globale Events getriggered werden, die z.B. vom GameManager für deren Abhandlung genutzt werden. Diese Events triggern Sounds, Karten-Auswahl, Änderungen der Spieler-Attribute wie z.B. Lebenspunkte. Sie könne aber auch angeben, dass eine Kollision stattgefunden hat usw. 
</p>

### BasicSounds
<p>
im <tt>SoundManager</tt> werden bereits für verschiedene globale Events Sound-Trigger abgehandelt. HUD-Aktionen werden mit Sounds unterlegt und es wird ein Sound-Track im Hintergrund abgespielt, sobald die Szene startet.
</p>

### Bewegungskarten
<p>
Die Bewegungskarten können aus vordefinierten Stapel-Dateien eingelesen werden. Sie werden vom Player genutzt, um Aktionen auszuwählen. Später werden sie in Aktionen/Bewegungen des SpaceCrafts umgewandelt und interpretiert. Sie sind in form echter Objekte in das Spiel integriert.
</p>

### Game Manager
<p>
Der <tt>GameManager</tt> ist zwar erst in Layer 3 definiert, aber bereits jetzt fester Bestandteil des Spiels und in großem Umfang funktionsfähig. Er sorgt für die korrekte Interaktion von HUD und Player, kann aber auch die Spiel Zustände festlegen und den Spielfluss steuern. Er steht auch in ständiger Kommunikation mit dem Spacecraft. Er lässt das Raumschiff neue Aktionen ausführen und kann auf Kollisionen des Raumschiffes reagieren. Wann es Zeit ist neue Karten auszuführen bestimmt ein eigenes Timer Skript, welches dem GameManager bescheid gibt, wenn es soweit ist. Außerdem startet und beendet der GameManager die Simulierten Objekte, sodass man die Simulation pausieren kann um neue Karten zu wählen um danach die Simulation fortzusetzen. Er ist auch für die Kameraeinstellungen zuständig, d.h. er derigiert das Kamera Skript.
</p>


### Musik
<p>
Es ist  bereits ein Soundtrack in das Spiel integriert, welcher auch im Einklang mit Trigger-Sounds ist und beim Start der Szene abgespielt wird.
</p>


### Multiplayer
<p>
Konnte bislang nicht implementiert werden.
</p>
### Kamera

Es gibt nun ein Skript, welches einer Kamera hinzugefügt werden kann. Die Kamerasteuerung erfolgt in Form einer State Machine. das Kamera Skript kann verschiedene States annehmen, dadurch verhält sich die Kamera entsprechend anders. Die Kamera kann bis jetzt einem Objekt folgen, eine fixe Position einnehmen sowie navigierbar sein. Eine Fixe Position könnte hilfreich sein, um schnell einen Überblick zu bekommen. Die Navigation der Kamera im Navigations-State erfolgt über die Arrow-Keys (x und y Achse) und das Maus-Rad zum Zoomen (z Achse). Die Navigation ist zum Planen der Karten wichtig, da man sich leicht einen Überblick verschaffen kann und sich frei auf der Map bewegen kann. Die Kamera kann mit Boundaries versehen werden, sodass man nicht bis ins unendliche zoomen oder sich bis ins unendliche Bewegen kann. Wenn die Kamera die Position ändert, egal ob innerhalb eines States (z.B. Verfolgung eines Objektes) oder beim Wechsel in einen anderen State, passiert dies nicht schlagartig, sondern wird von einer eigenen Klasse animiert, sodass alles "smoother" aussieht.

![camera_follow](images/Progress/general/camera_follow.gif)

Die Kamera verfolgt das Spacecraft.

![camera_navigation](images/Progress/general/camera_navigation.gif)

Die Kamera kann im Navigations State mit den Arrow-Keys und dem Mausrad gesteuert werden.

### Herausforderungen

Nach der Fertigstellung des ersten Layers ist unser Fokus durch die Notwendigkeit eines Gamemanagers und der dazugehörigen Spieler dahin abgewichen. Den in der Planung in Layer 3 ansässigen Gamemanager  wurde somit in den zweiten Layer verlegt da dieser Vorzeitig benötigt wurde. Durch diesen Vorschub ist es uns möglich geworden die nötigen HUD und Bewegungskarten sofort auf den Gamemanager umzustellen. Dies ermöglicht uns eine finalisierte Implementierung dieser und einer Nutzung des Eventsystems wie in der Planung vorgesehen.

Herausfordernd war die Implementierung der Bewegungskarten und des HUD's. Nach zeitaufwändiger anfänglicher Planung kam es durch unvorhergesehene kleine Probleme zu großer Debugarbeit. Der Großteil des HUD's welches nur von dieser Debugarbeit zurückgehalten wurde verlangsamte die Entwicklung der Bewegungskarten da diese direkt mit dem HUD verwoben sind. Nach diesen Schwierigkeiten kamen wir aber zu einem erfreulichen Fortschritt welcher unser Zwischenbericht berschreibt. Unsere Probleme mit Unity waren kaum nennenswert und wir hatten durch gute Planung wenige Mergeprobleme.

Ebenfalls herausfordernd war die Implementierung des SpaceraftControllers welcher die Bewegungen des Spacecrafts steuert. Nachdem wir anfänglich eine "zu realistische" Variante implementiert hatten, wurde uns klar, dass wir das Konzept grundlegend verändern müssen, was wir auch taten. Nun ist es möglich richtige Kurven zu fliegen, da die Rotation nun Animiert ist und nicht physikalisch korrekt bis ins unendliche weiter dreht. Als dies geschafft war wurde das Skript so angepasst, dass man Aktionen vorgelegen kann und somit eine Karten-Steuerung möglich ist.