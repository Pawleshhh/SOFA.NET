namespace SOFA.NET;

internal class Unit 
{

    public void Void() { }

    public static Func<Unit> Create
        (Action action)
        => () =>
        {
            action();
            return Fp.UnitValue;
        };
    public static Func<T, Unit> Create<T>
        (Action<T> action)
        => t =>
        {
            action(t);
            return Fp.UnitValue;
        };
    public static Func<T1, T2, Unit> Create<T1, T2>
        (Action<T1, T2> action)
        => (t1, t2) =>
        {
            action(t1, t2);
            return Fp.UnitValue;
        };
    public static Func<T1, T2, T3, Unit> Create<T1, T2, T3>
        (Action<T1, T2, T3> action)
        => (t1, t2, t3) =>
        {
            action(t1, t2, t3);
            return Fp.UnitValue;
        };
    public static Func<T1, T2, T3, T4, Unit> Create<T1, T2, T3, T4>
        (Action<T1, T2, T3, T4> action)
        => (t1, t2, t3, t4) =>
        {
            action(t1, t2, t3, t4);
            return Fp.UnitValue;
        };
    public static Func<T1, T2, T3, T4, T5, Unit> Create<T1, T2, T3, T4, T5>
        (Action<T1, T2, T3, T4, T5> action)
        => (t1, t2, t3, t4, t5) =>
        {
            action(t1, t2, t3, t4, t5);
            return Fp.UnitValue;
        };
    public static Func<T1, T2, T3, T4, T5, T6, Unit> Create<T1, T2, T3, T4, T5, T6>
        (Action<T1, T2, T3, T4, T5, T6> action)
        => (t1, t2, t3, t4, t5, t6) =>
        {
            action(t1, t2, t3, t4, t5, t6);
            return Fp.UnitValue;
        };
    public static Func<T1, T2, T3, T4, T5, T6, T7, Unit> Create<T1, T2, T3, T4, T5, T6, T7>
        (Action<T1, T2, T3, T4, T5, T6, T7> action)
        => (t1, t2, t3, t4, t5, t6, t7) =>
        {
            action(t1, t2, t3, t4, t5, t6, t7);
            return Fp.UnitValue;
        };
    public static Func<T1, T2, T3, T4, T5, T6, T7, T8, Unit> Create<T1, T2, T3, T4, T5, T6, T7, T8>
        (Action<T1, T2, T3, T4, T5, T6, T7, T8> action)
        => (t1, t2, t3, t4, t5, t6, t7, t8) =>
        {
            action(t1, t2, t3, t4, t5, t6, t7, t8);
            return Fp.UnitValue;
        };
    public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, Unit> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9>
        (Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> action)
        => (t1, t2, t3, t4, t5, t6, t7, t8, t9) =>
        {
            action(t1, t2, t3, t4, t5, t6, t7, t8, t9);
            return Fp.UnitValue;
        };
    public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, Unit> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>
        (Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> action)
        => (t1, t2, t3, t4, t5, t6, t7, t8, t9, t10) =>
        {
            action(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10);
            return Fp.UnitValue;
        };
    public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, Unit> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>
        (Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> action)
        => (t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11) =>
        {
            action(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11);
            return Fp.UnitValue;
        };
    public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, Unit> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>
        (Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> action)
        => (t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12) =>
        {
            action(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12);
            return Fp.UnitValue;
        };
    public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, Unit> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>
        (Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> action)
        => (t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13) =>
        {
            action(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13);
            return Fp.UnitValue;
        };
    public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, Unit> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>
        (Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> action)
        => (t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14) =>
        {
            action(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14);
            return Fp.UnitValue;
        };
    public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, Unit> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>
        (Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> action)
        => (t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15) =>
        {
            action(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15);
            return Fp.UnitValue;
        };
    public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, Unit> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>
        (Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> action)
        => (t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16) =>
        {
            action(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16);
            return Fp.UnitValue;
        };

}