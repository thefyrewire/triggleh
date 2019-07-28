using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triggleh
{
    public class FormPresenter
    {
        private readonly IFormGUI screen;

        public FormPresenter(IFormGUI screen)
        {
            this.screen = screen;
            screen.Register(this);
            InitialiseForm();
        }

        private void InitialiseForm()
        {
            // UpdateView();
            screen.ResetDetails();
        }

        public void UpdateView()
        {

        }

        public void Chk_Bits_CheckedChanged()
        {
            screen.EnableBits(screen.BitsEnabled);
        }

        public void Cmb_Bits_SelectedIndexChanged()
        {
            screen.EnableBitsBetween(screen.BitsCondition == 3);
        }

        public void Chk_ULEveryone_CheckedChanged()
        {
            screen.AllowSubsMods(!screen.UserLevelEveryone);
        }

        public void Txt_Keywords_Enter()
        {
            screen.SetAddKeywordAccept();
        }

        public void Btn_AddKeyword_Click()
        {
            if (screen.Keyword.Length == 0) return;

            int index = screen.AddKeyword(screen.Keyword);
            screen.KeywordsIndex  = index;
        }

        public void Btn_RemoveKeyword_Click()
        {
            if (screen.KeywordsIndex == -1) return;

            screen.RemoveKeyword(screen.KeywordsIndex);
        }
    }
}
