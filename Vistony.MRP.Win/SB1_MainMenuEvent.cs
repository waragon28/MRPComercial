﻿using System;
using System.Collections.Generic;
using System.Text;

using SAPbouiCOM.Framework;

using Forxap.Framework.Extensions;
using Forxap.Framework.Constants;
using Forxap.Framework.UI;

using Vistony.MRP.Constans;
using Vistony.MRP.Win.Asistentes;
using Vistony.MRP.Win.FormPlanificación;
using Vistony.MRP.Win.Documento;

namespace Vistony.MRP.Win
{
    public class SB1_MainMenuEvent
    {

        static SAPbouiCOM.Form oForm;
        private string menuCaption = string.Empty;
        private SAPbouiCOM.Form activeForm = null;


        /// <summary>
        /// Capturo los eventos del Menu del AddOn Iker One

        /// <param name="pVal"></param>
        /// <param name="BubbleEvent"></param>
        public void SB1_Application_MainMenuEvent(ref SAPbouiCOM.MenuEvent pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;

            try
            {
                if (pVal.BeforeAction)
                {
                    switch (pVal.MenuUID)
                    {

                        #region Modulos/Planemaiento 

                        case AddonMenuItem.AddonMainMenu:
                            {
                                OnShowInicializar();
                            }
                            break;
                        case AddonMenuItem.AddonMainMenuCluster:
                            {
                                OnShowCluster();
                            }
                            break;
                        case AddonMenuItem.AddonMainMenuForecast:
                            {
                                OnShowForecast();
                            }
                            break;
                        case AddonMenuItem.AddonMainMenuSCM_Clas_Clus:
                            {
                                OnShowUDO("OCLA");
                            }
                            break;
                        case AddonMenuItem.AddonMainMenuSCM_Hist_Fore:
                            {
                                OnShowHistorialForecast();
                            }
                            break;
                            #endregion

                    } // fin dl switch

                }// fin del IF


            }

            catch (Exception ex)
            {
                Application.SBO_Application.MessageBox(ex.ToString(), 1, "Ok", "", "");
            }
        }/// fin del  metodo

            
        // integración de SelesForce con SAP
        private void OnShowInicializar()
        {
            try
            {
               // wzdAsistenteMRP form  = new  wzdAsistenteMRP();
               // form.Show();
            }
            catch (Exception ex)
            {
                
                Forxap.Framework.UI.Sb1Messages.ShowError(ex.ToString());
            }
        }
        private void OnShowUDO(string objectType)
        {
            try
            {
                Application.SBO_Application.OpenForm(SAPbouiCOM.BoFormObjectEnum.fo_UserDefinedObject, objectType, "");
            }
            catch (Exception ex)
            {
                Forxap.Framework.UI.Sb1Messages.ShowError(ex.ToString());
            }
        }

        private void OnShowCluster()
        {
            try
            {
                FrmCluster form = new FrmCluster();
                form.Show();
            }
            catch (Exception ex)
            {

                Forxap.Framework.UI.Sb1Messages.ShowError(ex.ToString());
            }
        }
        private void OnShowForecast()
        {
            try
            {
                FrmForecast form = new FrmForecast();
                form.Show();
            }
            catch (Exception ex)
            {

                Forxap.Framework.UI.Sb1Messages.ShowError(ex.ToString());
            }
        }
        private void OnShowHistorialForecast()
        {
            try
            {
                FrmForecastDocument form = new FrmForecastDocument();
                form.Show();
            }
            catch (Exception ex)
            {

                Forxap.Framework.UI.Sb1Messages.ShowError(ex.ToString());
            }
        }
        private void OnShowConfigForm(string tableName)
        {
          
            SAPbouiCOM.Button oButton = null;
            SAPbouiCOM.Matrix oMatrix = null;
            //SAPbouiCOM.MenuItem oMenuItem = null;
            //SAPbouiCOM.Menus oMenu = null;
            string menuID = string.Empty;
            string menuCaption = string.Empty;
            int index = 0;

            try
            {


                //obtiene el ID del menu que encontra a traves del nombre de la tablas
                menuID = Forxap.Framework.UI.Menu.GetMenuID(tableName, SboMenuItem.WindowsDefinedUser);

                
                Application.SBO_Application.ActivateMenuItem(menuID);

                menuCaption = Application.SBO_Application.Menus.Item(menuID).String;




                index = menuCaption.IndexOf("-", 0);



                activeForm = Application.SBO_Application.Forms.ActiveForm;
                activeForm.Freeze(true);

                activeForm.Title = menuCaption.Substring(index + 2);

                // SAPbouiCOM.Item oItem = null;
                // SAPbouiCOM.StaticText lblInfo = null;



                oButton = activeForm.GetButton("2");
                oMatrix = activeForm.GetMatrix("3");

                oMatrix.Columns.Item(3).TitleObject.Caption = "Código";
                oMatrix.Columns.Item(4).TitleObject.Caption = "Descripción";


                //    oMatrix.CommonSetting.MergeCell(1,3,true); 


                //oItem = activeForm.Items.Add("lblInfo1", SAPbouiCOM.BoFormItemTypes.it_STATIC);
                //oItem.Left = oButton.Item.Left + 75;
                //oItem.Width = oMatrix.Item.Width;
                //oItem.Top = oButton.Item.Top - oButton.Item.Height;
                //oItem.Height = oButton.Item.Height;
                //oItem.Enabled = true;
                //lblInfo = ((SAPbouiCOM.StaticText)(oItem.Specific));
                //lblInfo.Caption = "Height : " + oItem.Height.ToString() + "Top : " +  oItem.Top.ToString();



                activeForm.Freeze(false);





            }
            catch (Exception ex)
            {
                Forxap.Framework.UI.Sb1Messages.ShowError(ex.ToString());
            }
            finally
            {

                // libero recursos

                if (activeForm != null)
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(activeForm);
                    activeForm = null;
                    GC.Collect();
                }

                if (oMatrix != null)
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(oMatrix);
                    oMatrix = null;
                    GC.Collect();
                }

            }

        }
        
        



    }// fin de la clase


}// fin del namespace
