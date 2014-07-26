#region Using statements

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICSharpCode.AvalonEdit.CodeCompletion;
using ICSharpCode.AvalonEdit.CodeCompletion.CompetionItems;
using System.Drawing;
using System.Windows.Media;
using System.Windows.Media.Imaging;

#endregion

namespace MHDEDIT.Util
{

    public class NonFilterStrategy : IFilterStrategy
    {

        public IEnumerable<ICompletionItem> Filter(IEnumerable<ICompletionItem> completionItems)
        {
            return completionItems;
        }

    }

}
