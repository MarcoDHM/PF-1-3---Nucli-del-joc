# PF 1/3 - Núcleo del juego (Coin Collector 3D)

**Práctica UF2 — Programación del jugador en 3D**

## Descripción
Núcleo jugable de **Coin Collector 3D**: una esfera controlada por físicas que se desplaza por un nivel recogiendo monedas mediante triggers, con límites de escenario y zona de muerte (KillZone).

## Requisitos Implementados

### 1. Nivel
- **Suelo**: `Plane` horizontal con tag `Ground`.
- **Paredes invisibles**: 4 cubos delimitadores con `MeshRenderer` desactivado e `Is Trigger = true`.
- **KillZone**: Cubo grande situado bajo el nivel con `Is Trigger = true` y `MeshRenderer` desactivado, con el script `KillZone.cs` que muestra `"Player killed!"` por consola y reinicia la escena al caer el jugador.

### 2. Player
- Esfera con `Rigidbody`, `SphereCollider` y tag `Player`.
- Movimiento fluido mediante WASD o flechas de dirección (`Horizontal` y `Vertical`).
- Velocidad configurable desde el Inspector (`speed`).
- Movimiento gestionado en `FixedUpdate` aplicando `linearVelocity` (conservando la componente en `Y`).
- Rotación bloqueada (`Freeze Rotation X`, `Freeze Rotation Z`) para evitar que la bola ruede.

### 3. Monedas & Prefabs
- Prefab `Coin.prefab` con material dorado diferenciado.
- `SphereCollider` con `Is Trigger = true`.
- Script `Coin.cs` con detección mediante `OnTriggerEnter`:
  - Suma `+1` punto al `GameManager`.
  - Muestra en consola: `"Coin collected! Score: X"`.
  - Destruye la moneda (`Destroy(gameObject)`).
- 8 monedas distribuidas por el nivel (el mínimo requerido eran 6).

### 4. GameManager
- GameObject `GameManager` con `GameManager.cs`.
- Patrón **Singleton** (`Instance`).
- Control de puntuación (`score`).
- Método `AddScore(int points)`.
- Método `RestartLevel()` que recarga la escena activa mediante `SceneManager`.

### 5. Escenas y Build Settings
- **`MenuPrincipal.unity`**: Pantalla inicial con Canvas y botón "Play" para cargar el nivel 1.
- **`Level1.unity`**: Escena principal de juego.
- Ambas escenas configuradas en los **Build Settings** de Unity en el orden correcto.

### 6. Ampliaciones Voluntarias (+2 puntos)
- **Giro en el eje Y**: Script `Spinner.cs` rotando continuamente las monedas.
- **Flotación arriba y abajo**: `Mathf.PingPong` aplicado a la altura de las monedas para generar un efecto visual dinámico.

## Estructura del Proyecto
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
    ├── PlayerController.cs
    └── Spinner.cs
```
