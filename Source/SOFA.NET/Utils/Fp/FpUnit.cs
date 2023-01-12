namespace SOFA.NET;

internal static partial class Fp
{

    public static readonly Unit UnitValue = new();

    public static Unit Unit(this Action action)
    {
        action();
        return UnitValue;
    }
    public static Unit Unit<T>
        (this Action<T> action, T t)
    {
        action(t);
        return UnitValue;
    }
    public static Unit Unit<T1, T2>
        (this Action<T1, T2> action,
        T1 t1, T2 t2)
    {
        action(t1, t2);
        return UnitValue;
    }
    public static Unit Unit<T1, T2, T3>
        (this Action<T1, T2, T3> action,
        T1 t1, T2 t2, T3 t3)
    {
        action(t1, t2, t3);
        return UnitValue;
    }
    public static Unit Unit<T1, T2, T3, T4>
        (this Action<T1, T2, T3, T4> action,
        T1 t1, T2 t2, T3 t3, T4 t4)
    {
        action(t1, t2, t3, t4);
        return UnitValue;
    }
    public static Unit Unit<T1, T2, T3, T4, T5>
        (this Action<T1, T2, T3, T4, T5> action,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5)
    {
        action(t1, t2, t3, t4, t5);
        return UnitValue;
    }
    public static Unit Unit<T1, T2, T3, T4, T5, T6>
        (this Action<T1, T2, T3, T4, T5, T6> action,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6)
    {
        action(t1, t2, t3, t4, t5, t6);
        return UnitValue;
    }
    public static Unit Unit<T1, T2, T3, T4, T5, T6, T7>
        (this Action<T1, T2, T3, T4, T5, T6, T7> action,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7)
    {
        action(t1, t2, t3, t4, t5, t6, t7);
        return UnitValue;
    }
    public static Unit Unit<T1, T2, T3, T4, T5, T6, T7, T8>
        (this Action<T1, T2, T3, T4, T5, T6, T7, T8> action,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8)
    {
        action(t1, t2, t3, t4, t5, t6, t7, t8);
        return UnitValue;
    }
    public static Unit Unit<T1, T2, T3, T4, T5, T6, T7, T8, T9>
        (this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> action,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9)
    {
        action(t1, t2, t3, t4, t5, t6, t7, t8, t9);
        return UnitValue;
    }
    public static Unit Unit<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>
        (this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> action,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10)
    {
        action(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10);
        return UnitValue;
    }
    public static Unit Unit<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>
        (this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> action,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11)
    {
        action(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11);
        return UnitValue;
    }
    public static Unit Unit<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>
        (this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> action,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12)
    {
        action(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12);
        return UnitValue;
    }
    public static Unit Unit<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>
        (this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> action,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13)
    {
        action(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13);
        return UnitValue;
    }
    public static Unit Unit<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>
        (this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> action,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14)
    {
        action(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14);
        return UnitValue;
    }
    public static Unit Unit<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>
        (this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> action,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15)
    {
        action(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15);
        return UnitValue;
    }
    public static Unit Unit<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>
        (this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> action,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16)
    {
        action(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16);
        return UnitValue;
    }

}
