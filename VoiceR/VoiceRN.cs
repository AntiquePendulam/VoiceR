using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Globalization;
using System.Diagnostics;

namespace VoiceR
{
    public partial class VoiceRN : Form
    {
        public Boolean yHide = false;
        public Boolean ERF = false;
        static CultureInfo ja = new CultureInfo("ja-jp");
        static CultureInfo en = new CultureInfo("en-us");
        static SpeechRecognitionEngine VoiceR = new SpeechRecognitionEngine(ja);
        static SpeechSynthesizer SpeeSy = new SpeechSynthesizer();
        static SpeechSynthesizer en_SpeeSy = new SpeechSynthesizer();
        Reader grm;
        Starting st = new Starting();
        int wI;
        int left, top;
        int count = 0;

        //SikenTekini Properties
        private Fractals frac;
        public Fractals GetForm
        {
            set { this.frac = value; }
        }

        public VoiceRN()
        {
            InitializeComponent();
            this.MinimumSize = new System.Drawing.Size(0, 180);
            left = Screen.PrimaryScreen.WorkingArea.Width - 50;
            top = (Screen.PrimaryScreen.WorkingArea.Height - this.Height)*2/3;
            this.SetDesktopLocation(left, top);
        }

        private void Shape()
        {
            System.Drawing.Drawing2D.GraphicsPath GP = new System.Drawing.Drawing2D.GraphicsPath();
            GP.AddRectangle(new Rectangle(0, 65, this.Width, 51));
            this.Region = new Region(GP);
        }

        public void SYSTEMLOADER()
        {
            this.Visible = false;
            st.Show();
            Shape();
            grm = new Reader(this);
            //VoiceRecognizer
            VoiceR.SetInputToDefaultAudioDevice();
            VoiceR.SpeechRecognized += VoiceR_SpeechRecognized;
            VoiceR.SpeechRecognitionRejected += VoiceR_SpeechRecognitionRejected;
            VoiceR.SpeechDetected += VoiceR_SpeechDetected;
            //Speaker : ja
            SpeeSy.SetOutputToDefaultAudioDevice();
            SpeeSy.SelectVoiceByHints(VoiceGender.Female, VoiceAge.NotSet, 0, ja);
            //Speaker : en
            en_SpeeSy.SetOutputToDefaultAudioDevice();
            en_SpeeSy.SelectVoiceByHints(VoiceGender.Male, VoiceAge.NotSet, 0, en);
            init();
            st.Dispose();
            wI = 350;
        }

        private void VoiceR_SpeechDetected(object sender, SpeechDetectedEventArgs e)
        {
            //frac.MICBOX.BackgroundImage = Properties.Resources.mickickerk;
            Blade.Stop();
            count = 0;
            frac.MICBOX.BackgroundImage = Properties.Resources.mic;
            Displayer("(／'ω')／にんしきちゅう！＼('ω'＼)");
        }

        private void VoiceR_SpeechRecognitionRejected(object sender, SpeechRecognitionRejectedEventArgs e)
        {
            //Blade
            yHide = false;
            Fractal.Start();
            Blade.Start();
            left = Screen.PrimaryScreen.WorkingArea.Width - this.Width;
            this.SetDesktopLocation(left, top);
            frac.MICBOX.BackgroundImage = Properties.Resources.mickicker;
            Displayer("認識できませんでした(´・ω・｀)");
        }
        private void init()
        {
            grm.XmlReader();   
            grm.AppPaths();
            grm.Library(true); //import Grammar
            grm.Library(false); //import Reply
            if (!ERF)
            {
                VoiceR.LoadGrammarAsync(grm.Launcher());
                VoiceR.LoadGrammarAsync(grm.Grimoire());
                VoiceR.LoadGrammarAsync(grm.Sea());
                if (grm.weatherFlag)
                {
                    VoiceR.LoadGrammarAsync(grm.Heven());
                }
                Displayer("ろーでぃんぐ成功(●´ω｀●)");
            }
            else
            {
                Displayer("ろーでぃんぐえらー(´・ω・｀)");
                en_SpeeSy.Speak("System Error.Please Debug me.");
            }
        }
        public void VoiceYay(Boolean yay)//true --- START / false --- STOP
        {
            if (yay)
            {
                Displayer("Wating...");
                //Emulate
                VoiceR.RecognizeAsync(RecognizeMode.Multiple);
                Displayer("I'm Hearing");
            }
            else
            {
                Displayer("Waiting...");
                VoiceR.RecognizeAsyncCancel();
                frac.MICBOX.BackgroundImage = Properties.Resources.mickick;
                Displayer("とまったよ(´・ω・｀)");
            }
        }
        //音声認識後処理
        private void VoiceR_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            frac.MICBOX.BackgroundImage = Properties.Resources.mickicker;

            //Blade
            yHide = false;
            Fractal.Start();
            Blade.Start();
            left = Screen.PrimaryScreen.WorkingArea.Width - this.Width;
            this.SetDesktopLocation(left, top);

