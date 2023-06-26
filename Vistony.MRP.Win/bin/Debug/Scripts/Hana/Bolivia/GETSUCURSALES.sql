CREATE PROCEDURE GETSUCURSALES()
AS
BEGIN
SELECT '1' "Orden",'BPS-TODAS' "P.Emision"  from dummy
                        UNION
                        SELECT DISTINCT
                         ("U_SYP_NDED") "Orden",("U_SYP_NDED")  as "U_SYP_NDED" FROM OUSR
						ORDER BY 1;
END;