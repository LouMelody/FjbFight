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
    public static readonly string asaka_upper = AsakaPrefix("upper");
    public static readonly string asaka_walk = AsakaPrefix("walk");
    #endregion

    #region アニメーション定数: Ishikawa
    public static readonly string ishikawa_bodyblow = IshikawaPrefix("bodyblow");
    public static readonly string ishikawa_damage = IshikawaPrefix("damage");
    public static readonly string ishikawa_down = IshikawaPrefix("down");
    public static readonly string ishikawa_idle = IshikawaPrefix("idle");
    public static readonly string ishikawa_jump = IshikawaPrefix("jump");
    public static readonly string ishikawa_jumpkick = IshikawaPrefix("jumpkick");
    public static readonly string ishikawa_punch = IshikawaPrefix("punch");
    public static readonly string ishikawa_up = IshikawaPrefix("up");
    public static readonly string ishikawa_upper = IshikawaPrefix("upper");
    public static readonly string ishikawa_walk = IshikawaPrefix("walk");
    #endregion
    private static string AsakaPrefix(string value)
    {
        return "asaka_" + value;
    }

    private static string IshikawaPrefix(string value)
    {
        return "ishikawa_" + value;
    }
}
