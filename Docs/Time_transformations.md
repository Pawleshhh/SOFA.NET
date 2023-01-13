+-----+-----+-----+----+-----+-----+-----+-----+
|     | Utc | Ut1 | Tt | Tcb | Tdb | Tcg | Tai |
+-----+-----+-----+----+-----+-----+-----+-----+
| Utc |  /  |  x  |    |     |     |     |  x  |
+-----+-----+-----+----+-----+-----+-----+-----+
| Ut1 |  x  |  /  |  x |     |     |     |  x  |
+-----+-----+-----+----+-----+-----+-----+-----+
| Tt  |     |  x  |  / |     |  x  |  x  |  x  |
+-----+-----+-----+----+-----+-----+-----+-----+
| Tcb |     |     |    |  /  |  x  |     |     |
+-----+-----+-----+----+-----+-----+-----+-----+
| Tdb |     |     |  x |  x  |  /  |     |     |
+-----+-----+-----+----+-----+-----+-----+-----+
| Tcg |     |     |  x |     |     |  /  |     |
+-----+-----+-----+----+-----+-----+-----+-----+
| Tai |  x  |  x  |  x |     |     |     |  /  |
+-----+-----+-----+----+-----+-----+-----+-----+

Utc -> Tai -> Tt
Utc -> Tai -> Tt -> Tdb -> Tcb
Utc -> Tai -> Tt -> Tdb
Utc -> Tai -> Tt -> Tcg

Ut1 -> Tt -> Tdb -> Tcb
Ut1 -> Tt -> Tdb
Ut1 -> Tt -> Tcg

Tt -> (Ut1 or Tai) -> Utc
Tt -> Tdb -> Tcb

Tcb -> Tdb -> Tt
Tcb -> Tdb -> Tt -> Ut1
Tcb -> Tdb -> Tt -> Tai
Tcb -> Tdb -> Tt -> Tai -> Utc
Tcb -> Tdb -> Tt -> Tcg

Tdb -> Tt -> Ut1
Tdb -> Tt -> Tai
Tdb -> Tt -> Tai -> Utc
Tdb -> Tt -> Tcg

Tcg -> Tt -> Ut1
Tcg -> Tt -> Tai
Tcg -> Tt -> Tai -> Utc
Tcg -> Tt -> Tdb
Tcg -> Tt -> Tdb -> Tcb

Tai -> Tt -> Tdb
Tai -> Tt -> Tdb -> Tcb
Tai -> Tt -> Tcg