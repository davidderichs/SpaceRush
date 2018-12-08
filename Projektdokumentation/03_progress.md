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

![HUD](images/Progress/05-Dez-2018/HUD.JPG)

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

### HUD aktueller Stand 08.12.2018

![HUD](images/Progress/08-Dez-2018/HUD.JPG)
