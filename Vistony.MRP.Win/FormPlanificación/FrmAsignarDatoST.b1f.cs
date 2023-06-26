using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAPbouiCOM.Framework;
using Forxap.Framework.Extensions;
using Forxap.Framework.UI;
using System.Threading;

namespace Vistony.MRP.Win.FormPlanificación
{
    [FormAttribute("Vistony.MRP.Win.FormPlanificación.FrmAsignarDatoST", "FormPlanificación/FrmAsignarDatoST.b1f")]
    class FrmAsignarDatoST : UserFormBase
    {
        public SAPbouiCOM.Form oForm;
        public FrmAsignarDatoST()
        {
        }
        FrmForecast OwnerForm;
        public FrmAsignarDatoST(FrmForecast ownerForm)
        {
            OwnerForm = ownerForm;
        }
        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            this.Button2 = ((SAPbouiCOM.Button)(this.GetItem("Item_6").Specific));
            this.ComboBox0 = ((SAPbouiCOM.ComboBox)(this.GetItem("Item_5").Specific));
            this.Button2.ClickBefore += new SAPbouiCOM._IButtonEvents_ClickBeforeEventHandler(this.Button2_ClickBefore);
            this.Button2.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.Button2_ClickAfter);
            this.Button3 = ((SAPbouiCOM.Button)(this.GetItem("Item_7").Specific));
            this.Button3.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.Button3_ClickAfter);
            this.EditText2 = ((SAPbouiCOM.EditText)(this.GetItem("Item_3").Specific));
            this.EditText2.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.EditText2_ChooseFromListAfter);
            this.EditText3 = ((SAPbouiCOM.EditText)(this.GetItem("Item_4").Specific));
            this.EditText3.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.EditText3_ChooseFromListAfter);
            this.OnCustomInitialize();

        }

        /// <summary>
        /// Initialize form event. Called by framework before form creation.
        /// </summary>
        public override void OnInitializeFormEvents()
        {
            this.LoadAfter += new LoadAfterHandler(this.Form_LoadAfter);

        }

        private void Form_LoadAfter(SAPbouiCOM.SBOItemEventArg pVal)
        {
          

        }

        private void OnCustomInitialize()
        {
            oForm = SAPbouiCOM.Framework.Application.SBO_Application.Forms.Item(this.UIAPIRawForm.UniqueID);
            oForm.ScreenCenter();
            Utils.LoadQueryDynamic(ref ComboBox0, "select \"Code\",\"Name\" from \"@SYP_MTRASLADO\" ");
            ComboBox0.Select("11", SAPbouiCOM.BoSearchKey.psk_ByValue);
        }

        private SAPbouiCOM.StaticText StaticText0;
        private SAPbouiCOM.StaticText StaticText1;
        private SAPbouiCOM.StaticText StaticText2;
        private SAPbouiCOM.EditText EditText0;
        private SAPbouiCOM.EditText EditText1;
        private SAPbouiCOM.ComboBox ComboBox0;
        private SAPbouiCOM.Button Button0;
        private SAPbouiCOM.Button Button1;

        private SAPbouiCOM.Button Button2;

        private void Button2_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            var ret = Sb1Messages.ShowQuestion("¿ Esta seguro de generar la Solicitud de traslado ?");

            if (ret)
            {

                FrmForecast owner = this.OwnerForm;
                string MotivoTraslado = ComboBox0.GetValue();
                Thread myNewThread = new Thread(() => owner.Generar_ST_Draft(EditText2.Value,EditText3.Value, MotivoTraslado));
                myNewThread.Start();
                oForm.Close();

            }

        }

        private void Button2_ClickBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal,out bool BubbleEvent)
        {
            BubbleEvent = true;
            if (EditText2.Value != "" && EditText3.Value != "")
            {
                BubbleEvent = true;
            }
            else
            {
                BubbleEvent = false;
            }
        }

        private SAPbouiCOM.Button Button3;

        private void Button3_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            oForm.Close();
        }

        private SAPbouiCOM.EditText EditText2;

        private void EditText2_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.SBOChooseFromListEventArg chooseFromListEvent = ((SAPbouiCOM.SBOChooseFromListEventArg)(pVal));
            try
            {

                if (chooseFromListEvent.SelectedObjects != null)
                {
                    if (chooseFromListEvent.SelectedObjects.Rows.Count > 0)
                    {
                        EditText2.Value = chooseFromListEvent.SelectedObjects.GetValue("WhsCode", 0).ToString();

                    }
                }

            }
            catch (Exception ex)
            {
                Sb1Messages.ShowError(string.Format(ex.ToString()), SAPbouiCOM.BoMessageTime.bmt_Short);

            }
        }

        private SAPbouiCOM.EditText EditText3;

        private void EditText3_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.SBOChooseFromListEventArg chooseFromListEvent = ((SAPbouiCOM.SBOChooseFromListEventArg)(pVal));
            try
            {

                if (chooseFromListEvent.SelectedObjects != null)
                {
                    if (chooseFromListEvent.SelectedObjects.Rows.Count > 0)
                    {
                        EditText3.Value = chooseFromListEvent.SelectedObjects.GetValue("WhsCode", 0).ToString();

                    }
                }

            }
            catch (Exception ex)
            {
                Sb1Messages.ShowError(string.Format(ex.ToString()), SAPbouiCOM.BoMessageTime.bmt_Short);

            }
        }

    }
}
