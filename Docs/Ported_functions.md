#### Astronomy/Calendars
- [x] int iauCal2jd(int iy, int im, int id, double *djm0, double *djm);
- [x] double iauEpb(double dj1, double dj2);
- [x] void iauEpb2jd(double epb, double *djm0, double *djm);
- [x] double iauEpj(double dj1, double dj2);
- [x] void iauEpj2jd(double epj, double *djm0, double *djm);
- [x] int iauJd2cal(double dj1, double dj2, int *iy, int *im, int *id, double *fd);
- ~~[ ] int iauJdcalf(int ndp, double dj1, double dj2, int iymdf[4]);~~

#### Astronomy/Astrometry
- [ ] void iauAb(double pnat[3], double v[3], double s, double bm1,
           double ppr[3]);
- [ ] void iauApcg(double date1, double date2,
             double ebpv[2][3], double ehp[3],
             iauASTROM *astrom);
- [ ] void iauApcg13(double date1, double date2, iauASTROM *astrom);
- [ ] void iauApci(double date1, double date2,
             double ebpv[2][3], double ehp[3],
             double x, double y, double s,
             iauASTROM *astrom);
- [ ] void iauApci13(double date1, double date2,
               iauASTROM *astrom, double *eo);
- [ ] void iauApco(double date1, double date2,
             double ebpv[2][3], double ehp[3],
             double x, double y, double s, double theta,
             double elong, double phi, double hm,
             double xp, double yp, double sp,
             double refa, double refb,
             iauASTROM *astrom);
- [ ] int iauApco13(double utc1, double utc2, double dut1,
              double elong, double phi, double hm, double xp, double yp,
              double phpa, double tc, double rh, double wl,
              iauASTROM *astrom, double *eo);
- [ ] void iauApcs(double date1, double date2, double pv[2][3],
             double ebpv[2][3], double ehp[3],
             iauASTROM *astrom);
- [ ] void iauApcs13(double date1, double date2, double pv[2][3],
               iauASTROM *astrom);
- [ ] void iauAper(double theta, iauASTROM *astrom);
- [ ] void iauAper13(double ut11, double ut12, iauASTROM *astrom);
- [ ] void iauApio(double sp, double theta,
             double elong, double phi, double hm, double xp, double yp,
             double refa, double refb,
             iauASTROM *astrom);
- [ ] int iauApio13(double utc1, double utc2, double dut1,
              double elong, double phi, double hm, double xp, double yp,
              double phpa, double tc, double rh, double wl,
              iauASTROM *astrom);
- [ ] void iauAtcc13(double rc, double dc,
               double pr, double pd, double px, double rv,
               double date1, double date2,
               double *ra, double *da);
- [ ] void iauAtccq(double rc, double dc,
              double pr, double pd, double px, double rv,
              iauASTROM *astrom, double *ra, double *da);
- [ ] void iauAtci13(double rc, double dc,
               double pr, double pd, double px, double rv,
               double date1, double date2,
               double *ri, double *di, double *eo);
- [ ] void iauAtciq(double rc, double dc, double pr, double pd,
              double px, double rv, iauASTROM *astrom,
              double *ri, double *di);
- [ ] void iauAtciqn(double rc, double dc, double pr, double pd,
               double px, double rv, iauASTROM *astrom,
               int n, iauLDBODY b[], double *ri, double *di);
- [ ] void iauAtciqz(double rc, double dc, iauASTROM *astrom,
               double *ri, double *di);
- [ ] int iauAtco13(double rc, double dc,
              double pr, double pd, double px, double rv,
              double utc1, double utc2, double dut1,
              double elong, double phi, double hm, double xp, double yp,
              double phpa, double tc, double rh, double wl,
              double *aob, double *zob, double *hob,
              double *dob, double *rob, double *eo);
- [ ] void iauAtic13(double ri, double di,
               double date1, double date2,
               double *rc, double *dc, double *eo);
- [ ] void iauAticq(double ri, double di, iauASTROM *astrom,
              double *rc, double *dc);
- [ ] void iauAticqn(double ri, double di, iauASTROM *astrom,
               int n, iauLDBODY b[], double *rc, double *dc);
- [ ] int iauAtio13(double ri, double di,
              double utc1, double utc2, double dut1,
              double elong, double phi, double hm, double xp, double yp,
              double phpa, double tc, double rh, double wl,
              double *aob, double *zob, double *hob,
              double *dob, double *rob);
