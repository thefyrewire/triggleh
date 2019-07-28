using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triggleh
{
    public class FormPresenter
    {
        private IFormGUI screen;

        public FormPresenter(IFormGUI screen)
        {
            this.screen = screen;
            screen.register(this);
            initialiseForm();
        }

        private void initialiseForm()
        {
            // updateView();
            screen.ResetDetails();
        }

        public void updateView()
        {

        }

    }
}
