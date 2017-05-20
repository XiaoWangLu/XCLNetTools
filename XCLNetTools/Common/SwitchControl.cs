﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace XCLNetTools.Common
{
    /// <summary>
    /// 开关控制
    /// </summary>
    public class SwitchControl
    {
        #region 开关配置和开关的百分比控制

        /// <summary>
        /// 百分比对应的匹配正则
        /// </summary>
        private static Dictionary<int, string> percentDic = new Dictionary<int, string>(){
                                            {1,"^[0][01]$"},
                                            {2,"^[0][01234]$"},
                                            {3,"^[0][0123456]$"},
                                            {4,"^[01][01234]$"},
                                            {5,"^[012][0123]$"},
                                            {6,"^[012][01234]$"},
                                            {7,"^[0123][0123]$"},
                                            {8,"^[0123][01234]$"},
                                            {9,"^[0123][012345]$"},
                                            {10,"^[01234][01234]$"},
                                            {11,"^[0123][0123456]$"},
                                            {12,"^[01234][012345]$"},
                                            {13,"^[012][0123456789A]$"},
                                            {14,"^[01234][0123456]$"},
                                            {15,"^[012][0123456789ABC]$"},
                                            {16,"^[01234][01234567]$"},
                                            {17,"^[012345][0123456]$"},
                                            {18,"^[01234][012345678]$"},
                                            {19,"^[012345][01234567]$"},
                                            {20,"^[01234][0123456789]$"},
                                            {21,"^[012345][012345678]$"},
                                            {22,"^[0123456][01234567]$"},
                                            {23,"^[0123456][01234567]$"},
                                            {24,"^[012345][0123456789]$"},
                                            {25,"^[01234567][01234567]$"},
                                            {26,"^[012345][0123456789A]$"},
                                            {27,"^[0123456][0123456789]$"},
                                            {28,"^[01234567][012345678]$"},
                                            {29,"^[01234][0123456789ABCDE]$"},
                                            {30,"^[0123456][0123456789A]$"},
                                            {31,"^[01234567][0123456789]$"},
                                            {32,"^[012345678][012345678]$"},
                                            {33,"^[0123456][0123456789AB]$"},
                                            {34,"^[01234567][0123456789A]$"},
                                            {35,"^[012345678][0123456789]$"},
                                            {36,"^[0123456][0123456789ABC]$"},
                                            {37,"^[01234567][0123456789AB]$"},
                                            {38,"^[01234567][0123456789AB]$"},
                                            {39,"^[012345678][0123456789A]$"},
                                            {40,"^[0123456789][0123456789]$"},
                                            {41,"^[01234567][0123456789ABC]$"},
                                            {42,"^[012345678][0123456789AB]$"},
                                            {43,"^[0123456789][0123456789A]$"},
                                            {44,"^[01234567][0123456789ABCD]$"},
                                            {45,"^[012345678][0123456789ABC]$"},
                                            {46,"^[012345678][0123456789ABC]$"},
                                            {47,"^[0123456789][0123456789AB]$"},
                                            {48,"^[0123456789A][0123456789A]$"},
                                            {49,"^[012345678][0123456789ABCD]$"},
                                            {50,"^[01234567][0123456789ABCDEF]$"},
                                            {51,"^[0123456789][0123456789ABC]$"},
                                            {52,"^[0123456789A][0123456789AB]$"},
                                            {53,"^[012345678][0123456789ABCDE]$"},
                                            {54,"^[0123456789][0123456789ABCD]$"},
                                            {55,"^[0123456789][0123456789ABCD]$"},
                                            {56,"^[0123456789A][0123456789ABC]$"},
                                            {57,"^[0123456789AB][0123456789AB]$"},
                                            {58,"^[0123456789][0123456789ABCDE]$"},
                                            {59,"^[0123456789][0123456789ABCDE]$"},
                                            {60,"^[0123456789A][0123456789ABCD]$"},
                                            {61,"^[0123456789AB][0123456789ABC]$"},
                                            {62,"^[0123456789AB][0123456789ABC]$"},
                                            {63,"^[0123456789][0123456789ABCDEF]$"},
                                            {64,"^[0123456789A][0123456789ABCDE]$"},
                                            {65,"^[0123456789A][0123456789ABCDE]$"},
                                            {66,"^[0123456789AB][0123456789ABCD]$"},
                                            {67,"^[0123456789ABC][0123456789ABC]$"},
                                            {68,"^[0123456789A][0123456789ABCDEF]$"},
                                            {69,"^[0123456789A][0123456789ABCDEF]$"},
                                            {70,"^[0123456789AB][0123456789ABCDE]$"},
                                            {71,"^[0123456789ABC][0123456789ABCD]$"},
                                            {72,"^[0123456789ABC][0123456789ABCD]$"},
                                            {73,"^[0123456789ABC][0123456789ABCD]$"},
                                            {74,"^[0123456789AB][0123456789ABCDEF]$"},
                                            {75,"^[0123456789AB][0123456789ABCDEF]$"},
                                            {76,"^[0123456789ABC][0123456789ABCDE]$"},
                                            {77,"^[0123456789ABCD][0123456789ABCD]$"},
                                            {78,"^[0123456789ABCD][0123456789ABCD]$"},
                                            {79,"^[0123456789ABCD][0123456789ABCD]$"},
                                            {80,"^[0123456789ABC][0123456789ABCDEF]$"},
                                            {81,"^[0123456789ABC][0123456789ABCDEF]$"},
                                            {82,"^[0123456789ABCD][0123456789ABCDE]$"},
                                            {83,"^[0123456789ABCD][0123456789ABCDE]$"},
                                            {84,"^[0123456789ABCD][0123456789ABCDE]$"},
                                            {85,"^[0123456789ABCD][0123456789ABCDE]$"},
                                            {86,"^[0123456789ABCD][0123456789ABCDEF]$"},
                                            {87,"^[0123456789ABCD][0123456789ABCDEF]$"},
                                            {88,"^[0123456789ABCDE][0123456789ABCDE]$"},
                                            {89,"^[0123456789ABCDE][0123456789ABCDE]$"},
                                            {90,"^[0123456789ABCDE][0123456789ABCDE]$"},
                                            {91,"^[0123456789ABCDE][0123456789ABCDE]$"},
                                            {92,"^[0123456789ABCDE][0123456789ABCDEF]$"},
                                            {93,"^[0123456789ABCDE][0123456789ABCDEF]$"},
                                            {94,"^[0123456789ABCDE][0123456789ABCDEF]$"},
                                            {95,"^[0123456789ABCDE][0123456789ABCDEF]$"},
                                            {96,"^[0123456789ABCDE][0123456789ABCDEF]$"},
                                            {97,"^[0123456789ABCDEF][0123456789ABCDEF]$"},
                                            {98,"^[0123456789ABCDEF][0123456789ABCDEF]$"},
                                            {99,"^[0123456789ABCDEF][0123456789ABCDEF]$"},
                                            {100,"^[0123456789ABCDEF][0123456789ABCDEF]$"}
        };

        //理论百分比  实际百分比
        //1=========0.78125
        //2=========1.953125
        //3=========2.734375
        //4=========3.90625
        //5=========4.6875
        //6=========5.859375
        //7=========6.25
        //8=========7.8125
        //9=========9.375
        //10=========9.765625
        //11=========10.9375
        //12=========11.71875
        //13=========12.890625
        //14=========13.671875
        //15=========15.234375
        //16=========15.625
        //17=========16.40625
        //18=========17.578125
        //19=========18.75
        //20=========19.53125
        //21=========21.09375
        //22=========21.875
        //23=========21.875
        //24=========23.4375
        //25=========25
        //26=========25.78125
        //27=========27.34375
        //28=========28.125
        //29=========29.296875
        //30=========30.078125
        //31=========31.25
        //32=========31.640625
        //33=========32.8125
        //34=========34.375
        //35=========35.15625
        //36=========35.546875
        //37=========37.5
        //38=========37.5
        //39=========38.671875
        //40=========39.0625
        //41=========40.625
        //42=========42.1875
        //43=========42.96875
        //44=========43.75
        //45=========45.703125
        //46=========45.703125
        //47=========46.875
        //48=========47.265625
        //49=========49.21875
        //50=========50
        //51=========50.78125
        //52=========51.5625
        //53=========52.734375
        //54=========54.6875
        //55=========54.6875
        //56=========55.859375
        //57=========56.25
        //58=========58.59375
        //59=========58.59375
        //60=========60.15625
        //61=========60.9375
        //62=========60.9375
        //63=========62.5
        //64=========64.453125
        //65=========64.453125
        //66=========65.625
        //67=========66.015625
        //68=========68.75
        //69=========68.75
        //70=========70.3125
        //71=========71.09375
        //72=========71.09375
        //73=========71.09375
        //74=========75
        //75=========75
        //76=========76.171875
        //77=========76.5625
        //78=========76.5625
        //79=========76.5625
        //80=========81.25
        //81=========81.25
        //82=========82.03125
        //83=========82.03125
        //84=========82.03125
        //85=========82.03125
        //86=========87.5
        //87=========87.5
        //88=========87.890625
        //89=========87.890625
        //90=========87.890625
        //91=========87.890625
        //92=========93.75
        //93=========93.75
        //94=========93.75
        //95=========93.75
        //96=========93.75
        //97=========100
        //98=========100
        //99=========100
        //100=========100

        /// <summary>
        /// 配置key类型枚举
        /// </summary>
        private enum SwitchKeyTypeEnum
        {
            /// <summary>
            /// 白名单（true）
            /// </summary>
            T,

            /// <summary>
            /// 黑名单（false）
            /// </summary>
            F,

            /// <summary>
            /// 既不是白名单也不在黑名单，最终的判断类型
            /// </summary>
            V
        }

        /// <summary>
        /// 开关是否打开
        /// 如：<![CDATA[IsOpen("T=admin;test;&F=user1;user2;&V=20","admin");]]>
        /// </summary>
        /// <param name="str">
        /// 配置项的值，一般是从数据库的配置表中读取
        /// 格式：<![CDATA[T=admin;test;&F=user1;user2;&V=20]]>
        /// 说明：
        /// 1、T后面的值为白名单，用;隔开，如果flag在此值中存在，则返回true
        /// 2、F后面的值为黑名单，用;隔开，如果flag在此值中存在，则返回false
        /// 3、当均不在黑白名单时，则使用V后面的值 ，该值为字符T或F或0~100之间的数字，当为T时，返回true；当为F时，返回false；当为数字时，即为百分比，由系统根据一定算法计算flag，并返回true或false
        /// 4、TFV之间用<![CDATA[&]]>隔开，类似url查询字符串
        /// 5、当整个配置值为T，则返回true；当整个配置值为空、F或不符合格式要求时，则返回false
        /// </param>
        /// <param name="flag">百分比控制时的标志字符串，比如用户名："admin"</param>
        /// <returns>true：开，false：关</returns>
        public static bool IsOpen(string str, string flag = "")
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return false;
            }

            str = str.Trim().ToUpper();
            if (str.Equals(SwitchKeyTypeEnum.T.ToString()))
            {
                return true;
            }
            if (str.Equals(SwitchKeyTypeEnum.F.ToString()))
            {
                return false;
            }

            var nv = System.Web.HttpUtility.ParseQueryString(str);
            if (null == nv || nv.Count == 0)
            {
                return false;
            }

            if (!string.IsNullOrWhiteSpace(flag))
            {
                flag = flag.Trim().ToUpper();
            }

            var val = string.Empty;

            //T
            val = nv[SwitchKeyTypeEnum.T.ToString()];
            if (!string.IsNullOrWhiteSpace(val))
            {
                if (val.Split(';').Contains(flag))
                {
                    return true;
                }
            }

            //F
            val = nv[SwitchKeyTypeEnum.F.ToString()];
            if (!string.IsNullOrWhiteSpace(val))
            {
                if (val.Split(';').Contains(flag))
                {
                    return false;
                }
            }

            //V
            val = nv[SwitchKeyTypeEnum.V.ToString()];
            if (!string.IsNullOrWhiteSpace(val))
            {
                if (val.Equals("T"))
                {
                    return true;
                }
                if (val.Equals("F"))
                {
                    return false;
                }

                int pVal = 0;
                if (!Int32.TryParse(val, out pVal))
                {
                    return false;
                }

                if (pVal <= 0)
                {
                    return false;
                }

                if (pVal >= 100)
                {
                    return true;
                }

                string flagMd5 = XCLNetTools.Encrypt.MD5.EncodeMD5(flag);

                return new Regex(percentDic[pVal]).IsMatch(flagMd5[0].ToString() + flagMd5[1].ToString());
            }

            return false;
        }

        #endregion 开关配置和开关的百分比控制

        /// <summary>
        /// 将T/F转为bool值
        /// </summary>
        /// <param name="val">T或F</param>
        /// <returns>T:true,F:false</returns>
        public static bool TFToBool(string val)
        {
            if (string.IsNullOrWhiteSpace(val))
            {
                return false;
            }
            val = val.ToUpper();
            if (val == "T")
            {
                return true;
            }
            if (val == "F")
            {
                return false;
            }
            throw new ArgumentOutOfRangeException("val", "val只能为：T或F");
        }
    }
}