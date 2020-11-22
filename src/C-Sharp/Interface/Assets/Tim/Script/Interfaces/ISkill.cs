/// <summary>
/// The character skill interface.
/// </summary>
public interface ISkill
{
	/// <summary>
	/// Fires the skill.
	/// </summary>
	/// <param name="property">
	/// Character's body properties.
	/// </param>
	void Trigger(IProperty property);
}
