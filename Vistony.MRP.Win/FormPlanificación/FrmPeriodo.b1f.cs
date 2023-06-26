using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAPbouiCOM.Framework;
using Forxap.Framework.Extensions;
using Vistony.MRP.Constans;
using Forxap.Framework.UI;
using System.Threading;

namespace Vistony.MRP.Win.FormPlanificación
{
    [FormAttribute("Vistony.MRP.Win.FormPlanificación.FrmPeriodo", "FormPlanificación/FrmPeriodo.b1f")]
    class FrmPeriodo : UserFormBase
    {
        public FrmPeriodo()
        {
        }
        FrmForecast OwnerForm;
        public FrmPeriodo(FrmForecast ownerForm)
        {
            OwnerForm = ownerForm;
        }

        SAPbouiCOM.Form oForm;

        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            this.StaticText0 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_0").Specific));
            this.ComboBox0 = ((SAPbouiCOM.ComboBox)(this.GetItem("Item_1").Specific));
            this.Button0 = ((SAPbouiCOM.Button)(this.GetItem("Item_2").Specific));
            this.Button0.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.Button0_ClickAfter);
            this.Button1 = ((SAPbouiCOM.Button)(this.GetItem("Item_3").Specific));
            this.OnCustomInitialize();

        }

        /// <summary>
        /// Initialize form event. Called by framework before form creation.
        /// </summary>
        public override void OnInitializeFormEvents()
        {
        }

        private SAPbouiCOM.StaticText StaticText0;
        private SAPbouiCOM.ComboBox ComboBox0;

        private void OnCustomInitialize()
        {
            oForm = SAPbouiCOM.Framework.Application.SBO_Application.Forms.Item(this.UIAPIRawForm.UniqueID);
            oForm.ScreenCenter();
            Utils.LoadQueryDynamic(ref ComboBox0, AddonMessageInfo.QueryGetPeriodoForecast);
            ComboBox0.Select(1, SAPbouiCOM.BoSearchKey.psk_Index);
        }

        private SAPbouiCOM.Button Button0;
        private SAPbouiCOM.Button Button1;

        private void Button0_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
           var ret = Sb1Messages.ShowQuestion("¿ Esta seguro de asignar este periodo ?");

            if (ret)
            {

                FrmForecast owner = this.OwnerForm;
                string Periodo= ComboBox0.GetValue();

                Thread myNewThread = new Thread(() => owner.Procesar(Periodo));
                myNewThread.Start();
                oForm.Close();

            }
        }
    }

}
