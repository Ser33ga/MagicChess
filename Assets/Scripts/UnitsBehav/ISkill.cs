using System.Collections;
using System;
using System.Collections.Generic;
using Unity.Android.Gradle.Manifest;
using UnityEngine;
public interface ISkill
{
    public IEnumerator SkillCasting();
}
public class ArcherSkill:ISkill
{
    public IEnumerator SkillCasting()
    {
        yield return null;
    }
}