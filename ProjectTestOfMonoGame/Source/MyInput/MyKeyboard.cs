using Microsoft.Xna.Framework.Input;

namespace ProjectTestOfMonoGame.Source.MyInput
{

    public class MyKeyboard
    {
        private static KeyboardState currentKeyState;
        private static KeyboardState previousKeyState;

        public static KeyboardState GetState()
        {
            previousKeyState = currentKeyState;
            currentKeyState = Keyboard.GetState();
            return currentKeyState;
        }

        public static bool isPressed(Keys key)
        {
            return currentKeyState.IsKeyDown(key);
        }

        public static bool hasNotBeenPressed(Keys key)
        {
            return currentKeyState.IsKeyDown(key) && !previousKeyState.IsKeyDown(key);
        }
    }
}
