﻿using System;

public static class PropertyFactory
{
    /// <summary>
    /// Creates properties from given <paramref name="characterType"/>.
    /// </summary>
    /// <param name="characterType">
    /// The character type.
    /// </param>
    /// <returns>
    /// Returns concrete properties object.
    /// </returns>
    public static IProperty Make(CharacterTypes characterType)
    {
        switch (characterType)
        {
            case CharacterTypes.Ashe:
                return new Character_Ashe();
            case CharacterTypes.Yi:
                return new Character_MasterYi();
            default:
                throw new ArgumentException("Unsupported character type \"" + characterType + "\"");
        }
    }
}