- [ ] void iauAtioq(double ri, double di, iauASTROM *astrom,
              double *aob, double *zob,
              double *hob, double *dob, double *rob);
- [ ] int iauAtoc13(const char *type, double ob1, double ob2,
              double utc1, double utc2, double dut1,
              double elong, double phi, double hm, double xp, double yp,
              double phpa, double tc, double rh, double wl,
              double *rc, double *dc);
- [ ] int iauAtoi13(const char *type, double ob1, double ob2,
              double utc1, double utc2, double dut1,
              double elong, double phi, double hm, double xp, double yp,
              double phpa, double tc, double rh, double wl,
              double *ri, double *di);
- [ ] void iauAtoiq(const char *type,
              double ob1, double ob2, iauASTROM *astrom,
              double *ri, double *di);
- [ ] void iauLd(double bm, double p[3], double q[3], double e[3],
           double em, double dlim, double p1[3]);
- [ ] void iauLdn(int n, iauLDBODY b[], double ob[3], double sc[3],
            double sn[3]);
- [ ] void iauLdsun(double p[3], double e[3], double em, double p1[3]);
- [ ] void iauPmpx(double rc, double dc, double pr, double pd,
             double px, double rv, double pmt, double pob[3],
             double pco[3]);
- [ ] int iauPmsafe(double ra1, double dec1, double pmr1, double pmd1,
              double px1, double rv1,
              double ep1a, double ep1b, double ep2a, double ep2b,
              double *ra2, double *dec2, double *pmr2, double *pmd2,
              double *px2, double *rv2);
- [ ] void iauPvtob(double elong, double phi, double height, double xp,
              double yp, double sp, double theta, double pv[2][3]);
- [ ] void iauRefco(double phpa, double tc, double rh, double wl,
              double *refa, double *refb);

#### Astronomy/Ephemerides
- [x] int iauEpv00(double date1, double date2,
             double pvh[2][3], double pvb[2][3]);
- [x] void iauMoon98(double date1, double date2, double pv[2][3]);
- [x] int iauPlan94(double date1, double date2, int np, double pv[2][3]);

#### Astronomy/FundamentalArgs
- [x] double iauFad03(double t);
- [x] double iauFae03(double t);
- [x] double iauFaf03(double t);
- [x] double iauFaju03(double t);
- [x] double iauFal03(double t);
- [x] double iauFalp03(double t);
- [x] double iauFama03(double t);
- [x] double iauFame03(double t);
- [x] double iauFane03(double t);
- [x] double iauFaom03(double t);
- [x] double iauFapa03(double t);
- [x] double iauFasa03(double t);
- [x] double iauFaur03(double t);
- [x] double iauFave03(double t);

#### Astronomy/PrecNutPolar
- [ ] void iauBi00(double *dpsibi, double *depsbi, double *dra);
- [ ] void iauBp00(double date1, double date2,
             double rb[3][3], double rp[3][3], double rbp[3][3]);
- [ ] void iauBp06(double date1, double date2,
             double rb[3][3], double rp[3][3], double rbp[3][3]);
- [x] void iauBpn2xy(double rbpn[3][3], double *x, double *y);
- [ ] void iauC2i00a(double date1, double date2, double rc2i[3][3]);
- [ ] void iauC2i00b(double date1, double date2, double rc2i[3][3]);
- [ ] void iauC2i06a(double date1, double date2, double rc2i[3][3]);
- [ ] void iauC2ibpn(double date1, double date2, double rbpn[3][3],
               double rc2i[3][3]);
- [ ] void iauC2ixy(double date1, double date2, double x, double y,
              double rc2i[3][3]);
- [ ] void iauC2ixys(double x, double y, double s, double rc2i[3][3]);
- [ ] void iauC2t00a(double tta, double ttb, double uta, double utb,
               double xp, double yp, double rc2t[3][3]);
- [ ] void iauC2t00b(double tta, double ttb, double uta, double utb,
               double xp, double yp, double rc2t[3][3]);
- [ ] void iauC2t06a(double tta, double ttb, double uta, double utb,
               double xp, double yp, double rc2t[3][3]);
- [ ] void iauC2tcio(double rc2i[3][3], double era, double rpom[3][3],
               double rc2t[3][3]);
