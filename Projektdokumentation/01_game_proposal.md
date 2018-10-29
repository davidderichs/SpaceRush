# Spielbeschreibung

## SpaceRush

SpaceRush - Ein Wettrennen im Weltraum. Jeder gegen Jeden. Störe deinen Gegner. Sei smart. Plane gut voraus. Sei unberechenbar. Zerstöre die Schiffe der anderen. Achte auf dein eigenes Schiff. Sei so schnell, wie du nur kannst. Bleibe im Spiel.

Ziel des Spiels ist es, sich gegen den Widerstand des Weltraums und anderer Spieler durchzusetzen und als erster den Zielpunkt zu erreichen.

### Spielbereich

Der Raum, in dem sich die Schiffe befinden, ist zweidimensional. Im Raum befinden sich Planeten, die Kraftfelder (Gravitation) ausstrahlen. Befinden sich Schiffe in der Nähe der Planeten, werden sie angezogen und in ihrer Flugbahn abgelenkt und rotiert.

### Bewegung

Die Schiffe manövrieren mittels eines Raketenantriebs (Boost). Die Bewegung der Schiffe ist durch bestimmte Bewegungsmuster limitiert bzw. eingeschränkt. Ausgangspunkt ist immer die Position des Schiffes und seine Blickrichtgung. In Jeder Runde werden 5 Bewegungen für das eigene Schiff vorgegeben. z.B. Boost (3), Boost (2), Boost(1), Rotation(links), Rotation(rechts), U-Turn

Die Bewegung der Schiffe wird durch die Gravitation der im Raum befindlichen Planeten, aber auch durch andere Schiffe oder sonstige Objekte manipuliert.

### Interaktionen

Die Schiffe sind mit Waffen ausgestattet, beispielsweise Laser. Außerdem haben sie Kraftfelder, durch welche sie sich gegenseitig von ihrer Flugbahn ablenken können, ohne Schaden zu nehmen.

Bekommt ein Schiff Schaden, hat dies Konsequenzen. Zum einen kann der Spieler in der nächsten Runde aus weniger Bewegungsmöglichkeiten auswählen und zum anderen steigt die Gefahr, zerstört zu werden.

Steigt der Schaden weiter, sind ab einer Kritischen Anzahl von Schadenspunkten, bestimmte Bewegungen fest und können nicht mehr geändert werden. Das hat zur Folge, dass defekte, also bereits mit viel Schaden belastete Schiffe nicht mehr uneingeschränkte Bewegungsfreiheit haben und noch angreifbarer sind.

# Technische Elemente

## Raum 

Zweidimensional, Schachbrettmuster (unsichtbar)

## Objekte im Raum

- Schiffe
- Planeten, Monde, Raumstationen
- Gegenstände

### Schiffe-Eigenschaften

Position, Blickrichtung, Lebenspunkte, Schaden, Waffe(n), Boost, Geschwindigkeit, Position, Item(s)

### Planeten-Eigenschaften

Größe, Gravitation, Position, Masse

### Gegenstände-Eigenschaften

Zugehörigkeit zu Schiff/Spieler, Addiert Eigenschaften zum Schiff

**Items**

Gravitationsmine: Löst bei eintritt in Aktivierungs-Radius der Mine aus. Der Spieler kann entscheiden ob sie wegstößt oder heranzieht. Kann leichte Objekte (Weltraumschrott, Satelieten) verschieben.

Raumschiff Grav.welle: Das Raumschiff kann eine Welle auslösen welche Gegenstände und Raumschiffe vom Raumschiff wegschiebt.

EMP-Granate: Die EMP schaltet bestimmte Aktionen des Schiffes aus. Z.B. Weniger Aktionen pro Runde oder Items fallen aus.

Laser: Das Raumschiff schießt auf ein Ziehl. Kann Raumschiffe, Gegenstände beschädigen.

Rakete: Das Raumschiff schießt eine Rakete welche in einem Radius schaden zufügt.

Schild: Das Raumschiff bekommt einen Schild welcher eine bestimmte Menge an Schaden abblockt.

Reparatur: Repariert schäden am Schiff.

Zusätzlicher Treibstoff: Erhöht die Menge des Treibstoffes für die nächste Runde.

**Umgebung**

Monde: Um Planeten fliegende Monde welche Schiffe bei kontakt beschädigen.

Sonnen: Hohe Anziehungskraft und Sonnenwinde welche das Schiff schwer beschädigen.

Schwarzes Loch: Beschädigt das Raumschiff stark. Anschließend wird man (zurückgesetzt zum letzten Checkpoint?)

Wurmloch: Schnelle Transportmöglichkeit zwischen zwei festen Punkten. Beschädigt das Schiff leicht.

Weltraumschrott: Beweglicher Schrott im Weltraum welcher Schiffe bei kontakt beschädigt.

Asteroiden: Sich bewegende Asteroiden welche von Planeten und Sonnen abgelenkt werden.

Meteroiten-Gürtel: Sich schnell bewegende Meteroiten welche das Schiff bei kontakt Beschädigen.

Raumstationen: Besitzen eine Radiusbasierte-Waffe welche den Spieler anvisiert.

 



# Big Idea



# Entwicklungszeitplan



# Teamaufteilung