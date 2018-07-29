using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Speech.Recognition;
using System.IO;
using System.Collections;
using System.Speech.Synthesis;
using System.Globalization;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Xml;

namespace VoiceR
{
    public class Reader
    {
        public ArrayList App = new ArrayList();
        public ArrayList Paths = new ArrayList();
        public ArrayList ID = new ArrayList();
        public ArrayList Rep = new ArrayList();
        public ArrayList RID = new ArrayList();
        public ArrayList Greeting = new ArrayList();
        public ArrayList CityNames = new ArrayList();
        public ArrayList CityIDs = new ArrayList();
        public VoiceRN VoR;

        public Boolean weatherFlag = true;
        public Reader(VoiceRN VoR)
        {
            this.VoR = VoR;
        }
        public Grammar Launcher()
        {
            Choices AppName = new Choices();
            string[] apps = (string[])App.ToArray(typeof(string));
            AppName.Add(apps);
            GrammarBuilder gb_result = new GrammarBuilder();
            gb_result.Append(AppName);
            gb_result.Append("を開いて");
            Grammar g_result = new Grammar(gb_result);

            //Grammarに名前をつけてあげよねそうしよね
            g_result.Name = "application";
            return g_result;
        }
        public Grammar Heven()
        {
            string[] City = (string[])CityNames.ToArray(typeof(string));
            Choices Citys = new Choices();
            Choices CIDs = new Choices();
            Citys.Add(City);
            GrammarBuilder gb_result = new GrammarBuilder();
            gb_result.Append(Citys);
            gb_result.Append("の天気を教えて");
            Grammar g_result = new Grammar(gb_result);

            //Grammarに名前をつけてあげよねそうしよね
            g_result.Name = "weather";
            return g_result;
        }
        public Grammar Sea()
        {
            Choices Youtube = new Choices();
            Youtube.Add(new string[] { "をYoutubeで検索して", "を検索して"});
            GrammarBuilder gb_result = new GrammarBuilder();
            gb_result.AppendDictation();
            gb_result.Append(Youtube);
            Grammar g_result = new Grammar(gb_result);

            //Grammarに名前をつけてあげよねそうしよね
            g_result.Name = "search";
            return g_result;
        }
        public Grammar Grimoire()
        {
            Choices Words = new Choices();
            string[] word = (string[])Greeting.ToArray(typeof(string));

            Words.Add(word);
            GrammarBuilder gb_result = new GrammarBuilder(Words);
            Grammar g_result = new Grammar(gb_result);
            g_result.Name = "grimore";
            return g_result;
        }


        public void AppPaths()
        {
            App.Clear();
            Paths.Clear();
            Rep.Clear();
            VoR.Displayer("Reading Applications");
            try
            {
                using (StreamReader DATA = new StreamReader(@"Grammars\luncher.voicer", System.Text.Encoding.GetEncoding("utf-8")))
                {
                    string ReadData;
                    //true = 奇数 false = 偶数
                    Boolean OEFlag = false;
                    while ((ReadData = DATA.ReadLine()) != null)
                    {
                        OEFlag = !OEFlag;
                        if (OEFlag)
                        {
                            App.Add(ReadData);
                            VoR.Displayer("READ NOW [ " + ReadData + " ] As AppName");
                        }
                        else
                        {
                            Paths.Add(ReadData);
                            VoR.Displayer("READ NOW [ " + ReadData + " ] As Path");
                        }
                    }
                }
                VoR.Displayer("Done");
            }
            catch(Exception Exc)
            {
                VoR.Displayer("ERROR : " + Exc.Message);
                VoR.ERF = true;
            }
        }

        public void Library(Boolean b)
        {
            //if b = true Reading Grammar
            String LP, Dr;
            if (b)
            {
                LP = @"Grammars\greeting0.voicer";
                Dr = "Libraries";
            }
            else
            {
                LP = @"Reply\greeting0.voicer";
                Dr = "Reply";
            }

            VoR.Displayer("Reading : " + Dr);
            try
            {
                using (StreamReader DATA = new StreamReader(LP, System.Text.Encoding.UTF8))
                {
                    string ReadData;
                    string IDdata = "";
                    while ((ReadData = DATA.ReadLine()) != null)
                    {
                        //Reading ID
                        if (ReadData.IndexOf(":ID") >= 0)
                        {
                            IDdata = ReadData.Replace(":ID ", "");
                            VoR.Displayer("Reading [ " + IDdata + " ] as ID");
                        }
                        else if (ReadData.IndexOf(":SPE") >= 0)
                        {
                            IDdata = ReadData.Replace(":SPE ", "");
                            VoR.Displayer("Reading [ " + IDdata + " ] as SPECIAL");
                        }
                        else //ReadingWord
                        {
                            string key;
                            //Greeting : ID
                            if (b)
                            {
                                ID.Add(IDdata);
                                Greeting.Add(ReadData);
                            }
                            else
                            {
                                RID.Add(IDdata);
                                Rep.Add(ReadData);
                            }
                            if (IDdata == "special") key = "*special Word";
                            else key = "word";

                            VoR.Displayer("Reading [ " + ReadData + " ] as " + key);
                        }
                    }
                }
                VoR.Displayer("Done");
            }
            catch(Exception e)
            {
                VoR.Displayer("【【【ERROR】】】 : " + e.Message);
                VoR.ERF = true;
            }
        }
        String Word;
        public void Weather(String str)
        {
            Word = str.Replace("の天気を教えて", "");
            Array cash = CityNames.ToArray();
            int IDNumber = Array.IndexOf(cash, Word);
            String ClockID = (String)CityIDs[IDNumber];

            String baseurl = "http://weather.livedoor.com/forecast/webservice/json/v1";
            String url = baseurl + "?city=" + ClockID;
            String Json = new HttpClient().GetStringAsync(url).Result;
            JObject jobj = JObject.Parse(Json);
            string todayWeather = (string)((jobj["forecasts"][0]["telop"] as JValue).Value);
            VoR.Displayer("今日の" + Word+ "の天気は : " + todayWeather + "です");
        }

        public void XmlReader()
        {
            XmlDocument IDSheet = new XmlDocument();
            XmlElement SheetElement,temp;
            XmlNodeList CityList;

            try
            {
                IDSheet.Load(@"http://weather.livedoor.com/forecast/rss/primary_area.xml");
                SheetElement = IDSheet.DocumentElement;
                CityList = IDSheet.GetElementsByTagName("city");

                foreach (XmlNode xn in CityList)
                {
                    temp = (XmlElement)xn;
                    CityNames.Add( temp.GetAttribute("title") );
                    CityIDs.Add( temp.GetAttribute("id") );
                }
            }
            catch
            {
                MessageBox.Show("IDシートをローディング出来ませんでした。\nウェザー機能は使えません。\nネットワークの状況等をご確認下さい");
                weatherFlag = false;
            }
        }
    }
}