- [ ] void iauC2teqx(double rbpn[3][3], double gst, double rpom[3][3],
               double rc2t[3][3]);
- [ ] void iauC2tpe(double tta, double ttb, double uta, double utb,
              double dpsi, double deps, double xp, double yp,
              double rc2t[3][3]);
- [ ] void iauC2txy(double tta, double ttb, double uta, double utb,
              double x, double y, double xp, double yp,
              double rc2t[3][3]);
- [ ] double iauEo06a(double date1, double date2);
- [x] double iauEors(double rnpb[3][3], double s);
- [x] void iauFw2m(double gamb, double phib, double psi, double eps,
             double r[3][3]);
- [ ] void iauFw2xy(double gamb, double phib, double psi, double eps,
              double *x, double *y);
- [ ] void iauLtp(double epj, double rp[3][3]);
- [ ] void iauLtpb(double epj, double rpb[3][3]);
- [x] void iauLtpecl(double epj, double vec[3]);
- [x] void iauLtpequ(double epj, double veq[3]);
- [ ] void iauNum00a(double date1, double date2, double rmatn[3][3]);
- [ ] void iauNum00b(double date1, double date2, double rmatn[3][3]);
- [ ] void iauNum06a(double date1, double date2, double rmatn[3][3]);
- [ ] void iauNumat(double epsa, double dpsi, double deps, double rmatn[3][3]);
- [x] void iauNut00a(double date1, double date2, double *dpsi, double *deps);
- [x] void iauNut00b(double date1, double date2, double *dpsi, double *deps);
- [x] void iauNut06a(double date1, double date2, double *dpsi, double *deps);
- [x] void iauNut80(double date1, double date2, double *dpsi, double *deps);
- [ ] void iauNutm80(double date1, double date2, double rmatn[3][3]);
- [x] double iauObl06(double date1, double date2);
- [x] double iauObl80(double date1, double date2);
- [ ] void iauP06e(double date1, double date2,
             double *eps0, double *psia, double *oma, double *bpa,
             double *bqa, double *pia, double *bpia,
             double *epsa, double *chia, double *za, double *zetaa,
             double *thetaa, double *pa,
             double *gam, double *phi, double *psi);
- [ ] void iauPb06(double date1, double date2,
             double *bzeta, double *bz, double *btheta);
- [x] void iauPfw06(double date1, double date2,
              double *gamb, double *phib, double *psib, double *epsa);
- [ ] void iauPmat00(double date1, double date2, double rbp[3][3]);
- [x] void iauPmat06(double date1, double date2, double rbp[3][3]);
- [ ] void iauPmat76(double date1, double date2, double rmatp[3][3]);
- [ ] void iauPn00(double date1, double date2, double dpsi, double deps,
             double *epsa,
             double rb[3][3], double rp[3][3], double rbp[3][3],
             double rn[3][3], double rbpn[3][3]);
- [ ] void iauPn00a(double date1, double date2,
              double *dpsi, double *deps, double *epsa,
              double rb[3][3], double rp[3][3], double rbp[3][3],
              double rn[3][3], double rbpn[3][3]);
- [ ] void iauPn00b(double date1, double date2,
              double *dpsi, double *deps, double *epsa,
              double rb[3][3], double rp[3][3], double rbp[3][3],
              double rn[3][3], double rbpn[3][3]);
- [ ] void iauPn06(double date1, double date2, double dpsi, double deps,
             double *epsa,
             double rb[3][3], double rp[3][3], double rbp[3][3],
             double rn[3][3], double rbpn[3][3]);
- [ ] void iauPn06a(double date1, double date2,
              double *dpsi, double *deps, double *epsa,
              double rb[3][3], double rp[3][3], double rbp[3][3],
              double rn[3][3], double rbpn[3][3]);
- [ ] void iauPnm00a(double date1, double date2, double rbpn[3][3]);
- [ ] void iauPnm00b(double date1, double date2, double rbpn[3][3]);
- [x] void iauPnm06a(double date1, double date2, double rnpb[3][3]);
- [ ] void iauPnm80(double date1, double date2, double rmatpn[3][3]);
- [ ] void iauPom00(double xp, double yp, double sp, double rpom[3][3]);
- [x] void iauPr00(double date1, double date2,
             double *dpsipr, double *depspr);
