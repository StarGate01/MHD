#region Using statements

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpDX;
using SharpDX.DirectInput;

#endregion

namespace MHD.Input
{

    public class InputProvider
    {

        #region Private attributes

        private Keyboard keyboardAdapter;
        private KeyboardState keyboardState;
        private KeyboardState keyboardStateOld;
        private Mouse mouseAdapter;
        private MouseState mouseState;
        private System.Windows.Forms.Form renderForm;

        #endregion

        #region Public properties

        public KeyboardState KeyboardState
        {
            get { return keyboardState; }
        }
        public KeyboardState KeyboardStateOld
        {
            get { return keyboardStateOld; }
        }
        public MouseState MouseState
        {
            get { return mouseState; }
        }
        public Vector2 MousePositionAbsolute
        {
            get { 
                System.Drawing.Point mousePos = renderForm.PointToClient(System.Windows.Forms.Control.MousePosition);
                return new Vector2(mousePos.X, mousePos.Y);
            }
        }

        #endregion

        public InputProvider(System.Windows.Forms.Form form)
        {
            DirectInput inputDevice = new DirectInput();
            keyboardAdapter = new Keyboard(inputDevice);
            keyboardAdapter.Acquire();
            keyboardState = keyboardStateOld = keyboardAdapter.GetCurrentState();
            mouseAdapter = new Mouse(inputDevice);
            mouseAdapter.Acquire();
            mouseState = mouseAdapter.GetCurrentState();
            renderForm = form;
        }

        public void Update()
        {
            keyboardStateOld = keyboardState;
            keyboardState = keyboardAdapter.GetCurrentState();
            mouseState = mouseAdapter.GetCurrentState();
        }


    }

}
