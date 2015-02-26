using System;
using System.Collections.Generic;
using System.Text;

namespace DTcms.BLL
{
    public partial class jsAQI
    {
        
        //求最大值
        public static float[] Sort(float[] number,string flag )
        {
            float[] t = number;
            float temp = 0;
            for (int i = 0; i < t.Length; i++)
            {
                for (int j = i + 1; j < t.Length; j++)
                {
                    if (t[i] < t[j])
                    {
                        temp = t[i];
                        t[i] = t[j];
                        t[j] = temp;             
                    }
                }
            }
            return t;
        }

        public static float jsaqi(string canshuname, string canshu)
        {

            float IAQIp=0;//污染物项目p的空气质量分指数
            int BPlo=0;//与Cp相近的污染物浓度限值的低位值
            int BPhi = 0;//与Cp相近的污染物浓度限值的高位值
            int IAQIlo = 0;//与BPhi对应的空气质量分指数
            int IAQIhi = 0;//与BPlo对应的空气质量分指数
            float Cp = float.Parse(canshu);//字符型转换成float类型
            //求二氧化硫（SO2）24h平均浓度限值
            if ( canshuname == "SO2")
            {
                if (Cp >= 0 && Cp <= 50)
                {
                    BPlo = 0;
                    BPhi = 50;
                    IAQIlo = 0;
                    IAQIhi = 50;

                }
                else if (Cp > 50 && Cp <= 150)
                {
                    BPlo = 50;
                    BPhi = 150;
                    IAQIlo = 50;
                    IAQIhi = 100;
                }
                else if (Cp > 150 && Cp <= 475)
                {
                    BPlo = 150;
                    BPhi = 475;
                    IAQIlo = 100;
                    IAQIhi = 150;
                }
                else if (Cp > 475 && Cp <= 800)
                {
                    BPlo = 475;
                    BPhi = 150;
                    IAQIlo = 150;
                    IAQIhi = 200;
                }
                else if (Cp > 800 && Cp <= 1600)
                {
                    BPlo = 800;
                    BPhi = 1600;
                    IAQIlo = 200;
                    IAQIhi = 300;

                }
                else if (Cp > 1600 && Cp <= 2100)
                {
                    BPlo = 1600;
                    BPhi = 2100;
                    IAQIlo = 300;
                    IAQIhi = 400;
                }
                else if (Cp > 2100 && Cp <= 2620)
                {
                    BPlo = 2100;
                    BPhi = 2620;
                    IAQIlo = 400;
                    IAQIhi = 500;
                }

            }

            //求二氧化氮（NO2）24h平均浓度限值
            if ( canshuname == "NO2")
            {
                if (Cp >= 0 && Cp <= 40)
                {
                    BPlo = 0;
                    BPhi = 40;
                    IAQIlo = 0;
                    IAQIhi = 50;

                }
                else if (Cp > 40 && Cp <= 80)
                {
                    BPlo = 40;
                    BPhi = 80;
                    IAQIlo = 50;
                    IAQIhi = 100;
                }
                else if (Cp > 80 && Cp <= 180)
                {
                    BPlo = 80;
                    BPhi = 180;
                    IAQIlo = 100;
                    IAQIhi = 150;
                }
                else if (Cp > 180 && Cp <= 280)
                {
                    BPlo = 180;
                    BPhi = 280;
                    IAQIlo = 150;
                    IAQIhi = 200;
                }
                else if (Cp > 280 && Cp <= 565)
                {
                    BPlo = 280;
                    BPhi = 565;
                    IAQIlo = 200;
                    IAQIhi = 300;

                }
                else if (Cp > 565 && Cp <= 750)
                {
                    BPlo = 565;
                    BPhi = 750;
                    IAQIlo = 300;
                    IAQIhi = 400;
                }
                else if (Cp > 750 && Cp <= 940)
                {
                    BPlo = 750;
                    BPhi = 940;
                    IAQIlo = 400;
                    IAQIhi = 500;
                }

            }

            //求颗粒物（粒径小于等于10um）（PM10）24h平均浓度限值
            if (canshuname == "PM10")
            {
                if (Cp >= 0 && Cp <= 50)
                {
                    BPlo = 0;
                    BPhi = 50;
                    IAQIlo = 0;
                    IAQIhi = 50;

                }
                else if (Cp > 50 && Cp <= 150)
                {
                    BPlo = 50;
                    BPhi = 150;
                    IAQIlo = 50;
                    IAQIhi = 100;
                }
                else if (Cp > 150 && Cp <= 250)
                {
                    BPlo = 150;
                    BPhi = 250;
                    IAQIlo = 100;
                    IAQIhi = 150;
                }
                else if (Cp > 250 && Cp <= 350)
                {
                    BPlo = 250;
                    BPhi = 350;
                    IAQIlo = 150;
                    IAQIhi = 200;
                }
                else if (Cp > 350 && Cp <= 420)
                {
                    BPlo = 350;
                    BPhi = 420;
                    IAQIlo = 200;
                    IAQIhi = 300;

                }
                else if (Cp > 420 && Cp <= 500)
                {
                    BPlo = 420;
                    BPhi = 500;
                    IAQIlo = 300;
                    IAQIhi = 400;
                }
                else if (Cp > 500 && Cp <= 600)
                {
                    BPlo = 500;
                    BPhi = 600;
                    IAQIlo = 400;
                    IAQIhi = 500;
                }

            }

            //一氧化碳（CO）24h平均浓度限值
            if (canshuname == "CO")
            {
                if (Cp >= 0 && Cp <= 2)
                {
                    BPlo = 0;
                    BPhi = 2;
                    IAQIlo = 0;
                    IAQIhi = 50;

                }
                else if (Cp > 2 && Cp <= 4)
                {
                    BPlo = 2;
                    BPhi = 4;
                    IAQIlo = 50;
                    IAQIhi = 100;
                }
                else if (Cp > 4 && Cp <= 14)
                {
                    BPlo = 4;
                    BPhi = 14;
                    IAQIlo = 100;
                    IAQIhi = 150;
                }
                else if (Cp > 14 && Cp <= 24)
                {
                    BPlo = 14;
                    BPhi = 24;
                    IAQIlo = 150;
                    IAQIhi = 200;
                }
                else if (Cp > 24 && Cp <= 36)
                {
                    BPlo = 24;
                    BPhi = 36;
                    IAQIlo = 200;
                    IAQIhi = 300;

                }
                else if (Cp > 36 && Cp <= 48)
                {
                    BPlo = 36;
                    BPhi = 48;
                    IAQIlo = 300;
                    IAQIhi = 400;
                }
                else if (Cp > 48 && Cp <= 60)
                {
                    BPlo = 48;
                    BPhi = 60;
                    IAQIlo = 400;
                    IAQIhi = 500;
                }

            }

            //求臭氧（O3)1h平均浓度限值
            if (canshuname == "O3")
            {
                if (Cp >= 0 && Cp <= 160)
                {
                    BPlo = 0;
                    BPhi = 160;
                    IAQIlo = 0;
                    IAQIhi = 50;

                }
                else if (Cp > 160 && Cp <= 200)
                {
                    BPlo =160;
                    BPhi = 200;
                    IAQIlo = 50;
                    IAQIhi = 100;
                }
                else if (Cp > 200 && Cp <= 300)
                {
                    BPlo = 200;
                    BPhi = 300;
                    IAQIlo = 100;
                    IAQIhi = 150;
                }
                else if (Cp > 300 && Cp <= 400)
                {
                    BPlo = 300;
                    BPhi = 400;
                    IAQIlo = 150;
                    IAQIhi = 200;
                }
                else if (Cp > 400 && Cp <= 800)
                {
                    BPlo = 400;
                    BPhi = 800;
                    IAQIlo = 200;
                    IAQIhi = 300;

                }
                else if (Cp > 800 && Cp <= 1000)
                {
                    BPlo = 800;
                    BPhi = 1000;
                    IAQIlo = 300;
                    IAQIhi = 400;
                }
                else if (Cp > 1000 && Cp <= 1200)
                {
                    BPlo = 1000;
                    BPhi = 1200;
                    IAQIlo = 400;
                    IAQIhi = 500;
                }

            }

            //臭氧(O3)8小时滑动平均
            if (canshuname == "O3_8h")
            {
                if (Cp >= 0 && Cp <= 100)
                {
                    BPlo = 0;
                    BPhi = 100;
                    IAQIlo = 0;
                    IAQIhi = 50;

                }
                else if (Cp > 100 && Cp <= 160)
                {
                    BPlo = 100;
                    BPhi = 160;
                    IAQIlo = 50;
                    IAQIhi = 100;
                }
                else if (Cp > 160 && Cp <= 215)
                {
                    BPlo = 160;
                    BPhi = 215;
                    IAQIlo = 100;
                    IAQIhi = 150;
                }
                else if (Cp > 215 && Cp <= 265)
                {
                    BPlo = 215;
                    BPhi = 265;
                    IAQIlo = 150;
                    IAQIhi = 200;
                }
                else if (Cp >265&& Cp <= 800)
                {
                    BPlo = 265;
                    BPhi = 800;
                    IAQIlo = 200;
                    IAQIhi = 300;

                }            
            }

            //求颗粒物（粒径小于等于10um）（PM10）24h平均浓度限值
            if (canshuname == "PM2.5")
            {
                if (Cp >= 0 && Cp <= 35)
                {
                    BPlo = 0;
                    BPhi = 35;
                    IAQIlo = 0;
                    IAQIhi = 50;

                }
                else if (Cp > 35 && Cp <= 75)
                {
                    BPlo = 35;
                    BPhi = 75;
                    IAQIlo = 50;
                    IAQIhi = 100;
                }
                else if (Cp > 75 && Cp <= 115)
                {
                    BPlo = 75;
                    BPhi = 115;
                    IAQIlo = 100;
                    IAQIhi = 150;
                }
                else if (Cp > 115 && Cp <= 150)
                {
                    BPlo = 115;
                    BPhi = 150;
                    IAQIlo = 150;
                    IAQIhi = 200;
                }
                else if (Cp > 150 && Cp <= 250)
                {
                    BPlo = 150;
                    BPhi = 250;
                    IAQIlo = 200;
                    IAQIhi = 300;

                }
                else if (Cp > 250 && Cp <= 350)
                {
                    BPlo = 250;
                    BPhi = 350;
                    IAQIlo = 300;
                    IAQIhi = 400;
                }
                else if (Cp > 350 && Cp <= 500)
                {
                    BPlo = 350;
                    BPhi = 500;
                    IAQIlo = 400;
                    IAQIhi = 500;
                }

            }
            IAQIp = (((IAQIhi - IAQIlo) / (BPhi - BPlo)) * (Cp - BPlo)) + IAQIlo;

            return IAQIp;

        }
    }
}
