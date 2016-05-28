﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSInterface;

namespace Overheadpanel
{
    class FUEL : Panel
    {
        private static FSIClient fsi;

        public FUEL()
        {
            //debug variable
            is_debug = true;

            //starting FSI Client for IRS
            fsi = new FSIClient("Overhead FUEL");
            fsi.OnVarReceiveEvent += fsiOnVarReceive;
            fsi.DeclareAsWanted(new FSIID[]
                {
                    FSIID.MBI_FUEL_CROSSFEED_SWITCH,
                    FSIID.MBI_FUEL_CTR_LEFT_PUMP_SWITCH,
                    FSIID.MBI_FUEL_CTR_RIGHT_PUMP_SWITCH,
                    FSIID.MBI_FUEL_LEFT_AFT_PUMP_SWITCH,
                    FSIID.MBI_FUEL_LEFT_FWD_PUMP_SWITCH,
                    FSIID.MBI_FUEL_RIGHT_AFT_PUMP_SWITCH,
                    FSIID.MBI_FUEL_RIGHT_FWD_PUMP_SWITCH
                }
            );

            //standard values

            fsi.ProcessWrites();
        }


        static void fsiOnVarReceive(FSIID id)
        {
            //CROSSFEED
            if (id == FSIID.MBI_FUEL_CROSSFEED_SWITCH)
            {
                if (fsi.MBI_FUEL_CROSSFEED_SWITCH)
                {
                    debug("FUEL Crossfeed On");
                } else
                {
                    debug("FUEL Crossfeed Off");
                }

                //ELT light
                fsi.MBI_FUEL_CROSSFEED_VALVE_OPEN_LIGHT = fsi.MBI_FUEL_CROSSFEED_SWITCH;
                fsi.ProcessWrites();
            }

            //FUEL CTR L
            if (id == FSIID.MBI_FUEL_CTR_LEFT_PUMP_SWITCH)
            {
                if (!fsi.MBI_FUEL_CTR_LEFT_PUMP_SWITCH)
                {
                    debug("FUEL CTR LEFT PUMP On");
                }
                else
                {
                    debug("FUEL CTR LEFT PUMP Off");
                }

                //ELT light
                fsi.MBI_FUEL_CTR_LEFT_PUMP_LOW_PRESSURE_LIGHT = fsi.MBI_FUEL_CTR_LEFT_PUMP_SWITCH;
                fsi.ProcessWrites();
            }

            //FUEL CTR R
            if (id == FSIID.MBI_FUEL_CTR_RIGHT_PUMP_SWITCH)
            {
                if (!fsi.MBI_FUEL_CTR_RIGHT_PUMP_SWITCH)
                {
                    debug("FUEL CTR RIGHT PUMP On");
                }
                else
                {
                    debug("FUEL CTR RIGHT PUMP Off");
                }

                //ELT light
                fsi.MBI_FUEL_CTR_RIGHT_PUMP_LOW_PRESSURE_LIGHT = fsi.MBI_FUEL_CTR_RIGHT_PUMP_SWITCH;
                fsi.ProcessWrites();
            }


            //FUEL AFT L
            if (id == FSIID.MBI_FUEL_LEFT_AFT_PUMP_SWITCH)
            {
                if (!fsi.MBI_FUEL_LEFT_AFT_PUMP_SWITCH)
                {
                    debug("FUEL AFT LEFT PUMP On");
                }
                else
                {
                    debug("FUEL AFT LEFT PUMP Off");
                }

                //ELT light
                fsi.MBI_FUEL_LEFT_AFT_PUMP_LOW_PRESSURE_LIGHT = fsi.MBI_FUEL_LEFT_AFT_PUMP_SWITCH;
                fsi.ProcessWrites();
            }

            //FUEL AFT R
            if (id == FSIID.MBI_FUEL_RIGHT_AFT_PUMP_SWITCH)
            {
                if (!fsi.MBI_FUEL_RIGHT_AFT_PUMP_SWITCH)
                {
                    debug("FUEL AFT RIGHT PUMP On");
                }
                else
                {
                    debug("FUEL AFT RIGHT PUMP Off");
                }

                //ELT light
                fsi.MBI_FUEL_RIGHT_AFT_PUMP_LOW_PRESSURE_LIGHT = fsi.MBI_FUEL_RIGHT_AFT_PUMP_SWITCH;
                fsi.ProcessWrites();
            }

            //FUEL FWD L
            if (id == FSIID.MBI_FUEL_LEFT_FWD_PUMP_SWITCH)
            {
                if (!fsi.MBI_FUEL_LEFT_FWD_PUMP_SWITCH)
                {
                    debug("FUEL FWD LEFT PUMP On");
                }
                else
                {
                    debug("FUEL FWD LEFT PUMP Off");
                }

                //ELT light
                fsi.MBI_FUEL_LEFT_FWD_PUMP_LOW_PRESSURE_LIGHT = fsi.MBI_FUEL_LEFT_FWD_PUMP_SWITCH;
                fsi.ProcessWrites();
            }

            //FUEL FWD R
            if (id == FSIID.MBI_FUEL_RIGHT_FWD_PUMP_SWITCH)
            {
                if (!fsi.MBI_FUEL_RIGHT_FWD_PUMP_SWITCH)
                {
                    debug("FUEL FWD RIGHT PUMP On");
                }
                else
                {
                    debug("FUEL FWD RIGHT PUMP Off");
                }

                //ELT light
                fsi.MBI_FUEL_RIGHT_FWD_PUMP_LOW_PRESSURE_LIGHT = fsi.MBI_FUEL_RIGHT_FWD_PUMP_SWITCH;
                fsi.ProcessWrites();
            }
        }
    }
}