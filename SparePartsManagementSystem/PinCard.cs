using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace SparePartsManagementSystem
{
    public  class PinCard
    {

        public string PartNumber { set; get; }

        public ATEPinCardType PinCardType { set; get; }

        public DateTime CreateDateTime { set; get; }




       public  enum ATEPinCardType
        {

            Mother_Card,                                    //03066-66500
            i_System_Card_Assembly,                         //N1807-69603
            Sysem_Card_Assembly,                            //03066-69603
            i_System_Card_PCA_only,                         //N1807-66803
            ControlXTP_Card_with_New_SDRAM_socket,          //E9900-69506
            ControlXT_Card,                                 //E4000-69512
            ASRU_N_Card,                                    //N1807-66500
            ASRU_C_Card,                                    //03066-69532
            Utility_Card,                                   //N1807-66502
            Hybrid_144_Non_multiplexed_Pin_Card,            //N1140-69500
            HybridPlus_Standard_DD_Pin_Card,                //E4000-69552
            HybridPlus_Advanced_DD_Pin_Card,                //E4000-69553
            HybridPlus_High_Accuracy_DD_Pin_Card,           //E4000-69554
            HybridPlus_Pay_Per_Use_DD_Pin_Card,             //E4000-69555
            Hybrid32_Card,                                  //E9900-69502
            AnalogPlus_Card,                                //E4000-69551
            AccessPlus_Card,                                //E1061-69501
            PCI_400_ScanWorks_Controller_Card,              //N1180-66500
            BSI_Card,                                       //E9900-66505
            //Null_Card_PartNumberIsIllegal,                  
            Null_Card_CantFindPartNumber
        }


        /// <summary>
        /// according to the partnumber,return the pin card type
        /// </summary>
        /// <param name="partnumber">partnumber</param>
        /// <returns>pin card type</returns>
        public  static  ATEPinCardType AutoJudgePinCardViaPartNumber(string partnumber)
        {
            ATEPinCardType pincard = new ATEPinCardType();
     
            if (partnumber.Length >= 10)
            {
                string Part = partnumber.ToUpper().Substring(0, 5) + "-" + partnumber.ToUpper().Substring(4, 5);

                switch (Part )
                {
                    case "03066-66500":
                        pincard = ATEPinCardType.Mother_Card;
                        break;
                    case "N1807-69603":
                        pincard = ATEPinCardType.i_System_Card_Assembly;
                        break;
                    case "03066-69603":
                        pincard = ATEPinCardType.Sysem_Card_Assembly;
                        break ;
                    case "N1807-66803":
                        pincard = ATEPinCardType.i_System_Card_PCA_only;
                        break;
                    case "E9900-69506":
                        pincard = ATEPinCardType.ControlXTP_Card_with_New_SDRAM_socket;
                        break;
                    case "E4000-69512":
                        pincard = ATEPinCardType.ControlXT_Card;
                        break;
                    case "N1807-66500":
                        pincard = ATEPinCardType.ASRU_N_Card;
                        break;
                    case "03066-69532":
                        pincard = ATEPinCardType.ASRU_C_Card;
                        break;
                    case "N1807-66502":
                        pincard = ATEPinCardType.Utility_Card;
                        break;
                    case "N1140-69500":
                        pincard = ATEPinCardType.Hybrid_144_Non_multiplexed_Pin_Card;
                        break;
                    case "E4000-69552":
                        pincard = ATEPinCardType.HybridPlus_Standard_DD_Pin_Card;
                        break;
                    case "E4000-69553":
                        pincard = ATEPinCardType.HybridPlus_Advanced_DD_Pin_Card;
                        break;
                    case "E4000-69554":
                        pincard = ATEPinCardType.HybridPlus_High_Accuracy_DD_Pin_Card;
                        break;
                    case "E4000-69555":
                        pincard = ATEPinCardType.HybridPlus_Pay_Per_Use_DD_Pin_Card;
                        break;
                    case "E9900-69502":
                        pincard = ATEPinCardType.Hybrid32_Card;
                        break;
                    case "E4000-69551":
                        pincard = ATEPinCardType.AnalogPlus_Card;
                        break;
                    case "E1061-69501":
                        pincard = ATEPinCardType.AccessPlus_Card;
                        break;
                    case "N1180-66500":
                        pincard = ATEPinCardType.PCI_400_ScanWorks_Controller_Card;
                        break;
                    case "E9900-66505":
                        pincard = ATEPinCardType.BSI_Card;
                        break;
                    default:
                        pincard = ATEPinCardType.Null_Card_CantFindPartNumber;
                        break;
                }

            }
            else
            {
                pincard = ATEPinCardType.Null_Card_CantFindPartNumber;
            }
            return pincard;
        }

        /// <summary>
        /// check the partnumber is illegal
        /// </summary>
        /// <param name="partnumber">part number</param>
        /// <returns>illegal,return false;legal,return true</returns>
        public  static  bool CheckPartNumberIsIllegal(string partnumber)
        {
            //check the part number
            string pattern = "^[A-Za-z0-9]*$";
            return  Regex.IsMatch(partnumber.Trim(), pattern);
        }

        /// <summary>
        /// get pin card start time via part number
        /// </summary>
        /// <param name="partnumber">pin card part number </param>
        /// <returns>the date</returns>
        public static DateTime GetPinCardStartTime(string partnumber)
        {
            //0306666532395193 2001 0700197
            //E400066542314502 2015 3000052
            //E400066550512923 2012 1700088

            DateTime time = new DateTime();

            if (partnumber.Length == 27)
            {
                try
                {
                    string temp = partnumber.Substring(16, 4);

                    time = DateTime.ParseExact(temp, "yyyy", System.Globalization.CultureInfo.CurrentCulture); 

                }
                catch (Exception ex)
                {
                    
                }
            }
            return time;
        }


    }
}
