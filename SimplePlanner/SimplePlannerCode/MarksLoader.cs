namespace SimplePlanner.SimplePlannerCode
{
    class MarksLoader(ushort marksNeeded, string key)
    {
        public IList<MarkViewModel> LoadMarks()
        {
            var marksString = Preferences.Get(key, null);
            var marks = marksString?.Select(ch => new MarkViewModel { IsChecked = ch == '1' }).ToArray();
            return marks ?? GetDefault();
        }

        public void SaveMarks(IList<MarkViewModel> marks)
        {
            var marksString = String.Concat(marks.Select(b => b.IsChecked ? "1" : "0"));
            Preferences.Set(key, marksString);
        }

        public IList<MarkViewModel> GetDefault()
        {
            var array = new MarkViewModel[marksNeeded];
            for (var i = 0; i < marksNeeded; i++) array[i] = new MarkViewModel();
            return array;
        }
    }
}