- [ ] void iauPrec76(double date01, double date02,
               double date11, double date12,
               double *zeta, double *z, double *theta);
- [ ] double iauS00(double date1, double date2, double x, double y);
- [ ] double iauS00a(double date1, double date2);
- [ ] double iauS00b(double date1, double date2);
- [x] double iauS06(double date1, double date2, double x, double y);
- [ ] double iauS06a(double date1, double date2);
- [ ] double iauSp00(double date1, double date2);
- [ ] void iauXy06(double date1, double date2, double *x, double *y);
- [ ] void iauXys00a(double date1, double date2,
               double *x, double *y, double *s);
- [ ] void iauXys00b(double date1, double date2,
               double *x, double *y, double *s);
- [ ] void iauXys06a(double date1, double date2,
               double *x, double *y, double *s);

#### Astronomy/RotationAndTime
- [x] double iauEe00(double date1, double date2, double epsa, double dpsi);
- [x] double iauEe00a(double date1, double date2);
- [x] double iauEe00b(double date1, double date2);
- [x] double iauEe06a(double date1, double date2);
- [x] double iauEect00(double date1, double date2);
- [x] double iauEqeq94(double date1, double date2);
- [x] double iauEra00(double dj1, double dj2);
- [x] double iauGmst00(double uta, double utb, double tta, double ttb);
- [x] double iauGmst06(double uta, double utb, double tta, double ttb);
- [x] double iauGmst82(double dj1, double dj2);
- [x] double iauGst00a(double uta, double utb, double tta, double ttb);
- [x] double iauGst00b(double uta, double utb);
- [x] double iauGst06(double uta, double utb, double tta, double ttb,
                double rnpb[3][3]);
- [x] double iauGst06a(double uta, double utb, double tta, double ttb);
- [x] double iauGst94(double uta, double utb);

#### Astronomy/SpaceMotion
- [ ] int iauPvstar(double pv[2][3], double *ra, double *dec,
              double *pmr, double *pmd, double *px, double *rv);
- [ ] int iauStarpv(double ra, double dec,
              double pmr, double pmd, double px, double rv,
              double pv[2][3]);

#### Astronomy/StarCatalogs
- [ ] void iauFk425(double r1950, double d1950,
              double dr1950, double dd1950,
              double p1950, double v1950,
              double *r2000, double *d2000,
              double *dr2000, double *dd2000,
              double *p2000, double *v2000);
- [ ] void iauFk45z(double r1950, double d1950, double bepoch,
              double *r2000, double *d2000);
- [ ] void iauFk524(double r2000, double d2000,
              double dr2000, double dd2000,
              double p2000, double v2000,
              double *r1950, double *d1950,
              double *dr1950, double *dd1950,
              double *p1950, double *v1950);
- [ ] void iauFk52h(double r5, double d5,
              double dr5, double dd5, double px5, double rv5,
              double *rh, double *dh,
              double *drh, double *ddh, double *pxh, double *rvh);
- [ ] void iauFk54z(double r2000, double d2000, double bepoch,
              double *r1950, double *d1950,
              double *dr1950, double *dd1950);
- [ ] void iauFk5hip(double r5h[3][3], double s5h[3]);
- [ ] void iauFk5hz(double r5, double d5, double date1, double date2,
              double *rh, double *dh);
- [ ] void iauH2fk5(double rh, double dh,
              double drh, double ddh, double pxh, double rvh,
              double *r5, double *d5,
              double *dr5, double *dd5, double *px5, double *rv5);
- [ ] void iauHfk5z(double rh, double dh, double date1, double date2,
              double *r5, double *d5, double *dr5, double *dd5);
- [ ] int iauStarpm(double ra1, double dec1,
              double pmr1, double pmd1, double px1, double rv1,
              double ep1a, double ep1b, double ep2a, double ep2b,
              double *ra2, double *dec2,
              double *pmr2, double *pmd2, double *px2, double *rv2);

#### Astronomy/EclipticCoordinates
- [x] void iauEceq06(double date1, double date2, double dl, double db,
               double *dr, double *dd);
- [x] void iauEcm06(double date1, double date2, double rm[3][3]);
- [x] void iauEqec06(double date1, double date2, double dr, double dd,
               double *dl, double *db);
