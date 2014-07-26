#region Using statements

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICSharpCode.AvalonEdit.CodeCompletion;
using System.Reflection;

#endregion

namespace MHDEDIT.Util
{

    public class AllFilterStrategy : IFilterStrategy
    {
        
        public IEnumerable<ICompletionItem> Filter(IEnumerable<ICompletionItem> completionItems)
        {
            return new List<ICompletionItem>();
        }

    }

}
