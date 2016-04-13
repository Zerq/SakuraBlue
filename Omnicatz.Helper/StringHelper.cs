using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omnicatz.Helper.ConsoleStrings {
    public static class ConsoleStringHelper {
        
             
        /// <summary>
        /// word wrap so it fits withing a set width defined by number of characters making it more managable in a console UI
        /// </summary>
        /// <param name="sourceString"></param>
        /// <param name="maxLength"></param>
        /// <param name="noPriorBreaks"></param>
        /// <returns></returns>
        public static string WidthWrap(this string sourceString, int maxLength, bool noPriorBreaks = false) {
            int charsSinceBreak = 0;
            int lastWhiteSpace = 0;
            int pos = 0;


            char[] ary;

            if (noPriorBreaks) {
                ary = sourceString.Replace("\r\n", " ").ToCharArray();
            } else {
                ary = sourceString.ToCharArray();
            }

            while (pos != ary.Length) {
                char c = ary[pos];
                if (c == ' ' && charsSinceBreak < maxLength) { lastWhiteSpace = pos; } else
                if (charsSinceBreak == maxLength) {
                    ary[lastWhiteSpace] = '\n';
                    pos = lastWhiteSpace;
                    charsSinceBreak = 0;
                } else
                if (c == '\n') { lastWhiteSpace = pos; charsSinceBreak = 0; }
                charsSinceBreak++;
                pos++;
            }

            return string.Join("", ary);
        }


        public class Page {
            public List<string> lines { get; set; } = new List<string>();
        }
        /// <summary>
        /// returns Groupings of a string that will make paging through a text easier especially for the console
        /// </summary>
        /// <param name="sourceString"></param>
        /// <param name="maxHeight"></param>
        /// <returns></returns>
        public static List<Page> HeightWrap(this string sourceString, int maxHeight) {
            var lines =sourceString.Split(new string[] { Environment.NewLine, "\n" }, StringSplitOptions.None );

            var groups = lines.Count() / maxHeight;
            if (lines.Count() % maxHeight != 0){
                groups++;
            }
            List<Page> pages = new List<Page>(); 
            int index = 0;
            for (int g = 0; g < groups-1; g++) {
                Page page = new Page();
                for (int l = 0; l < maxHeight; l++) {
                    page.lines.Add(lines[index]);              
                        index++;
                }
                pages.Add(page);
            }
            return pages;
        }
    }
}
