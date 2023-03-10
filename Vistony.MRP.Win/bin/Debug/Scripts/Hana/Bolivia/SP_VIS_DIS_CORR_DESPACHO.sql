CREATE PROCEDURE "SP_VIS_DIS_CORR_DESPACHO"
(
IN FECHPROG VARCHAR(10)
)
AS
COUNTDIAPROG INT;
MES INT;
ANIO INT;
DIA INT;
NUMCORRDES  VARCHAR(30);
BEGIN
	
	SELECT COUNT(*) INTO COUNTDIAPROG from "OINV" where 
	"U_SYP_DT_FCDES" = :FECHPROG;
	
	SELECT (YEAR(''||:FECHPROG||'')) INTO ANIO  FROM DUMMY;
	SELECT (MONTH(''||:FECHPROG||'')) INTO MES  FROM DUMMY;
	SELECT (DAYOFMONTH(''||:FECHPROG||'')) INTO DIA  FROM DUMMY;
	NUMCORRDES :=  CAST(:ANIO AS varchar(4)) ||  LPAD (:MES, 2, '0') || LPAD(:DIA,2,'0') || LPAD(:COUNTDIAPROG+1, 2, '0');

	
	SELECT NUMCORRDES AS DATO FROM DUMMY;
		
END