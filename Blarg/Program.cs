using SakuraBlue.Entities;
//using Megadrive;
using Omnicatz.AccessDenied;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Omnicatz.Helper;

namespace SakuraBlue {
    class Program {

        public const string GameTitle = "SakuraBlue";









    public  static GameState.GameStateBase currentState ;//= Singleton<GameState.Map>.GetInstance();

        public static char HexToChar(string hex)
        {
            return (char)ushort.Parse(hex, System.Globalization.NumberStyles.HexNumber);
        }
        static void Main(string[] args) {

            Omnicatz.Helper.DialogHelper.WriteLongVoicedDialog(@"Early years
engraving of exterior of church, showing spire and grounds
Sheffield Parish Church in 1819
Three-quarter length portrait of youth, looking at viewer, wearing blue jacket and white trousers
Bennett in the uniform of a student of the Royal Academy of Music, by James Warren Childe, c. 1832

Bennett was born in Sheffield, Yorkshire, the third child and only son of Robert Bennett, the organist of Sheffield parish church, and his wife Elizabeth, née Donn.[1][i] In addition to his duties as an organist, Robert Bennett was a conductor, composer and piano teacher; he named his son after his friend William Sterndale, some of whose poems the elder Bennett had set to music. His mother died in 1818, aged 27, and his father, after remarrying, died in 1819.[3] Thus orphaned at the age of three, Bennett was brought up in Cambridge by his paternal grandfather, John Bennett, from whom he received his first musical education.[4] John Bennett was a professional bass, who sang as a lay clerk in the (then unified) choir of King's, St John's and Trinity colleges.[1] The young Bennett had a fine alto voice[5] and entered the choir of King's College Chapel in February 1824.[6] In 1826, at the age of ten, he was accepted into the Royal Academy of Music (RAM), which had been founded in 1822.[ii] The examiners were so impressed by the child's talent that they waived all fees for his tuition and board.[7]

Bennett was a pupil at the RAM for the next ten years. At his grandfather's wish his principal instrumental studies were at first as a violinist, under Paolo Spagnoletti and later Antonio James Oury.[8] He also studied the piano under W. H. Holmes, and after five years, with his grandfather's agreement, he took the piano as his principal study.[9] He was a shy youth and was diffident about his skill in composition, which he studied under the principal of the RAM, William Crotch, and then under Cipriani Potter, who took over as principal in 1832.[10] Amongst the friends Bennett made at the Academy was the future music critic J. W. Davison.[11] Bennett did not study singing, but when the RAM mounted a student production of The Marriage of Figaro in 1830, Bennett, aged fourteen, was cast in the mezzo-soprano role of the page boy Cherubino (usually played by a woman en travesti). This was among the few failures of his career at the RAM. The Observer wryly commented, ""of the page ... we will not speak"", but acknowledged that Bennett sang pleasingly and to the satisfaction of the audience.[12] The Harmonicon, however, called his performance ""in every way a blot on the piece"".[13]

Among Bennett's student compositions were a piano concerto (No. 1 in D minor, Op. 1), a symphony and an overture to The Tempest.[14] The concerto received its public premiere at an orchestral concert in Cambridge on 28 November 1832, with Bennett as soloist. Performances soon followed in London and, by royal command, at Windsor Castle, where Bennett played in April 1833 for King William IV and Queen Adelaide.[15] The RAM published the concerto at its own expense as a tribute.[16] A further London performance was given in June 1833. The critic of The Harmonicon wrote of this concert:

    [T]he most complete and gratifying performance was that of young Bennett, whose composition would have conferred honour on any established master, and his execution of it was really surprising, not merely for its correctness and brilliancy, but for the feeling he manifested, which, if he proceed as he has begun, must in a few years place him very high in his profession.[13]

In the audience was Felix Mendelssohn, who was sufficiently impressed to invite Bennett to the Lower Rhenish Music Festival in Düsseldorf. Bennett asked, ""May I come to be your pupil?"" Mendelssohn replied, ""No, no. You must come to be my friend"".[15]

In 1834 Bennett was appointed organist of St Ann's, Wandsworth, London, a chapel of ease to Wandsworth parish church.[17] He held the post for a year, after which he taught private students in central London and at schools in Edmonton and Hendon.[18] Although by common consent the RAM had little more to teach him after his seventh or eighth year, he was permitted to remain as a free boarder there until 1836, which suited him well, as his income was small.[19] In May 1835 Bennett made his first appearance at the Philharmonic Society of London, playing the premiere of his Second Piano Concerto (in E-flat major, Op. 4), and in the following year he gave there the premiere of his Third Concerto (in C minor, Op. 9). Bennett was also a member of the Society of British Musicians, founded in 1834 to promote specifically British musicians and compositions. Davison wrote in 1834 that Bennett's overture named for Lord Byron's Parisina was ""the best thing that has been played at the Society's concerts"".[20][21]
Germany: Mendelssohn and Schumann (1836–42)
watercolour portrait against blank background of a young man with dark, curly hair, facing the spectator: dressed in fashionable clothes of the 1830s, dark jacket with velvet collar, black silk cravat, high collar, white waistcoat
Felix Mendelssohn (detail) by James Warren Childe, 1839
engraving of young man in armchair with round face and dark curly hair, wearing dark clothing, facing spectator
Robert Schumann, lithograph by Josef Kriehuber, in 1839

In May 1836 Bennett travelled to Düsseldorf in the company of Davison to attend the Lower Rhenish Music Festival for the first performance of Mendelssohn's oratorio St Paul. Bennett's visit was enabled by a subsidy by the piano-making firm of John Broadwood & Sons.[22] Inspired by his journey up the Rhine, Bennett began work on his overture The Naiads (Op. 15).[23] After Bennett left for home, Mendelssohn wrote to their mutual friend, the English organist and composer Thomas Attwood, ""I think him the most promising young musician I know, not only in your country but also here, and I am convinced if he does not become a very great musician, it is not God's will, but his own"".[3] After Bennett's first visit to Germany there followed three extended visits to work in Leipzig. He was there from October 1836 to June 1837, during which time he made his debut at the Gewandhaus as the soloist in his Third Piano Concerto with Mendelssohn conducting. He later conducted his Naiads overture.[24] During this visit he also arranged the first cricket match ever played in Germany, (""as fitting a Yorkshireman"" as the musicologist Percy M. Young comments).[25] At this time Bennett wrote to Davison:

    [Mendelssohn] took me to his house and gave me the printed score of [his overture] 'Melusina', and afterwards we supped at the 'Hôtel de Bavière', where all the musical clique feed ... The party consist[ed] of Mendelssohn, [Ferdinand] David, Stamity [sic] ... and a Mr. Schumann, a musical editor, who expected to see me a fat man with large black whiskers.[26]

Bennett had been at first slightly in awe of Mendelssohn, but no such formality ever attached to Bennett's friendship with Robert Schumann, with whom he went on long country walks by day and visited the local taverns by night. Each dedicated a large-scale piano work to the other: in August 1837 Schumann dedicated his Symphonic Studies to Bennett, who reciprocated the dedication a few weeks later with his Fantasie, Op. 16.[27] Schumann was eloquently enthusiastic about Bennett's music; in 1837 he devoted an essay to Bennett in the Neue Zeitschrift für Musik, praising amongst other works Bennett's Op. 10 Musical Sketches for piano, ""three of Bennett's loveliest pictures"". The essay ends: ""For some time now he has been peering over my shoulder, and for the second time he has asked 'But what are you writing?' Dear friend, I shall write no more than: 'If only you knew!'""[28] Bennett however had from the outset some reservations about Schumann's music, which, he told Davison in 1837, he thought ""rather too eccentric"".[29]

On Bennett's return to London he took up a teaching post at the RAM which he held until 1858.[3] During his second long stay in Germany, from October 1838 to March 1839, he played his Fourth Piano Concerto (Op. 19, in F minor) and the Wood Nymphs Overture, Op. 20. Returning to England, he wrote to his Leipzig publisher Friedrich Kistner in 1840, bemoaning the difference between England and Germany (and hoping that a German would redress the situation):

    You know what a dreadful place England is for music; and in London I have nobody who I can talk to about such things, all the people are mad with [Sigismond] Thalberg and [Johann] Strauss [I], and I have not heard a single Symphony or Overture in one concert since last June. I sincerely hope that Prince Albert ... will do something to improve our taste.[30]

On Bennett's third trip, from January to March 1842, in which he also visited Kassel, Dresden and Berlin, he played his Caprice for piano and orchestra, Op. 22, in Leipzig.[31] Despite his then-pessimistic view of music in England, Bennett missed his chance to establish himself in Germany. The musicologist Nicholas Temperley writes

    One might guess that the early loss of both parents produced in Bennett an exceptionally intense need for reassurance and encouragement. England could not provide this for a native composer in his time. He found it temporarily in German musical circles; yet, when the opportunity came to claim his earned place as a leader in German music, he was not quite bold enough to grasp it.[3]

Teacher and conductor (1842–49)
black and white reproduction of watercolour drawing of young woman, facing the spectator, hair parted at centre, shawl over shoulders
Mary Anne Wood, whom Bennett married in 1844
photograph of a manm, facing spectator but looking down, dressed in mid-Victorian style with broad silk tie and tie-pin
Bennett aged about 35

Bennett returned to London in March 1842, and continued his teaching at the RAM. The next year the post of professor of music at the University of Edinburgh became vacant. With Mendelssohn's strong encouragement Bennett applied for the position. Mendelssohn wrote to the principal of the university, ""I beg you to use your powerful influence on behalf of that candidate whom I consider in every respect worthy of the place, a true ornament to his art and his country, and indeed one of the best and most highly gifted musicians now living: Mr. Sterndale Bennett."" Despite this advocacy Bennett's application was unsuccessful.[32]

Bennett had been impressed in Leipzig with the concept of chamber music concerts, which had been, apart from string quartet recitals, a rarity in London. He began in 1843 a series of such concerts including piano trios of Louis Spohr and Ludwig van Beethoven, works for piano solo, and string sonatas by Mendelssohn and others. Amongst those taking part in these recitals were the piano virtuoso Alexander Dreyschock and Frédéric Chopin's pupil, the 13-year old Carl Filtsch.[33]

in 1844 Bennett married Mary Anne Wood (1824–1862), the daughter of a naval commander.[34] Composition gave way to a ceaseless round of teaching and musical administration. The writer and composer Geoffrey Bush sees the marriage as marking a break in Bennett's career; ""from 1844 to 1856 [Bennett] was a freelance teacher, conductor and concert organiser; a very occasional pianist and a still more occasional composer.""[35] Clara Schumann noted that Bennett spent too much time giving private lessons to keep up with changing trends in music: ""His only chance of learning new music is in the carriage on the way from one lesson to another.""[36]

From 1842 Bennett had been a director of the Philharmonic Society of London. He helped to relieve the society's perilous finances by persuading Mendelssohn and Spohr to perform with the Society's orchestra, attracting full houses and much-needed income.[37] In 1842 the orchestra, under the composer's baton, gave the London premiere of Mendelssohn's Third (Scottish) Symphony, two months after its world premiere in Leipzig.[38] In 1844 Mendelssohn conducted the last six concerts of the society's season, in which among his own works and those of many others he included music by Bennett.[39] From 1846 to 1854 the Society's conductor was Michael Costa, of whom Bennett disapproved; Costa was too devoted to Italian opera and not a partisan of the German masters, as was Bennett. Bennett wrote to Mendelssohn on July 24, displaying some querulousness, ""The Philharmonic Directors have engaged Costa ... with which I am not very well pleased, but I could not persuade them to the contrary, and am tired of quarrelling with them. They are a worse set this year than we have ever had.""[40]

In May 1848, on the opening of Queen's College, London, Bennett, as one of the Founding Directors, delivered an inaugural lecture and joined the staff, while continuing his work at the RAM and private teaching. He wrote the thirty Preludes and Lessons, Op. 33, for his piano students at the college; they were published in 1853 and remained in widespread use by music students well into the twentieth century.[1] In a profile of Bennett published in 1903 F. G. Edwards noted that Bennett's duties as a teacher severely reduced his opportunity to compose, although he maintained his reputation as a soloist in annual chamber music and piano recitals at the Hanover Square Rooms, which included chamber music and concerti by Johann Sebastian Bach and Beethoven's An die ferne Geliebte, ""then almost novelties"".[41] Over the years he gave over forty concerts at this venue, and amongst those who took part were the violinists Henri Vieuxtemps and Heinrich Ernst, the pianists Stephen Heller, Ignaz Moscheles and Clara Schumann, and the cellist Carlo Piatti (for whom Bennett wrote his Sonata Duo); composers represented included—apart from Bennett's favourite classical masters and Mendelssohn—Domenico Scarlatti, Fanny Mendelssohn and Schumann.[42]

As well as the demands of his work as a teacher and pianist, there were other factors that may have contributed to Bennett's long withdrawal from large-scale composition. Charles Villiers Stanford writes that the death of Mendelssohn in 1847 came to Bennett as ""an irreparable loss"".[43] In the following year Bennett severed his hitherto close ties with the Philharmonic Society, which had presented many of his most successful compositions. This break resulted from an initially minor disagreement with Costa over his interpretation at the final rehearsal of Bennett's overture Parisina.[44] The intransigence of both parties inflated this into a furious row, and began a breach between them which was to last throughout Bennett's career. Bennett was disgusted at the Society's failure to back him up, and resigned.[43]
", ConsoleColor.Red, new Omnicatz.Helper.Helper.Rectangle(0, 0, 5, 80), volum: 100);




            Console.Title = GameTitle;
            Console.OutputEncoding = UnicodeEncoding.UTF8;
         
            currentState = Singleton<GameState.Menu.TopMenu>.GetInstance();

    

            currentState.RunInitiate();

            makeBorderless();
            var width = Console.BufferWidth;//237
            var height = Console.BufferHeight;//67


            while (true) {
                currentState.RunRender();
                currentState.Update();
              
            }

         


        }

        #region window
        [DllImport("user32.dll")]
        public static extern bool ShowWindow(System.IntPtr hWnd, int cmdShow);

        [DllImport("USER32.DLL")]
        public static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
        static extern IntPtr FindWindowByCaption(IntPtr ZeroOnly, string lpWindowName);

        [DllImport("user32.dll")]
        static extern bool DrawMenuBar(IntPtr hWnd);

        [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
        public static extern IntPtr SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int Y, int cx, int cy, int wFlags);

        [DllImport("user32.dll", SetLastError = true)]
        static extern bool GetWindowRect(IntPtr hwnd, out RECT lpRect);

        [DllImport("user32", ExactSpelling = true, SetLastError = true)]
        internal static extern int MapWindowPoints(IntPtr hWndFrom, IntPtr hWndTo, [In, Out] ref RECT rect, [MarshalAs(UnmanagedType.U4)] int cPoints);

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr GetDesktopWindow();

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int left, top, bottom, right;
        }

   
         private const int nIndex = -16;
         private const int dwNewLong = 0x00080000;
  

        static void makeBorderless()
        {
            IntPtr window = FindWindowByCaption(IntPtr.Zero, GameTitle);
            RECT rect;
            GetWindowRect(window, out rect);
            IntPtr hWndFrom = GetDesktopWindow();
            MapWindowPoints(hWndFrom, window, ref rect, 2);
            SetWindowLong(window, nIndex,dwNewLong);
            SetWindowPos(window, -2, 100, 75, rect.bottom, rect.right, 0x0040);
            DrawMenuBar(window);
            Process process = Process.GetCurrentProcess();
            Console.BufferHeight = Console.WindowHeight;
            ShowWindow(process.MainWindowHandle, 3);
            Console.CursorVisible = false;

        }
        #endregion
    }
}
