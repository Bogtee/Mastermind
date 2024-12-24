using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mastermind
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Generisemo nasumican kod
            Random random = new Random();
            int[] secretCode = new int[4];
            for (int i = 0; i < 4; i++)
            {
                secretCode[i] = random.Next(1, 7);
            }

            Console.WriteLine("Kod je generisan");

            bool isCodeCracked = false;
            int attempts = 0;

            // Generise sve moguce kombinacije
            var allCodes = GenerateAllCodes();

            var remainingCodes = new HashSet<string>(allCodes);
            string currentGuess = "1122";

            Console.WriteLine("Rad programa:");

            while (!isCodeCracked)
            {
                attempts++;
                Console.WriteLine($"Pokusaj broj {attempts}: {currentGuess}");

                // Proverava tacnost trenutnog koda i dobija nazad broj tacnih i netacnih pozicija
                var feedback = GetFeedback(currentGuess, secretCode);

                Console.WriteLine($"Broj tacnih pozicija: {feedback.correctPosition}, Broj netacnih pozicija: {feedback.wrongPosition}");

                // Ako je algoritam nasao tacan kod zavrsi program
                if (feedback.correctPosition == 4)
                {
                    isCodeCracked = true;
                    Console.WriteLine("Algoritam je pronasao resenje");
                    break;
                }

                // Izbaci kodove koji ne zadovoljavaju broj tacnih i netacnih pozicija
                remainingCodes.RemoveWhere(code => !FeedbackMatches(code, currentGuess, feedback));

                // Biraj sledeci kod
                currentGuess = GetNextGuess(remainingCodes);
            }

            Console.WriteLine($"Trazeni kod je: {string.Join("", secretCode)}");
            Console.WriteLine($"Algoritam je dosao do resenja u {attempts} koraka.");
        }



        // Funkcija koja generise sve moguce kodove
        private static HashSet<string> GenerateAllCodes()
        {
            var codes = new HashSet<string>();
            for (int i = 1; i <= 6; i++)
                for (int j = 1; j <= 6; j++)
                    for (int k = 1; k <= 6; k++)
                        for (int l = 1; l <= 6; l++)
                        {
                            codes.Add($"{i}{j}{k}{l}");
                        }
            return codes;
        }

        // Funkcija koja proverava tacnost pokusaja
        private static (int correctPosition, int wrongPosition) GetFeedback(string guess, int[] secretCode)
        {
            int correctPosition = 0;
            int wrongPosition = 0;

            bool[] matchedInCode = new bool[4];
            bool[] matchedInGuess = new bool[4];

            for (int i = 0; i < 4; i++)
            {
                if (guess[i] - '0' == secretCode[i])
                {
                    correctPosition++;
                    matchedInCode[i] = true;
                    matchedInGuess[i] = true;
                }
            }

            for (int i = 0; i < 4; i++)
            {
                if (!matchedInGuess[i])
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (!matchedInCode[j] && guess[i] - '0' == secretCode[j])
                        {
                            wrongPosition++;
                            matchedInCode[j] = true;
                            break;
                        }
                    }
                }
            }

            return (correctPosition, wrongPosition);
        }

        // Funkcija koja izbacuje kodove koji nisu validni
        private static bool FeedbackMatches(string code, string guess, (int correctPosition, int wrongPosition) feedback)
        {
            var testCode = code.Select(c => c - '0').ToArray();
            var testFeedback = GetFeedback(guess, testCode);
            return testFeedback == feedback;
        }

        // Funkcija koja bira novi kod
        private static string GetNextGuess(HashSet<string> remainingCodes)
        {
            return remainingCodes.First();
        }
    }
}