- [x] void iauLteceq(double epj, double dl, double db, double *dr, double *dd);
- [x] void iauLtecm(double epj, double rm[3][3]);
- [x] void iauLteqec(double epj, double dr, double dd, double *dl, double *db);

#### Astronomy/GalacticCoordinates
- [x] void iauG2icrs(double dl, double db, double *dr, double *dd);
- [x] void iauIcrs2g(double dr, double dd, double *dl, double *db);

#### Astronomy/GeodeticGeocentric
- [x] int iauEform(int n, double *a, double *f);
- [x] int iauGc2gd(int n, double xyz[3],
             double *elong, double *phi, double *height);
- [x] int iauGc2gde(double a, double f, double xyz[3],
              double *elong, double *phi, double *height);
- [x] int iauGd2gc(int n, double elong, double phi, double height,
             double xyz[3]);
- [x] int iauGd2gce(double a, double f,
              double elong, double phi, double height, double xyz[3]);

#### Astronomy/Timescales
- [ ] ~~int iauD2dtf(const char *scale, int ndp, double d1, double d2,~~
             ~~int *iy, int *im, int *id, int ihmsf[4]);~~
- [x] int iauDat(int iy, int im, int id, double fd, double *deltat);
- [x] double iauDtdb(double date1, double date2,
               double ut, double elong, double u, double v);
- [ ] ~~int iauDtf2d(const char *scale, int iy, int im, int id,~~
             ~~int ihr, int imn, double sec, double *d1, double *d2);~~
- [x] int iauTaitt(double tai1, double tai2, double *tt1, double *tt2);
- [x] int iauTaiut1(double tai1, double tai2, double dta,
              double *ut11, double *ut12);
- [x] int iauTaiutc(double tai1, double tai2, double *utc1, double *utc2);
- [x] int iauTcbtdb(double tcb1, double tcb2, double *tdb1, double *tdb2);
- [x] int iauTcgtt(double tcg1, double tcg2, double *tt1, double *tt2);
- [x] int iauTdbtcb(double tdb1, double tdb2, double *tcb1, double *tcb2);
- [x] int iauTdbtt(double tdb1, double tdb2, double dtr,
             double *tt1, double *tt2);
- [x] int iauTttai(double tt1, double tt2, double *tai1, double *tai2);
- [x] int iauTttcg(double tt1, double tt2, double *tcg1, double *tcg2);
- [x] int iauTttdb(double tt1, double tt2, double dtr,
             double *tdb1, double *tdb2);
- [x] int iauTtut1(double tt1, double tt2, double dt,
             double *ut11, double *ut12);
- [x] int iauUt1tai(double ut11, double ut12, double dta,
              double *tai1, double *tai2);
- [x] int iauUt1tt(double ut11, double ut12, double dt,
             double *tt1, double *tt2);
- [x] int iauUt1utc(double ut11, double ut12, double dut1,
              double *utc1, double *utc2);
- [x] int iauUtctai(double utc1, double utc2, double *tai1, double *tai2);
- [x] int iauUtcut1(double utc1, double utc2, double dut1,
              double *ut11, double *ut12);

#### Astronomy/HorizonEquatorial
- [x] void iauAe2hd(double az, double el, double phi,
              double *ha, double *dec);
- [x] void iauHd2ae(double ha, double dec, double phi,
              double *az, double *el);
- [x] double iauHd2pa(double ha, double dec, double phi);

#### Astronomy/Gnomonic
- [ ] int iauTpors(double xi, double eta, double a, double b,
             double *a01, double *b01, double *a02, double *b02);
- [ ] int iauTporv(double xi, double eta, double v[3],
             double v01[3], double v02[3]);
- [ ] void iauTpsts(double xi, double eta, double a0, double b0,
              double *a, double *b);
- [ ] void iauTpstv(double xi, double eta, double v0[3], double v[3]);
- [ ] int iauTpxes(double a, double b, double a0, double b0,
             double *xi, double *eta);
- [ ] int iauTpxev(double v[3], double v0[3], double *xi, double *eta);

