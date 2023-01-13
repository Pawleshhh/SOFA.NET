namespace SOFA.NET;

internal static partial class Fp
{

    #region Partly Action Last arg

    public static Action Partly<TLast>(this Action<TLast> action, TLast last) => () => action(last);
    public static Action<TLast> Partly<T1, TLast>(this Action<T1, TLast> action,
        T1 t1) => last => action(t1, last);
    public static Action<TLast> Partly<T1, T2, TLast>(this Action<T1, T2, TLast> action,
        T1 t1, T2 t2) => last => action(t1, t2, last);
    public static Action<TLast> Partly<T1, T2, T3, TLast>(this Action<T1, T2, T3, TLast> action,
        T1 t1, T2 t2, T3 t3) => last => action(t1, t2, t3, last);
    public static Action<TLast> Partly<T1, T2, T3, T4, TLast>(this Action<T1, T2, T3, T4, TLast> action,
        T1 t1, T2 t2, T3 t3, T4 t4) => last => action(t1, t2, t3, t4, last);
    public static Action<TLast> Partly<T1, T2, T3, T4, T5, TLast>(this Action<T1, T2, T3, T4, T5, TLast> action,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5) => last => action(t1, t2, t3, t4, t5, last);
    public static Action<TLast> Partly<T1, T2, T3, T4, T5, T6, TLast>(this Action<T1, T2, T3, T4, T5, T6, TLast> action,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6) => last => action(t1, t2, t3, t4, t5, t6, last);
    public static Action<TLast> Partly<T1, T2, T3, T4, T5, T6, T7, TLast>(this Action<T1, T2, T3, T4, T5, T6, T7, TLast> action,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7) => last => action(t1, t2, t3, t4, t5, t6, t7, last);
    public static Action<TLast> Partly<T1, T2, T3, T4, T5, T6, T7, T8, TLast>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, TLast> action,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8) => last => action(t1, t2, t3, t4, t5, t6, t7, t8, last);
    public static Action<TLast> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, TLast>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, TLast> action,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9) => last => action(t1, t2, t3, t4, t5, t6, t7, t8, t9, last);
    public static Action<TLast> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TLast>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TLast> action,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10) => last => action(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, last);
    public static Action<TLast> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TLast>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TLast> action,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11) => last => action(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, last);
    public static Action<TLast> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TLast>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TLast> action,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12) => last => action(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, last);
    public static Action<TLast> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TLast>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TLast> action,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13) => last => action(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, last);
    public static Action<TLast> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TLast>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TLast> action,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14) => last => action(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, last);
    public static Action<TLast> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TLast>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TLast> action,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15) => last => action(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, last);

    #endregion Partly Action

    #region Partly Action Last 2 args

    public static Action<T1, TLast> Partly<T1, TLast>(this Action<T1, TLast> action) => (t1, last) => action(t1, last);
    public static Action<T2, TLast> Partly<T1, T2, TLast>(this Action<T1, T2, TLast> action,
        T1 t1) => (t2, last) => action(t1, t2, last);
    public static Action<T3, TLast> Partly<T1, T2, T3, TLast>(this Action<T1, T2, T3, TLast> action,
        T1 t1, T2 t2) => (t3, last) => action(t1, t2, t3, last);
    public static Action<T4, TLast> Partly<T1, T2, T3, T4, TLast>(this Action<T1, T2, T3, T4, TLast> action,
        T1 t1, T2 t2, T3 t3) => (t4, last) => action(t1, t2, t3, t4, last);
    public static Action<T5, TLast> Partly<T1, T2, T3, T4, T5, TLast>(this Action<T1, T2, T3, T4, T5, TLast> action,
        T1 t1, T2 t2, T3 t3, T4 t4) => (t5, last) => action(t1, t2, t3, t4, t5, last);
    public static Action<T6, TLast> Partly<T1, T2, T3, T4, T5, T6, TLast>(this Action<T1, T2, T3, T4, T5, T6, TLast> action,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5) => (t6, last) => action(t1, t2, t3, t4, t5, t6, last);
    public static Action<T7, TLast> Partly<T1, T2, T3, T4, T5, T6, T7, TLast>(this Action<T1, T2, T3, T4, T5, T6, T7, TLast> action,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6) => (t7, last) => action(t1, t2, t3, t4, t5, t6, t7, last);
    public static Action<T8, TLast> Partly<T1, T2, T3, T4, T5, T6, T7, T8, TLast>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, TLast> action,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7) => (t8, last) => action(t1, t2, t3, t4, t5, t6, t7, t8, last);
    public static Action<T9, TLast> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, TLast>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, TLast> action,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8) => (t9, last) => action(t1, t2, t3, t4, t5, t6, t7, t8, t9, last);
    public static Action<T10, TLast> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TLast>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TLast> action,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9) => (t10, last) => action(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, last);
    public static Action<T11, TLast> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TLast>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TLast> action,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10) => (t11, last) => action(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, last);
    public static Action<T12, TLast> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TLast>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TLast> action,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11) => (t12, last) => action(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, last);
    public static Action<T13, TLast> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TLast>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TLast> action,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12) => (t13, last) => action(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, last);
    public static Action<T14, TLast> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TLast>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TLast> action,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13) => (t14, last) => action(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, last);
    public static Action<T15, TLast> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TLast>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TLast> action,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14) => (t15, last) => action(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, last);

    #endregion Partly Action

    #region Partly Action Last 3 args
    public static Action<T2, T3, TLast> Partly<T1, T2, T3, TLast>(this Action<T1, T2, T3, TLast> action,
        T1 t1) => (t2, t3, last) => action(t1, t2, t3, last);
    public static Action<T3, T4, TLast> Partly<T1, T2, T3, T4, TLast>(this Action<T1, T2, T3, T4, TLast> action,
        T1 t1, T2 t2) => (t3, t4, last) => action(t1, t2, t3, t4, last);
    public static Action<T4, T5, TLast> Partly<T1, T2, T3, T4, T5, TLast>(this Action<T1, T2, T3, T4, T5, TLast> action,
        T1 t1, T2 t2, T3 t3) => (t4, t5, last) => action(t1, t2, t3, t4, t5, last);
    public static Action<T5, T6, TLast> Partly<T1, T2, T3, T4, T5, T6, TLast>(this Action<T1, T2, T3, T4, T5, T6, TLast> action,
        T1 t1, T2 t2, T3 t3, T4 t4) => (t5, t6, last) => action(t1, t2, t3, t4, t5, t6, last);
    public static Action<T6, T7, TLast> Partly<T1, T2, T3, T4, T5, T6, T7, TLast>(this Action<T1, T2, T3, T4, T5, T6, T7, TLast> action,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5) => (t6, t7, last) => action(t1, t2, t3, t4, t5, t6, t7, last);
    public static Action<T7, T8, TLast> Partly<T1, T2, T3, T4, T5, T6, T7, T8, TLast>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, TLast> action,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6) => (t7, t8, last) => action(t1, t2, t3, t4, t5, t6, t7, t8, last);
    public static Action<T8, T9, TLast> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, TLast>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, TLast> action,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7) => (t8, t9, last) => action(t1, t2, t3, t4, t5, t6, t7, t8, t9, last);
    public static Action<T9, T10, TLast> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TLast>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TLast> action,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8) => (t9, t10, last) => action(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, last);
    public static Action<T10, T11, TLast> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TLast>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TLast> action,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9) => (t10, t11, last) => action(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, last);
    public static Action<T11, T12, TLast> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TLast>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TLast> action,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10) => (t11, t12, last) => action(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, last);
    public static Action<T12, T13, TLast> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TLast>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TLast> action,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11) => (t12, t13, last) => action(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, last);
    public static Action<T13, T14, TLast> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TLast>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TLast> action,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12) => (t13, t14, last) => action(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, last);
    public static Action<T14, T15, TLast> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TLast>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TLast> action,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13) => (t14, t15, last) => action(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, last);
    #endregion

    #region Partly Action Last 4 args
    public static Action<T2, T3, T4, TLast> Partly<T1, T2, T3, T4, TLast>(this Action<T1, T2, T3, T4, TLast> action,
        T1 t1) => (t2, t3, t4, last) => action(t1, t2, t3, t4, last);
    public static Action<T3, T4, T5, TLast> Partly<T1, T2, T3, T4, T5, TLast>(this Action<T1, T2, T3, T4, T5, TLast> action,
        T1 t1, T2 t2) => (t3, t4, t5, last) => action(t1, t2, t3, t4, t5, last);
    public static Action<T4, T5, T6, TLast> Partly<T1, T2, T3, T4, T5, T6, TLast>(this Action<T1, T2, T3, T4, T5, T6, TLast> action,
        T1 t1, T2 t2, T3 t3) => (t4, t5, t6, last) => action(t1, t2, t3, t4, t5, t6, last);
    public static Action<T5, T6, T7, TLast> Partly<T1, T2, T3, T4, T5, T6, T7, TLast>(this Action<T1, T2, T3, T4, T5, T6, T7, TLast> action,
        T1 t1, T2 t2, T3 t3, T4 t4) => (t5, t6, t7, last) => action(t1, t2, t3, t4, t5, t6, t7, last);
    public static Action<T6, T7, T8, TLast> Partly<T1, T2, T3, T4, T5, T6, T7, T8, TLast>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, TLast> action,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5) => (t6, t7, t8, last) => action(t1, t2, t3, t4, t5, t6, t7, t8, last);
    public static Action<T7, T8, T9, TLast> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, TLast>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, TLast> action,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6) => (t7, t8, t9, last) => action(t1, t2, t3, t4, t5, t6, t7, t8, t9, last);
    public static Action<T8, T9, T10, TLast> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TLast>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TLast> action,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7) => (t8, t9, t10, last) => action(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, last);
    public static Action<T9, T10, T11, TLast> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TLast>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TLast> action,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8) => (t9, t10, t11, last) => action(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, last);
    public static Action<T10, T11, T12, TLast> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TLast>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TLast> action,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9) => (t10, t11, t12, last) => action(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, last);
    public static Action<T11, T12, T13, TLast> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TLast>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TLast> action,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10) => (t11, t12, t13, last) => action(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, last);
    public static Action<T12, T13, T14, TLast> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TLast>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TLast> action,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11) => (t12, t13, t14, last) => action(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, last);
    public static Action<T13, T14, T15, TLast> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TLast>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TLast> action,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12) => (t13, t14, t15, last) => action(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, last);
    #endregion

    #region Partly Action Last 5 args
    public static Action<T2, T3, T4, T5, TLast> Partly<T1, T2, T3, T4, T5, TLast>(this Action<T1, T2, T3, T4, T5, TLast> action,
        T1 t1) => (t2, t3, t4, t5, last) => action(t1, t2, t3, t4, t5, last);
    public static Action<T3, T4, T5, T6, TLast> Partly<T1, T2, T3, T4, T5, T6, TLast>(this Action<T1, T2, T3, T4, T5, T6, TLast> action,
        T1 t1, T2 t2) => (t3, t4, t5, t6, last) => action(t1, t2, t3, t4, t5, t6, last);
    public static Action<T4, T5, T6, T7, TLast> Partly<T1, T2, T3, T4, T5, T6, T7, TLast>(this Action<T1, T2, T3, T4, T5, T6, T7, TLast> action,
        T1 t1, T2 t2, T3 t3) => (t4, t5, t6, t7, last) => action(t1, t2, t3, t4, t5, t6, t7, last);
    public static Action<T5, T6, T7, T8, TLast> Partly<T1, T2, T3, T4, T5, T6, T7, T8, TLast>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, TLast> action,
        T1 t1, T2 t2, T3 t3, T4 t4) => (t5, t6, t7, t8, last) => action(t1, t2, t3, t4, t5, t6, t7, t8, last);
    public static Action<T6, T7, T8, T9, TLast> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, TLast>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, TLast> action,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5) => (t6, t7, t8, t9, last) => action(t1, t2, t3, t4, t5, t6, t7, t8, t9, last);
    public static Action<T7, T8, T9, T10, TLast> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TLast>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TLast> action,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6) => (t7, t8, t9, t10, last) => action(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, last);
    public static Action<T8, T9, T10, T11, TLast> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TLast>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TLast> action,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7) => (t8, t9, t10, t11, last) => action(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, last);
    public static Action<T9, T10, T11, T12, TLast> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TLast>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TLast> action,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8) => (t9, t10, t11, t12, last) => action(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, last);
    public static Action<T10, T11, T12, T13, TLast> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TLast>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TLast> action,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9) => (t10, t11, t12, t13, last) => action(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, last);
    public static Action<T11, T12, T13, T14, TLast> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TLast>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TLast> action,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10) => (t11, t12, t13, t14, last) => action(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, last);
    public static Action<T12, T13, T14, T15, TLast> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TLast>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TLast> action,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11) => (t12, t13, t14, t15, last) => action(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, last);
    #endregion

    #region Partly Action Last 6 args
    public static Action<T2, T3, T4, T5, T6, TLast> Partly<T1, T2, T3, T4, T5, T6, TLast>(this Action<T1, T2, T3, T4, T5, T6, TLast> action,
        T1 t1) => (t2, t3, t4, t5, t6, last) => action(t1, t2, t3, t4, t5, t6, last);
    public static Action<T3, T4, T5, T6, T7, TLast> Partly<T1, T2, T3, T4, T5, T6, T7, TLast>(this Action<T1, T2, T3, T4, T5, T6, T7, TLast> action,
        T1 t1, T2 t2) => (t3, t4, t5, t6, t7, last) => action(t1, t2, t3, t4, t5, t6, t7, last);
    public static Action<T4, T5, T6, T7, T8, TLast> Partly<T1, T2, T3, T4, T5, T6, T7, T8, TLast>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, TLast> action,
        T1 t1, T2 t2, T3 t3) => (t4, t5, t6, t7, t8, last) => action(t1, t2, t3, t4, t5, t6, t7, t8, last);
    public static Action<T5, T6, T7, T8, T9, TLast> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, TLast>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, TLast> action,
        T1 t1, T2 t2, T3 t3, T4 t4) => (t5, t6, t7, t8, t9, last) => action(t1, t2, t3, t4, t5, t6, t7, t8, t9, last);
    public static Action<T6, T7, T8, T9, T10, TLast> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TLast>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TLast> action,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5) => (t6, t7, t8, t9, t10, last) => action(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, last);
    public static Action<T7, T8, T9, T10, T11, TLast> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TLast>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TLast> action,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6) => (t7, t8, t9, t10, t11, last) => action(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, last);
    public static Action<T8, T9, T10, T11, T12, TLast> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TLast>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TLast> action,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7) => (t8, t9, t10, t11, t12, last) => action(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, last);
    public static Action<T9, T10, T11, T12, T13, TLast> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TLast>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TLast> action,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8) => (t9, t10, t11, t12, t13, last) => action(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, last);
    public static Action<T10, T11, T12, T13, T14, TLast> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TLast>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TLast> action,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9) => (t10, t11, t12, t13, t14, last) => action(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, last);
    public static Action<T11, T12, T13, T14, T15, TLast> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TLast>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TLast> action,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10) => (t11, t12, t13, t14, t15, last) => action(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, last);
    #endregion

    #region Partly Action Last 7 args
    public static Action<T2, T3, T4, T5, T6, T7, TLast> Partly<T1, T2, T3, T4, T5, T6, T7, TLast>(this Action<T1, T2, T3, T4, T5, T6, T7, TLast> action,
        T1 t1) => (t2, t3, t4, t5, t6, t7, last) => action(t1, t2, t3, t4, t5, t6, t7, last);
    public static Action<T3, T4, T5, T6, T7, T8, TLast> Partly<T1, T2, T3, T4, T5, T6, T7, T8, TLast>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, TLast> action,
        T1 t1, T2 t2) => (t3, t4, t5, t6, t7, t8, last) => action(t1, t2, t3, t4, t5, t6, t7, t8, last);
    public static Action<T4, T5, T6, T7, T8, T9, TLast> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, TLast>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, TLast> action,
        T1 t1, T2 t2, T3 t3) => (t4, t5, t6, t7, t8, t9, last) => action(t1, t2, t3, t4, t5, t6, t7, t8, t9, last);
    public static Action<T5, T6, T7, T8, T9, T10, TLast> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TLast>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TLast> action,
        T1 t1, T2 t2, T3 t3, T4 t4) => (t5, t6, t7, t8, t9, t10, last) => action(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, last);
    public static Action<T6, T7, T8, T9, T10, T11, TLast> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TLast>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TLast> action,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5) => (t6, t7, t8, t9, t10, t11, last) => action(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, last);
    public static Action<T7, T8, T9, T10, T11, T12, TLast> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TLast>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TLast> action,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6) => (t7, t8, t9, t10, t11, t12, last) => action(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, last);
    public static Action<T8, T9, T10, T11, T12, T13, TLast> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TLast>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TLast> action,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7) => (t8, t9, t10, t11, t12, t13, last) => action(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, last);
    public static Action<T9, T10, T11, T12, T13, T14, TLast> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TLast>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TLast> action,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8) => (t9, t10, t11, t12, t13, t14, last) => action(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, last);
    public static Action<T10, T11, T12, T13, T14, T15, TLast> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TLast>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TLast> action,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9) => (t10, t11, t12, t13, t14, t15, last) => action(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, last);
    #endregion

    #region Parlty Action Last 8 args
    public static Action<T2, T3, T4, T5, T6, T7, T8, TLast> Partly<T1, T2, T3, T4, T5, T6, T7, T8, TLast>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, TLast> action,
        T1 t1) => (t2, t3, t4, t5, t6, t7, t8, last) => action(t1, t2, t3, t4, t5, t6, t7, t8, last);
    public static Action<T3, T4, T5, T6, T7, T8, T9, TLast> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, TLast>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, TLast> action,
        T1 t1, T2 t2) => (t3, t4, t5, t6, t7, t8, t9, last) => action(t1, t2, t3, t4, t5, t6, t7, t8, t9, last);
    public static Action<T4, T5, T6, T7, T8, T9, T10, TLast> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TLast>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TLast> action,
        T1 t1, T2 t2, T3 t3) => (t4, t5, t6, t7, t8, t9, t10, last) => action(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, last);
    public static Action<T5, T6, T7, T8, T9, T10, T11, TLast> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TLast>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TLast> action,
        T1 t1, T2 t2, T3 t3, T4 t4) => (t5, t6, t7, t8, t9, t10, t11, last) => action(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, last);
    public static Action<T6, T7, T8, T9, T10, T11, T12, TLast> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TLast>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TLast> action,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5) => (t6, t7, t8, t9, t10, t11, t12, last) => action(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, last);
    public static Action<T7, T8, T9, T10, T11, T12, T13, TLast> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TLast>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TLast> action,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6) => (t7, t8, t9, t10, t11, t12, t13, last) => action(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, last);
    public static Action<T8, T9, T10, T11, T12, T13, T14, TLast> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TLast>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TLast> action,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7) => (t8, t9, t10, t11, t12, t13, t14, last) => action(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, last);
    public static Action<T9, T10, T11, T12, T13, T14, T15, TLast> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TLast>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TLast> action,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8) => (t9, t10, t11, t12, t13, t14, t15, last) => action(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, last);
    #endregion

    #region Parlty Action Last 9 args
    public static Action<T2, T3, T4, T5, T6, T7, T8, T9, TLast> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, TLast>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, TLast> action,
        T1 t1) => (t2, t3, t4, t5, t6, t7, t8, t9, last) => action(t1, t2, t3, t4, t5, t6, t7, t8, t9, last);
    public static Action<T3, T4, T5, T6, T7, T8, T9, T10, TLast> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TLast>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TLast> action,
        T1 t1, T2 t2) => (t3, t4, t5, t6, t7, t8, t9, t10, last) => action(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, last);
    public static Action<T4, T5, T6, T7, T8, T9, T10, T11, TLast> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TLast>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TLast> action,
        T1 t1, T2 t2, T3 t3) => (t4, t5, t6, t7, t8, t9, t10, t11, last) => action(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, last);
    public static Action<T5, T6, T7, T8, T9, T10, T11, T12, TLast> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TLast>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TLast> action,
        T1 t1, T2 t2, T3 t3, T4 t4) => (t5, t6, t7, t8, t9, t10, t11, t12, last) => action(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, last);
    public static Action<T6, T7, T8, T9, T10, T11, T12, T13, TLast> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TLast>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TLast> action,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5) => (t6, t7, t8, t9, t10, t11, t12, t13, last) => action(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, last);
    public static Action<T7, T8, T9, T10, T11, T12, T13, T14, TLast> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TLast>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TLast> action,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6) => (t7, t8, t9, t10, t11, t12, t13, t14, last) => action(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, last);
    public static Action<T8, T9, T10, T11, T12, T13, T14, T15, TLast> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TLast>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TLast> action,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7) => (t8, t9, t10, t11, t12, t13, t14, t15, last) => action(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, last);
    #endregion

    #region Partly Action Last 10 args
    public static Action<T2, T3, T4, T5, T6, T7, T8, T9, T10, TLast> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TLast>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TLast> action,
        T1 t1) => (t2, t3, t4, t5, t6, t7, t8, t9, t10, last) => action(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, last);
    public static Action<T3, T4, T5, T6, T7, T8, T9, T10, T11, TLast> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TLast>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TLast> action,
        T1 t1, T2 t2) => (t3, t4, t5, t6, t7, t8, t9, t10, t11, last) => action(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, last);
    public static Action<T4, T5, T6, T7, T8, T9, T10, T11, T12, TLast> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TLast>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TLast> action,
        T1 t1, T2 t2, T3 t3) => (t4, t5, t6, t7, t8, t9, t10, t11, t12, last) => action(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, last);
    public static Action<T5, T6, T7, T8, T9, T10, T11, T12, T13, TLast> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TLast>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TLast> action,
        T1 t1, T2 t2, T3 t3, T4 t4) => (t5, t6, t7, t8, t9, t10, t11, t12, t13, last) => action(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, last);
    public static Action<T6, T7, T8, T9, T10, T11, T12, T13, T14, TLast> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TLast>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TLast> action,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5) => (t6, t7, t8, t9, t10, t11, t12, t13, t14, last) => action(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, last);
    public static Action<T7, T8, T9, T10, T11, T12, T13, T14, T15, TLast> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TLast>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TLast> action,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6) => (t7, t8, t9, t10, t11, t12, t13, t14, t15, last) => action(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, last);
    #endregion

    #region Partly Action Last 11 args
    public static Action<T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TLast> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TLast>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TLast> action,
            T1 t1) => (t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, last) => action(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, last);
    public static Action<T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TLast> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TLast>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TLast> action,
        T1 t1, T2 t2) => (t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, last) => action(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, last);
    public static Action<T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TLast> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TLast>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TLast> action,
        T1 t1, T2 t2, T3 t3) => (t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, last) => action(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, last);
    public static Action<T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TLast> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TLast>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TLast> action,
        T1 t1, T2 t2, T3 t3, T4 t4) => (t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, last) => action(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, last);
    public static Action<T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TLast> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TLast>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TLast> action,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5) => (t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, last) => action(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, last);
    #endregion

    #region Partly Action Last 12 args
    public static Action<T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TLast> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TLast>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TLast> action,
        T1 t1) => (t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, last) => action(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, last);
    public static Action<T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TLast> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TLast>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TLast> action,
        T1 t1, T2 t2) => (t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, last) => action(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, last);
    public static Action<T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TLast> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TLast>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TLast> action,
        T1 t1, T2 t2, T3 t3) => (t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, last) => action(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, last);
    public static Action<T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TLast> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TLast>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TLast> action,
        T1 t1, T2 t2, T3 t3, T4 t4) => (t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, last) => action(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, last);
    #endregion

    #region Partly Action Last 13 args
    public static Action<T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TLast> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TLast>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TLast> action,
            T1 t1) => (t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, last) => action(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, last);
    public static Action<T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TLast> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TLast>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TLast> action,
        T1 t1, T2 t2) => (t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, last) => action(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, last);
    public static Action<T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TLast> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TLast>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TLast> action,
        T1 t1, T2 t2, T3 t3) => (t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, last) => action(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, last);
    #endregion

    #region Partly Action Last 14 args
    public static Action<T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TLast> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TLast>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TLast> action,
        T1 t1) => (t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, last) => action(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, last);
    public static Action<T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TLast> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TLast>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TLast> action,
        T1 t1, T2 t2) => (t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, last) => action(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, last);
    #endregion

    #region Partly Action Last 15 args
    public static Action<T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TLast> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TLast>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TLast> action,
        T1 t1) => (t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, last) => action(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, last);
    #endregion

    #region Partly Func Last arg

    public static Func<TResult> Partly<TLast, TResult>(this Func<TLast, TResult> func, TLast last) => () => func(last);
    public static Func<TLast, TResult> Partly<T1, TLast, TResult>(this Func<T1, TLast, TResult> func,
        T1 t1) => last => func(t1, last);
    public static Func<TLast, TResult> Partly<T1, T2, TLast, TResult>(this Func<T1, T2, TLast, TResult> func,
        T1 t1, T2 t2) => last => func(t1, t2, last);
    public static Func<TLast, TResult> Partly<T1, T2, T3, TLast, TResult>(this Func<T1, T2, T3, TLast, TResult> func,
        T1 t1, T2 t2, T3 t3) => last => func(t1, t2, t3, last);
    public static Func<TLast, TResult> Partly<T1, T2, T3, T4, TLast, TResult>(this Func<T1, T2, T3, T4, TLast, TResult> func,
        T1 t1, T2 t2, T3 t3, T4 t4) => last => func(t1, t2, t3, t4, last);
    public static Func<TLast, TResult> Partly<T1, T2, T3, T4, T5, TLast, TResult>(this Func<T1, T2, T3, T4, T5, TLast, TResult> func,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5) => last => func(t1, t2, t3, t4, t5, last);
    public static Func<TLast, TResult> Partly<T1, T2, T3, T4, T5, T6, TLast, TResult>(this Func<T1, T2, T3, T4, T5, T6, TLast, TResult> func,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6) => last => func(t1, t2, t3, t4, t5, t6, last);
    public static Func<TLast, TResult> Partly<T1, T2, T3, T4, T5, T6, T7, TLast, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, TLast, TResult> func,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7) => last => func(t1, t2, t3, t4, t5, t6, t7, last);
    public static Func<TLast, TResult> Partly<T1, T2, T3, T4, T5, T6, T7, T8, TLast, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, TLast, TResult> func,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8) => last => func(t1, t2, t3, t4, t5, t6, t7, t8, last);
    public static Func<TLast, TResult> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, TLast, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TLast, TResult> func,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9) => last => func(t1, t2, t3, t4, t5, t6, t7, t8, t9, last);
    public static Func<TLast, TResult> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TLast, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TLast, TResult> func,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10) => last => func(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, last);
    public static Func<TLast, TResult> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TLast, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TLast, TResult> func,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11) => last => func(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, last);
    public static Func<TLast, TResult> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TLast, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TLast, TResult> func,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12) => last => func(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, last);
    public static Func<TLast, TResult> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TLast, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TLast, TResult> func,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13) => last => func(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, last);
    public static Func<TLast, TResult> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TLast, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TLast, TResult> func,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14) => last => func(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, last);
    public static Func<TLast, TResult> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TLast, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TLast, TResult> func,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15) => last => func(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, last);

    #endregion Partly

    #region Partly Func Last 2 args

    public static Func<T1, TLast, TResult> Partly<T1, TLast, TResult>(this Func<T1, TLast, TResult> func) => (t1, last) => func(t1, last);
    public static Func<T2, TLast, TResult> Partly<T1, T2, TLast, TResult>(this Func<T1, T2, TLast, TResult> func,
        T1 t1) => (t2, last) => func(t1, t2, last);
    public static Func<T3, TLast, TResult> Partly<T1, T2, T3, TLast, TResult>(this Func<T1, T2, T3, TLast, TResult> func,
        T1 t1, T2 t2) => (t3, last) => func(t1, t2, t3, last);
    public static Func<T4, TLast, TResult> Partly<T1, T2, T3, T4, TLast, TResult>(this Func<T1, T2, T3, T4, TLast, TResult> func,
        T1 t1, T2 t2, T3 t3) => (t4, last) => func(t1, t2, t3, t4, last);
    public static Func<T5, TLast, TResult> Partly<T1, T2, T3, T4, T5, TLast, TResult>(this Func<T1, T2, T3, T4, T5, TLast, TResult> func,
        T1 t1, T2 t2, T3 t3, T4 t4) => (t5, last) => func(t1, t2, t3, t4, t5, last);
    public static Func<T6, TLast, TResult> Partly<T1, T2, T3, T4, T5, T6, TLast, TResult>(this Func<T1, T2, T3, T4, T5, T6, TLast, TResult> func,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5) => (t6, last) => func(t1, t2, t3, t4, t5, t6, last);
    public static Func<T7, TLast, TResult> Partly<T1, T2, T3, T4, T5, T6, T7, TLast, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, TLast, TResult> func,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6) => (t7, last) => func(t1, t2, t3, t4, t5, t6, t7, last);
    public static Func<T8, TLast, TResult> Partly<T1, T2, T3, T4, T5, T6, T7, T8, TLast, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, TLast, TResult> func,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7) => (t8, last) => func(t1, t2, t3, t4, t5, t6, t7, t8, last);
    public static Func<T9, TLast, TResult> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, TLast, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TLast, TResult> func,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8) => (t9, last) => func(t1, t2, t3, t4, t5, t6, t7, t8, t9, last);
    public static Func<T10, TLast, TResult> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TLast, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TLast, TResult> func,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9) => (t10, last) => func(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, last);
    public static Func<T11, TLast, TResult> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TLast, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TLast, TResult> func,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10) => (t11, last) => func(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, last);
    public static Func<T12, TLast, TResult> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TLast, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TLast, TResult> func,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11) => (t12, last) => func(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, last);
    public static Func<T13, TLast, TResult> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TLast, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TLast, TResult> func,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12) => (t13, last) => func(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, last);
    public static Func<T14, TLast, TResult> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TLast, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TLast, TResult> func,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13) => (t14, last) => func(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, last);
    public static Func<T15, TLast, TResult> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TLast, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TLast, TResult> func,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14) => (t15, last) => func(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, last);

    #endregion Partly Func

    #region Partly Func Last 3 args
    public static Func<T2, T3, TLast, TResult> Partly<T1, T2, T3, TLast, TResult>(this Func<T1, T2, T3, TLast, TResult> func,
        T1 t1) => (t2, t3, last) => func(t1, t2, t3, last);
    public static Func<T3, T4, TLast, TResult> Partly<T1, T2, T3, T4, TLast, TResult>(this Func<T1, T2, T3, T4, TLast, TResult> func,
        T1 t1, T2 t2) => (t3, t4, last) => func(t1, t2, t3, t4, last);
    public static Func<T4, T5, TLast, TResult> Partly<T1, T2, T3, T4, T5, TLast, TResult>(this Func<T1, T2, T3, T4, T5, TLast, TResult> func,
        T1 t1, T2 t2, T3 t3) => (t4, t5, last) => func(t1, t2, t3, t4, t5, last);
    public static Func<T5, T6, TLast, TResult> Partly<T1, T2, T3, T4, T5, T6, TLast, TResult>(this Func<T1, T2, T3, T4, T5, T6, TLast, TResult> func,
        T1 t1, T2 t2, T3 t3, T4 t4) => (t5, t6, last) => func(t1, t2, t3, t4, t5, t6, last);
    public static Func<T6, T7, TLast, TResult> Partly<T1, T2, T3, T4, T5, T6, T7, TLast, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, TLast, TResult> func,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5) => (t6, t7, last) => func(t1, t2, t3, t4, t5, t6, t7, last);
    public static Func<T7, T8, TLast, TResult> Partly<T1, T2, T3, T4, T5, T6, T7, T8, TLast, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, TLast, TResult> func,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6) => (t7, t8, last) => func(t1, t2, t3, t4, t5, t6, t7, t8, last);
    public static Func<T8, T9, TLast, TResult> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, TLast, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TLast, TResult> func,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7) => (t8, t9, last) => func(t1, t2, t3, t4, t5, t6, t7, t8, t9, last);
    public static Func<T9, T10, TLast, TResult> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TLast, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TLast, TResult> func,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8) => (t9, t10, last) => func(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, last);
    public static Func<T10, T11, TLast, TResult> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TLast, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TLast, TResult> func,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9) => (t10, t11, last) => func(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, last);
    public static Func<T11, T12, TLast, TResult> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TLast, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TLast, TResult> func,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10) => (t11, t12, last) => func(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, last);
    public static Func<T12, T13, TLast, TResult> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TLast, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TLast, TResult> func,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11) => (t12, t13, last) => func(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, last);
    public static Func<T13, T14, TLast, TResult> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TLast, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TLast, TResult> func,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12) => (t13, t14, last) => func(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, last);
    public static Func<T14, T15, TLast, TResult> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TLast, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TLast, TResult> func,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13) => (t14, t15, last) => func(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, last);
    #endregion

    #region Partly Func Last 4 args
    public static Func<T2, T3, T4, TLast, TResult> Partly<T1, T2, T3, T4, TLast, TResult>(this Func<T1, T2, T3, T4, TLast, TResult> func,
        T1 t1) => (t2, t3, t4, last) => func(t1, t2, t3, t4, last);
    public static Func<T3, T4, T5, TLast, TResult> Partly<T1, T2, T3, T4, T5, TLast, TResult>(this Func<T1, T2, T3, T4, T5, TLast, TResult> func,
        T1 t1, T2 t2) => (t3, t4, t5, last) => func(t1, t2, t3, t4, t5, last);
    public static Func<T4, T5, T6, TLast, TResult> Partly<T1, T2, T3, T4, T5, T6, TLast, TResult>(this Func<T1, T2, T3, T4, T5, T6, TLast, TResult> func,
        T1 t1, T2 t2, T3 t3) => (t4, t5, t6, last) => func(t1, t2, t3, t4, t5, t6, last);
    public static Func<T5, T6, T7, TLast, TResult> Partly<T1, T2, T3, T4, T5, T6, T7, TLast, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, TLast, TResult> func,
        T1 t1, T2 t2, T3 t3, T4 t4) => (t5, t6, t7, last) => func(t1, t2, t3, t4, t5, t6, t7, last);
    public static Func<T6, T7, T8, TLast, TResult> Partly<T1, T2, T3, T4, T5, T6, T7, T8, TLast, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, TLast, TResult> func,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5) => (t6, t7, t8, last) => func(t1, t2, t3, t4, t5, t6, t7, t8, last);
    public static Func<T7, T8, T9, TLast, TResult> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, TLast, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TLast, TResult> func,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6) => (t7, t8, t9, last) => func(t1, t2, t3, t4, t5, t6, t7, t8, t9, last);
    public static Func<T8, T9, T10, TLast, TResult> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TLast, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TLast, TResult> func,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7) => (t8, t9, t10, last) => func(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, last);
    public static Func<T9, T10, T11, TLast, TResult> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TLast, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TLast, TResult> func,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8) => (t9, t10, t11, last) => func(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, last);
    public static Func<T10, T11, T12, TLast, TResult> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TLast, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TLast, TResult> func,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9) => (t10, t11, t12, last) => func(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, last);
    public static Func<T11, T12, T13, TLast, TResult> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TLast, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TLast, TResult> func,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10) => (t11, t12, t13, last) => func(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, last);
    public static Func<T12, T13, T14, TLast, TResult> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TLast, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TLast, TResult> func,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11) => (t12, t13, t14, last) => func(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, last);
    public static Func<T13, T14, T15, TLast, TResult> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TLast, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TLast, TResult> func,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12) => (t13, t14, t15, last) => func(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, last);
    #endregion

    #region Partly Func Last 5 args
    public static Func<T2, T3, T4, T5, TLast, TResult> Partly<T1, T2, T3, T4, T5, TLast, TResult>(this Func<T1, T2, T3, T4, T5, TLast, TResult> func,
        T1 t1) => (t2, t3, t4, t5, last) => func(t1, t2, t3, t4, t5, last);
    public static Func<T3, T4, T5, T6, TLast, TResult> Partly<T1, T2, T3, T4, T5, T6, TLast, TResult>(this Func<T1, T2, T3, T4, T5, T6, TLast, TResult> func,
        T1 t1, T2 t2) => (t3, t4, t5, t6, last) => func(t1, t2, t3, t4, t5, t6, last);
    public static Func<T4, T5, T6, T7, TLast, TResult> Partly<T1, T2, T3, T4, T5, T6, T7, TLast, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, TLast, TResult> func,
        T1 t1, T2 t2, T3 t3) => (t4, t5, t6, t7, last) => func(t1, t2, t3, t4, t5, t6, t7, last);
    public static Func<T5, T6, T7, T8, TLast, TResult> Partly<T1, T2, T3, T4, T5, T6, T7, T8, TLast, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, TLast, TResult> func,
        T1 t1, T2 t2, T3 t3, T4 t4) => (t5, t6, t7, t8, last) => func(t1, t2, t3, t4, t5, t6, t7, t8, last);
    public static Func<T6, T7, T8, T9, TLast, TResult> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, TLast, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TLast, TResult> func,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5) => (t6, t7, t8, t9, last) => func(t1, t2, t3, t4, t5, t6, t7, t8, t9, last);
    public static Func<T7, T8, T9, T10, TLast, TResult> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TLast, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TLast, TResult> func,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6) => (t7, t8, t9, t10, last) => func(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, last);
    public static Func<T8, T9, T10, T11, TLast, TResult> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TLast, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TLast, TResult> func,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7) => (t8, t9, t10, t11, last) => func(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, last);
    public static Func<T9, T10, T11, T12, TLast, TResult> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TLast, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TLast, TResult> func,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8) => (t9, t10, t11, t12, last) => func(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, last);
    public static Func<T10, T11, T12, T13, TLast, TResult> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TLast, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TLast, TResult> func,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9) => (t10, t11, t12, t13, last) => func(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, last);
    public static Func<T11, T12, T13, T14, TLast, TResult> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TLast, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TLast, TResult> func,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10) => (t11, t12, t13, t14, last) => func(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, last);
    public static Func<T12, T13, T14, T15, TLast, TResult> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TLast, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TLast, TResult> func,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11) => (t12, t13, t14, t15, last) => func(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, last);
    #endregion

    #region Partly Func Last 6 args
    public static Func<T2, T3, T4, T5, T6, TLast, TResult> Partly<T1, T2, T3, T4, T5, T6, TLast, TResult>(this Func<T1, T2, T3, T4, T5, T6, TLast, TResult> func,
        T1 t1) => (t2, t3, t4, t5, t6, last) => func(t1, t2, t3, t4, t5, t6, last);
    public static Func<T3, T4, T5, T6, T7, TLast, TResult> Partly<T1, T2, T3, T4, T5, T6, T7, TLast, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, TLast, TResult> func,
        T1 t1, T2 t2) => (t3, t4, t5, t6, t7, last) => func(t1, t2, t3, t4, t5, t6, t7, last);
    public static Func<T4, T5, T6, T7, T8, TLast, TResult> Partly<T1, T2, T3, T4, T5, T6, T7, T8, TLast, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, TLast, TResult> func,
        T1 t1, T2 t2, T3 t3) => (t4, t5, t6, t7, t8, last) => func(t1, t2, t3, t4, t5, t6, t7, t8, last);
    public static Func<T5, T6, T7, T8, T9, TLast, TResult> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, TLast, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TLast, TResult> func,
        T1 t1, T2 t2, T3 t3, T4 t4) => (t5, t6, t7, t8, t9, last) => func(t1, t2, t3, t4, t5, t6, t7, t8, t9, last);
    public static Func<T6, T7, T8, T9, T10, TLast, TResult> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TLast, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TLast, TResult> func,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5) => (t6, t7, t8, t9, t10, last) => func(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, last);
    public static Func<T7, T8, T9, T10, T11, TLast, TResult> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TLast, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TLast, TResult> func,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6) => (t7, t8, t9, t10, t11, last) => func(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, last);
    public static Func<T8, T9, T10, T11, T12, TLast, TResult> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TLast, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TLast, TResult> func,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7) => (t8, t9, t10, t11, t12, last) => func(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, last);
    public static Func<T9, T10, T11, T12, T13, TLast, TResult> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TLast, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TLast, TResult> func,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8) => (t9, t10, t11, t12, t13, last) => func(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, last);
    public static Func<T10, T11, T12, T13, T14, TLast, TResult> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TLast, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TLast, TResult> func,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9) => (t10, t11, t12, t13, t14, last) => func(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, last);
    public static Func<T11, T12, T13, T14, T15, TLast, TResult> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TLast, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TLast, TResult> func,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10) => (t11, t12, t13, t14, t15, last) => func(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, last);
    #endregion

    #region Partly Func Last 7 args
    public static Func<T2, T3, T4, T5, T6, T7, TLast, TResult> Partly<T1, T2, T3, T4, T5, T6, T7, TLast, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, TLast, TResult> func,
        T1 t1) => (t2, t3, t4, t5, t6, t7, last) => func(t1, t2, t3, t4, t5, t6, t7, last);
    public static Func<T3, T4, T5, T6, T7, T8, TLast, TResult> Partly<T1, T2, T3, T4, T5, T6, T7, T8, TLast, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, TLast, TResult> func,
        T1 t1, T2 t2) => (t3, t4, t5, t6, t7, t8, last) => func(t1, t2, t3, t4, t5, t6, t7, t8, last);
    public static Func<T4, T5, T6, T7, T8, T9, TLast, TResult> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, TLast, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TLast, TResult> func,
        T1 t1, T2 t2, T3 t3) => (t4, t5, t6, t7, t8, t9, last) => func(t1, t2, t3, t4, t5, t6, t7, t8, t9, last);
    public static Func<T5, T6, T7, T8, T9, T10, TLast, TResult> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TLast, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TLast, TResult> func,
        T1 t1, T2 t2, T3 t3, T4 t4) => (t5, t6, t7, t8, t9, t10, last) => func(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, last);
    public static Func<T6, T7, T8, T9, T10, T11, TLast, TResult> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TLast, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TLast, TResult> func,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5) => (t6, t7, t8, t9, t10, t11, last) => func(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, last);
    public static Func<T7, T8, T9, T10, T11, T12, TLast, TResult> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TLast, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TLast, TResult> func,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6) => (t7, t8, t9, t10, t11, t12, last) => func(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, last);
    public static Func<T8, T9, T10, T11, T12, T13, TLast, TResult> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TLast, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TLast, TResult> func,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7) => (t8, t9, t10, t11, t12, t13, last) => func(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, last);
    public static Func<T9, T10, T11, T12, T13, T14, TLast, TResult> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TLast, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TLast, TResult> func,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8) => (t9, t10, t11, t12, t13, t14, last) => func(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, last);
    public static Func<T10, T11, T12, T13, T14, T15, TLast, TResult> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TLast, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TLast, TResult> func,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9) => (t10, t11, t12, t13, t14, t15, last) => func(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, last);
    #endregion

    #region Partly Func Last 8 args
    public static Func<T2, T3, T4, T5, T6, T7, T8, TLast, TResult> Partly<T1, T2, T3, T4, T5, T6, T7, T8, TLast, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, TLast, TResult> func,
        T1 t1) => (t2, t3, t4, t5, t6, t7, t8, last) => func(t1, t2, t3, t4, t5, t6, t7, t8, last);
    public static Func<T3, T4, T5, T6, T7, T8, T9, TLast, TResult> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, TLast, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TLast, TResult> func,
        T1 t1, T2 t2) => (t3, t4, t5, t6, t7, t8, t9, last) => func(t1, t2, t3, t4, t5, t6, t7, t8, t9, last);
    public static Func<T4, T5, T6, T7, T8, T9, T10, TLast, TResult> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TLast, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TLast, TResult> func,
        T1 t1, T2 t2, T3 t3) => (t4, t5, t6, t7, t8, t9, t10, last) => func(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, last);
    public static Func<T5, T6, T7, T8, T9, T10, T11, TLast, TResult> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TLast, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TLast, TResult> func,
        T1 t1, T2 t2, T3 t3, T4 t4) => (t5, t6, t7, t8, t9, t10, t11, last) => func(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, last);
    public static Func<T6, T7, T8, T9, T10, T11, T12, TLast, TResult> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TLast, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TLast, TResult> func,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5) => (t6, t7, t8, t9, t10, t11, t12, last) => func(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, last);
    public static Func<T7, T8, T9, T10, T11, T12, T13, TLast, TResult> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TLast, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TLast, TResult> func,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6) => (t7, t8, t9, t10, t11, t12, t13, last) => func(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, last);
    public static Func<T8, T9, T10, T11, T12, T13, T14, TLast, TResult> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TLast, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TLast, TResult> func,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7) => (t8, t9, t10, t11, t12, t13, t14, last) => func(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, last);
    public static Func<T9, T10, T11, T12, T13, T14, T15, TLast, TResult> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TLast, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TLast, TResult> func,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8) => (t9, t10, t11, t12, t13, t14, t15, last) => func(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, last);
    #endregion

    #region Partly Func Last 9 args
    public static Func<T2, T3, T4, T5, T6, T7, T8, T9, TLast, TResult> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, TLast, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TLast, TResult> func,
        T1 t1) => (t2, t3, t4, t5, t6, t7, t8, t9, last) => func(t1, t2, t3, t4, t5, t6, t7, t8, t9, last);
    public static Func<T3, T4, T5, T6, T7, T8, T9, T10, TLast, TResult> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TLast, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TLast, TResult> func,
        T1 t1, T2 t2) => (t3, t4, t5, t6, t7, t8, t9, t10, last) => func(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, last);
    public static Func<T4, T5, T6, T7, T8, T9, T10, T11, TLast, TResult> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TLast, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TLast, TResult> func,
        T1 t1, T2 t2, T3 t3) => (t4, t5, t6, t7, t8, t9, t10, t11, last) => func(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, last);
    public static Func<T5, T6, T7, T8, T9, T10, T11, T12, TLast, TResult> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TLast, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TLast, TResult> func,
        T1 t1, T2 t2, T3 t3, T4 t4) => (t5, t6, t7, t8, t9, t10, t11, t12, last) => func(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, last);
    public static Func<T6, T7, T8, T9, T10, T11, T12, T13, TLast, TResult> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TLast, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TLast, TResult> func,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5) => (t6, t7, t8, t9, t10, t11, t12, t13, last) => func(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, last);
    public static Func<T7, T8, T9, T10, T11, T12, T13, T14, TLast, TResult> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TLast, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TLast, TResult> func,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6) => (t7, t8, t9, t10, t11, t12, t13, t14, last) => func(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, last);
    public static Func<T8, T9, T10, T11, T12, T13, T14, T15, TLast, TResult> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TLast, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TLast, TResult> func,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7) => (t8, t9, t10, t11, t12, t13, t14, t15, last) => func(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, last);
    #endregion

    #region Partly Func Last 10 args
    public static Func<T2, T3, T4, T5, T6, T7, T8, T9, T10, TLast, TResult> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TLast, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TLast, TResult> func,
        T1 t1) => (t2, t3, t4, t5, t6, t7, t8, t9, t10, last) => func(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, last);
    public static Func<T3, T4, T5, T6, T7, T8, T9, T10, T11, TLast, TResult> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TLast, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TLast, TResult> func,
        T1 t1, T2 t2) => (t3, t4, t5, t6, t7, t8, t9, t10, t11, last) => func(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, last);
    public static Func<T4, T5, T6, T7, T8, T9, T10, T11, T12, TLast, TResult> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TLast, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TLast, TResult> func,
        T1 t1, T2 t2, T3 t3) => (t4, t5, t6, t7, t8, t9, t10, t11, t12, last) => func(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, last);
    public static Func<T5, T6, T7, T8, T9, T10, T11, T12, T13, TLast, TResult> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TLast, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TLast, TResult> func,
        T1 t1, T2 t2, T3 t3, T4 t4) => (t5, t6, t7, t8, t9, t10, t11, t12, t13, last) => func(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, last);
    public static Func<T6, T7, T8, T9, T10, T11, T12, T13, T14, TLast, TResult> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TLast, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TLast, TResult> func,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5) => (t6, t7, t8, t9, t10, t11, t12, t13, t14, last) => func(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, last);
    public static Func<T7, T8, T9, T10, T11, T12, T13, T14, T15, TLast, TResult> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TLast, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TLast, TResult> func,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6) => (t7, t8, t9, t10, t11, t12, t13, t14, t15, last) => func(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, last);
    #endregion

    #region Partly Func Last 11 args
    public static Func<T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TLast, TResult> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TLast, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TLast, TResult> func,
            T1 t1) => (t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, last) => func(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, last);
    public static Func<T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TLast, TResult> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TLast, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TLast, TResult> func,
        T1 t1, T2 t2) => (t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, last) => func(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, last);
    public static Func<T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TLast, TResult> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TLast, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TLast, TResult> func,
        T1 t1, T2 t2, T3 t3) => (t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, last) => func(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, last);
    public static Func<T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TLast, TResult> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TLast, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TLast, TResult> func,
        T1 t1, T2 t2, T3 t3, T4 t4) => (t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, last) => func(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, last);
    public static Func<T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TLast, TResult> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TLast, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TLast, TResult> func,
        T1 t1, T2 t2, T3 t3, T4 t4, T5 t5) => (t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, last) => func(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, last);
    #endregion

    #region Partly Func Last 12 args
    public static Func<T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TLast, TResult> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TLast, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TLast, TResult> func,
        T1 t1) => (t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, last) => func(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, last);
    public static Func<T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TLast, TResult> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TLast, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TLast, TResult> func,
        T1 t1, T2 t2) => (t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, last) => func(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, last);
    public static Func<T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TLast, TResult> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TLast, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TLast, TResult> func,
        T1 t1, T2 t2, T3 t3) => (t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, last) => func(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, last);
    public static Func<T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TLast, TResult> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TLast, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TLast, TResult> func,
        T1 t1, T2 t2, T3 t3, T4 t4) => (t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, last) => func(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, last);
    #endregion

    #region Partly Func Last 13 args
    public static Func<T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TLast, TResult> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TLast, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TLast, TResult> func,
            T1 t1) => (t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, last) => func(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, last);
    public static Func<T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TLast, TResult> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TLast, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TLast, TResult> func,
        T1 t1, T2 t2) => (t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, last) => func(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, last);
    public static Func<T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TLast, TResult> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TLast, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TLast, TResult> func,
        T1 t1, T2 t2, T3 t3) => (t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, last) => func(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, last);
    #endregion

    #region Partly Func Last 14 args
    public static Func<T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TLast, TResult> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TLast, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TLast, TResult> func,
        T1 t1) => (t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, last) => func(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, last);
    public static Func<T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TLast, TResult> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TLast, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TLast, TResult> func,
        T1 t1, T2 t2) => (t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, last) => func(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, last);
    #endregion

    #region Partly Func Last 15 args
    public static Func<T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TLast, TResult> Partly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TLast, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TLast, TResult> func,
        T1 t1) => (t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, last) => func(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, last);
    #endregion

}
