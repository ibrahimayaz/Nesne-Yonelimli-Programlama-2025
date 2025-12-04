# Örnek 6 — Auto-property ve private set (çok basit)

```csharp
public class GameScore
{
    public string PlayerName { get; set; } = string.Empty; // dışarıdan set edilebilir
    public int Score { get; private set; }                  // dışarıdan set edilemez
    public int Level { get; private set; } = 1;             // dışarıdan set edilemez

    public void IncreaseScore(int points) => Score += points; // basit artış
    public void LevelUp() => Level++;                         // basit seviye artışı
}
```