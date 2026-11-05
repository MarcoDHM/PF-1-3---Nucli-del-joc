# PF 1/3 - Nucli del joc (Coin Collector 3D)

**Pràctica UF2 — Programació del jugador en 3D**

## Descripció
Nucli jugable de **Coin Collector 3D**: una esfera controlada per físiques que es mou per un nivell recollint monedes amb triggers i límits d'escenari amb zona de mort (KillZone).

## Requisits Implementats

### 1. Nivell
- **Terra**: `Plane` horitzontal amb tag `Ground`.
- **Parets invisibles**: 4 cubs delimitadors amb `MeshRenderer` desactivat i `Is Trigger = true`.
- **KillZone**: Cub gran sota el nivell amb `Is Trigger = true` i `MeshRenderer` desactivat, amb el script `KillZone.cs` que mostra `"Player killed!"` per consola i reinicia l'escena.

### 2. Player
- Esfera amb `Rigidbody`, `SphereCollider` i tag `Player`.
- Moviment suau amb WASD o fletxes direccionals (`Horizontal` i `Vertical`).
- Velocitat configurable des de l'Inspector (`speed`).
- Moviment gestionat a `FixedUpdate` aplicant `linearVelocity` (conservant la velocitat en `Y`).
- Rotació bloquejada (`Freeze Rotation X`, `Freeze Rotation Z`) evitant que la bola rodi.

### 3. Monedes & Prefabs
- Prefab `Coin.prefab` amb material daurat diferenciat.
- `SphereCollider` amb `Is Trigger = true`.
- Script `Coin.cs` amb detecció mitjançant `OnTriggerEnter`:
  - Afegeix `+1` punt al `GameManager`.
  - Mostra a consola: `"Coin collected! Score: X"`.
  - Es destrueix la moneda (`Destroy(gameObject)`).
- 8 monedes col·locades al nivell (mínim 6 requerides).

### 4. GameManager
- GameObject `GameManager` amb `GameManager.cs`.
- Patró **Singleton** (`Instance`).
- Gestió de puntuació (`score`).
- Mètode `AddScore(int points)`.
- Mètode `RestartLevel()` que recarrega l'escena activa mitjançant `SceneManager`.

### 5. Escenes i Build Settings
- **`MenuPrincipal.unity`**: Pantalla inicial amb Canvas i botó "Play" per carregar el nivell 1.
- **`Level1.unity`**: Escena de joc completa.
- Ambdues escenes afegides als **Build Settings** de Unity en l'ordre correcte.

### 6. Ampliacions Voluntàries (+2 punts)
- **Giro en l'eix Y**: Script `Spinner.cs` rotant constantment les monedes.
- **Flotació amunt i avall**: `Mathf.PingPong` aplicat a l'alçada de les monedes per donar un efecte visual dinàmic.

## Estructura del Projecte
```
Assets/
├── Materials/
│   ├── CoinGold.mat
│   ├── GroundMat.mat
│   └── PlayerMat.mat
├── Prefabs/
│   └── Coin.prefab
├── Scenes/
│   ├── MenuPrincipal.unity
│   └── Level1.unity
└── Scripts/
    ├── Coin.cs
    ├── GameManager.cs
    ├── KillZone.cs
    ├── MainMenu.cs
    ├── PlayerController.cs
    └── Spinner.cs
```
