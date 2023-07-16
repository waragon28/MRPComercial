using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vistony.MRP.Constans
{
    public class AddonMessageInfo
    {
        public const string AddonName = "Add-Ons SCM";

        public const string StartLoading = AddonName + " Iniciando Carga de Datos...";
        public const string FinishLoading = AddonName + " Carga Finalizada ...";

        public const string Message001 = AddonName + "Usuario no configurado para el " + AddonName;
        public const string Message002 = "Error de Carga de " + AddonName;
        public const string Message003 = "No cuenta con Registros ";
        public const string Message04 = "Se genero la Solicitud de Transferencia";
        public const string Message013 = "No ingreso código de almacen";
        public const string Message05 = "No cuenta por persmisos para ingresar a este modulo";
        public const string Message06 = "No se configuro correctamente su usuario";
        public const string Message07 = "No cuenta con Registros ";
        public const string Message08 = "Generando Solicitud de traslado";
        public const string Message09 = "No se configuro Punto de Destino en el Almacen";
        public const string Message10 = "No se configuro Punto de emisión en el Almacen";
        public const string Message011 = "Fecha Hasta no puede ser superior a : {0} ";
        public const string Message012 = "Se genero la solicitud de traslado número ";
        public const string SAPNotRunning = AddonName + " SAP Business One, no se encuentra corriendo ";
        public const string Message005 = "La solicitud de Traslado paso por un flujo de aprobacion.";
        public const string Message016 = "Validando Procedimientos Almacenados...";
        public const string Message017 = "Validación Culminada";
        public const string Message018 = "Error al crear los procedimiento almacenado";
        public const string QueryGetListSucu_Ind = "CALL VIS_GET_MRP_CLUSTER_CONSUL()";
        public const string QueryGetSucursales = "CALL GETSUCURSALES()";
        public const string QueryGetSucursalesAlmacen = "CALL GETSUCURSALESALMACEN()"; 
        public const string QueryGetConsultas = "CALL ADD_MRP_GETCONSULTAS()";

        public const string QueryGetConsultaAncon_B2B = "CALL P_VIST_PLANNING_PLANEAMIENTO_ANCON_B2B()";
        public const string QueryGetConsultasDetalleLPC_B2C = "CALL P_VIST_PLANNING_PLANEAMIENTO_B2C()";
        public const string QueryGetConsultasDetalleLima_B2C = "CALL \"P_VIST_PLANNING_PLANEAMIENTO_B2C_Detalle_Lima\"()";
        public const string QueryGetConsultas_Televentas_B2C = "CALL \"P_VIST_PLANNING_PLANEAMIENTO_B2C_Televentas\"()";
        public const string QueryGetConsultas_Rofalab = "CALL P_VIST_PLANNING_PLANEAMIENTO_ROFALAB('','')";
        public const string QueryGetConsultas_Supermercados = "CALL \"P_VIST_PLANNING_PLANEAMIENTO_SUPERMERCADOS\"()";
        public const string QueryGetConsultas_Categoria_Cluster = "CALL P_VIST_PLANNING_PLANEAMIENTO_CATE_CLUSTER()";
        public const string QueryGetConsultas_List_Gerencia_Forecast = "CALL P_VIST_PLANNING_PLANEAMIENTO_GERENCIA()";
        public const string QueryGetConsultas_List_UnidadMedida_Forecast = "CALL P_VIST_PLANNING_PLANEAMIENTO_UNIDAD_MEDIDA()";
        public const string QueryGetPeriodoForecast = "CALL P_VIST_PLANNING_PERIODO_FORECAST()";
        public const string QueryGetPlanning = "CALL P_VIST_PLANNING_PLANEAMIENTO('{0}','{1}')";
        public const string QueryGetPlanningxSucursal = "CALL P_VIST_PLANNING_PLANEAMIENTO_X_SUCURSAL('{0}','{1}')";
        public const string QueryGetPlanningClear = "CALL P_VIST_PLANNING_PLANEAMIENTO_CLEAR()";
        public const string QueryGetPlanningSelect = "CALL P_VIST_PLANNING_PLANEAMIENTO_SELECT()";
        public const string QueryGetForecastSucursales = "CALL P_VIST_PLANNING_PLANEAMIENTO_FORECAST_V2('{0}','{1}','{2}','{3}','{4}')";
        public const string QueryTipoGerencia = "SELECT T0.\"empID\" \"Cod.Emp.\", "+
                                                "T1.\"firstName\" || ' ' || T1.\"lastName\" AS \"Empleado\" FROM HEM6 T0 "+
                                                "INNER JOIN \"OHEM\" T1 ON "+
                                                "T0.\"empID\" =  T1.\"empID\" "+
                                                "WHERE T0.\"roleID\"=6 " ;
    }// fin de la clase


}// fin del namespace