#### VectorMatrix/AngleOps
- [ ] void iauA2af(int ndp, double angle, char *sign, int idmsf[4]);
- [ ] void iauA2tf(int ndp, double angle, char *sign, int ihmsf[4]);
- [ ] int iauAf2a(char s, int ideg, int iamin, double asec, double *rad);
- [ ] double iauAnp(double a);
- [ ] double iauAnpm(double a);
- [ ] void iauD2tf(int ndp, double days, char *sign, int ihmsf[4]);
- [ ] int iauTf2a(char s, int ihour, int imin, double sec, double *rad);
- [ ] int iauTf2d(char s, int ihour, int imin, double sec, double *days);

#### VectorMatrix/BuildRotations
- [x] void iauRx(double phi, double r[3][3]);
- [x] void iauRy(double theta, double r[3][3]);
- [x] void iauRz(double psi, double r[3][3]);

#### VectorMatrix/CopyExtendExtract
- [ ] void iauCp(double p[3], double c[3]);
- [ ] void iauCpv(double pv[2][3], double c[2][3]);
- [ ] void iauCr(double r[3][3], double c[3][3]);
- [ ] void iauP2pv(double p[3], double pv[2][3]);
- [ ] void iauPv2p(double pv[2][3], double p[3]);

#### VectorMatrix/Initialization
- [x] void iauIr(double r[3][3]);
- [ ] void iauZp(double p[3]);
- [ ] void iauZpv(double pv[2][3]);
- [ ] void iauZr(double r[3][3]);

#### VectorMatrix/MatrixOps
- [ ] void iauRxr(double a[3][3], double b[3][3], double atb[3][3]);
- [ ] void iauTr(double r[3][3], double rt[3][3]);

#### VectorMatrix/MatrixVectorProducts
- [x] void iauRxp(double r[3][3], double p[3], double rp[3]);
- [ ] void iauRxpv(double r[3][3], double pv[2][3], double rpv[2][3]);
- [x] void iauTrxp(double r[3][3], double p[3], double trp[3]);
- [ ] void iauTrxpv(double r[3][3], double pv[2][3], double trpv[2][3]);

#### VectorMatrix/RotationVectors
- [ ] void iauRm2v(double r[3][3], double w[3]);
- [ ] void iauRv2m(double w[3], double r[3][3]);

#### VectorMatrix/SeparationAndAngle
- [ ] double iauPap(double a[3], double b[3]);
- [ ] double iauPas(double al, double ap, double bl, double bp);
- [ ] double iauSepp(double a[3], double b[3]);
- [ ] double iauSeps(double al, double ap, double bl, double bp);

#### VectorMatrix/SphericalCartesian
- [x] void iauC2s(double p[3], double *theta, double *phi);
- [x] void iauP2s(double p[3], double *theta, double *phi, double *r);
- [x] void iauPv2s(double pv[2][3],
             double *theta, double *phi, double *r,
             double *td, double *pd, double *rd);
- [x] void iauS2c(double theta, double phi, double c[3]);
- [x] void iauS2p(double theta, double phi, double r, double p[3]);
- [x] void iauS2pv(double theta, double phi, double r,
             double td, double pd, double rd,
             double pv[2][3]);

#### VectorMatrix/VectorOps
- [ ] double iauPdp(double a[3], double b[3]);
- [ ] double iauPm(double p[3]);
- [ ] void iauPmp(double a[3], double b[3], double amb[3]);
- [ ] void iauPn(double p[3], double *r, double u[3]);
- [ ] void iauPpp(double a[3], double b[3], double apb[3]);
- [ ] void iauPpsp(double a[3], double s, double b[3], double apsb[3]);
- [ ] void iauPvdpv(double a[2][3], double b[2][3], double adb[2]);
- [ ] void iauPvm(double pv[2][3], double *r, double *s);
- [ ] void iauPvmpv(double a[2][3], double b[2][3], double amb[2][3]);
- [ ] void iauPvppv(double a[2][3], double b[2][3], double apb[2][3]);
- [ ] void iauPvu(double dt, double pv[2][3], double upv[2][3]);
- [ ] void iauPvup(double dt, double pv[2][3], double p[3]);
- [ ] void iauPvxpv(double a[2][3], double b[2][3], double axb[2][3]);
- [ ] void iauPxp(double a[3], double b[3], double axb[3]);
- [ ] void iauS2xpv(double s1, double s2, double pv[2][3], double spv[2][3]);
- [ ] void iauSxp(double s, double p[3], double sp[3]);
- [ ] void iauSxpv(double s, double pv[2][3], double spv[2][3]);