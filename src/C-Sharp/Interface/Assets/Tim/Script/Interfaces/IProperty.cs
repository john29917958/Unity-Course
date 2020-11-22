/// <summary>
/// Defines character properties.
/// </summary>
public interface IProperty
{
    /// <summary>
    /// Attack Damage (物理攻擊傷害)
    /// </summary>
    int Ad { get; set; }

    /// <summary>
    /// Ability Power (法術傷害)
    /// </summary>
    int Ap { get; set; }

    /// <summary>
    /// Armor Resistance (物防)
    /// </summary>
    int Ar { get; set; }

    /// <summary>
    /// Magic Resistance (魔防)
    /// </summary>
    int Mr { get; set; }
}