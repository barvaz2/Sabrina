using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeneratePatterns
{
    public partial class Form1 : Form
    {
        List<ImageData> _imagePool;
        Random _rnd;
        int _totalA = 0;
        int _totalB = 0;

        private void LoadImages()
        {
            _imagePool = new List<ImageData>();
            _rnd = new Random();

            /*
             * AddProbablityToPool(string P, int count, int prob)
                          
            There are A-N = 14 unique images (P)
            For each image we specify how many times we want it to appear in the pool (count)
            The total amount of images in the pool is 200
            For each image we specify what is the probability that the first answer will be the correct one (prob)

            ShuffleNoRepeat(List<ImageData> deck)

            Shuffle the deck in a manner such that an image can't appear twice in a row
             */

            AddProbablityToPool("A", 19, 89);
            AddProbablityToPool("B", 9, 78);
            AddProbablityToPool("C", 26, 92);
            AddProbablityToPool("D", 9, 22);
            AddProbablityToPool("E", 12, 83);
            AddProbablityToPool("F", 6, 50);
            AddProbablityToPool("G", 19, 89);
            AddProbablityToPool("H", 19, 11);
            AddProbablityToPool("I", 6, 50);
            AddProbablityToPool("J", 12, 17);
            AddProbablityToPool("K", 9, 55);
            AddProbablityToPool("L", 26, 8);
            AddProbablityToPool("M", 9, 44);
            AddProbablityToPool("N", 19, 11);

            ShuffleNoRepeat(_imagePool);
        }


        public void AddProbablityToPool(string P, int count, int prob)
        {
            float f = (float)prob / 100f;
            int answerA = (int)Math.Round((count * f), MidpointRounding.ToEven);
            int answerB = count - answerA;
            _totalA += answerA;
            _totalB += answerB;
            List<string> answers = new List<string>();
            for (int i = 0; i < answerA; i++)
            {
                answers.Add("A");
            }
            for (int i = 0; i < answerB; i++)
            {
                answers.Add("B");
            }
            Shuffle(answers);
            for (int i = 0; i < count; i++)
            {
                _imagePool.Add(new ImageData()
                    {
                        ImgName = P,
                        Answer = answers[i]
                    });
            }
        }

        public void Shuffle(List<string> deck)
        {
            for (int n = deck.Count - 1; n > 0; --n)
            {
                int k = _rnd.Next(n + 1);
                string temp = deck[n];
                deck[n] = deck[k];
                deck[k] = temp;
            }
        }
        public void ShuffleNoRepeat(List<ImageData> deck)
        {
            for (int n = deck.Count - 1; n > 0; --n)
            {
                int k = _rnd.Next(n + 1);
                ImageData temp = deck[n];
                deck[n] = deck[k];
                deck[k] = temp;
            }

            Dictionary<int, int> replacedVals = new Dictionary<int, int>();
            for (int i = 0; i < deck.Count - 1; i++)
            {
                if (deck[i].ImgName == deck[i + 1].ImgName)
                {
                    ImageData temp = deck[i + 1];
                    bool toStop = false;
                    int replaceIndex = deck.Count - 1;

                    while (!toStop)
                    {
                        if (deck[replaceIndex].ImgName == deck[i + 1].ImgName)
                        {
                            replaceIndex--;
                            continue;
                        }
                        if (replaceIndex > 0 && deck[replaceIndex - 1].ImgName == deck[i + 1].ImgName)
                        {
                            replaceIndex--;
                            continue;
                        }
                        if (replaceIndex < deck.Count - 1 && deck[replaceIndex + 1].ImgName == deck[i + 1].ImgName)
                        {
                            replaceIndex--;
                            continue;
                        }
                        toStop = true;
                    }
                    deck[i + 1] = deck[replaceIndex];
                    deck[replaceIndex] = temp;
                    replacedVals[i + 1] = replaceIndex;
                    replacedVals[replaceIndex] = i + 1;
                    i = 0;
                }
            }

        }
        public Form1()
        {
            InitializeComponent();
        }

        private void b_save_Click(object sender, EventArgs e)
        {
            CreateNewPattern();
        }

        private void CreateNewPattern()
        {
            LoadImages();
            StringBuilder sb = GetImageDataCSVText(_imagePool);
            SaveFile(sb);
        }

        private StringBuilder GetImageDataCSVText(List<ImageData> _imagePool)
        {
            StringBuilder sb = new StringBuilder();
            foreach (ImageData id in _imagePool)
            {
                sb.AppendLine(String.Format("{0},{1}", id.ImgName, id.Answer));
            }
            return sb;
        }

        private void SaveFile(StringBuilder sb)
        {
            SaveFileDialog savefile = new SaveFileDialog();
            // set a default file name
            savefile.FileName = "ImageData1.csv";
            // set filters - this can be done in properties as well
            savefile.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";

            if (savefile.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(savefile.FileName, sb.ToString());
            }
        }
    }
}
