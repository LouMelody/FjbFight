using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AnimString
{
    #region アニメーション定数: Asaka
    public static readonly string asaka_bodyblow = AsakaPrefix("bodyblow");
    public static readonly string asaka_damage = AsakaPrefix("damage");
    public static readonly string asaka_down = AsakaPrefix("down");
    public static readonly string asaka_idle = AsakaPrefix("idle");
    public static readonly string asaka_jump = AsakaPrefix("jump");
    public static readonly string asaka_jumpkick = AsakaPrefix("jumpkick");
    public static readonly string asaka_punch = AsakaPrefix("punch");
    public static readonly string asaka_up = AsakaPrefix("up");
    public static readonly string asaka_upper = AsakaPrefix("uppper");
    public static readonly string asaka_walk = AsakaPrefix("walk");
    #endregion

    private static string AsakaPrefix(string value)
    {
        return "asaka_" + value;
    }
}
