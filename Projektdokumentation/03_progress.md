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

![HUD](images\Progress\05-Dez-2018\HUD.JPG)