            Displayer("かんがえちう(*´ω｀*)");
            //結果をString型で格納
            String Result = e.Result.Text;
            //認識照合率値
            float Conf = e.Result.Confidence;
            String a = e.Result.Grammar.Name;
            //認識が65%に満たない際処理せず
            if (Conf < 0.50){ Displayer("認識率が50％以下です もう一度発声してちょ"); return; }
            Displayer("RECOGNIZED : " + Result + " : " + a);
            if (a == "application")
            {
                StartAppilcation(Result);
            }
            else if(a == "grimore")
            {
                Replayer(Result);
            }
            else if(a == "search")
            {
                Searcher(Result);
            }
            else if(a == "weather")
            {
                grm.Weather(Result);
            }
        }
        private void StartAppilcation(String str)
        {
            Displayer("I'm processing SA. : " + str);
            String AppName = str.Replace("を開いて", ""); Displayer(AppName);
            Array cash = grm.App.ToArray();
            int PathN = Array.IndexOf(cash, AppName);Displayer("" + PathN);
            if(PathN != -1)
            {
                Displayer("Starting : " + (String)AppName);
                Displayer("AppPath  : " + (String)grm.Paths[PathN]);
                //SpeeSy.Speak(AppName + "を起動します");
                try
                {
                    Process.Start((String)grm.Paths[PathN]);
                }
                catch
                {
                    Displayer("ApplicationPath Error!");
                }
            }
        }
        private void Replayer(String str)
        {
            Displayer("へんとうかんがえちゅう(●´ω｀●)");
            Indexer(str);
        }
        private void Searcher(String str)
        {
            String SearchWord;
            Displayer("けんさくなーう");
            if (str.IndexOf("Youtubeで") >= 0)
            {
                SearchWord = str.Replace("をYoutubeで検索して", "");
                Displayer(SearchWord + "をYoutubeで検索します");
                //SpeeSy.Speak(SearchWord + "を検索します");
                SearchWord = SearchWord.Replace("Youtubeで", "");
                Process.Start("https://www.youtube.com/results?search_query=" + SearchWord);
            }
            else
            {
                SearchWord = str.Replace("を検索して", "");
                Displayer(SearchWord + "を検索します");
                //SpeeSy.Speak(SearchWord + "を検索します");
                Process.Start("https://search.yahoo.co.jp/search?p=" + SearchWord + "&ei=UTF-8");
            }
        }
        //Display Log.
        public void Displayer(String str)
        {
            this.MoonLight.Text = str;
        }
        //Search Grammar, GreetingID and Find ReplyID and ReplyWord by using GreetingID.
        private void Indexer(String str)
        {
            Array cash = grm.Greeting.ToArray();
            int index = Array.IndexOf(cash, str);
            String getID = (String)grm.ID[index];
            cash = grm.RID.ToArray();
            index = Array.IndexOf(cash, getID);
            int Lindex = Array.LastIndexOf(cash, getID);
            if(index != Lindex)
            {
                System.Random r = new System.Random();
                index = r.Next(index, Lindex + 1);
            }

            String ReplyWord = grm.Rep[index].ToString();
            Displayer(ReplyWord);

            //SpeeSy.Speak(ReplyWord);
            if (getID == "end command")
            {
                Displayer("【終了中】(´・ω・)(´・ω・)(・ω・｀)(・ω・｀)");
                frac.MICBOX.BackgroundImage = Properties.Resources.mickick;
                VoiceYay(false);
                frac.yay = false;
                frac.SYuuryo();
            }
        }

        private Point mousePoint;
        private void VoiceRN_MouseDown(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                //位置を記憶する
                mousePoint = new Point(e.X, e.Y);
            }
        }

        private void VoiceRN_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                this.Left += e.X - mousePoint.X;
                this.Top += e.Y - mousePoint.Y;
            }
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Displayer("(*´ω｀*)ノシ");
            en_SpeeSy.Speak("Goodbye");
            frac.Dispose();
            this.Dispose();
        }
        public void Speaker(String str)
        {
            SpeeSy.Speak(str);
        }

        
        
        private void VoiceRN_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //Fractal.Start();
        }
        private void Blade_Tick(object sender, EventArgs e)
        {
            if (++count >= 3)
            {
                Fractal.Start();
                Blade.Stop();
            }
        }

        public void Fractal_Tick(object sender, EventArgs e)
        {
            if (yHide)
            {
                Displayer("⊂二二二（ ＾ω＾）二⊃ ﾌﾞｰﾝ");
                this.Width -= 10;
                this.Left += 10;
                if(this.Width <= 0)
                {
                    Fractal.Stop();
                    yHide = false;
                    left = Screen.PrimaryScreen.WorkingArea.Width - this.Width;
                    this.SetDesktopLocation(left, top);
                    this.Refresh();
                }
            }
            else
            {
                this.Width += 10;
                this.Left -= 10;
                if(this.Width >= wI)
                {
                    
                    this.Width = wI;
                    Fractal.Stop();
                    yHide = true;
                    left = Screen.PrimaryScreen.WorkingArea.Width - this.Width;
                    this.SetDesktopLocation(left, top);
                    this.Refresh();
                }
            }
        }
    }
}